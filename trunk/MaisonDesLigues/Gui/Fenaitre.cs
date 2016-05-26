using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Net.Mail;

namespace MaisonDesLigues.Gui
{

    enum TypeInscription { Intervenant, Licencie, Benevole, Aucun };

    public partial class Fenaitre : Form
    {

        ///
        /// Env
        ///
        public Fenaitre()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            InitializeComponent();
            //
            laDate.Text = "Le " + Utilitaire.obtenirMaintenant().ToString("d") + " (date de test)";
            // Gestion Validation
            InscriptionGlobaleValidatation = new GlobaleValidatation(validInscription);
            // Gestion Enregistrement
            btInscritpionEnregistrerEtMail.Text = "Enregistrer + Email";
            //
            refreshInscription();
        }

        ///
        /// Arrangement : Inscription
        ///
        GlobaleValidatation InscriptionGlobaleValidatation;
        Validation licencieChequeValidation;
        //
        Structures.Inscription.LesNuites InscriptionLesNuites;
        Structures.Inscription.LesDatesBenevolat InscriptionLesDatesBenevolat;
        Structures.Inscription.LesDatesRepasAccompagnant InscriptionLesDatesRepasAccompagnant;
        //
        TypeInscription InscriptionChoixActif = TypeInscription.Aucun;
        //
        private void resetInscription()
        {
            loadInscriptionHebergement(false);
            loadInscriptionBenevoleDateBenevolat(false);
            loadInscriptionBenevoletDateRepasAccompagnant(false);
            //
            Utilitaire.toutVider(tabInscription);
            refreshInscription();
        }

        private void refreshInscription() {
            InscriptionGlobaleValidatation.detacher(gbInscriptionLicencie.Text);
            InscriptionGlobaleValidatation.detacher(gbInscriptionLicencieCheque.Text);
            InscriptionGlobaleValidatation.detacher(gbInscriptionIntervenant.Text);
            InscriptionGlobaleValidatation.detacher(gbInscriptionBenevole.Text);
            //
            if  (this.rbInscriptionIntervenant.Checked)     switchInscription(TypeInscription.Intervenant);
            else if (this.rbInscriptionLicencie.Checked)    switchInscription(TypeInscription.Licencie);
            else if (this.rbInscriptionBenevole.Checked)    switchInscription(TypeInscription.Benevole);
            else                                            switchInscription(TypeInscription.Aucun);
            //
            validInscriptionType();
            validInscriptionIdentite();
        }
        private void switchInscription(TypeInscription activeType) {
            InscriptionChoixActif = activeType;
            switch (activeType)
            {
                case TypeInscription.Intervenant:  loadInscriptionIntervenant(); break;
                case TypeInscription.Benevole:     loadInscriptionBenevole(); break; 
                case TypeInscription.Licencie:     loadInscriptionLicencie(); break; 
            }
            // Afin de laisser les elements se charger, a placer en dernier donc
            this.gbInscriptionIntervenant.Visible = (activeType == TypeInscription.Intervenant);
            this.gbInscriptionBenevole.Visible = (activeType == TypeInscription.Benevole);
            this.gbInscriptionLicencie.Visible = (activeType == TypeInscription.Licencie);
        }

        /* 3 TYPES D'INSCRIPTIONS */

