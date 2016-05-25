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
            laDate.Text = "Le " + Utilitaire.obtenirMaintenant().ToString("d") + " (date de test)";
            // Gestion Enregistrement
            btInscritpionEnregistrer.Text = "Enregistrer + Email";
        }

        ///
        /// Arrangement : Inscription
        ///
        Structures.Inscription.LesNuites InscriptionLesNuites;
        Structures.Inscription.LesDatesBenevolat InscriptionLesDatesBenevolat;
        //
        TypeInscription InscriptionChoixActif = TypeInscription.Aucun;
        //
        private void refreshInscription() {
            if  (this.rbInscriptionIntervenant.Checked)     switchInscription(TypeInscription.Intervenant);
            else if (this.rbInscriptionLicencie.Checked)    switchInscription(TypeInscription.Licencie);
            else if (this.rbInscriptionBenevole.Checked)    switchInscription(TypeInscription.Benevole);
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
            if (cbInscriptionIntervenantAtelier.DataSource == null)
            {
                DataTable IntervenantAtelier = Modele.ObtenirDonnees("VATELIER01");
                Utilitaire.ajouterChoixSurUneDatatble(IntervenantAtelier, "ID", "LIBELLE");
                cbInscriptionIntervenantAtelier.DataSource = IntervenantAtelier;
                cbInscriptionIntervenantAtelier.ValueMember = "ID";
                cbInscriptionIntervenantAtelier.DisplayMember = "LIBELLE";
            }
            // Gestion bouton auto
            loadInscriptionHebergement(true);
            loadInscriptionBenevoletDateBenevolat(false);
            //
            validInscriptionIntervenant();
        }
        private void loadInscriptionBenevole()
        {
            // Gestion bouton auto
            loadInscriptionHebergement(false);
            loadInscriptionBenevoletDateBenevolat(true);
            //
            validInscriptionBenevole();
        }
        private void loadInscriptionLicencie()
        {


            /*
                customise datagrid
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("Selected", typeof(bool))); //this will show checkboxes
                dt.Columns.Add(new DataColumn("Text", typeof(string)));   //this will show text
                */
            
            //
            nudInscriptionLicencieChequeMontant1.Maximum = decimal.MaxValue;
            nudInscriptionLicencieChequeMontant2.Maximum = decimal.MaxValue;
            // Gestion bouton auto
            loadInscriptionHebergement(true);
            loadInscriptionBenevoletDateBenevolat(false);
            //
            tbInscriptionLicencieChequeN2.Enabled = cbInscriptionLicencieChequeN2Activer.Checked;
            nudInscriptionLicencieChequeMontant2.Enabled = cbInscriptionLicencieChequeN2Activer.Checked;
            //
            validInscriptionLicencie();
            //
            loadMontantTotal();
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
            }
            // Afin de laisser les elements se charger, a placer en dernier donc
            gbInscriptionHebergementNuites.Visible = chbInscriptionNuites.Checked;
            gbInscriptionHebergement.Visible = visible;
        }

        private void loadInscriptionBenevoletDateBenevolat(bool visible) {
            if (visible) {
                if (InscriptionLesDatesBenevolat == null)
                    InscriptionLesDatesBenevolat = new Structures.Inscription.LesDatesBenevolat(pInscriptionBenevoleDates, chbInscriptionBenevoleDates_CheckedChanged);
            }
            else {
                if (InscriptionLesDatesBenevolat != null)
                    InscriptionLesDatesBenevolat = null; // Supprime les nuites et appel le destructeur de chaque nuitee
            }
            // Afin de laisser les elements se charger, a placer en dernier donc
            gbInscriptionBenevoleDates.Visible = visible;
        }


        /* GERER LES OPTIONS LIES AUX PRIX D'UNE INSCRIPTION */

        private void loadMontantTotal() {

        }


        private int calculerInscriptionLicencieAccompagnant()
        {
            DataTable LesTarifs = Modele.ObtenirDonnees("VTARIFINSCRIPTION");
            //DataRow LesTarifs.Rows.
            int prixRepasAccompagnant = Utilitaire.totalCheckedDuContainer(gbInscriptionLicencieRepasAccompagnant);
            return prixRepasAccompagnant;
        }

            

        /* GERER LA VALIDATION */

        private void validInscriptionType()
        {
            Validation type = new Validation();
            type.applyAuMoinUnCheckedEstFait(flpInscriptionTypeParticipant, "Aucun type choisi");
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
        }

        private void validInscriptionBenevole()
        {
            Validation benevole = new Validation();
            benevole.applyFunction(tbInscriptionBenevoleDateNaissance, Validateur.estUnDateFR, "La date est incorrecte");
            benevole.applyRegex(tbInscriptionBenevoleNumeroLicence, Validateur.NumeroDeLicence, "Le numéro de licence est incorrecte", true);
            benevole.applyAuMoinUnCheckedEstFait(pInscriptionBenevoleDates, "Au moins une date doit être choisi");
        }

        private void validInscriptionIntervenant()
        {
            Validation intervenant = new Validation();
            intervenant.applyAuMoinUnCheckedEstFait(flpInscriptionIntervenantType, "Un intervenant doit animer ou intervenir");
            intervenant.applyChoix(cbInscriptionIntervenantAtelier, "L'atelier de l'intervenant n'est pas correcte", new Control[]{ flpInscriptionIntervenantType });
        }

        private void validInscriptionLicencie()
        {
            Validation licencie = new Validation();
            licencie.applyRegex(tbInscriptionLicencieNumeroLicence, Validateur.NumeroDeLicence, "Le numéro de licence est incorrecte");
            licencie.applyRegex(tbInscriptionLicencieChequeN1, Validateur.NumeroDeCheque, "Le numéro de chèque 1 est incorrecte");
            licencie.applyRegex(tbInscriptionLicencieChequeN2, Validateur.NumeroDeCheque, "Le numéro de chèque 2 est incorrecte");
            licencie.applyChoix(cbInscriptionIntervenantAtelier, "L'atelier de l'intervenant n'est pas correcte", new Control[] { flpInscriptionIntervenantType });
        }

        private void validInscriptionNuite()
        {
            Validation nuite = new Validation();
            nuite.applyAuMoinUnCheckedEstFait(pInscriptionNuites, "Au moins une nuite doit être choisi si hébergement demandé");
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
        
        /* VALIDATION IDENDITE EVENTS */
        private void tbInscriptionIdendite_TextChanged(object sender, EventArgs e) {
            validInscriptionIdentite();
        }

        /* VALIDATION INTERVENANT EVENTS */
        private void rbInscriptionIntervenantType_CheckedChanged(object sender, EventArgs e) {
            validInscriptionIntervenant();
        }
        private void cbInscriptionIntervenantAtelier_Change(object sender, EventArgs e) {
            validInscriptionIntervenant();
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
            loadInscriptionHebergement(true);
        }
        private void chbInscriptionUneNuite_CheckedChanged(object sender, EventArgs e) {
            validInscriptionNuite();
        }

        /* GESTION & VALIDATION  LICENCIE EVENTS */
        private void cbInscriptionLicencieRepasAccompagnant_CheckedChanged(object sender, EventArgs e) {
            loadInscriptionLicencie();
        }
        private void cbInscriptionLicencieChequeN2Activer_CheckedChanged(object sender, EventArgs e) {
            loadInscriptionLicencie();
        }
        private void tbInscriptionLicencie_TextChanged(object sender, EventArgs e) {
            validInscriptionLicencie();
        }
    }
}
