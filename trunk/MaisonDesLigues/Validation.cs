using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MaisonDesLigues
{
    //const string Yes = "Hiphop";
    //const Regex Nom = new Regex("hip hop"); //(@"^[a-zA-ZÀ-ÿ\s\’-]{2,40}$");

    static class Validation
    {
        public static readonly Regex Nom = new Regex(@"^[a-zA-ZÀ-ÿ\s\’-]{2,40}$", RegexOptions.IgnoreCase);
        public static readonly Regex Email = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$", RegexOptions.IgnoreCase);
        public static readonly Regex NomVille = new Regex(@"^[a-zA-ZÀ-ÿ0-9]{2,64}$", RegexOptions.IgnoreCase);
        public static readonly Regex CodePostal = new Regex(@"^[0-9]{5}$");
        public static readonly Regex Adresse1 = new Regex(@"^.{3,512}$");
        public static readonly Regex Adresse2 = new Regex(@"^.{0,512}$");
        public static readonly Regex NumeroDeCheque = new Regex(@"^[A-Z0-9]{2,20}$", RegexOptions.IgnoreCase);
        public static readonly Regex NumeroDeLicence = new Regex(@"^[A-Z0-9]{5,20}$", RegexOptions.IgnoreCase);

        public static bool contientAuMoinUnCheckboxChecked(ScrollableControl UnContainer) {
            return Utilitaire.totalCheckedDuContainer(UnContainer) > 0;
        }



    }
}
