using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;


namespace MaisonDesLigues
{
    namespace Structures
    {
        namespace Inscription
        {
            
            //
            //
            //
            //
            
            /// <summary> Cette strucutre permet de connaitre les d'une nuité </summary>
            struct UnChoixNuite
            {
                public string idNuite;
                public string idHotel;
                public string idChambre;
                public string composeStr;
            }
            
            /// <summary> Cette classe permet l'affichage d'une entrée pour la nuités </summary>
            class LesNuites
            {
                public LesNuites(ScrollableControl lePanel, Action<object, EventArgs> callback)
                {
                    lePanel.Controls.Clear();
                    listeDesNuites = new List<LaNuite>();
                    DataTable lesNuites = Modele.ObtenirDonnees("V_DATENUITEE02");
                    DateTime dateDeMaintenant = Utilitaire.obtenirMaintenant();
                    Int16 numNuite = 0;
                    foreach (DataRow nuiteLigne in lesNuites.Rows)
                    {
                        //DateTime laDateNuite = DateTime.ParseExact( nuiteLigne[1].ToString(), "yyyy-MM-dd", null);
                        DateTime laDateNuite = (DateTime)nuiteLigne[1];
                        if ((DateTime.Compare(laDateNuite, dateDeMaintenant) > 0) || laDateNuite.Date.Equals(dateDeMaintenant.Date)) // est bien une date dans le futur ou bien la date d'aujourd'hui
                        {
                            listeDesNuites.Add(new LaNuite(lePanel, nuiteLigne[0].ToString(), numNuite, laDateNuite, callback));
                            numNuite++;
                        }
                    }
                }
                public List<UnChoixNuite> getLesNuitesChoisies() {
                    List<UnChoixNuite> listeDesNuitesChoisies = new List<UnChoixNuite>();
                    foreach (LaNuite uneNuite in listeDesNuites) {
                        if ( uneNuite.estSelectionner() ) {
                            listeDesNuitesChoisies.Add( uneNuite.getChoix() );
                        }
                    }
                    return listeDesNuitesChoisies;
                }
                public float getPrixTotalDesNuites()
                {
                    float total = 0;
                    UnChoixNuite uneNuiteChoix;
                    DataTable lesPrix = Modele.ObtenirDonnees("V_TARIFHOTELCHAMBRE");
                    DataRow[] desLignePrix;
                    //
                    foreach (LaNuite uneNuite in listeDesNuites)
                    {
                        if(uneNuite.estSelectionner())
                        {
                            uneNuiteChoix = uneNuite.getChoix();
                            if (uneNuiteChoix.idHotel == null || uneNuiteChoix.idChambre == null)
                                continue;
                            //
                            desLignePrix = lesPrix.Select("CODEHOTEL = '"+uneNuiteChoix.idHotel + "' AND IDCATEGORIECHAMBRE = '"+uneNuiteChoix.idChambre + "'");
                            if (desLignePrix.Length != 1)
                                continue;
                            //
                            total += float.Parse(desLignePrix[0]["PRIX"].ToString());
                        }
                    }
                    return total;
                }


                private List<LaNuite> listeDesNuites;
            }

