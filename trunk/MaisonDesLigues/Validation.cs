using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;
using System.Globalization;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;

namespace MaisonDesLigues
{
    //const string Yes = "Hiphop";
    //const Regex Nom = new Regex("hip hop"); //(@"^[a-zA-ZÀ-ÿ\s\’-]{2,40}$");

    static class Validateur
    {
        public static readonly Regex Nom = new Regex(@"^[a-zA-ZÀ-ÿ\s\’-]{2,40}$", RegexOptions.IgnoreCase);
        public static readonly Regex Email = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$", RegexOptions.IgnoreCase);
        public static readonly Regex NomVille = new Regex(@"^[a-zA-ZÀ-ÿ0-9]{2,64}$", RegexOptions.IgnoreCase);
        public static readonly Regex CodePostal = new Regex(@"^[0-9]{5}$");
        public static readonly Regex TelephoneFr = new Regex(@"^[0-9]{10}$");
        public static readonly Regex Adresse1 = new Regex(@"^.{3,512}$");
        public static readonly Regex Adresse2 = new Regex(@"^.{0,512}$");
        public static readonly Regex NumeroDeCheque = new Regex(@"^[A-Z0-9]{2,20}$", RegexOptions.IgnoreCase);
        public static readonly Regex NumeroDeLicence = new Regex(@"^[A-Z0-9]{5,20}$", RegexOptions.IgnoreCase);

        public static bool contientAuMoinUnCheckboxChecked(ScrollableControl UnContainer) {
            return Utilitaire.totalCheckedDuContainer(UnContainer) > 0;
        }

        public static bool estUnDateFR(string uneDate) {
            DateTime result;
            DateTime maintenant = Utilitaire.obtenirMaintenant();
            DateTime auPlusTart = new DateTime(1900, 01, 01);
            if ( DateTime.TryParseExact(uneDate, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out result) )
                return (DateTime.Compare(maintenant, result) > 0 && DateTime.Compare(result,auPlusTart) > 0);
            return false;
        }
    }

