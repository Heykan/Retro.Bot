namespace Retro.Bot.Forms.UC
{
    partial class AccountSelectorUC
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
            this.label_name = new DarkUI.Controls.DarkLabel();
            this.label_status = new DarkUI.Controls.DarkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label_name.Location = new System.Drawing.Point(90, 9);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(46, 14);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "Yoshino";
            this.label_name.MouseEnter += new System.EventHandler(this.control_MouseEnter);
            this.label_name.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label_status.Location = new System.Drawing.Point(112, 27);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(36, 14);
            this.label_status.TabIndex = 2;
            this.label_status.Text = "Inactif";
            this.label_status.MouseEnter += new System.EventHandler(this.control_MouseEnter);
            this.label_status.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Retro.Bot.Properties.Resources.rec_1_;
            this.pictureBox2.Location = new System.Drawing.Point(90, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseEnter += new System.EventHandler(this.control_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Retro.Bot.Properties.Resources.robot;
            this.pictureBox1.Location = new System.Drawing.Point(34, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.control_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // AccountSelectorUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AccountSelectorUC";
            this.Size = new System.Drawing.Size(192, 50);
            this.MouseEnter += new System.EventHandler(this.control_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DarkUI.Controls.DarkLabel label_name;
        private DarkUI.Controls.DarkLabel label_status;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