            /// <summary> Cette classe permet l'affichage des entrées pour les nuités </summary>
            class LaNuite
            {
                public LaNuite(ScrollableControl lePanel, String UnIDNuite, int num, DateTime laDate, Action<object, EventArgs> callback)
                {
                    IdNuite = UnIDNuite;
                    chLaNuite = new CheckBox();
                    chLaNuite.Name = "chInscriptionUneNuite" + num;
                    chLaNuite.Text = "Nuit du " + laDate.ToString("D");
                    chLaNuite.Width = 220;
                    chLaNuite.Left = 10;
                    chLaNuite.Top = 5 + (25 * num);
                    chLaNuite.Visible = true;
                    chLaNuite.CheckedChanged += new System.EventHandler(callback);
                    cbHotel = new ComboBox();
                    cbHotel.Name = "cbInscriptionUneNuiteHotel" + num;
                    cbHotel.DataSource = Modele.ObtenirDonnees("V_HOTEL01");
                    cbHotel.DisplayMember = "LIBELLE";
                    cbHotel.ValueMember = "ID";
                    cbHotel.Width = 200;
                    cbHotel.Left = 240;
                    cbHotel.Top = 5 + (25 * num);
                    cbHotel.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbHotel.Visible = true;
                    cbHotel.SelectedIndexChanged += new System.EventHandler(callback);
                    cbChambre = new ComboBox();
                    cbChambre.Name = "cbInscriptionUneNuiteChambre" + num;
                    cbChambre.DataSource = Modele.ObtenirDonnees("V_CATEGORIECHAMBRE01");
                    cbChambre.DisplayMember = "LIBELLE";
                    cbChambre.ValueMember = "ID";
                    cbChambre.Width = 90;
                    cbChambre.Left = 450;
                    cbChambre.Top = 5 + (25 * num);
                    cbChambre.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbChambre.Visible = true;
                    cbChambre.SelectedIndexChanged += new System.EventHandler(callback);
                    // Ajout
                    lePanel.Controls.Add(chLaNuite);
                    lePanel.Controls.Add(cbHotel);
                    lePanel.Controls.Add(cbChambre);
                }
                public bool estSelectionner() {
                    return chLaNuite.Checked;
                }
                public String getIdNuite() {
                    return IdNuite;
                }
                public UnChoixNuite getChoix() {
                    UnChoixNuite unChoix = new UnChoixNuite();
                    unChoix.idNuite = IdNuite;
                    unChoix.composeStr = chLaNuite.Text;
                    if (cbHotel.SelectedItem!= null) {
                        unChoix.idHotel = cbHotel.SelectedValue.ToString();
                        unChoix.composeStr += " Dans l'hotel " + cbHotel.Text;
                    }
                    if (cbChambre.SelectedItem != null) {
                        unChoix.idChambre = cbChambre.SelectedValue.ToString();
                        unChoix.composeStr += " Avec chambre " + cbChambre.Text;
                    }
                    return unChoix;
                }
                private CheckBox chLaNuite;
                private ComboBox cbHotel;
                private ComboBox cbChambre;
                private String IdNuite;
            }

           ///
           ///
           ///
           ///

            /// <summary> Cette strucutre permet de connaitre les d'une nuité </summary>
            struct UnChoixDateBenevolat
            {
                public string idDateBenevolat;
                public string composeStr;
            }
            /// <summary> Cette classe permet l'affichage d'une entrée pour la nuités </summary>
            class LesDatesBenevolat
            {
                public LesDatesBenevolat(ScrollableControl lePanel, Action<object, EventArgs> callback)
                {
                    lePanel.Controls.Clear();
                    listeDesDatesBenevolat = new List<LaDateBenevolat>();
                    DataTable lesDateBenevolat = Modele.ObtenirDonnees("V_DATEBENEVOLAT01");
                    DateTime dateDeMaintenant = Utilitaire.obtenirMaintenant();
                    Int16 numDateBenevolat = 0;
                    foreach (DataRow dateBenevolatLigne in lesDateBenevolat.Rows)
                    {
                        DateTime laDateNuite = (DateTime)dateBenevolatLigne[1];
                        if ((DateTime.Compare(laDateNuite, dateDeMaintenant) > 0) || laDateNuite.Date.Equals(dateDeMaintenant.Date)) // est bien une date dans le futur ou bien la date d'aujourd'hui
                        {
                            listeDesDatesBenevolat.Add(new LaDateBenevolat(lePanel, dateBenevolatLigne[0].ToString(), numDateBenevolat, laDateNuite, callback));
                            numDateBenevolat++;
                        }
                    }
                }
                public List<UnChoixDateBenevolat> getLesDatesBenevolatChoisies()
                {
                    List<UnChoixDateBenevolat> listeDesDatesBenevolatChoisies = new List<UnChoixDateBenevolat>();
                    foreach (LaDateBenevolat uneDatesBenevolat in listeDesDatesBenevolat)
                    {
                        if (uneDatesBenevolat.estSelectionner()) {
                            listeDesDatesBenevolatChoisies.Add(uneDatesBenevolat.getIdDateBenevolat());
                        }
                    }
                    return listeDesDatesBenevolatChoisies;
                }
                private List<LaDateBenevolat> listeDesDatesBenevolat;
            }

