namespace MaisonDesLigues
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
            this.laDate = new System.Windows.Forms.Label();
            this.pInscritpionComplement = new System.Windows.Forms.Panel();
            this.gbInscriptionIntervenant = new System.Windows.Forms.GroupBox();
            this.chbInscriptionIntervenantNuites = new System.Windows.Forms.CheckBox();
            this.gbInscriptionIntervenantNuites = new System.Windows.Forms.GroupBox();
            this.pInscriptionIntervenantNuites = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.cbInscriptionIntervenantAtelier = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbInscriptionBenevole = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btInscritpionEnregistrer = new System.Windows.Forms.Button();
            this.gbInscriptionIdentite = new System.Windows.Forms.GroupBox();
            this.tbInscriptionEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInscriptionTelephone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbInscriptionVille = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInscriptionCP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInscriptionAdresse2 = new System.Windows.Forms.TextBox();
            this.tbInscriptionAdresse1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInscriptionPrenom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInscriptionNom = new System.Windows.Forms.TextBox();
            this.laInscriptionNom = new System.Windows.Forms.Label();
            this.pHautDroit = new System.Windows.Forms.Panel();
            this.pbAffiche = new System.Windows.Forms.PictureBox();
            this.btInscriptionQuitter = new System.Windows.Forms.Button();
            this.gbInscriptionTypeParticipant = new System.Windows.Forms.GroupBox();
            this.flpInscriptionTypeParticipant = new System.Windows.Forms.FlowLayoutPanel();
            this.rbInscriptionIntervenant = new System.Windows.Forms.RadioButton();
            this.rbInscriptionLicencie = new System.Windows.Forms.RadioButton();
            this.rbInscriptionBenevole = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl.SuspendLayout();
            this.tabInscription.SuspendLayout();
            this.pInscritpionComplement.SuspendLayout();
            this.gbInscriptionIntervenant.SuspendLayout();
            this.gbInscriptionIntervenantNuites.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbInscriptionBenevole.SuspendLayout();
            this.gbInscriptionIdentite.SuspendLayout();
            this.pHautDroit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAffiche)).BeginInit();
            this.gbInscriptionTypeParticipant.SuspendLayout();
            this.flpInscriptionTypeParticipant.SuspendLayout();
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
            this.tabInscription.Controls.Add(this.laDate);
            this.tabInscription.Controls.Add(this.pInscritpionComplement);
            this.tabInscription.Controls.Add(this.btInscritpionEnregistrer);
            this.tabInscription.Controls.Add(this.gbInscriptionIdentite);
            this.tabInscription.Controls.Add(this.pHautDroit);
            this.tabInscription.Controls.Add(this.gbInscriptionTypeParticipant);
            resources.ApplyResources(this.tabInscription, "tabInscription");
            this.tabInscription.Name = "tabInscription";
            this.tabInscription.UseVisualStyleBackColor = true;
            // 
            // laDate
            // 
            resources.ApplyResources(this.laDate, "laDate");
            this.laDate.Name = "laDate";
            // 
            // pInscritpionComplement
            // 
            this.pInscritpionComplement.Controls.Add(this.gbInscriptionIntervenant);
            this.pInscritpionComplement.Controls.Add(this.gbInscriptionBenevole);
            resources.ApplyResources(this.pInscritpionComplement, "pInscritpionComplement");
            this.pInscritpionComplement.Name = "pInscritpionComplement";
            // 
            // gbInscriptionIntervenant
            // 
            this.gbInscriptionIntervenant.Controls.Add(this.chbInscriptionIntervenantNuites);
            this.gbInscriptionIntervenant.Controls.Add(this.gbInscriptionIntervenantNuites);
            this.gbInscriptionIntervenant.Controls.Add(this.flowLayoutPanel1);
            this.gbInscriptionIntervenant.Controls.Add(this.cbInscriptionIntervenantAtelier);
            this.gbInscriptionIntervenant.Controls.Add(this.label7);
            resources.ApplyResources(this.gbInscriptionIntervenant, "gbInscriptionIntervenant");
            this.gbInscriptionIntervenant.Name = "gbInscriptionIntervenant";
            this.gbInscriptionIntervenant.TabStop = false;
            // 
            // chbInscriptionIntervenantNuites
            // 
            resources.ApplyResources(this.chbInscriptionIntervenantNuites, "chbInscriptionIntervenantNuites");
            this.chbInscriptionIntervenantNuites.Name = "chbInscriptionIntervenantNuites";
            this.chbInscriptionIntervenantNuites.UseVisualStyleBackColor = true;
            this.chbInscriptionIntervenantNuites.CheckedChanged += new System.EventHandler(this.chbInscriptionIntervenantNuites_CheckedChanged);
            // 
            // gbInscriptionIntervenantNuites
            // 
            this.gbInscriptionIntervenantNuites.Controls.Add(this.pInscriptionIntervenantNuites);
            resources.ApplyResources(this.gbInscriptionIntervenantNuites, "gbInscriptionIntervenantNuites");
            this.gbInscriptionIntervenantNuites.Name = "gbInscriptionIntervenantNuites";
            this.gbInscriptionIntervenantNuites.TabStop = false;
            // 
            // pInscriptionIntervenantNuites
            // 
            resources.ApplyResources(this.pInscriptionIntervenantNuites, "pInscriptionIntervenantNuites");
            this.pInscriptionIntervenantNuites.Name = "pInscriptionIntervenantNuites";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // cbInscriptionIntervenantAtelier
            // 
            this.cbInscriptionIntervenantAtelier.FormattingEnabled = true;
            resources.ApplyResources(this.cbInscriptionIntervenantAtelier, "cbInscriptionIntervenantAtelier");
            this.cbInscriptionIntervenantAtelier.Name = "cbInscriptionIntervenantAtelier";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // gbInscriptionBenevole
            // 
            this.gbInscriptionBenevole.Controls.Add(this.dateTimePicker1);
            this.gbInscriptionBenevole.Controls.Add(this.checkBox3);
            this.gbInscriptionBenevole.Controls.Add(this.checkBox2);
            this.gbInscriptionBenevole.Controls.Add(this.textBox10);
            this.gbInscriptionBenevole.Controls.Add(this.label9);
            this.gbInscriptionBenevole.Controls.Add(this.textBox9);
            this.gbInscriptionBenevole.Controls.Add(this.label8);
            resources.ApplyResources(this.gbInscriptionBenevole, "gbInscriptionBenevole");
            this.gbInscriptionBenevole.Name = "gbInscriptionBenevole";
            this.gbInscriptionBenevole.TabStop = false;
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // checkBox3
            // 
            resources.ApplyResources(this.checkBox3, "checkBox3");
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            resources.ApplyResources(this.textBox10, "textBox10");
            this.textBox10.Name = "textBox10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // textBox9
            // 
            resources.ApplyResources(this.textBox9, "textBox9");
            this.textBox9.Name = "textBox9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // btInscritpionEnregistrer
            // 
            resources.ApplyResources(this.btInscritpionEnregistrer, "btInscritpionEnregistrer");
            this.btInscritpionEnregistrer.Name = "btInscritpionEnregistrer";
            this.btInscritpionEnregistrer.UseVisualStyleBackColor = true;
            // 
            // gbInscriptionIdentite
            // 
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionEmail);
            this.gbInscriptionIdentite.Controls.Add(this.label6);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionTelephone);
            this.gbInscriptionIdentite.Controls.Add(this.label5);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionVille);
            this.gbInscriptionIdentite.Controls.Add(this.label4);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionCP);
            this.gbInscriptionIdentite.Controls.Add(this.label3);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionAdresse2);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionAdresse1);
            this.gbInscriptionIdentite.Controls.Add(this.label2);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionPrenom);
            this.gbInscriptionIdentite.Controls.Add(this.label1);
            this.gbInscriptionIdentite.Controls.Add(this.tbInscriptionNom);
            this.gbInscriptionIdentite.Controls.Add(this.laInscriptionNom);
            resources.ApplyResources(this.gbInscriptionIdentite, "gbInscriptionIdentite");
            this.gbInscriptionIdentite.Name = "gbInscriptionIdentite";
            this.gbInscriptionIdentite.TabStop = false;
            // 
            // tbInscriptionEmail
            // 
            resources.ApplyResources(this.tbInscriptionEmail, "tbInscriptionEmail");
            this.tbInscriptionEmail.Name = "tbInscriptionEmail";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tbInscriptionTelephone
            // 
            resources.ApplyResources(this.tbInscriptionTelephone, "tbInscriptionTelephone");
            this.tbInscriptionTelephone.Name = "tbInscriptionTelephone";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tbInscriptionVille
            // 
            resources.ApplyResources(this.tbInscriptionVille, "tbInscriptionVille");
            this.tbInscriptionVille.Name = "tbInscriptionVille";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tbInscriptionCP
            // 
            resources.ApplyResources(this.tbInscriptionCP, "tbInscriptionCP");
            this.tbInscriptionCP.Name = "tbInscriptionCP";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbInscriptionPrenom
            // 
            resources.ApplyResources(this.tbInscriptionPrenom, "tbInscriptionPrenom");
            this.tbInscriptionPrenom.Name = "tbInscriptionPrenom";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbInscriptionNom
            // 
            resources.ApplyResources(this.tbInscriptionNom, "tbInscriptionNom");
            this.tbInscriptionNom.Name = "tbInscriptionNom";
            // 
            // laInscriptionNom
            // 
            resources.ApplyResources(this.laInscriptionNom, "laInscriptionNom");
            this.laInscriptionNom.Name = "laInscriptionNom";
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
            // gbInscriptionTypeParticipant
            // 
            this.gbInscriptionTypeParticipant.Controls.Add(this.flpInscriptionTypeParticipant);
            resources.ApplyResources(this.gbInscriptionTypeParticipant, "gbInscriptionTypeParticipant");
            this.gbInscriptionTypeParticipant.Name = "gbInscriptionTypeParticipant";
            this.gbInscriptionTypeParticipant.TabStop = false;
            // 
            // flpInscriptionTypeParticipant
            // 
            this.flpInscriptionTypeParticipant.Controls.Add(this.rbInscriptionIntervenant);
            this.flpInscriptionTypeParticipant.Controls.Add(this.rbInscriptionLicencie);
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
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.pInscritpionComplement.ResumeLayout(false);
            this.gbInscriptionIntervenant.ResumeLayout(false);
            this.gbInscriptionIntervenant.PerformLayout();
            this.gbInscriptionIntervenantNuites.ResumeLayout(false);
            this.gbInscriptionIntervenantNuites.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.gbInscriptionBenevole.ResumeLayout(false);
            this.gbInscriptionBenevole.PerformLayout();
            this.gbInscriptionIdentite.ResumeLayout(false);
            this.gbInscriptionIdentite.PerformLayout();
            this.pHautDroit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAffiche)).EndInit();
            this.gbInscriptionTypeParticipant.ResumeLayout(false);
            this.flpInscriptionTypeParticipant.ResumeLayout(false);
            this.flpInscriptionTypeParticipant.PerformLayout();
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
        private System.Windows.Forms.Label laInscriptionNom;
        private System.Windows.Forms.TextBox tbInscriptionNom;
        private System.Windows.Forms.Button btInscritpionEnregistrer;
        private System.Windows.Forms.TextBox tbInscriptionPrenom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInscriptionEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbInscriptionTelephone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbInscriptionVille;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbInscriptionCP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInscriptionAdresse2;
        private System.Windows.Forms.TextBox tbInscriptionAdresse1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbInscriptionIntervenantAtelier;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox gbInscriptionIntervenantNuites;
        private System.Windows.Forms.CheckBox chbInscriptionIntervenantNuites;
        private System.Windows.Forms.Panel pInscritpionComplement;
        private System.Windows.Forms.GroupBox gbInscriptionBenevole;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel pInscriptionIntervenantNuites;
        private System.Windows.Forms.Label laDate;
    }
}