        private void loadInscriptionIntervenant()
        {
            if (cbInscriptionIntervenantAtelier.DataSource == null) {
                DataTable Atelier = Modele.ObtenirDonnees("V_ATELIER01");
                Utilitaire.ajouterChoixSurUneDatatble(Atelier, "ID", "LIBELLE");
                cbInscriptionIntervenantAtelier.DataSource = Atelier;
                cbInscriptionIntervenantAtelier.ValueMember = "ID";
                cbInscriptionIntervenantAtelier.DisplayMember = "LIBELLE";
            }
            // Un seul intervenant
            lbInscriptionIntervenantTypeIntervenantExiste.Text = "";
            rbInscriptionIntervenantTypeIntervenant.Enabled = true;
            if (cbInscriptionIntervenantAtelier.SelectedItem != null) {
                DataRow AtelierSelectionne = ((DataRowView)cbInscriptionIntervenantAtelier.SelectedItem).Row;
                if (AtelierSelectionne["IDPARTICIPANTINTERVENANT"]!=null) {
                    if (AtelierSelectionne["IDPARTICIPANTINTERVENANT"].ToString() != "") {
                        lbInscriptionIntervenantTypeIntervenantExiste.Text = "Un intervenant existe déja pour cet atelier";
                        rbInscriptionIntervenantTypeIntervenant.Enabled = false;
                    }
                }
            }
            // Gestion bouton auto
            loadInscriptionHebergement(true);
            loadInscriptionBenevoleDateBenevolat(false);
            loadInscriptionBenevoletDateRepasAccompagnant(false);
            //
            validInscriptionIntervenant();
            loadMontantTotal();
        }
        private void loadInscriptionBenevole()
        {
            // Gestion bouton auto
            loadInscriptionHebergement(false);
            loadInscriptionBenevoleDateBenevolat(true);
            loadInscriptionBenevoletDateRepasAccompagnant(false);
            //
            validInscriptionBenevole();
            loadMontantTotal();
        }
        private void loadInscriptionLicencie()
        {
            if (cbInscriptionLicencieQualite.DataSource == null) {
                DataTable Qualite = Modele.ObtenirDonnees("V_QUALITE01");
                Utilitaire.ajouterChoixSurUneDatatble(Qualite, "ID", "LIBELLE");
                cbInscriptionLicencieQualite.DataSource = Qualite;
                cbInscriptionLicencieQualite.ValueMember = "ID";
                cbInscriptionLicencieQualite.DisplayMember = "LIBELLE";
            }
            // DATAGRID
            if (dgInscriptionLicencieChoixAteliers.DataSource == null) {
                DataTable AtelierParVacation = Modele.ObtenirDonnees("V_ATELIER02");
                dgInscriptionLicencieChoixAteliers.AutoGenerateColumns = false;
                dgInscriptionLicencieChoixAteliers.DataSource = AtelierParVacation;
            }
            //
            nudInscriptionLicencieChequeMontant1.Maximum = decimal.MaxValue;
            nudInscriptionLicencieChequeMontant2.Maximum = decimal.MaxValue;
            // Gestion bouton auto
            loadInscriptionHebergement(true);
            loadInscriptionBenevoleDateBenevolat(false);
            loadInscriptionBenevoletDateRepasAccompagnant(true);
            //
            tbInscriptionLicencieChequeN2.Enabled = cbInscriptionLicencieChequeN2Activer.Checked;
            nudInscriptionLicencieChequeMontant2.Enabled = cbInscriptionLicencieChequeN2Activer.Checked;
            //
            validInscriptionLicencie();
            validInscriptionLicencieCheque();
            loadMontantTotal();
        }

        private void loadInscriptionActionEnregistrement()
        {

        }


        /* GERER LES OPTIONS LIES AUX INSCRIPTIONS */

        private void loadInscriptionHebergement(bool visible) {
            if (chbInscriptionNuites.Checked && visible) {
                if (InscriptionLesNuites == null)
                    InscriptionLesNuites = new Structures.Inscription.LesNuites(pInscriptionNuites, chbInscriptionUneNuite_CheckedChanged);
                validInscriptionNuite();
            }
            else {
                if (InscriptionLesNuites != null)
                    InscriptionLesNuites = null; // Supprime les nuites et appel le destructeur de chaque nuitee
                InscriptionGlobaleValidatation.detacher(gbInscriptionHebergement.Text);
            }
            // Afin de laisser les elements se charger, a placer en dernier donc
            gbInscriptionHebergementNuites.Visible = chbInscriptionNuites.Checked;
            gbInscriptionHebergement.Visible = visible;
        }

        private void loadInscriptionBenevoleDateBenevolat(bool visible) {
            if (visible) {
                if (InscriptionLesDatesBenevolat == null)
                    InscriptionLesDatesBenevolat = new Structures.Inscription.LesDatesBenevolat(pInscriptionBenevoleDates, chbInscriptionBenevoleDates_CheckedChanged);
                validInscriptionBenevole();
            }
            else {
                if (InscriptionLesDatesBenevolat != null)
                    InscriptionLesDatesBenevolat = null; 
                InscriptionGlobaleValidatation.detacher(gbInscriptionBenevole.Text);
            }
            // Afin de laisser les elements se charger, a placer en dernier donc
            gbInscriptionBenevoleDates.Visible = visible;
        }

