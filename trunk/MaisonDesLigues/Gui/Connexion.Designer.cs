namespace MaisonDesLigues.Gui
{
    partial class Connexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connexion));
            this.lLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.tbMdp = new System.Windows.Forms.TextBox();
            this.lMdp = new System.Windows.Forms.Label();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.btConnecter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(47, 47);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(39, 13);
            this.lLogin.TabIndex = 1;
            this.lLogin.Text = "Login :";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(92, 44);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(141, 20);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.Text = "**factif**";
            // 
            // lTitle
            // 
            this.lTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lTitle.Location = new System.Drawing.Point(13, 15);
            this.lTitle.Name = "lTitle";
            this.lTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lTitle.Size = new System.Drawing.Size(218, 18);
            this.lTitle.TabIndex = 3;
            this.lTitle.Text = "Application Assises de l\'escrime";
            // 
            // tbMdp
            // 
            this.tbMdp.Location = new System.Drawing.Point(92, 70);
            this.tbMdp.Name = "tbMdp";
            this.tbMdp.Size = new System.Drawing.Size(141, 20);
            this.tbMdp.TabIndex = 5;
            // 
            // lMdp
            // 
            this.lMdp.AutoSize = true;
            this.lMdp.Location = new System.Drawing.Point(9, 73);
            this.lMdp.Name = "lMdp";
            this.lMdp.Size = new System.Drawing.Size(77, 13);
            this.lMdp.TabIndex = 4;
            this.lMdp.Text = "Mot de passe :";
            // 
            // btAnnuler
            // 
            this.btAnnuler.Location = new System.Drawing.Point(125, 106);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btAnnuler.TabIndex = 10;
            this.btAnnuler.Text = "Annuler";
            this.btAnnuler.UseVisualStyleBackColor = true;
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
            // 
            // btConnecter
            // 
            this.btConnecter.Location = new System.Drawing.Point(44, 106);
            this.btConnecter.Name = "btConnecter";
            this.btConnecter.Size = new System.Drawing.Size(75, 23);
            this.btConnecter.TabIndex = 9;
            this.btConnecter.Text = "Connecter";
            this.btConnecter.UseVisualStyleBackColor = true;
            this.btConnecter.Click += new System.EventHandler(this.btConnecter_Click);
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 139);
            this.Controls.Add(this.btAnnuler);
            this.Controls.Add(this.btConnecter);
            this.Controls.Add(this.tbMdp);
            this.Controls.Add(this.lMdp);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connexion";
            this.Text = "Connexion MDL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.TextBox tbMdp;
        private System.Windows.Forms.Label lMdp;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Button btConnecter;
    }
}