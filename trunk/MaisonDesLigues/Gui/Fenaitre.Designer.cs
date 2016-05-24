namespace MaisonDesLigues.Gui
{
    partial class Fenaitre
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fenaitre));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInscription = new System.Windows.Forms.TabPage();
            this.lbInscriptionMontant = new System.Windows.Forms.Label();
            this.tbInscriptionMontant = new System.Windows.Forms.TextBox();
            this.laDate = new System.Windows.Forms.Label();
            this.btInscritpionRafraichir = new System.Windows.Forms.Button();
            this.gbInscriptionTypeParticipant = new System.Windows.Forms.GroupBox();
            this.flpInscriptionTypeParticipant = new System.Windows.Forms.FlowLayoutPanel();
            this.rbInscriptionIntervenant = new System.Windows.Forms.RadioButton();
            this.rbInscriptionLicencie = new System.Windows.Forms.RadioButton();
            this.rbInscriptionBenevole = new System.Windows.Forms.RadioButton();
            this.gbInscriptionIdentite = new System.Windows.Forms.GroupBox();
            this.tbInscriptionEmail = new System.Windows.Forms.TextBox();
            this.lbInscriptionEmail = new System.Windows.Forms.Label();
            this.tbInscriptionTelephone = new System.Windows.Forms.TextBox();
            this.lbInscriptionTelephone = new System.Windows.Forms.Label();
            this.tbInscriptionVille = new System.Windows.Forms.TextBox();
            this.lbInscriptionVille = new System.Windows.Forms.Label();
            this.tbInscriptionCP = new System.Windows.Forms.TextBox();
            this.lbInscriptionCP = new System.Windows.Forms.Label();
            this.tbInscriptionAdresse2 = new System.Windows.Forms.TextBox();
            this.tbInscriptionAdresse1 = new System.Windows.Forms.TextBox();
            this.lbInscriptionAdresse = new System.Windows.Forms.Label();
            this.tbInscriptionPrenom = new System.Windows.Forms.TextBox();
            this.lbInscriptionPrenom = new System.Windows.Forms.Label();
            this.tbInscriptionNom = new System.Windows.Forms.TextBox();
            this.lbInscriptionNom = new System.Windows.Forms.Label();
            this.pInscritpionComplement = new System.Windows.Forms.Panel();
            this.gbInscriptionLicencie = new System.Windows.Forms.GroupBox();
            this.dgInscriptionLicencieChoixAteliers = new System.Windows.Forms.DataGridView();
            this.tbInscriptionLicencieNumeroLicence = new System.Windows.Forms.TextBox();
            this.lbInscriptionLicencieNumeroLicence = new System.Windows.Forms.Label();
            this.gbInscriptionLicencieCheque = new System.Windows.Forms.GroupBox();
            this.lbInscriptionLicencieChequeN = new System.Windows.Forms.Label();
            this.lbInscriptionLicencieCheque1 = new System.Windows.Forms.Label();
            this.tbInscriptionLicencieChequeN1 = new System.Windows.Forms.TextBox();
            this.lbInscriptionLicencieCheque2 = new System.Windows.Forms.Label();
            this.lbInscriptionLicencieChequeMontant = new System.Windows.Forms.Label();
            this.cbInscriptionLicencieChequeN2Activer = new System.Windows.Forms.CheckBox();
            this.tbInscriptionLicencieChequeN2 = new System.Windows.Forms.TextBox();
            this.gbInscriptionLicencieRepasAccompagnant = new System.Windows.Forms.GroupBox();
            this.cbInscriptionLicencieRepasAccompagnantSamediMidi = new System.Windows.Forms.CheckBox();
            this.cbInscriptionLicencieRepasAccompagnantSamediSoir = new System.Windows.Forms.CheckBox();
            this.cbInscriptionLicencieRepasAccompagnantDimancheMidi = new System.Windows.Forms.CheckBox();
            this.lbInscriptionLicencieAtelier = new System.Windows.Forms.Label();
            this.gbInscriptionIntervenant = new System.Windows.Forms.GroupBox();
            this.flpInscriptionIntervenantType = new System.Windows.Forms.FlowLayoutPanel();
            this.rbInscriptionIntervenantTypeAnimateur = new System.Windows.Forms.RadioButton();
            this.rbInscriptionIntervenantTypeIntervenant = new System.Windows.Forms.RadioButton();
            this.cbInscriptionIntervenantAtelier = new System.Windows.Forms.ComboBox();
            this.lbInscriptionIntervenantAtelier = new System.Windows.Forms.Label();
            this.gbInscriptionBenevole = new System.Windows.Forms.GroupBox();
            this.dtpInscriptionBenevoleDateDeNaissance = new System.Windows.Forms.DateTimePicker();
            this.tbInscriptionBenevoleNumeroLicence = new System.Windows.Forms.TextBox();
            this.lbInscriptionBenevoleNumeroLicence = new System.Windows.Forms.Label();
            this.tbInscriptionBenevoleDateNaissance = new System.Windows.Forms.TextBox();
            this.lbInscriptionBenevoleDateNaissance = new System.Windows.Forms.Label();
            this.btInscritpionErreurs = new System.Windows.Forms.Button();
            this.btInscritpionEnregistrer = new System.Windows.Forms.Button();
            this.gbInscriptionHebergement = new System.Windows.Forms.GroupBox();
            this.gbInscriptionHebergementNuites = new System.Windows.Forms.GroupBox();
            this.pInscriptionNuites = new System.Windows.Forms.Panel();
            this.pInscriptionNuitesInfo = new System.Windows.Forms.Panel();
            this.lInscriptionNuitesInfoTypeChambre = new System.Windows.Forms.Label();
            this.lInscriptionNuitesInfoHotel = new System.Windows.Forms.Label();
            this.lInscriptionNuitesInfoDate = new System.Windows.Forms.Label();
            this.chbInscriptionNuites = new System.Windows.Forms.CheckBox();
            this.pHautDroit = new System.Windows.Forms.Panel();
            this.pbAffiche = new System.Windows.Forms.PictureBox();
            this.btInscriptionQuitter = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbInscriptionBenevoleNumeroLicenceOptionel = new System.Windows.Forms.Label();
            this.gbInscriptionBenevoleDates = new System.Windows.Forms.GroupBox();
            this.pInscriptionBenevoleDates = new System.Windows.Forms.Panel();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATELIER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHOIX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VACATION = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nudInscriptionLicencieChequeMontant1 = new System.Windows.Forms.NumericUpDown();
            this.nudInscriptionLicencieChequeMontant2 = new System.Windows.Forms.NumericUpDown();
            this.tabControl.SuspendLayout();
            this.tabInscription.SuspendLayout();
            this.gbInscriptionTypeParticipant.SuspendLayout();
            this.flpInscriptionTypeParticipant.SuspendLayout();
            this.gbInscriptionIdentite.SuspendLayout();
            this.pInscritpionComplement.SuspendLayout();
            this.gbInscriptionLicencie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInscriptionLicencieChoixAteliers)).BeginInit();
            this.gbInscriptionLicencieCheque.SuspendLayout();
            this.gbInscriptionLicencieRepasAccompagnant.SuspendLayout();
            this.gbInscriptionIntervenant.SuspendLayout();
            this.flpInscriptionIntervenantType.SuspendLayout();
            this.gbInscriptionBenevole.SuspendLayout();
            this.gbInscriptionHebergement.SuspendLayout();
            this.gbInscriptionHebergementNuites.SuspendLayout();
            this.pInscriptionNuitesInfo.SuspendLayout();
            this.pHautDroit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAffiche)).BeginInit();
            this.gbInscriptionBenevoleDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInscriptionLicencieChequeMontant1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInscriptionLicencieChequeMontant2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInscription);
            this.tabControl.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabInscription
            // 
            this.tabInscription.Controls.Add(this.lbInscriptionMontant);
            this.tabInscription.Controls.Add(this.tbInscriptionMontant);
            this.tabInscription.Controls.Add(this.laDate);
            this.tabInscription.Controls.Add(this.btInscritpionRafraichir);
            this.tabInscription.Controls.Add(this.gbInscriptionTypeParticipant);
            this.tabInscription.Controls.Add(this.gbInscriptionIdentite);
            this.tabInscription.Controls.Add(this.pInscritpionComplement);
            this.tabInscription.Controls.Add(this.btInscritpionErreurs);
            this.tabInscription.Controls.Add(this.btInscritpionEnregistrer);
            this.tabInscription.Controls.Add(this.gbInscriptionHebergement);
            this.tabInscription.Controls.Add(this.pHautDroit);
            resources.ApplyResources(this.tabInscription, "tabInscription");
            this.tabInscription.Name = "tabInscription";
            this.tabInscription.UseVisualStyleBackColor = true;
            // 
            // lbInscriptionMontant
            // 
            resources.ApplyResources(this.lbInscriptionMontant, "lbInscriptionMontant");
            this.lbInscriptionMontant.Name = "lbInscriptionMontant";
            // 
            // tbInscriptionMontant
            // 
            resources.ApplyResources(this.tbInscriptionMontant, "tbInscriptionMontant");
            this.tbInscriptionMontant.Name = "tbInscriptionMontant";
            // 
            // laDate
            // 
            resources.ApplyResources(this.laDate, "laDate");
            this.laDate.Name = "laDate";
            // 
            // btInscritpionRafraichir
            // 
            resources.ApplyResources(this.btInscritpionRafraichir, "btInscritpionRafraichir");
            this.btInscritpionRafraichir.Name = "btInscritpionRafraichir";
            this.btInscritpionRafraichir.UseCompatibleTextRendering = true;
            this.btInscritpionRafraichir.UseVisualStyleBackColor = true;
            // 
            // gbInscriptionTypeParticipant
            // 
            this.gbInscriptionTypeParticipant.Controls.Add(this.flpInscriptionTypeParticipant);
            resources.ApplyResources(this.gbInscriptionTypeParticipant, "gbInscriptionTypeParticipant");
            this.gbInscriptionTypeParticipant.Name = "gbInscriptionTypeParticipant";
            this.gbInscriptionTypeParticipant.TabStop = false;
            // 
            // flpInscriptionTypeParticipant
            // 
            this.flpInscriptionTypeParticipant.Controls.Add(this.rbInscriptionLicencie);
            this.flpInscriptionTypeParticipant.Controls.Add(this.rbInscriptionIntervenant);
            this.flpInscriptionTypeParticipant.Controls.Add(this.rbInscriptionBenevole);
            resources.ApplyResources(this.flpInscriptionTypeParticipant, "flpInscriptionTypeParticipant");
            this.flpInscriptionTypeParticipant.Name = "flpInscriptionTypeParticipant";
            // 
            // rbInscriptionIntervenant
            // 
            resources.ApplyResources(this.rbInscriptionIntervenant, "rbInscriptionIntervenant");
            this.rbInscriptionIntervenant.Name = "rbInscriptionIntervenant";
            this.rbInscriptionIntervenant.TabStop = true;
            this.rbInscriptionIntervenant.UseVisualStyleBackColor = true;
            this.rbInscriptionIntervenant.CheckedChanged += new System.EventHandler(this.rbInscriptionIntervenant_CheckedChanged);
            // 
            // rbInscriptionLicencie
            // 
            resources.ApplyResources(this.rbInscriptionLicencie, "rbInscriptionLicencie");
            this.rbInscriptionLicencie.Name = "rbInscriptionLicencie";
            this.rbInscriptionLicencie.TabStop = true;
            this.rbInscriptionLicencie.UseVisualStyleBackColor = true;
            this.rbInscriptionLicencie.CheckedChanged += new System.EventHandler(this.rbInscriptionLicencie_CheckedChanged);
            // 
            // rbInscriptionBenevole
            // 
            resources.ApplyResources(this.rbInscriptionBenevole, "rbInscriptionBenevole");
            this.rbInscriptionBenevole.Name = "rbInscriptionBenevole";
            this.rbInscriptionBenevole.TabStop = true;
            this.rbInscriptionBenevole.UseVisualStyleBackColor = true;
            this.rbInscriptionBenevole.CheckedChanged += new System.EventHandler(this.rbInscriptionBenevole_CheckedChanged);
            // 
            // gbInscriptionIdentite
            // 
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionEmail);
            this.gbInscriptionIdentite.Controls.Add(this.lbInscriptionEmail);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionTelephone);
            this.gbInscriptionIdentite.Controls.Add(this.lbInscriptionTelephone);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionVille);
            this.gbInscriptionIdentite.Controls.Add(this.lbInscriptionVille);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionCP);
            this.gbInscriptionIdentite.Controls.Add(this.lbInscriptionCP);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionAdresse2);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionAdresse1);
            this.gbInscriptionIdentite.Controls.Add(this.lbInscriptionAdresse);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionPrenom);
            this.gbInscriptionIdentite.Controls.Add(this.lbInscriptionPrenom);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionNom);
            this.gbInscriptionIdentite.Controls.Add(this.lbInscriptionNom);
            resources.ApplyResources(this.gbInscriptionIdentite, "gbInscriptionIdentite");
            this.gbInscriptionIdentite.Name = "gbInscriptionIdentite";
            this.gbInscriptionIdentite.TabStop = false;
            // 
            // tbInscriptionEmail
            // 
            resources.ApplyResources(this.tbInscriptionEmail, "tbInscriptionEmail");
            this.tbInscriptionEmail.Name = "tbInscriptionEmail";
            // 
            // lbInscriptionEmail
            // 
            resources.ApplyResources(this.lbInscriptionEmail, "lbInscriptionEmail");
            this.lbInscriptionEmail.Name = "lbInscriptionEmail";
            // 
            // tbInscriptionTelephone
            // 
            resources.ApplyResources(this.tbInscriptionTelephone, "tbInscriptionTelephone");
            this.tbInscriptionTelephone.Name = "tbInscriptionTelephone";
            // 
            // lbInscriptionTelephone
            // 
            resources.ApplyResources(this.lbInscriptionTelephone, "lbInscriptionTelephone");
            this.lbInscriptionTelephone.Name = "lbInscriptionTelephone";
            // 
            // tbInscriptionVille
            // 
            resources.ApplyResources(this.tbInscriptionVille, "tbInscriptionVille");
            this.tbInscriptionVille.Name = "tbInscriptionVille";
            // 
            // lbInscriptionVille
            // 
            resources.ApplyResources(this.lbInscriptionVille, "lbInscriptionVille");
            this.lbInscriptionVille.Name = "lbInscriptionVille";
            // 
            // tbInscriptionCP
            // 
            resources.ApplyResources(this.tbInscriptionCP, "tbInscriptionCP");
            this.tbInscriptionCP.Name = "tbInscriptionCP";
            // 
            // lbInscriptionCP
            // 
            resources.ApplyResources(this.lbInscriptionCP, "lbInscriptionCP");
            this.lbInscriptionCP.Name = "lbInscriptionCP";
            // 
            // tbInscriptionAdresse2
            // 
            resources.ApplyResources(this.tbInscriptionAdresse2, "tbInscriptionAdresse2");
            this.tbInscriptionAdresse2.Name = "tbInscriptionAdresse2";
            // 
            // tbInscriptionAdresse1
            // 
            resources.ApplyResources(this.tbInscriptionAdresse1, "tbInscriptionAdresse1");
            this.tbInscriptionAdresse1.Name = "tbInscriptionAdresse1";
            // 
            // lbInscriptionAdresse
            // 
            resources.ApplyResources(this.lbInscriptionAdresse, "lbInscriptionAdresse");
            this.lbInscriptionAdresse.Name = "lbInscriptionAdresse";
            // 
            // tbInscriptionPrenom
            // 
            resources.ApplyResources(this.tbInscriptionPrenom, "tbInscriptionPrenom");
            this.tbInscriptionPrenom.Name = "tbInscriptionPrenom";
            // 
            // lbInscriptionPrenom
            // 
            resources.ApplyResources(this.lbInscriptionPrenom, "lbInscriptionPrenom");
            this.lbInscriptionPrenom.Name = "lbInscriptionPrenom";
            // 
            // tbInscriptionNom
            // 
            resources.ApplyResources(this.tbInscriptionNom, "tbInscriptionNom");
            this.tbInscriptionNom.Name = "tbInscriptionNom";
            // 
            // lbInscriptionNom
            // 
            resources.ApplyResources(this.lbInscriptionNom, "lbInscriptionNom");
            this.lbInscriptionNom.Name = "lbInscriptionNom";
            // 
            // pInscritpionComplement
            // 
            this.pInscritpionComplement.Controls.Add(this.gbInscriptionLicencie);
            this.pInscritpionComplement.Controls.Add(this.gbInscriptionIntervenant);
            this.pInscritpionComplement.Controls.Add(this.gbInscriptionBenevole);
            resources.ApplyResources(this.pInscritpionComplement, "pInscritpionComplement");
            this.pInscritpionComplement.Name = "pInscritpionComplement";
            // 
            // gbInscriptionLicencie
            // 
            this.gbInscriptionLicencie.Controls.Add(this.dgInscriptionLicencieChoixAteliers);
            this.gbInscriptionLicencie.Controls.Add(this.tbInscriptionLicencieNumeroLicence);
            this.gbInscriptionLicencie.Controls.Add(this.lbInscriptionLicencieNumeroLicence);
            this.gbInscriptionLicencie.Controls.Add(this.gbInscriptionLicencieCheque);
            this.gbInscriptionLicencie.Controls.Add(this.gbInscriptionLicencieRepasAccompagnant);
            this.gbInscriptionLicencie.Controls.Add(this.lbInscriptionLicencieAtelier);
            resources.ApplyResources(this.gbInscriptionLicencie, "gbInscriptionLicencie");
            this.gbInscriptionLicencie.Name = "gbInscriptionLicencie";
            this.gbInscriptionLicencie.TabStop = false;
            // 
            // dgInscriptionLicencieChoixAteliers
            // 
            this.dgInscriptionLicencieChoixAteliers.AllowUserToAddRows = false;
            this.dgInscriptionLicencieChoixAteliers.AllowUserToDeleteRows = false;
            this.dgInscriptionLicencieChoixAteliers.AllowUserToResizeRows = false;
            this.dgInscriptionLicencieChoixAteliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInscriptionLicencieChoixAteliers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgInscriptionLicencieChoixAteliers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.N,
            this.ATELIER,
            this.CHOIX,
            this.VACATION});
            resources.ApplyResources(this.dgInscriptionLicencieChoixAteliers, "dgInscriptionLicencieChoixAteliers");
            this.dgInscriptionLicencieChoixAteliers.Name = "dgInscriptionLicencieChoixAteliers";
            this.dgInscriptionLicencieChoixAteliers.RowHeadersVisible = false;
            // 
            // tbInscriptionLicencieNumeroLicence
            // 
            resources.ApplyResources(this.tbInscriptionLicencieNumeroLicence, "tbInscriptionLicencieNumeroLicence");
            this.tbInscriptionLicencieNumeroLicence.Name = "tbInscriptionLicencieNumeroLicence";
            // 
            // lbInscriptionLicencieNumeroLicence
            // 
            resources.ApplyResources(this.lbInscriptionLicencieNumeroLicence, "lbInscriptionLicencieNumeroLicence");
            this.lbInscriptionLicencieNumeroLicence.Name = "lbInscriptionLicencieNumeroLicence";
            // 
            // gbInscriptionLicencieCheque
            // 
            this.gbInscriptionLicencieCheque.Controls.Add(this.nudInscriptionLicencieChequeMontant2);
            this.gbInscriptionLicencieCheque.Controls.Add(this.nudInscriptionLicencieChequeMontant1);
            this.gbInscriptionLicencieCheque.Controls.Add(this.lbInscriptionLicencieChequeN);
            this.gbInscriptionLicencieCheque.Controls.Add(this.lbInscriptionLicencieChequeMontant);
            this.gbInscriptionLicencieCheque.Controls.Add(this.lbInscriptionLicencieCheque1);
            this.gbInscriptionLicencieCheque.Controls.Add(this.tbInscriptionLicencieChequeN1);
            this.gbInscriptionLicencieCheque.Controls.Add(this.lbInscriptionLicencieCheque2);
            this.gbInscriptionLicencieCheque.Controls.Add(this.cbInscriptionLicencieChequeN2Activer);
            this.gbInscriptionLicencieCheque.Controls.Add(this.tbInscriptionLicencieChequeN2);
            resources.ApplyResources(this.gbInscriptionLicencieCheque, "gbInscriptionLicencieCheque");
            this.gbInscriptionLicencieCheque.Name = "gbInscriptionLicencieCheque";
            this.gbInscriptionLicencieCheque.TabStop = false;
            // 
            // lbInscriptionLicencieChequeN
            // 
            resources.ApplyResources(this.lbInscriptionLicencieChequeN, "lbInscriptionLicencieChequeN");
            this.lbInscriptionLicencieChequeN.Name = "lbInscriptionLicencieChequeN";
            // 
            // lbInscriptionLicencieCheque1
            // 
            resources.ApplyResources(this.lbInscriptionLicencieCheque1, "lbInscriptionLicencieCheque1");
            this.lbInscriptionLicencieCheque1.Name = "lbInscriptionLicencieCheque1";
            // 
            // tbInscriptionLicencieChequeN1
            // 
            resources.ApplyResources(this.tbInscriptionLicencieChequeN1, "tbInscriptionLicencieChequeN1");
            this.tbInscriptionLicencieChequeN1.Name = "tbInscriptionLicencieChequeN1";
            // 
            // lbInscriptionLicencieCheque2
            // 
            resources.ApplyResources(this.lbInscriptionLicencieCheque2, "lbInscriptionLicencieCheque2");
            this.lbInscriptionLicencieCheque2.Name = "lbInscriptionLicencieCheque2";
            // 
            // lbInscriptionLicencieChequeMontant
            // 
            resources.ApplyResources(this.lbInscriptionLicencieChequeMontant, "lbInscriptionLicencieChequeMontant");
            this.lbInscriptionLicencieChequeMontant.Name = "lbInscriptionLicencieChequeMontant";
            // 
            // cbInscriptionLicencieChequeN2Activer
            // 
            resources.ApplyResources(this.cbInscriptionLicencieChequeN2Activer, "cbInscriptionLicencieChequeN2Activer");
            this.cbInscriptionLicencieChequeN2Activer.Name = "cbInscriptionLicencieChequeN2Activer";
            this.cbInscriptionLicencieChequeN2Activer.UseVisualStyleBackColor = true;
            // 
            // tbInscriptionLicencieChequeN2
            // 
            resources.ApplyResources(this.tbInscriptionLicencieChequeN2, "tbInscriptionLicencieChequeN2");
            this.tbInscriptionLicencieChequeN2.Name = "tbInscriptionLicencieChequeN2";
            // 
            // gbInscriptionLicencieRepasAccompagnant
            // 
            this.gbInscriptionLicencieRepasAccompagnant.Controls.Add(this.cbInscriptionLicencieRepasAccompagnantSamediMidi);
            this.gbInscriptionLicencieRepasAccompagnant.Controls.Add(this.cbInscriptionLicencieRepasAccompagnantSamediSoir);
            this.gbInscriptionLicencieRepasAccompagnant.Controls.Add(this.cbInscriptionLicencieRepasAccompagnantDimancheMidi);
            resources.ApplyResources(this.gbInscriptionLicencieRepasAccompagnant, "gbInscriptionLicencieRepasAccompagnant");
            this.gbInscriptionLicencieRepasAccompagnant.Name = "gbInscriptionLicencieRepasAccompagnant";
            this.gbInscriptionLicencieRepasAccompagnant.TabStop = false;
            // 
            // cbInscriptionLicencieRepasAccompagnantSamediMidi
            // 
            resources.ApplyResources(this.cbInscriptionLicencieRepasAccompagnantSamediMidi, "cbInscriptionLicencieRepasAccompagnantSamediMidi");
            this.cbInscriptionLicencieRepasAccompagnantSamediMidi.Name = "cbInscriptionLicencieRepasAccompagnantSamediMidi";
            this.cbInscriptionLicencieRepasAccompagnantSamediMidi.UseVisualStyleBackColor = true;
            // 
            // cbInscriptionLicencieRepasAccompagnantSamediSoir
            // 
            resources.ApplyResources(this.cbInscriptionLicencieRepasAccompagnantSamediSoir, "cbInscriptionLicencieRepasAccompagnantSamediSoir");
            this.cbInscriptionLicencieRepasAccompagnantSamediSoir.Name = "cbInscriptionLicencieRepasAccompagnantSamediSoir";
            this.cbInscriptionLicencieRepasAccompagnantSamediSoir.UseVisualStyleBackColor = true;
            // 
            // cbInscriptionLicencieRepasAccompagnantDimancheMidi
            // 
            resources.ApplyResources(this.cbInscriptionLicencieRepasAccompagnantDimancheMidi, "cbInscriptionLicencieRepasAccompagnantDimancheMidi");
            this.cbInscriptionLicencieRepasAccompagnantDimancheMidi.Name = "cbInscriptionLicencieRepasAccompagnantDimancheMidi";
            this.cbInscriptionLicencieRepasAccompagnantDimancheMidi.UseVisualStyleBackColor = true;
            // 
            // lbInscriptionLicencieAtelier
            // 
            resources.ApplyResources(this.lbInscriptionLicencieAtelier, "lbInscriptionLicencieAtelier");
            this.lbInscriptionLicencieAtelier.Name = "lbInscriptionLicencieAtelier";
            // 
            // gbInscriptionIntervenant
            // 
            this.gbInscriptionIntervenant.Controls.Add(this.flpInscriptionIntervenantType);
            this.gbInscriptionIntervenant.Controls.Add(this.cbInscriptionIntervenantAtelier);
            this.gbInscriptionIntervenant.Controls.Add(this.lbInscriptionIntervenantAtelier);
            resources.ApplyResources(this.gbInscriptionIntervenant, "gbInscriptionIntervenant");
            this.gbInscriptionIntervenant.Name = "gbInscriptionIntervenant";
            this.gbInscriptionIntervenant.TabStop = false;
            // 
            // flpInscriptionIntervenantType
            // 
            this.flpInscriptionIntervenantType.Controls.Add(this.rbInscriptionIntervenantTypeAnimateur);
            this.flpInscriptionIntervenantType.Controls.Add(this.rbInscriptionIntervenantTypeIntervenant);
            resources.ApplyResources(this.flpInscriptionIntervenantType, "flpInscriptionIntervenantType");
            this.flpInscriptionIntervenantType.Name = "flpInscriptionIntervenantType";
            // 
            // rbInscriptionIntervenantTypeAnimateur
            // 
            resources.ApplyResources(this.rbInscriptionIntervenantTypeAnimateur, "rbInscriptionIntervenantTypeAnimateur");
            this.rbInscriptionIntervenantTypeAnimateur.Name = "rbInscriptionIntervenantTypeAnimateur";
            this.rbInscriptionIntervenantTypeAnimateur.TabStop = true;
            this.rbInscriptionIntervenantTypeAnimateur.UseVisualStyleBackColor = true;
            // 
            // rbInscriptionIntervenantTypeIntervenant
            // 
            resources.ApplyResources(this.rbInscriptionIntervenantTypeIntervenant, "rbInscriptionIntervenantTypeIntervenant");
            this.rbInscriptionIntervenantTypeIntervenant.Name = "rbInscriptionIntervenantTypeIntervenant";
            this.rbInscriptionIntervenantTypeIntervenant.TabStop = true;
            this.rbInscriptionIntervenantTypeIntervenant.UseVisualStyleBackColor = true;
            // 
            // cbInscriptionIntervenantAtelier
            // 
            this.cbInscriptionIntervenantAtelier.FormattingEnabled = true;
            resources.ApplyResources(this.cbInscriptionIntervenantAtelier, "cbInscriptionIntervenantAtelier");
            this.cbInscriptionIntervenantAtelier.Name = "cbInscriptionIntervenantAtelier";
            // 
            // lbInscriptionIntervenantAtelier
            // 
            resources.ApplyResources(this.lbInscriptionIntervenantAtelier, "lbInscriptionIntervenantAtelier");
            this.lbInscriptionIntervenantAtelier.Name = "lbInscriptionIntervenantAtelier";
            // 
            // gbInscriptionBenevole
            // 
            this.gbInscriptionBenevole.Controls.Add(this.gbInscriptionBenevoleDates);
            this.gbInscriptionBenevole.Controls.Add(this.lbInscriptionBenevoleNumeroLicenceOptionel);
            this.gbInscriptionBenevole.Controls.Add(this.dtpInscriptionBenevoleDateDeNaissance);
            this.gbInscriptionBenevole.Controls.Add(this.tbInscriptionBenevoleNumeroLicence);
            this.gbInscriptionBenevole.Controls.Add(this.lbInscriptionBenevoleNumeroLicence);
            this.gbInscriptionBenevole.Controls.Add(this.tbInscriptionBenevoleDateNaissance);
            this.gbInscriptionBenevole.Controls.Add(this.lbInscriptionBenevoleDateNaissance);
            resources.ApplyResources(this.gbInscriptionBenevole, "gbInscriptionBenevole");
            this.gbInscriptionBenevole.Name = "gbInscriptionBenevole";
            this.gbInscriptionBenevole.TabStop = false;
            // 
            // dtpInscriptionBenevoleDateDeNaissance
            // 
            resources.ApplyResources(this.dtpInscriptionBenevoleDateDeNaissance, "dtpInscriptionBenevoleDateDeNaissance");
            this.dtpInscriptionBenevoleDateDeNaissance.Name = "dtpInscriptionBenevoleDateDeNaissance";
            // 
            // tbInscriptionBenevoleNumeroLicence
            // 
            resources.ApplyResources(this.tbInscriptionBenevoleNumeroLicence, "tbInscriptionBenevoleNumeroLicence");
            this.tbInscriptionBenevoleNumeroLicence.Name = "tbInscriptionBenevoleNumeroLicence";
            // 
            // lbInscriptionBenevoleNumeroLicence
            // 
            resources.ApplyResources(this.lbInscriptionBenevoleNumeroLicence, "lbInscriptionBenevoleNumeroLicence");
            this.lbInscriptionBenevoleNumeroLicence.Name = "lbInscriptionBenevoleNumeroLicence";
            // 
            // tbInscriptionBenevoleDateNaissance
            // 
            resources.ApplyResources(this.tbInscriptionBenevoleDateNaissance, "tbInscriptionBenevoleDateNaissance");
            this.tbInscriptionBenevoleDateNaissance.Name = "tbInscriptionBenevoleDateNaissance";
            // 
            // lbInscriptionBenevoleDateNaissance
            // 
            resources.ApplyResources(this.lbInscriptionBenevoleDateNaissance, "lbInscriptionBenevoleDateNaissance");
            this.lbInscriptionBenevoleDateNaissance.Name = "lbInscriptionBenevoleDateNaissance";
            // 
            // btInscritpionErreurs
            // 
            resources.ApplyResources(this.btInscritpionErreurs, "btInscritpionErreurs");
            this.btInscritpionErreurs.Name = "btInscritpionErreurs";
            this.btInscritpionErreurs.UseCompatibleTextRendering = true;
            this.btInscritpionErreurs.UseVisualStyleBackColor = true;
            // 
            // btInscritpionEnregistrer
            // 
            resources.ApplyResources(this.btInscritpionEnregistrer, "btInscritpionEnregistrer");
            this.btInscritpionEnregistrer.Name = "btInscritpionEnregistrer";
            this.btInscritpionEnregistrer.UseCompatibleTextRendering = true;
            this.btInscritpionEnregistrer.UseVisualStyleBackColor = true;
            // 
            // gbInscriptionHebergement
            // 
            this.gbInscriptionHebergement.Controls.Add(this.gbInscriptionHebergementNuites);
            this.gbInscriptionHebergement.Controls.Add(this.chbInscriptionNuites);
            resources.ApplyResources(this.gbInscriptionHebergement, "gbInscriptionHebergement");
            this.gbInscriptionHebergement.Name = "gbInscriptionHebergement";
            this.gbInscriptionHebergement.TabStop = false;
            // 
            // gbInscriptionHebergementNuites
            // 
            this.gbInscriptionHebergementNuites.Controls.Add(this.pInscriptionNuites);
            this.gbInscriptionHebergementNuites.Controls.Add(this.pInscriptionNuitesInfo);
            resources.ApplyResources(this.gbInscriptionHebergementNuites, "gbInscriptionHebergementNuites");
            this.gbInscriptionHebergementNuites.Name = "gbInscriptionHebergementNuites";
            this.gbInscriptionHebergementNuites.TabStop = false;
            // 
            // pInscriptionNuites
            // 
            resources.ApplyResources(this.pInscriptionNuites, "pInscriptionNuites");
            this.pInscriptionNuites.Name = "pInscriptionNuites";
            // 
            // pInscriptionNuitesInfo
            // 
            resources.ApplyResources(this.pInscriptionNuitesInfo, "pInscriptionNuitesInfo");
            this.pInscriptionNuitesInfo.Controls.Add(this.lInscriptionNuitesInfoTypeChambre);
            this.pInscriptionNuitesInfo.Controls.Add(this.lInscriptionNuitesInfoHotel);
            this.pInscriptionNuitesInfo.Controls.Add(this.lInscriptionNuitesInfoDate);
            this.pInscriptionNuitesInfo.Name = "pInscriptionNuitesInfo";
            // 
            // lInscriptionNuitesInfoTypeChambre
            // 
            resources.ApplyResources(this.lInscriptionNuitesInfoTypeChambre, "lInscriptionNuitesInfoTypeChambre");
            this.lInscriptionNuitesInfoTypeChambre.Name = "lInscriptionNuitesInfoTypeChambre";
            // 
            // lInscriptionNuitesInfoHotel
            // 
            resources.ApplyResources(this.lInscriptionNuitesInfoHotel, "lInscriptionNuitesInfoHotel");
            this.lInscriptionNuitesInfoHotel.Name = "lInscriptionNuitesInfoHotel";
            // 
            // lInscriptionNuitesInfoDate
            // 
            resources.ApplyResources(this.lInscriptionNuitesInfoDate, "lInscriptionNuitesInfoDate");
            this.lInscriptionNuitesInfoDate.Name = "lInscriptionNuitesInfoDate";
            // 
            // chbInscriptionNuites
            // 
            resources.ApplyResources(this.chbInscriptionNuites, "chbInscriptionNuites");
            this.chbInscriptionNuites.Name = "chbInscriptionNuites";
            this.chbInscriptionNuites.UseVisualStyleBackColor = true;
            this.chbInscriptionNuites.CheckedChanged += new System.EventHandler(this.chbInscriptionNuites_CheckedChanged);
            // 
            // pHautDroit
            // 
            resources.ApplyResources(this.pHautDroit, "pHautDroit");
            this.pHautDroit.Controls.Add(this.pbAffiche);
            this.pHautDroit.Controls.Add(this.btInscriptionQuitter);
            this.pHautDroit.Name = "pHautDroit";
            // 
            // pbAffiche
            // 
            resources.ApplyResources(this.pbAffiche, "pbAffiche");
            this.pbAffiche.Image = global::MaisonDesLigues.Properties.Resources.affiche;
            this.pbAffiche.Name = "pbAffiche";
            this.pbAffiche.TabStop = false;
            // 
            // btInscriptionQuitter
            // 
            resources.ApplyResources(this.btInscriptionQuitter, "btInscriptionQuitter");
            this.btInscriptionQuitter.Name = "btInscriptionQuitter";
            this.btInscriptionQuitter.UseVisualStyleBackColor = true;
            this.btInscriptionQuitter.Click += new System.EventHandler(this.btInscriptionQuitter_Click);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbInscriptionBenevoleNumeroLicenceOptionel
            // 
            resources.ApplyResources(this.lbInscriptionBenevoleNumeroLicenceOptionel, "lbInscriptionBenevoleNumeroLicenceOptionel");
            this.lbInscriptionBenevoleNumeroLicenceOptionel.Name = "lbInscriptionBenevoleNumeroLicenceOptionel";
            // 
            // gbInscriptionBenevoleDates
            // 
            this.gbInscriptionBenevoleDates.Controls.Add(this.pInscriptionBenevoleDates);
            resources.ApplyResources(this.gbInscriptionBenevoleDates, "gbInscriptionBenevoleDates");
            this.gbInscriptionBenevoleDates.Name = "gbInscriptionBenevoleDates";
            this.gbInscriptionBenevoleDates.TabStop = false;
            // 
            // pInscriptionBenevoleDates
            // 
            resources.ApplyResources(this.pInscriptionBenevoleDates, "pInscriptionBenevoleDates");
            this.pInscriptionBenevoleDates.Name = "pInscriptionBenevoleDates";
            // 
            // N
            // 
            resources.ApplyResources(this.N, "N");
            this.N.Name = "N";
            this.N.ReadOnly = true;
            this.N.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ATELIER
            // 
            this.ATELIER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            resources.ApplyResources(this.ATELIER, "ATELIER");
            this.ATELIER.Name = "ATELIER";
            this.ATELIER.ReadOnly = true;
            // 
            // CHOIX
            // 
            resources.ApplyResources(this.CHOIX, "CHOIX");
            this.CHOIX.Name = "CHOIX";
            this.CHOIX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // VACATION
            // 
            resources.ApplyResources(this.VACATION, "VACATION");
            this.VACATION.Name = "VACATION";
            // 
            // nudInscriptionLicencieChequeMontant1
            // 
            this.nudInscriptionLicencieChequeMontant1.DecimalPlaces = 2;
            resources.ApplyResources(this.nudInscriptionLicencieChequeMontant1, "nudInscriptionLicencieChequeMontant1");
            this.nudInscriptionLicencieChequeMontant1.Name = "nudInscriptionLicencieChequeMontant1";
            // 
            // nudInscriptionLicencieChequeMontant2
            // 
            this.nudInscriptionLicencieChequeMontant2.DecimalPlaces = 2;
            resources.ApplyResources(this.nudInscriptionLicencieChequeMontant2, "nudInscriptionLicencieChequeMontant2");
            this.nudInscriptionLicencieChequeMontant2.Name = "nudInscriptionLicencieChequeMontant2";
            // 
            // Fenaitre
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Fenaitre";
            this.tabControl.ResumeLayout(false);
            this.tabInscription.ResumeLayout(false);
            this.tabInscription.PerformLayout();
            this.gbInscriptionTypeParticipant.ResumeLayout(false);
            this.flpInscriptionTypeParticipant.ResumeLayout(false);
            this.flpInscriptionTypeParticipant.PerformLayout();
            this.gbInscriptionIdentite.ResumeLayout(false);
            this.gbInscriptionIdentite.PerformLayout();
            this.pInscritpionComplement.ResumeLayout(false);
            this.gbInscriptionLicencie.ResumeLayout(false);
            this.gbInscriptionLicencie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInscriptionLicencieChoixAteliers)).EndInit();
            this.gbInscriptionLicencieCheque.ResumeLayout(false);
            this.gbInscriptionLicencieCheque.PerformLayout();
            this.gbInscriptionLicencieRepasAccompagnant.ResumeLayout(false);
            this.gbInscriptionLicencieRepasAccompagnant.PerformLayout();
            this.gbInscriptionIntervenant.ResumeLayout(false);
            this.gbInscriptionIntervenant.PerformLayout();
            this.flpInscriptionIntervenantType.ResumeLayout(false);
            this.flpInscriptionIntervenantType.PerformLayout();
            this.gbInscriptionBenevole.ResumeLayout(false);
            this.gbInscriptionBenevole.PerformLayout();
            this.gbInscriptionHebergement.ResumeLayout(false);
            this.gbInscriptionHebergement.PerformLayout();
            this.gbInscriptionHebergementNuites.ResumeLayout(false);
            this.gbInscriptionHebergementNuites.PerformLayout();
            this.pInscriptionNuitesInfo.ResumeLayout(false);
            this.pInscriptionNuitesInfo.PerformLayout();
            this.pHautDroit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAffiche)).EndInit();
            this.gbInscriptionBenevoleDates.ResumeLayout(false);
            this.gbInscriptionBenevoleDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInscriptionLicencieChequeMontant1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInscriptionLicencieChequeMontant2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInscription;
        private System.Windows.Forms.GroupBox gbInscriptionTypeParticipant;
        private System.Windows.Forms.FlowLayoutPanel flpInscriptionTypeParticipant;
        private System.Windows.Forms.RadioButton rbInscriptionIntervenant;
        private System.Windows.Forms.RadioButton rbInscriptionLicencie;
        private System.Windows.Forms.RadioButton rbInscriptionBenevole;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btInscriptionQuitter;
        private System.Windows.Forms.PictureBox pbAffiche;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pHautDroit;
        private System.Windows.Forms.GroupBox gbInscriptionIntervenant;
        private System.Windows.Forms.GroupBox gbInscriptionIdentite;
        private System.Windows.Forms.Label lbInscriptionNom;
        private System.Windows.Forms.TextBox tbInscriptionNom;
        private System.Windows.Forms.Button btInscritpionEnregistrer;
        private System.Windows.Forms.TextBox tbInscriptionPrenom;
        private System.Windows.Forms.Label lbInscriptionPrenom;
        private System.Windows.Forms.TextBox tbInscriptionEmail;
        private System.Windows.Forms.Label lbInscriptionEmail;
        private System.Windows.Forms.TextBox tbInscriptionTelephone;
        private System.Windows.Forms.Label lbInscriptionTelephone;
        private System.Windows.Forms.TextBox tbInscriptionVille;
        private System.Windows.Forms.Label lbInscriptionVille;
        private System.Windows.Forms.TextBox tbInscriptionCP;
        private System.Windows.Forms.Label lbInscriptionCP;
        private System.Windows.Forms.TextBox tbInscriptionAdresse2;
        private System.Windows.Forms.TextBox tbInscriptionAdresse1;
        private System.Windows.Forms.Label lbInscriptionAdresse;
        private System.Windows.Forms.Label lbInscriptionIntervenantAtelier;
        private System.Windows.Forms.ComboBox cbInscriptionIntervenantAtelier;
        private System.Windows.Forms.FlowLayoutPanel flpInscriptionIntervenantType;
        private System.Windows.Forms.RadioButton rbInscriptionIntervenantTypeAnimateur;
        private System.Windows.Forms.RadioButton rbInscriptionIntervenantTypeIntervenant;
        private System.Windows.Forms.CheckBox chbInscriptionNuites;
        private System.Windows.Forms.Panel pInscritpionComplement;
        private System.Windows.Forms.GroupBox gbInscriptionBenevole;
        private System.Windows.Forms.TextBox tbInscriptionBenevoleNumeroLicence;
        private System.Windows.Forms.Label lbInscriptionBenevoleNumeroLicence;
        private System.Windows.Forms.TextBox tbInscriptionBenevoleDateNaissance;
        private System.Windows.Forms.Label lbInscriptionBenevoleDateNaissance;
        private System.Windows.Forms.DateTimePicker dtpInscriptionBenevoleDateDeNaissance;
        private System.Windows.Forms.Label laDate;
        private System.Windows.Forms.Button btInscritpionRafraichir;
        private System.Windows.Forms.Button btInscritpionErreurs;
        private System.Windows.Forms.GroupBox gbInscriptionHebergement;
        private System.Windows.Forms.GroupBox gbInscriptionHebergementNuites;
        private System.Windows.Forms.Panel pInscriptionNuites;
        private System.Windows.Forms.Panel pInscriptionNuitesInfo;
        private System.Windows.Forms.Label lInscriptionNuitesInfoTypeChambre;
        private System.Windows.Forms.Label lInscriptionNuitesInfoHotel;
        private System.Windows.Forms.Label lInscriptionNuitesInfoDate;
        private System.Windows.Forms.GroupBox gbInscriptionLicencie;
        private System.Windows.Forms.Label lbInscriptionLicencieAtelier;
        private System.Windows.Forms.Label lbInscriptionMontant;
        private System.Windows.Forms.TextBox tbInscriptionMontant;
        private System.Windows.Forms.CheckBox cbInscriptionLicencieRepasAccompagnantSamediMidi;
        private System.Windows.Forms.CheckBox cbInscriptionLicencieRepasAccompagnantDimancheMidi;
        private System.Windows.Forms.CheckBox cbInscriptionLicencieRepasAccompagnantSamediSoir;
        private System.Windows.Forms.Label lbInscriptionLicencieChequeMontant;
        private System.Windows.Forms.Label lbInscriptionLicencieChequeN;
        private System.Windows.Forms.TextBox tbInscriptionLicencieChequeN1;
        private System.Windows.Forms.TextBox tbInscriptionLicencieChequeN2;
        private System.Windows.Forms.Label lbInscriptionLicencieCheque1;
        private System.Windows.Forms.Label lbInscriptionLicencieCheque2;
        private System.Windows.Forms.CheckBox cbInscriptionLicencieChequeN2Activer;
        private System.Windows.Forms.GroupBox gbInscriptionLicencieCheque;
        private System.Windows.Forms.GroupBox gbInscriptionLicencieRepasAccompagnant;
        private System.Windows.Forms.TextBox tbInscriptionLicencieNumeroLicence;
        private System.Windows.Forms.Label lbInscriptionLicencieNumeroLicence;
        private System.Windows.Forms.DataGridView dgInscriptionLicencieChoixAteliers;
        private System.Windows.Forms.Label lbInscriptionBenevoleNumeroLicenceOptionel;
        private System.Windows.Forms.GroupBox gbInscriptionBenevoleDates;
        private System.Windows.Forms.Panel pInscriptionBenevoleDates;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATELIER;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHOIX;
        private System.Windows.Forms.DataGridViewComboBoxColumn VACATION;
        private System.Windows.Forms.NumericUpDown nudInscriptionLicencieChequeMontant1;
        private System.Windows.Forms.NumericUpDown nudInscriptionLicencieChequeMontant2;
    }
}