        private void loadInscriptionBenevoletDateRepasAccompagnant(bool visible)
        {
            if (visible)
            {
                if (InscriptionLesDatesRepasAccompagnant == null)
                    InscriptionLesDatesRepasAccompagnant = new Structures.Inscription.LesDatesRepasAccompagnant(pInscriptionLicencieRepasAccompagnant, cbInscriptionLicencieRepasAccompagnant_CheckedChanged);
                    validInscriptionLicencie();
            }
            else {
                if (InscriptionLesDatesRepasAccompagnant != null)
                    InscriptionLesDatesRepasAccompagnant = null; 
            }
            // Afin de laisser les elements se charger, a placer en dernier donc
            gbInscriptionLicencieRepasAccompagnant.Visible = visible;
        }


        /* GERER LES OPTIONS LIES AUX PRIX D'UNE INSCRIPTION */

        private float loadMontantTotal() {
            float total = 0;
            //
            float prixNuites = 0;
            float prixAccompagnant = 0;
            float prixInscription = obtenirFraisInscription();
            //
            if (InscriptionLesDatesRepasAccompagnant != null)
                prixAccompagnant = InscriptionLesDatesRepasAccompagnant.getPrixTotalDesRepasAccompagnant();
            if(InscriptionLesNuites!=null)
                prixNuites = InscriptionLesNuites.getPrixTotalDesNuites();
            //
            total = prixAccompagnant + prixNuites + prixInscription;
            //
            if (InscriptionChoixActif == TypeInscription.Licencie)
                tbInscriptionMontant.Text = "Total="+total.ToString()+ " ( Frais inscription="+prixInscription.ToString()+" ; Nuite(s)=" + prixNuites.ToString() + " ; Repas accompagnant="+prixAccompagnant.ToString()+ " ).";
            else if (InscriptionChoixActif == TypeInscription.Intervenant)
                tbInscriptionMontant.Text = "Gratuit. Total des frais à charges=" + total.ToString() + " ( Nuite(s)=" + prixNuites.ToString() + " ).";
            else if (InscriptionChoixActif == TypeInscription.Benevole)
                tbInscriptionMontant.Text = "Gratuit.";
            //
            return total;
        }

        private float obtenirFraisInscription()
        {
            DataTable LesTarifs = Modele.ObtenirDonnees("V_TARIFINSCRIPTION");
            return float.Parse(LesTarifs.Rows[0]["TARIFINSCRIPTION"].ToString());
        }

        /* VALIDER */

        private void validInscription(GlobaleValidatation gv)
        {
            bool auMoinUneErreur = gv.contientAuMoinUneErreur();
            //
            btInscritpionErreurs.Visible = auMoinUneErreur;
            btInscritpionEnregistrerEtMail.Enabled = !auMoinUneErreur;
            //
            btInscriptionAvertirEmail.Visible = false;
            btInscriptionAvertirTel.Visible = false;
            if (licencieChequeValidation != null) {
                if (licencieChequeValidation.contientAuMoinUneErreur()) {
                    if (Validateur.Email.IsMatch(tbInscriptionEmail.Text)) {
                        btInscriptionAvertirEmail.Visible = true;
                    }
                    else if (Validateur.TelephoneFr.IsMatch(tbInscriptionTelephone.Text)) {
                        btInscriptionAvertirTel.Visible = true;
                    }
                }
            }
        }

        /* GERER LA VALIDATION */

        private void validInscriptionType()
        {
            Validation type = new Validation();
            type.applyAuMoinUnCheckedEstFait(flpInscriptionTypeParticipant, "Aucun type choisi");
            InscriptionGlobaleValidatation.attacher(type, gbInscriptionTypeParticipant.Text);
        }

        private void validInscriptionIdentite()
        {
            Validation identity = new Validation();
            identity.applyRegex(tbInscriptionNom, Validateur.Nom, "Le nom est incorrecte");
            identity.applyRegex(tbInscriptionPrenom, Validateur.Nom, "Le prénom est incorrecte");
            identity.applyRegex(tbInscriptionAdresse2, Validateur.Adresse1, "L'adresse n°2 est incorrecte", true);
            identity.applyRegex(tbInscriptionAdresse1, Validateur.Adresse1, "L'adresse n°1 est incorrecte", false, new Control[] { tbInscriptionAdresse2 });
            identity.applyRegex(tbInscriptionCP, Validateur.CodePostal, "Le code postal est incorrecte");
            identity.applyRegex(tbInscriptionVille, Validateur.NomVille, "La ville est incorrecte");
            identity.applyRegex(tbInscriptionTelephone, Validateur.TelephoneFr, "Le téléphone est incorrecte", true);
            identity.applyRegex(tbInscriptionEmail, Validateur.Email, "L'email est incorrecte", true);
            InscriptionGlobaleValidatation.attacher(identity, gbInscriptionIdentite.Text);
        }

