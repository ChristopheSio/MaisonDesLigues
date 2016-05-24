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
            validInscriptionType(false);
            validInscriptionIdentite(false);
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
                cbInscriptionIntervenantAtelier.DataSource = Modele.ObtenirDonnees("VATELIER01");
                cbInscriptionIntervenantAtelier.ValueMember = "ID";
                cbInscriptionIntervenantAtelier.DisplayMember = "LIBELLE";
            }
            // Gestion bouton auto
            loadInscriptionHebergement(true);
            loadInscriptionBenevoletDateBenevolat(false);
        }
        private void loadInscriptionBenevole()
        {


            // Gestion bouton auto
            loadInscriptionHebergement(false);
            loadInscriptionBenevoletDateBenevolat(true);
            //
            validInscriptionBenevole(false);
        }
        private void loadInscriptionLicencie()
        {


            /*
                customise datagrid
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("Selected", typeof(bool))); //this will show checkboxes
                dt.Columns.Add(new DataColumn("Text", typeof(string)));   //this will show text
                */
            // Gestion bouton auto
            loadInscriptionHebergement(true);
            loadInscriptionBenevoletDateBenevolat(false);
        }

        /* GERER LES OPTIONS LIES AUX INSCRIPTIONS */

        private void loadInscriptionHebergement(bool visible) {
            if (chbInscriptionNuites.Checked && visible) {
                if (InscriptionLesNuites == null)
                    InscriptionLesNuites = new Structures.Inscription.LesNuites(pInscriptionNuites, chbInscriptionUneNuite_CheckedChanged);
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
                //

            }
            else {
                if (InscriptionLesDatesBenevolat != null)
                    InscriptionLesDatesBenevolat = null; // Supprime les nuites et appel le destructeur de chaque nuitee
            }
            // Afin de laisser les elements se charger, a placer en dernier donc
            gbInscriptionBenevoleDates.Visible = visible;
        }

        /* GERER LA VALIDATION */

        private string validInscriptionType(bool avecLog)
        {
            Validation type = new Validation(avecLog);
            type.applyUnCheckedEstFait(flpInscriptionTypeParticipant, "Aucun type choisi");
            return type.logErreurs();
        }

        private string validInscriptionIdentite(bool avecLog)
        {
            Validation identity = new Validation(avecLog);
            identity.applyRegex(tbInscriptionNom, Validateur.Nom, "Le nom est incorrecte");
            identity.applyRegex(tbInscriptionPrenom, Validateur.Nom, "Le prénom est incorrecte");
            identity.applyRegex(tbInscriptionAdresse2, Validateur.Adresse2, "L'adresse n°2 est incorrecte");
            identity.applyRegex(tbInscriptionAdresse1, Validateur.Adresse1, "L'adresse n°1 est incorrecte", new Control[] { tbInscriptionAdresse2 });
            identity.applyRegex(tbInscriptionCP, Validateur.CodePostal, "Le code postal est incorrecte");
            identity.applyRegex(tbInscriptionVille, Validateur.NomVille, "La ville est incorrecte");
            identity.applyRegex(tbInscriptionTelephone, Validateur.TelephoneFr, "Le téléphone est incorrecte");
            identity.applyRegex(tbInscriptionEmail, Validateur.Email, "L'email est incorrecte");
            return identity.logErreurs();
        }

        private string validInscriptionBenevole(bool avecLog)
        {
            Validation benevole = new Validation(avecLog);
            benevole.applyFunction(tbInscriptionBenevoleDateNaissance, Validateur.estUnDateFR, "La date est incorrecte");
            benevole.applyRegex(tbInscriptionBenevoleNumeroLicence, Validateur.NumeroDeLicence, "Le numéro de licence est incorrecte");
            benevole.applyUnCheckedEstFait(pInscriptionBenevoleDates, "Au moins une date doit être choisi");
            return benevole.logErreurs();
        }

        private string validInscriptionNuite(bool avecLog)
        {
            // @TODO A FAIRE
            Validation benevole = new Validation(avecLog);
            benevole.applyFunction(tbInscriptionBenevoleDateNaissance, Validateur.estUnDateFR, "La date est incorrecte");
            benevole.applyRegex(tbInscriptionBenevoleNumeroLicence, Validateur.NumeroDeLicence, "Le numéro de licence est incorrecte");
            benevole.applyUnCheckedEstFait(pInscriptionBenevoleDates, "Au moins une date doit être choisi");
            return benevole.logErreurs();
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
        
        /* VALIDATION EVENTS */
        private void tbInscriptionIdendite_TextChanged(object sender, EventArgs e) {
            validInscriptionIdentite(false);
        }

        private void tbInscriptionBenevole_TextChanged(object sender, EventArgs e) {
            validInscriptionBenevole(false);
        }

        /* GESTION DATE BENEVOLAT EVENTS */
        private void chbInscriptionBenevoleDates_CheckedChanged(object sender, EventArgs e) {
            validInscriptionBenevole(false);
        }

        /* GESTION NUITES EVENTS */
        private void chbInscriptionNuites_CheckedChanged(object sender, EventArgs e) {
            loadInscriptionHebergement(true);
            validInscriptionNuite(false);
        }
        private void chbInscriptionUneNuite_CheckedChanged(object sender, EventArgs e)
        {
            loadInscriptionHebergement(true);
            validInscriptionNuite(false);
        }

    }
}