     class Validation
     {
        public Validation() {
            totalTest = 0;
            totalValidTest = 0;
            listLogErreurs = new List<string>();
        }
        //
        private void setBackColor(Control unControle, bool doitValider) {
            unControle.BackColor = doitValider ? 
                System.Drawing.SystemColors.Window :
                System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); // 255; 192; 192
        }
        private void setBackColor(DataGridViewRow uneDatagridviewrow, bool doitValider)
        {
            uneDatagridviewrow.DefaultCellStyle.BackColor = doitValider ?
                System.Drawing.SystemColors.Window :
                System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); // 255; 192; 192
        }
        private void setValid(bool doitValider, string logErreur) {
            totalTest++;
            if (doitValider)
                totalValidTest++;
            else if (logErreur != null)
                listLogErreurs.Add(logErreur);
        }
        private void setControleDependant(bool doitValider, Control[] controlesDependant) {
            if (controlesDependant == null) return;
            foreach (Control unControleDependant in controlesDependant) {
                if(doitValider==false)
                    setBackColor(unControleDependant, doitValider);
            }
        }
        private bool validOptionel(Control unControle, bool doitValider, bool estOptionel) {
            return (((unControle.Text=="")&&estOptionel==true)||unControle.Enabled==false) ? true : doitValider;
        }
        //
        public void apply(Control unControle, bool doitValider, string logErreur, bool estOptionel = false, Control[] controlesDependant = null) {
            bool valid = validOptionel(unControle, doitValider, estOptionel);
            setValid(valid, logErreur);
            setBackColor(unControle, valid);
            setControleDependant(valid, controlesDependant);
        }
        public void applyRegex(Control unControle, Regex doitMatch, string logErreur, bool estOptionel = false, Control[] controlesDependant = null) {
            apply(unControle, doitMatch.IsMatch(unControle.Text), logErreur, estOptionel, controlesDependant);
        }
        public void applyFunction(Control unControle, Func<string, bool> functionDeTest, string logErreur, bool estOptionel = false, Control[] controlesDependant = null) {
            apply(unControle, functionDeTest(unControle.Text), logErreur, estOptionel, controlesDependant);
        }
        //
        public void applyAuMoinUnCheckedEstFait(Control unContainer, string logErreur, Control[] controlesDependant = null) {
            bool estOk = Utilitaire.totalCheckedDuContainer(unContainer) > 0;
            setValid(estOk, logErreur);
            setBackColor(unContainer, estOk);
            setControleDependant(estOk, controlesDependant);
        }
        public void applyChoix(ComboBox uneCombobox, string logErreur, Control[] controlesDependant = null) {
            bool estOk = false;
            try {
                estOk = uneCombobox.SelectedValue.ToString() != "-1";
            } catch(Exception) { }
            //
            setValid(estOk, logErreur);
            setBackColor(uneCombobox, estOk);
            setControleDependant(estOk, controlesDependant);
        }
        public void applyChoixDatagridview(DataGridView uneDatagridview, int min, int max, string logErreur, Control[] controlesDependant = null)
        {
            int nbChoixChecked = 0;
            foreach(DataGridViewRow uneLigne in uneDatagridview.Rows) {
                if (uneLigne.Cells["CHOIX"] == null) continue;
                if (uneLigne.Cells["CHOIX"].Value == null) continue;
                if ((bool)uneLigne.Cells["CHOIX"].Value == false) continue;
                nbChoixChecked++;
            }
            //
            bool valid = (nbChoixChecked >= min) && (nbChoixChecked <= max);
            setValid(valid, logErreur);
            setControleDependant(valid, controlesDependant);
            foreach (DataGridViewRow uneLigne in uneDatagridview.Rows) {
                setBackColor(uneLigne, valid);
            }
        }
        //
        public bool contientAuMoinUneErreur() {
            return totalTest > totalValidTest;
        }
        public string logErreurs() {
            string log = "";
            foreach (string uneErreur in listLogErreurs) {
                log += uneErreur+"\n";
            }
            return log;
        }
        public int totalErreurs() {
            return totalTest-totalValidTest;
        }
        //
        private List<string> listLogErreurs;
        private int totalTest;
        private int totalValidTest;

    }

    class GlobaleValidatation
    {
        public GlobaleValidatation(Action<GlobaleValidatation> _callback) {
            lesValidationsDict = new Dictionary<string, Validation>();
            callback = _callback;
        }
        public void attacher(Validation uneValidation, string nomDuGroupe) {
            lesValidationsDict[nomDuGroupe] = uneValidation;
            if (callback == null) return;
            callback(this);
        }
        public void detacher(string nomDuGroupe) {
            if (lesValidationsDict.ContainsKey(nomDuGroupe))
                lesValidationsDict.Remove(nomDuGroupe);
        }
        public void actualise() {
            callback(this);
        }
        public Dictionary<string, Validation> getLesValidationsDict() {
            return lesValidationsDict;
        }
        public bool contientAuMoinUneErreur() {
            foreach (KeyValuePair<string, Validation> kvp in lesValidationsDict) {
                if (kvp.Value.contientAuMoinUneErreur())
                    return true;
            }
            return false;
        }
        public string logErreurs() {
            string log = "";
            foreach (KeyValuePair<string, Validation> kvp in lesValidationsDict) {
                if (!kvp.Value.contientAuMoinUneErreur())
                    continue;
                log += "-- " + kvp.Key + " --\n";
                log += kvp.Value.logErreurs()+"\n";
            }
            return log;
        }
        public int totalErreurs() {
            int total = 0;
            foreach (KeyValuePair<string, Validation> kvp in lesValidationsDict) {
                total += kvp.Value.totalErreurs();
            }
            return total;
        }

        Dictionary<string, Validation> lesValidationsDict;
        Action<GlobaleValidatation> callback;
    }

    // foreach (Control unControle in unContainer.Controls) { setBackColor(unControle, estOk); }
    // MessageBox.Show("unControle :" + unControle.GetType().Name, "unControle", MessageBoxButtons.OK);
}
