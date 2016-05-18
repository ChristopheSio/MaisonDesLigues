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

namespace MaisonDesLigues
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
            try {
                Modele.seConnecter("", "");
            }
            catch(Exception e) {
                DialogResult res = MessageBox.Show("Une erreur de connexion s'est produite :\n\n" + e.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            InitializeComponent();
            laDate.Text = "Le " + Utilitaire.obtenirMaintenant().ToString("d") + " (date de test)";
        }


        ///
        /// Arrangement : Inscription
        ///

        Structures.Inscription.LesNuites InscriptionIntervenantLesNuites;

        private void refreshInscription()
        {
            if  (this.rbInscriptionIntervenant.Checked)     switchInscription(TypeInscription.Intervenant);
            else if (this.rbInscriptionLicencie.Checked)    switchInscription(TypeInscription.Licencie);
            else if (this.rbInscriptionBenevole.Checked)    switchInscription(TypeInscription.Benevole);
        }

        private void switchInscription(TypeInscription activeType)
        {
            switch (activeType)
            {
                case TypeInscription.Intervenant:  loadInscriptionIntervenant(); break;
                case TypeInscription.Benevole:     loadInscriptionBenevole(); break;
            }
            // Afin de laisser les elements se charger
            this.gbInscriptionIntervenant.Visible = (activeType == TypeInscription.Intervenant);
            this.gbInscriptionBenevole.Visible = (activeType == TypeInscription.Benevole);
        }

        
        private void loadInscriptionIntervenant()
        {
            if (cbInscriptionIntervenantAtelier.DataSource == null)
            {
                cbInscriptionIntervenantAtelier.DataSource = Modele.ObtenirDonnees("VATELIER01");
                cbInscriptionIntervenantAtelier.ValueMember = "ID";
                cbInscriptionIntervenantAtelier.DisplayMember = "LIBELLE";
            }
            //
            gbInscriptionIntervenantNuites.Visible = chbInscriptionIntervenantNuites.Checked;
            if (chbInscriptionIntervenantNuites.Checked)
            {
                if (InscriptionIntervenantLesNuites == null)
                    InscriptionIntervenantLesNuites = new Structures.Inscription.LesNuites(pInscriptionIntervenantNuites);
            }
            else
            {
                if (InscriptionIntervenantLesNuites != null)
                    InscriptionIntervenantLesNuites = null; // Supprime les nuites et appel le destructeur de chaque nuitee
            }
            

        }

        private void loadInscriptionBenevole()
        {

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
        /// Event : Inscription->Intervenant
        ///

        private void chbInscriptionIntervenantNuites_CheckedChanged(object sender, EventArgs e) {
            loadInscriptionIntervenant();
        }
    }
}