        private void validInscriptionBenevole()
        {
            Validation benevole = new Validation();
            benevole.applyFunction(tbInscriptionBenevoleDateNaissance, Validateur.estUnDateFR, "La date est incorrecte");
            benevole.applyRegex(tbInscriptionBenevoleNumeroLicence, Validateur.NumeroDeLicence, "Le numéro de licence est incorrecte", true);
            benevole.applyAuMoinUnCheckedEstFait(pInscriptionBenevoleDates, "Au moins une date doit être choisi");
            InscriptionGlobaleValidatation.attacher(benevole, gbInscriptionBenevole.Text);
        }

        private void validInscriptionIntervenant()
        {
            Validation intervenant = new Validation();
            intervenant.applyAuMoinUnCheckedEstFait(flpInscriptionIntervenantType, "Un intervenant doit animer ou intervenir");
            intervenant.applyChoix(cbInscriptionIntervenantAtelier, "L'atelier de l'intervenant n'est pas correcte", new Control[]{ flpInscriptionIntervenantType });
            InscriptionGlobaleValidatation.attacher(intervenant, gbInscriptionIntervenant.Text);
        }

        private void validInscriptionLicencie()
        {
            Validation licencie = new Validation();
            licencie.applyRegex(tbInscriptionLicencieNumeroLicence, Validateur.NumeroDeLicence, "Le numéro de licence est incorrecte");
            licencie.applyChoix(cbInscriptionLicencieQualite, "La qualité du licencié n'est pas correcte");
            licencie.applyRegex(tbInscriptionLicencieChequeN1, Validateur.NumeroDeCheque, "Le numéro de chèque 1 est incorrecte");
            licencie.applyRegex(tbInscriptionLicencieChequeN2, Validateur.NumeroDeCheque, "Le numéro de chèque 2 est incorrecte");
            licencie.applyChoixDatagridview(dgInscriptionLicencieChoixAteliers, 1, 5, "Il doit avoir au moin 1 ateliers choisie ou 5 maximum");
            InscriptionGlobaleValidatation.attacher(licencie, gbInscriptionLicencie.Text);
        }

        private void validInscriptionLicencieCheque()
        {
            licencieChequeValidation = new Validation();
            //
            float prixInscription = obtenirFraisInscription();
            float prixHotel = (InscriptionLesNuites==null)?0:InscriptionLesNuites.getPrixTotalDesNuites();
            float prixCh1Demande = prixHotel + prixInscription;
            float prixCh2Accompagnant = (InscriptionLesDatesRepasAccompagnant == null) ? 0 : InscriptionLesDatesRepasAccompagnant.getPrixTotalDesRepasAccompagnant();
            float prixCheques = prixCh1Demande + prixCh2Accompagnant;
            //
            string msgInfoPrixInscription   = "\n  -> Frais d'inscription = " + prixInscription;
            string msgInfoPrixHotel         = prixHotel== 0?"":"\n  -> Frais d'hôtels = " + prixHotel;
            string msgInfoAccompagnant      = prixCh2Accompagnant==0?"":("\n  -> Frais repas de l'accompagnant = " + prixCh2Accompagnant);
            //
            if (cbInscriptionLicencieChequeN2Activer.Checked)
            {
                licencieChequeValidation.apply(nudInscriptionLicencieChequeMontant1, (float)nudInscriptionLicencieChequeMontant1.Value == prixCh1Demande,
                    "Le montant du chèque n°1 : " + nudInscriptionLicencieChequeMontant1.Text + "\n ne correspond pas à la sommes des montants suivant :" + msgInfoPrixInscription + msgInfoPrixHotel + "\n  => Total de " + prixCh1Demande
                 );
                licencieChequeValidation.apply(nudInscriptionLicencieChequeMontant2, (float)nudInscriptionLicencieChequeMontant2.Value == prixCh2Accompagnant,
                    "Le montant du chèque n°2 : " + nudInscriptionLicencieChequeMontant2.Text + ((msgInfoAccompagnant == "") ? " ne peux payer aucun repas acommpagnant" : ("\n ne correspond pas à la sommes des montants suivant :" + msgInfoAccompagnant + "\n  => Total de " + prixCh2Accompagnant))
                 );
            }
            else
            {
                licencieChequeValidation.apply(nudInscriptionLicencieChequeMontant1, (float)nudInscriptionLicencieChequeMontant1.Value == prixCheques,
                    "Le montant du chèque n°1 : " + nudInscriptionLicencieChequeMontant1.Text + "\n ne correspond pas à la sommes des montants suivant :" + msgInfoPrixInscription + msgInfoPrixHotel + msgInfoAccompagnant + "\n  => Total de " + prixCheques
                 );
                licencieChequeValidation.apply(nudInscriptionLicencieChequeMontant2, true, ""); // pour rendre par default
            }
            InscriptionGlobaleValidatation.attacher(licencieChequeValidation, gbInscriptionLicencieCheque.Text);
        }

