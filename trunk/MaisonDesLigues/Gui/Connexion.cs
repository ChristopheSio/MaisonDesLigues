using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaisonDesLigues.Gui
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }


        private void tryConnection()
        {
            try {
                Modele.seConnecter(tbLogin.Text, tbMdp.Text);
            }
            catch (Exception e) {
                DialogResult res = MessageBox.Show("Une erreur de connexion s'est produite :\n\n" + e.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            // Start App if no exception
            this.Hide();
            Gui.Fenaitre App = new Gui.Fenaitre();
            App.ShowDialog();
            //
            this.Close();
        }


        /* Action */

        private void btConnecter_Click(object sender, EventArgs e)
        {
            tryConnection();
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
