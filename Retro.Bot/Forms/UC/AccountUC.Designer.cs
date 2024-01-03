namespace Retro.Bot.Forms.UC
{
    partial class AccountUC
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountUC));
            this.btn_disconect = new DarkUI.Controls.DarkButton();
            this.btn_start = new DarkUI.Controls.DarkButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_script = new DarkUI.Controls.DarkButton();
            this.btn_stop = new DarkUI.Controls.DarkButton();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.label_status = new DarkUI.Controls.DarkLabel();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.label_path = new DarkUI.Controls.DarkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.progress_level = new Retro.Bot.Forms.UC.CustomProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_disconect
            // 
            this.btn_disconect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_disconect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_disconect.Location = new System.Drawing.Point(785, 3);
            this.btn_disconect.Name = "btn_disconect";
            this.btn_disconect.Padding = new System.Windows.Forms.Padding(5);
            this.btn_disconect.Size = new System.Drawing.Size(116, 23);
            this.btn_disconect.TabIndex = 0;
            this.btn_disconect.Text = "Déconnexion";
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.ImageKey = "icons8-jouer-64.png";
            this.btn_start.ImageList = this.imageList1;
            this.btn_start.Location = new System.Drawing.Point(731, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Padding = new System.Windows.Forms.Padding(5);
            this.btn_start.Size = new System.Drawing.Size(23, 23);
            this.btn_start.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-jouer-64.png");
            this.imageList1.Images.SetKeyName(1, "icons8-faire-défiler-94.png");
            this.imageList1.Images.SetKeyName(2, "icons8-trophée-64.png");
            this.imageList1.Images.SetKeyName(3, "icons8-position-96.png");
            this.imageList1.Images.SetKeyName(4, "piece-de-monnaie.png");
            this.imageList1.Images.SetKeyName(5, "collecte-de-pieces.png");
            this.imageList1.Images.SetKeyName(6, "balance-balance.png");
            this.imageList1.Images.SetKeyName(7, "balance.png");
            this.imageList1.Images.SetKeyName(8, "eclair.png");
            this.imageList1.Images.SetKeyName(9, "coeur.png");
            this.imageList1.Images.SetKeyName(10, "icons8-arrêter-90.png");
            this.imageList1.Images.SetKeyName(11, "icons8-arrêter-30.png");
            // 
            // btn_script
            // 
            this.btn_script.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_script.ImageKey = "icons8-faire-défiler-94.png";
            this.btn_script.ImageList = this.imageList1;
            this.btn_script.Location = new System.Drawing.Point(706, 3);
            this.btn_script.Name = "btn_script";
            this.btn_script.Padding = new System.Windows.Forms.Padding(5);
            this.btn_script.Size = new System.Drawing.Size(23, 23);
            this.btn_script.TabIndex = 3;
            // 
            // btn_stop
            // 
            this.btn_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_stop.ImageKey = "icons8-arrêter-90.png";
            this.btn_stop.ImageList = this.imageList1;
            this.btn_stop.Location = new System.Drawing.Point(756, 3);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Padding = new System.Windows.Forms.Padding(5);
            this.btn_stop.Size = new System.Drawing.Size(23, 23);
            this.btn_stop.TabIndex = 1;
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(4, 5);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(54, 16);
            this.darkLabel1.TabIndex = 4;
            this.darkLabel1.Text = "Status :";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_status.Location = new System.Drawing.Point(63, 5);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(46, 16);
            this.label_status.TabIndex = 5;
            this.label_status.Text = "Inactif";
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(166, 5);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(51, 16);
            this.darkLabel3.TabIndex = 6;
            this.darkLabel3.Text = "Trajet :";
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label_path.Location = new System.Drawing.Point(223, 5);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(116, 16);
            this.label_path.TabIndex = 7;
            this.label_path.Text = "[Amakna] - Frene";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Retro.Bot.Properties.Resources.icons8_trophée_64;
            this.pictureBox1.Location = new System.Drawing.Point(7, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(63, 42);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(59, 16);
            this.darkLabel2.TabIndex = 9;
            this.darkLabel2.Text = "Niveau :";
            // 
            // progress_level
            // 
            this.progress_level.CustomText = "36";
            this.progress_level.DisplayStyle = Retro.Bot.Forms.UC.ProgressBarDisplayText.CustomText;
            this.progress_level.Location = new System.Drawing.Point(128, 39);
            this.progress_level.Maximum = 200;
            this.progress_level.Name = "progress_level";
            this.progress_level.Size = new System.Drawing.Size(107, 23);
            this.progress_level.TabIndex = 10;
            this.progress_level.Value = 36;
            // 
            // AccountUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.progress_level);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.btn_script);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_disconect);
            this.Name = "AccountUC";
            this.Size = new System.Drawing.Size(904, 569);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkButton btn_disconect;
        private DarkUI.Controls.DarkButton btn_stop;
        private DarkUI.Controls.DarkButton btn_start;
        private DarkUI.Controls.DarkButton btn_script;
        private System.Windows.Forms.ImageList imageList1;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel label_status;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkLabel label_path;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private CustomProgressBar progress_level;
    }
}