        private void validInscriptionNuite()
        {
            Validation nuite = new Validation();
            nuite.applyAuMoinUnCheckedEstFait(pInscriptionNuites, "Au moins une nuite doit être choisi si hébergement demandé");
            InscriptionGlobaleValidatation.attacher(nuite, gbInscriptionHebergement.Text);
        }


        ///
        /// Event : Inscription
        ///

        private void rbInscription_CheckedChanged(object sender, EventArgs e) {
            refreshInscription();
        }
        private void btInscriptionQuitter_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Voulez vous vraiment quitter ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) {
                Close();
            }
        }

        ///
        /// Event
        ///

        private void tabControl_Enter(object sender, EventArgs e) {
            refreshInscription();
        }

        /* ENREGISTER ET MAIL */
        private void btInscritpionEnregistrerEtMail_Click(object sender, EventArgs e)
        {
            // Preparation du messages
            string infoSaisie = "Participant\n Nom : "+ tbInscriptionNom.Text + "\n Prenom : " + tbInscriptionPrenom.Text + "\n Adresse1 : " + tbInscriptionAdresse1.Text + "\n Adresse2 : " + tbInscriptionAdresse2.Text + "\n Code postal : " + tbInscriptionCP.Text + "\n Ville : " + tbInscriptionVille.Text + "\n Telephone : " + tbInscriptionTelephone.Text + "\n Email : " + tbInscriptionEmail.Text;
            string infoInserer = null;
            string infoNuites = null;
            string infoDatesBenevolat = null;
            // Insertion en BDD
            String newId = null;
            switch (InscriptionChoixActif)
            {

                case TypeInscription.Intervenant:
                    String statut = rbInscriptionIntervenantTypeAnimateur.Checked ? "ANI" : rbInscriptionIntervenantTypeIntervenant.Checked ? "INT" : "";
                    Modele.InscrireIntervenant(
                        tbInscriptionNom.Text, tbInscriptionPrenom.Text, tbInscriptionAdresse1.Text, tbInscriptionAdresse2.Text, tbInscriptionCP.Text, tbInscriptionVille.Text, tbInscriptionTelephone.Text, tbInscriptionEmail.Text, 
                        cbInscriptionIntervenantAtelier.SelectedValue.ToString(), statut, 
                        out newId
                    );
                    infoInserer = "Intervenant\n Atelier : " + cbInscriptionIntervenantAtelier.Text + "\n Statut : ";
                    if (rbInscriptionIntervenantTypeAnimateur.Checked) infoInserer += "Animateur";
                    else if (rbInscriptionIntervenantTypeIntervenant.Checked) infoInserer += "Intervenant";
                    else infoInserer += "Incconu";
                    break;
                //
                case TypeInscription.Licencie:
                    Modele.InscrireLicencie(
                        tbInscriptionNom.Text, tbInscriptionPrenom.Text, tbInscriptionAdresse1.Text, tbInscriptionAdresse2.Text, tbInscriptionCP.Text, tbInscriptionVille.Text, tbInscriptionTelephone.Text, tbInscriptionEmail.Text,
                        cbInscriptionLicencieQualite.SelectedValue.ToString(), tbInscriptionLicencieNumeroLicence.Text,
                        out newId
                    );
                    infoInserer = "Intervenant\n QualiteLicencie : " + cbInscriptionLicencieQualite.Text + "\n Numero de licence : " + tbInscriptionLicencieNumeroLicence.Text;
                    //
                    List<Structures.Inscription.UnChoixDateRepasAccompagnant> LesDatesRepasAccompagnantChoix = InscriptionLesDatesRepasAccompagnant.getLesDatesRepasAccompagnantChoisies();
                    if (LesDatesRepasAccompagnantChoix.Count > 0) { 
                        infoInserer += "\n Repas accompagnant :\n";
                        foreach (Structures.Inscription.UnChoixDateRepasAccompagnant uneDateRepasAccompagnantChoix in LesDatesRepasAccompagnantChoix) {
                            Modele.AjouterUneRestaurationAccompagnant(newId, uneDateRepasAccompagnantChoix.idDateRepasAccompagnant);
                            infoInserer += "  - " + uneDateRepasAccompagnantChoix.composeStr + "\n";
                        }
                    }
                    //
                    if(cbInscriptionLicencieChequeN2Activer.Checked) {
                        infoInserer += "\n Paiment en 2 chèques :\n";
                        Modele.AjouterPaiement(newId, nudInscriptionLicencieChequeMontant1.Text, tbInscriptionLicencieChequeN1.Text, "Cheque1");
                        Modele.AjouterPaiement(newId, nudInscriptionLicencieChequeMontant2.Text, tbInscriptionLicencieChequeN2.Text, "Cheque2");
                        infoInserer += "  - N°1 : " + tbInscriptionLicencieChequeN1.Text + " d'un montant de " + nudInscriptionLicencieChequeMontant1.Text + "\n";
                        infoInserer += "  - N°2 : " + tbInscriptionLicencieChequeN2.Text + " d'un montant de " + nudInscriptionLicencieChequeMontant2.Text + "\n";
                    }
                    else {
                        infoInserer += "\n Paiment en 1 chèque :\n";
                        Modele.AjouterPaiement(newId, nudInscriptionLicencieChequeMontant1.Text, tbInscriptionLicencieChequeN1.Text, "Cheque");
                        infoInserer += "  - " + tbInscriptionLicencieChequeN1.Text + " d'un montant de " + nudInscriptionLicencieChequeMontant1.Text + "\n";
                    }
                    //
                    String newVacation = null;
                    DataTable Vacation = Modele.ObtenirDonnees("V_ATELIER03");
                    DataRow[] desVacationsAtelierInfo;
                    infoInserer += "\n Vacation attribuée :\n";
                    foreach (DataGridViewRow uneLigneDeChoix in dgInscriptionLicencieChoixAteliers.Rows)
                    {
                        if (uneLigneDeChoix.Cells["CHOIX"] == null) continue;
                        if (uneLigneDeChoix.Cells["CHOIX"].Value == null) continue;
                        if ((bool)uneLigneDeChoix.Cells["CHOIX"].Value == false) continue;
                        String idAtelier = uneLigneDeChoix.Cells["N"].Value.ToString();
                        Modele.AjouterUneParticipation(newId, idAtelier, out newVacation);
                        //
                        desVacationsAtelierInfo = Vacation.Select("IDATELIER = '" + idAtelier + "' AND IDVACATION = '" + newVacation + "'");
                        if (desVacationsAtelierInfo.Length == 1)
                            infoInserer += "  - Atelier " + desVacationsAtelierInfo[0]["LIBELLEATELIER"].ToString() + ", vacation N°"+ newVacation + " débute le " + desVacationsAtelierInfo[0]["DATEHEUREDEBUT"].ToString() + " et termine à " + desVacationsAtelierInfo[0]["DATEHEUREFIN"].ToString() + "\n";
                        else
                            infoInserer += "  - Atelier " + idAtelier + ", vacation N°" + newVacation + "\n";
                    }
                    break;
                //
                case TypeInscription.Benevole:
                    DateTime dateDeNaissance;
                    DateTime.TryParseExact(tbInscriptionBenevoleDateNaissance.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateDeNaissance);
                    //
                    Modele.InscrireBenevole(
                        tbInscriptionNom.Text, tbInscriptionPrenom.Text, tbInscriptionAdresse1.Text, tbInscriptionAdresse2.Text, tbInscriptionCP.Text, tbInscriptionVille.Text, tbInscriptionTelephone.Text, tbInscriptionEmail.Text,
                        dateDeNaissance, tbInscriptionBenevoleNumeroLicence.Text,
                        out newId
                        );
                    infoInserer = "Benevole\n Date de naissance : " + tbInscriptionBenevoleDateNaissance.Text + "\n Numero de licence : " + tbInscriptionBenevoleNumeroLicence.Text+"\n Dates de bénévolat :\n";
                    //
                    List<Structures.Inscription.UnChoixDateBenevolat> LesDatesDeBenevolatChoix = InscriptionLesDatesBenevolat.getLesDatesBenevolatChoisies();
                    foreach (Structures.Inscription.UnChoixDateBenevolat uneDateBenevolatChoix in LesDatesDeBenevolatChoix) {
                        Modele.AjouterUneDateDeBenevolat(newId, uneDateBenevolatChoix.idDateBenevolat);
                        infoInserer += "  - " + uneDateBenevolatChoix.composeStr+"\n";
                    }
                    break;
                
            }
            // Pour nuites si Licencié ou Intervenant
            if(newId!=null && chbInscriptionNuites.Checked && (InscriptionChoixActif == TypeInscription.Intervenant || InscriptionChoixActif == TypeInscription.Licencie)) {
                infoNuites = " Nuitées :\n";
                List <Structures.Inscription.UnChoixNuite> LesChoixDeNuites = InscriptionLesNuites.getLesNuitesChoisies();
                foreach (Structures.Inscription.UnChoixNuite unChoixNuite in LesChoixDeNuites) {
                    Modele.AjouterUneNuite(newId, unChoixNuite.idNuite, unChoixNuite.idHotel, unChoixNuite.idChambre);
                    infoNuites += "  - " + unChoixNuite.composeStr + "\n";
                }
            }
            // Msg recapitulatif
            string recapitulatif = "Enregistrment effectué le " + DateTime.Now.ToString() + "\n";
            recapitulatif += infoSaisie + "\n\n"; 
            if(infoInserer!=null)           recapitulatif += infoInserer + "\n\n";
            if (infoNuites != null)         recapitulatif += "\n" + infoNuites + "\n\n";
            if (infoDatesBenevolat != null) recapitulatif += "\n" + infoDatesBenevolat + "\n\n";
            // Envoie Email
            string msg = "Enregistrement terminé,\n un récaptulatif de cet enregistement a été enregistré dans le fichier journal.txt\n Voici le racapitulatif : \n\n";
            msg += recapitulatif;
            //
            Logs.enregistrerLog("Inscription MDL", msg);
            //
            if (Validateur.Email.IsMatch(tbInscriptionEmail.Text))
            {
                msg += "\n---\nDesirez vous envoyer l'email au participant ?";
                var result = MessageBox.Show(msg, "Confirmer l'envoie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataTable parametres = Modele.ObtenirDonnees("V_PARAMETRESMAIL");
                    MailAddress from = new MailAddress(parametres.Rows[0]["MAIL"].ToString(), parametres.Rows[0]["NOM"].ToString());
                    MailAddress to = new MailAddress(tbInscriptionEmail.Text, tbInscriptionNom.Text+" "+ tbInscriptionPrenom.Text);
                    string statut = Logs.envoyerEmail(
                        "Inscription MDL",
                        "Félicitation ! Votre inscription a MDL était réalisée\n" + recapitulatif,
                        from, to
                    );
                    MessageBox.Show("L'email vient d'etre envoyé, voici son statut : \n" + statut, "Statut email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else {
                var result = MessageBox.Show(msg, "Inscription terminée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //
            resetInscription();
        }




        /* RAFRAICHIR */
        private void btInscritpionRafraichir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Pouvez vous confirmer le rafaichissement,\n toutes les informations saisie vont être perdu", "Confirmer le rafraichissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                resetInscription();
            }
        }

        /* ERREURS */
        private void btInscritpionErreurs_Click(object sender, EventArgs e) {
            MessageBox.Show("Des erreurs ont était detectés,\nvoir :\n\n" + InscriptionGlobaleValidatation.logErreurs(), InscriptionGlobaleValidatation.totalErreurs().ToString() + " Erreur(s) detecté(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /* VALIDER TEL */
        private void btInscriptionAvertirTel_Click(object sender, EventArgs e)
        {
            string msg = "Voici le message tel qu'il serait s'il avait été envoyé par mail";
            msg += " \n\n--------------------------\n\n" + genererContenueMsgMailAvertir() + "\n\n--------------------------\n\n";
            MessageBox.Show(msg, "Apreçu message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /* VALIDER EMAIL */
        private void btInscriptionAvertirEmail_Click(object sender, EventArgs e)
        {
            string msg = "L'email suivant va être envoyé au destinataire : " + tbInscriptionEmail.Text;
            msg += " \n\n--------------------------\n\n" + genererContenueMsgMailAvertir()+ "\n\n--------------------------\n\n Vous confirmer l'envoie ?";
            var result = MessageBox.Show(msg, "Confirmer l'envoie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataTable parametres = Modele.ObtenirDonnees("V_PARAMETRESMAIL");
                MailAddress from = new MailAddress(parametres.Rows[0]["MAIL"].ToString(), parametres.Rows[0]["NOM"].ToString());
                MailAddress to = new MailAddress(tbInscriptionEmail.Text, tbInscriptionNom.Text + " " + tbInscriptionPrenom.Text);
                string statut = Logs.envoyerEmail(
                    "Service inscription MDL, problèmes de saisie",
                    genererContenueMsgMailAvertir(),
                    from, to
                );
                MessageBox.Show("L'email vient d'etre envoyé, voici son statut : \n" + statut, "Statut email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string genererContenueMsgMailAvertir()
        {
            string msg = "Bonjour " + tbInscriptionNom.Text + " " + tbInscriptionPrenom.Text + ".\n Votre inscription n'a pas pus être réalisé à causes des faits suivant :\n\n";
            msg += licencieChequeValidation.logErreurs();
            msg += "\n\n Nous attendons votre réponse au plus vite pour regler ce problème";
            return msg;
        }


        /* VALIDATION IDENDITE EVENTS */
        private void tbInscriptionIdendite_TextChanged(object sender, EventArgs e) {
            validInscriptionIdentite();
        }

        /* GESTION & VALIDATION INTERVENANT EVENTS */
        private void rbInscriptionIntervenantType_CheckedChanged(object sender, EventArgs e) {
            validInscriptionIntervenant();
        }
        private void cbInscriptionIntervenantAtelier_Change(object sender, EventArgs e) {
            loadInscriptionIntervenant();
        }

        /* GESTION & VALIDATION BENEVOLE/DATE BENEVOLAT EVENTS */
        private void tbInscriptionBenevole_TextChanged(object sender, EventArgs e) {
            validInscriptionBenevole();
        }
        private void chbInscriptionBenevoleDates_CheckedChanged(object sender, EventArgs e) {
            validInscriptionBenevole();
        }

        /* GESTION & VALIDATION NUITES EVENTS */
        private void chbInscriptionNuites_CheckedChanged(object sender, EventArgs e) {
            refreshInscription();
        }
        private void chbInscriptionUneNuite_CheckedChanged(object sender, EventArgs e) {
            refreshInscription();
        }

        /* GESTION & VALIDATION  LICENCIE EVENTS */
        private void cbInscriptionLicencieRepasAccompagnant_CheckedChanged(object sender, EventArgs e) {
            loadMontantTotal();
            loadInscriptionLicencie();
        }
        private void cbInscriptionLicencieChequeN2Activer_CheckedChanged(object sender, EventArgs e) {
            loadInscriptionLicencie();
        }
        private void tbInscriptionLicencie_TextChanged(object sender, EventArgs e) {
            validInscriptionLicencie();
            validInscriptionLicencieCheque();
        }
        private void cbInscriptionLicencieQualite_Change(object sender, EventArgs e) {
            validInscriptionLicencie();
        }


        private void dgInscriptionLicencieChoixAteliers_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //validInscriptionLicencie();
        }
        private void dgInscriptionLicencieChoixAteliers_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            //validInscriptionLicencie();
        }
        private void dgInscriptionLicencieChoixAteliers_Validating(object sender, CancelEventArgs e)
        {
            validInscriptionLicencie();
        }
        private void dgInscriptionLicencieChoixAteliers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgInscriptionLicencieChoixAteliers.Invalidate();
            dgInscriptionLicencieChoixAteliers.Refresh();
            validInscriptionLicencie();
        }
        private void dgInscriptionLicencieChoixAteliers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgInscriptionLicencieChoixAteliers.Invalidate();
            dgInscriptionLicencieChoixAteliers.Refresh();
            validInscriptionLicencie();
        }

        private void dgInscriptionLicencieChoixAteliers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgInscriptionLicencieChoixAteliers.Invalidate();
            dgInscriptionLicencieChoixAteliers.Refresh();
            validInscriptionLicencie();
        }


    }
}
