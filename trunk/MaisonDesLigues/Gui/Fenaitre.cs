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
        }


        ///
        /// Arrangement : Inscription
        ///

        Structures.Inscription.LesNuites InscriptionLesNuites;
        TypeInscription InscriptionChoixActif = TypeInscription.Aucun;

        private void refreshInscription()
        {
            if  (this.rbInscriptionIntervenant.Checked)     switchInscription(TypeInscription.Intervenant);
            else if (this.rbInscriptionLicencie.Checked)    switchInscription(TypeInscription.Licencie);
            else if (this.rbInscriptionBenevole.Checked)    switchInscription(TypeInscription.Benevole);
        }

        private void switchInscription(TypeInscription activeType)
        {
            InscriptionChoixActif = activeType;
            switch (activeType)
            {
                case TypeInscription.Intervenant:  loadInscriptionIntervenant(); break;
                case TypeInscription.Benevole:     loadInscriptionBenevole(); break; 
                case TypeInscription.Licencie:     loadInscriptionLicencie(); break; 
            }
            // Afin de laisser les elements se charger
            this.gbInscriptionIntervenant.Visible = (activeType == TypeInscription.Intervenant);
            this.gbInscriptionBenevole.Visible = (activeType == TypeInscription.Benevole);
            this.gbInscriptionLicencie.Visible = (activeType == TypeInscription.Licencie);
            // Gestion Hebergement
            loadInscriptionHebergement();
            this.gbInscriptionHebergement.Visible = (activeType == TypeInscription.Licencie) || (activeType == TypeInscription.Intervenant);
        }

        
        private void loadInscriptionIntervenant()
        {
            if (cbInscriptionIntervenantAtelier.DataSource == null)
            {
                cbInscriptionIntervenantAtelier.DataSource = Modele.ObtenirDonnees("VATELIER01");
                cbInscriptionIntervenantAtelier.ValueMember = "ID";
                cbInscriptionIntervenantAtelier.DisplayMember = "LIBELLE";
            }
        }

        private void loadInscriptionHebergement()
        {
            if (InscriptionChoixActif == TypeInscription.Intervenant) 
                gbInscriptionHebergement.Text = "Hébergement (choix non décisif, voir avec l'administration)";
            else if (InscriptionChoixActif == TypeInscription.Licencie)
                gbInscriptionHebergement.Text = "Hébergement";
            //
            gbInscriptionHebergementNuites.Visible = chbInscriptionNuites.Checked;
            if (chbInscriptionNuites.Checked)
            {
                if (InscriptionLesNuites == null)
                    InscriptionLesNuites = new Structures.Inscription.LesNuites(pInscriptionNuites);
            }
            else
            {
                if (InscriptionLesNuites != null)
                    InscriptionLesNuites = null; // Supprime les nuites et appel le destructeur de chaque nuitee
            }
        }

        private void loadInscriptionBenevole()
        {

        }

        private void loadInscriptionLicencie()
        {


            /*
                customise datagrid
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("Selected", typeof(bool))); //this will show checkboxes
                dt.Columns.Add(new DataColumn("Text", typeof(string)));   //this will show text
                */
        }

        ///
        /// Event : Inscription
        ///

        private void rbInscriptionIntervenant_CheckedChanged(object sender, EventArgs e) {
            switchInscription(TypeInscription.Intervenant);
        }
        private void rbInscriptionLicencie_CheckedChanged(object sender, EventArgs e) {
            switchInscription(TypeInscription.Licencie);
        }
        private void rbInscriptionBenevole_CheckedChanged(object sender, EventArgs e) {
            switchInscription(TypeInscription.Benevole);
        }
        private void btInscriptionQuitter_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Voulez vous vraiment quitter ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) {
                Close();
            }
        }

        ///
        /// Event : Inscription(Nuite)
        ///

        private void chbInscriptionNuites_CheckedChanged(object sender, EventArgs e) {
            loadInscriptionHebergement();
        }

    }
}
