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
        public static readonly Regex TelephoneFr = new Regex(@"^[0-9]{9}$");
        public static readonly Regex Adresse1 = new Regex(@"^.{3,512}$");
        public static readonly Regex Adresse2 = new Regex(@"^.{0,512}$");
        public static readonly Regex NumeroDeCheque = new Regex(@"^[A-Z0-9]{2,20}$", RegexOptions.IgnoreCase);
        public static readonly Regex NumeroDeLicence = new Regex(@"^[A-Z0-9]{5,20}$", RegexOptions.IgnoreCase);

        public static bool contientAuMoinUnCheckboxChecked(ScrollableControl UnContainer)
        {
            return Utilitaire.totalCheckedDuContainer(UnContainer) > 0;
        }

        public static bool estUnDateFR(string uneDate)
        {
            DateTime result;
            try
            {
                result = DateTime.ParseExact(uneDate, "DD/mm/YYYY", CultureInfo.InvariantCulture);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }

     class Validation
     {
        public Validation(bool logErreursActive) {
            totalTest = 0;
            totalValidTest = 0;
            if (logErreursActive)
                listLogErreurs = new List<string>();
        }
        //
        private void setBackColor(Control unControl, bool doitValider) {
            if (doitValider)
                unControl.BackColor = System.Drawing.SystemColors.Window;
            else
                unControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); // 255; 192; 192
        }
        private void setValid(bool doitValider, string logErreur) {
            totalTest++;
            if (doitValider)
                totalValidTest++;
            else if (listLogErreurs != null && logErreur != null)
                listLogErreurs.Add(logErreur);
        }
        private void setControleDependant(bool doitValider, Control[] controlesDependant) {
            if (controlesDependant == null) return;
            foreach (Control unControleDependant in controlesDependant)
            {
                setBackColor(unControleDependant, doitValider);
            }
        }
        //
        public void apply(Control unControle, bool doitValider, string logErreur = null, Control[] controlesDependant = null) {
            setValid(doitValider, logErreur);
            setBackColor(unControle, doitValider);
            setControleDependant(doitValider, controlesDependant);
        }
        public void applyRegex(Control unControle, Regex doitMatch, string logErreur = null, Control[] controlesDependant = null) {
            apply(unControle, doitMatch.IsMatch(unControle.Text), logErreur, controlesDependant);
        }
        public void applyFunction(Control unControle, Func<string, bool> functionDeTest, string logErreur = null, Control[] controlesDependant = null)
        {
            apply(unControle, functionDeTest(unControle.Text), logErreur, controlesDependant);
        }
        //
        public void applyUnCheckedEstFait(Control unContainer, string logErreur = null, Control[] controlesDependant = null) {
            bool estOk = Utilitaire.totalCheckedDuContainer(unContainer) > 0;
            setValid(estOk, logErreur);
            setBackColor(unContainer, estOk);
            /*foreach (Control unControle in unContainer.Controls) { setBackColor(unControle, estOk); }*/
            setControleDependant(estOk, controlesDependant);
        }
        //
        public bool contientAuMoinUneErreur() {
            return totalTest > totalValidTest;
        }
        public string logErreurs() {
            if (listLogErreurs == null)
                return null;
            //
            string log = "";
            foreach (string uneErreur in listLogErreurs) {
                log += uneErreur+"\n";
            }
            return log;
        }
        //
        private List<string> listLogErreurs;
        private int totalTest;
        private int totalValidTest;

    }
}