            class LaDateBenevolat
            {
                public LaDateBenevolat(ScrollableControl lePanel, String UnIDDateBenevolat, int num, DateTime laDateBenevolat, Action<object, EventArgs> callback)
                {
                    IdDateBenevolat = UnIDDateBenevolat;
                    cbDateBenevolat = new CheckBox();
                    cbDateBenevolat.Name = "cbInscriptionUneDateBenevolat" + num;
                    cbDateBenevolat.Text = "Journée du " + laDateBenevolat.ToString("D");
                    cbDateBenevolat.Width = 300;
                    cbDateBenevolat.Left = 10;
                    cbDateBenevolat.Top = 5 + (25 * num);
                    cbDateBenevolat.Visible = true;
                    cbDateBenevolat.CheckedChanged += new System.EventHandler(callback);
                    // Ajout
                    lePanel.Controls.Add(cbDateBenevolat);
                }
                public bool estSelectionner()
                {
                    return cbDateBenevolat.Checked;
                }
                public UnChoixDateBenevolat getIdDateBenevolat()
                {
                    UnChoixDateBenevolat uneDateBenevolat = new UnChoixDateBenevolat();
                    uneDateBenevolat.idDateBenevolat = IdDateBenevolat;
                    uneDateBenevolat.composeStr = cbDateBenevolat.Text;
                    return uneDateBenevolat;
                }
                private CheckBox cbDateBenevolat;
                private String IdDateBenevolat;
            }

            ///
            ///
            ///
            ///


            /// <summary> Cette strucutre permet de connaitre les chois repas accompagnant </summary>
            struct UnChoixDateRepasAccompagnant
            {
                public string idDateRepasAccompagnant;
                public string composeStr;
            }
            /// <summary> Cette classe permet l'affichage d'une entrée pour les repas accompagnant </summary>
            class LesDatesRepasAccompagnant
            {
                public LesDatesRepasAccompagnant(ScrollableControl lePanel, Action<object, EventArgs> callback)
                {
                    lePanel.Controls.Clear();
                    listeDesDatesRepasAccompagnant = new List<LaDateRepasAccompagnant>();
                    DataTable lesDateRepasAccompagnant = Modele.ObtenirDonnees("V_RESTAURATION01");
                    DateTime dateDeMaintenant = Utilitaire.obtenirMaintenant();
                    Int16 numDateRepasAccompagnant = 0;
                    foreach (DataRow dateRepasAccompagnantLigne in lesDateRepasAccompagnant.Rows)
                    {
                        DateTime laDateNuite = (DateTime)dateRepasAccompagnantLigne[1];
                        if ((DateTime.Compare(laDateNuite, dateDeMaintenant) > 0) || laDateNuite.Date.Equals(dateDeMaintenant.Date)) // est bien une date dans le futur ou bien la date d'aujourd'hui
                        {
                            listeDesDatesRepasAccompagnant.Add(new LaDateRepasAccompagnant(lePanel, dateRepasAccompagnantLigne[0].ToString(), numDateRepasAccompagnant, laDateNuite, dateRepasAccompagnantLigne[2].ToString(), callback));
                            numDateRepasAccompagnant++;
                        }
                    }
                }
                public List<UnChoixDateRepasAccompagnant> getLesDatesRepasAccompagnantChoisies()
                {
                    List<UnChoixDateRepasAccompagnant> listeDesDatesRepasAccompagnantChoisies = new List<UnChoixDateRepasAccompagnant>();
                    foreach (LaDateRepasAccompagnant uneDatesRepasAccompagnant in listeDesDatesRepasAccompagnant)
                    {
                        if (uneDatesRepasAccompagnant.estSelectionner())
                        {
                            listeDesDatesRepasAccompagnantChoisies.Add(uneDatesRepasAccompagnant.getIdDateRepasAccompagnant());
                        }
                    }
                    return listeDesDatesRepasAccompagnantChoisies;
                }
                public float getPrixTotalDesRepasAccompagnant()
                {
                    DataTable LesTarifs = Modele.ObtenirDonnees("V_TARIFINSCRIPTION");
                    float prixDuRepasAccompagnant = float.Parse(LesTarifs.Rows[0]["TARIFREPASACCOMPAGNANT"].ToString());
                    int nbRepas = 0;
                    //
                    foreach (LaDateRepasAccompagnant uneDateRepasAccompagnant in listeDesDatesRepasAccompagnant) {
                        if (uneDateRepasAccompagnant.estSelectionner())
                            nbRepas++;
                    }
                    return prixDuRepasAccompagnant * nbRepas;
                }
                private List<LaDateRepasAccompagnant> listeDesDatesRepasAccompagnant;
            }

