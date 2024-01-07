namespace Retro.Bot.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_add_account = new DarkUI.Controls.DarkButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel_bot = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_account = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_add_account
            // 
            this.btn_add_account.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_add_account.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_account.ImageKey = "robot.png";
            this.btn_add_account.ImageList = this.imageList1;
            this.btn_add_account.ImagePadding = 0;
            this.btn_add_account.Location = new System.Drawing.Point(12, 630);
            this.btn_add_account.Name = "btn_add_account";
            this.btn_add_account.Padding = new System.Windows.Forms.Padding(5);
            this.btn_add_account.Size = new System.Drawing.Size(192, 41);
            this.btn_add_account.TabIndex = 1;
            this.btn_add_account.Text = "Ajouter un nouveau client";
            this.btn_add_account.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_add_account.Click += new System.EventHandler(this.btn_add_account_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "robot.png");
            // 
            // panel_bot
            // 
            this.panel_bot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_bot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_bot.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel_bot.Location = new System.Drawing.Point(12, 12);
            this.panel_bot.Name = "panel_bot";
            this.panel_bot.Size = new System.Drawing.Size(192, 612);
            this.panel_bot.TabIndex = 3;
            // 
            // panel_account
            // 
            this.panel_account.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_account.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_account.Location = new System.Drawing.Point(210, 12);
            this.panel_account.Name = "panel_account";
            this.panel_account.Size = new System.Drawing.Size(1117, 659);
            this.panel_account.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 683);
            this.Controls.Add(this.panel_account);
            this.Controls.Add(this.panel_bot);
            this.Controls.Add(this.btn_add_account);
            this.Name = "MainForm";
            this.Text = "RetroBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkButton btn_add_account;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.FlowLayoutPanel panel_bot;
        public System.Windows.Forms.Panel panel_account;
    }
}