            class LaDateRepasAccompagnant
            {
                public LaDateRepasAccompagnant(ScrollableControl lePanel, String UnIDDateRepasAccompagnant, int num, DateTime laDateRepasAccompagnant, String type, Action<object, EventArgs> callback)
                {
                    IdDateRepasAccompagnant = UnIDDateRepasAccompagnant;
                    cbDateRepasAccompagnant = new CheckBox();
                    cbDateRepasAccompagnant.Name =  "cbInscriptionUneDateRepasAccompagnant" + num;
                    cbDateRepasAccompagnant.Text = type + " du " + laDateRepasAccompagnant.ToString("d");
                    cbDateRepasAccompagnant.Width = 300;
                    cbDateRepasAccompagnant.Left = 6;
                    cbDateRepasAccompagnant.Top = (19 * num);
                    cbDateRepasAccompagnant.Visible = true;
                    cbDateRepasAccompagnant.CheckedChanged += new System.EventHandler(callback);
                    // Ajout
                    lePanel.Controls.Add(cbDateRepasAccompagnant);
                }
                public bool estSelectionner()
                {
                    return cbDateRepasAccompagnant.Checked;
                }
                public UnChoixDateRepasAccompagnant getIdDateRepasAccompagnant()
                {
                    UnChoixDateRepasAccompagnant uneDateRepasAccompagnant = new UnChoixDateRepasAccompagnant();
                    uneDateRepasAccompagnant.idDateRepasAccompagnant = IdDateRepasAccompagnant;
                    uneDateRepasAccompagnant.composeStr = cbDateRepasAccompagnant.Text;
                    return uneDateRepasAccompagnant;
                }
                private CheckBox cbDateRepasAccompagnant;
                private String IdDateRepasAccompagnant;
            }
        }
    }
}

        /*
        
        /// <summary>
        /// Cette méthode permet de renseigner les propriétés des contrôles à créer. C'est une partie commune aux 
        /// 3 types de participants : intervenant, licencié, bénévole
        /// </summary>
        /// <param name="UneForme">le formulaire concerné</param>  
        /// <param name="UnContainer">le panel ou le groupbox dans lequel on va placer les controles</param> 
        /// <param name="UnControleAPlacer"> le controle en cours de création</param>
        /// <param name="UnPrefixe">les noms des controles sont standard : NomControle_XX
        ///                                         ou XX estl'id de l'enregistrement récupéré dans la vue qui
        ///                                         sert de siurce de données</param> 
        /// <param name="UneLigne">un enregistrement de la vue, celle pour laquelle on crée le contrôle</param> 
        /// <param name="i"> Un compteur qui sert à positionner en hauteur le controle</param>   
        /// <param name="callback"> Le pointeur de fonction. En fait le pointeur sur la fonction qui réagira à l'événement déclencheur </param>
        private static void AffecterControle(Form UneForme, ScrollableControl UnContainer, ButtonBase UnControleAPlacer, String UnPrefixe, DataRow UneLigne, Int16 i, Action<object, EventArgs> callback)
        {
            UnControleAPlacer.Name = UnPrefixe + UneLigne[0];
            UnControleAPlacer.Width = 320;
            UnControleAPlacer.Text = UneLigne[1].ToString();
            UnControleAPlacer.Left = 13;
            UnControleAPlacer.Top = 5 +(10 * i);
            UnControleAPlacer.Visible = true;                  
            System.Type UnType = UneForme.GetType();
            //((UnType)UneForme).
            UnContainer.Controls.Add(UnControleAPlacer);
        }

        /// <summary>
        /// Créé une combobox dans un container avec le nom passé en paramètre
        /// </summary>
        /// <param name="UnContainer">panel ou groupbox</param> 
        /// <param name="unNom">nom de la groupbox à créer</param> 
        /// <param name="UnTop">positionnement haut dans le container  </param> 
        /// <param name="UnLeft">positionnement bas dans le container </param> 
        public static void CreerCombo(ScrollableControl UnContainer, String unNom, Int16 UnTop, Int16 UnLeft)
        {
            CheckBox UneCheckBox= new CheckBox();
            UneCheckBox.Name=unNom;
            UneCheckBox.Top=UnTop;
            UneCheckBox.Left=UnLeft;
            UneCheckBox.Visible=true;
            UnContainer.Controls.Add(UneCheckBox);
        }

        /// <summary>
        /// Cette méthode crée des controles de type chckbox ou radio button dans un controle de type panel.
        /// Elle va chercher les données dans la base de données et crée autant de controles (les uns au dessous des autres
        /// qu'il y a de lignes renvoyées par la base de données.
        /// </summary>
        /// <param name="UneForme">Le formulaire concerné</param> 
        /// <param name="UneConnexion">L'objet connexion à utiliser pour la connexion à la BD</param> 
        /// <param name="pUneTable">Le nom de la source de données qui va fournir les données. Il s'agit en fait d'une vue de type
        /// VXXXXOn ou XXXX représente le nom de la tabl à partir de laquelle la vue est créée. n représente un numéro de séquence</param>  
        /// <param name="pPrefixe">les noms des controles sont standard : NomControle_XX
        ///                                         ou XX estl'id de l'enregistrement récupéré dans la vue qui
        ///                                         sert de source de données</param>
        /// <param name="UnPanel">panel ou groupbox dans lequel on va créer les controles</param>
        /// <param name="unTypeControle">type de controle à créer : checkbox ou radiobutton</param>
        /// <param name="callback"> Le pointeur de fonction. En fait le pointeur sur la fonction qui réagira à l'événement déclencheur </param>
        public static void CreerDesControles(Form UneForme, String pUneTable, String pPrefixe, ScrollableControl UnPanel, String unTypeControle, Action<object, EventArgs> callback)
        {
            DataTable datatable = Modele.ObtenirDonnees(pUneTable);
            // DataTable UneTable = UneConnexion.ObtenirDonnees(pUneTable);
            // on va récupérer les statuts dans un datatable puis on va parcourir les lignes(rows) de ce datatable pour 
            // construire dynamiquement les boutons radio pour le statut de l'intervenant dans son atelier


            Int16 i = 0;
            foreach (DataRow UneLigne in datatable.Rows)
            {
                //object UnControle = Activator.CreateInstance(object unobjet, unTypeControle);
                //UnControle=Convert.ChangeType(UnControle, TypeC);
                  
                if (unTypeControle == "CheckBox")
                {
                    CheckBox UnControle = new CheckBox();
                    AffecterControle(UneForme, UnPanel, UnControle, pPrefixe, UneLigne, i++, callback);     
              
                }
                else if (unTypeControle == "RadioButton")
                {
                    RadioButton UnControle = new RadioButton();
                    AffecterControle(UneForme, UnPanel, UnControle, pPrefixe, UneLigne, i++, callback);
                    UnControle.CheckedChanged += new System.EventHandler(callback);
                }
                i++;
            }
            UnPanel.Height = 20 * i + 5;
        }

        /// <summary>méthode permettant de remplir une combobox à partir d'une source de données</summary>
        /// <param name="UneConnexion">L'objet connexion à utiliser pour la connexion à la BD</param>
        /// <param name="UneCombo"> La combobox que l'on doit remplir</param>
        /// <param name="UneSource">Le nom de la source de données qui va fournir les données. Il s'agit en fait d'une vue de type
        /// VXXXXOn ou XXXX représente le nom de la tabl à partir de laquelle la vue est créée. n représente un numéro de séquence</param>
        public static void RemplirComboBox(ComboBox UneCombo, String UneSource)
        {
            UneCombo.DataSource = Modele.ObtenirDonnees(UneSource);
            UneCombo.DisplayMember = "LIBELLE";
            UneCombo.ValueMember = "id";
        }

        /// <summary>Cette fonction va compter le nombre de controles types CheckBox qui sont cochées contenus dans la collection controls du container passé en paramètre</summary>
        /// <param name="UnControl"> le container sur lequel on va compter les controles de type checkbox qui sont checked</param>
        /// <returns>nombre  de checkbox cochées</returns>
        internal static int CompteChecked(ScrollableControl UnContainer)
        {
            Int16 i = 0;
            foreach (Control UnControle in UnContainer.Controls)
            {
                if (UnControle.GetType().Name == "CheckBox" && ((CheckBox)UnControle).Checked)
                {
                    i++;
                }
            }
            return i;
        }
    }

}

    */