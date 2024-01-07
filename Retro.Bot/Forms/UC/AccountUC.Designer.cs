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
            this.label_area = new DarkUI.Controls.DarkLabel();
            this.imageList_tab = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.label_kamas = new DarkUI.Controls.DarkLabel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label_position = new DarkUI.Controls.DarkLabel();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.progress_pods = new Retro.Bot.Forms.UC.CustomProgressBar();
            this.progress_energy = new Retro.Bot.Forms.UC.CustomProgressBar();
            this.progress_life = new Retro.Bot.Forms.UC.CustomProgressBar();
            this.tabControl_data = new Retro.Bot.Forms.UC.DotNetBarTabControl();
            this.tab_console = new System.Windows.Forms.TabPage();
            this.btn_send = new DarkUI.Controls.DarkButton();
            this.textbox_chat = new DarkUI.Controls.DarkTextBox();
            this.combobox_chat = new DarkUI.Controls.DarkComboBox();
            this.rtb_chat = new System.Windows.Forms.RichTextBox();
            this.tab_fight = new System.Windows.Forms.TabPage();
            this.tab_map = new System.Windows.Forms.TabPage();
            this.tab_setting = new System.Windows.Forms.TabPage();
            this.progress_level = new Retro.Bot.Forms.UC.CustomProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.tabControl_data.SuspendLayout();
            this.tab_console.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_disconect
            // 
            this.btn_disconect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_disconect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_disconect.Location = new System.Drawing.Point(995, 3);
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
            this.btn_start.Location = new System.Drawing.Point(941, 3);
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
            this.btn_script.Location = new System.Drawing.Point(916, 3);
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
            this.btn_stop.Location = new System.Drawing.Point(966, 3);
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
            this.label_status.Location = new System.Drawing.Point(60, 5);
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
            this.label_path.Location = new System.Drawing.Point(220, 5);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(11, 16);
            this.label_path.TabIndex = 7;
            this.label_path.Text = "-";
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
            // label_area
            // 
            this.label_area.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_area.AutoSize = true;
            this.label_area.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_area.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label_area.Location = new System.Drawing.Point(818, 42);
            this.label_area.Name = "label_area";
            this.label_area.Size = new System.Drawing.Size(121, 16);
            this.label_area.TabIndex = 11;
            this.label_area.Text = "Unknow - Unknow";
            this.label_area.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList_tab
            // 
            this.imageList_tab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_tab.ImageStream")));
            this.imageList_tab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_tab.Images.SetKeyName(0, "icons8-épée-96.png");
            this.imageList_tab.Images.SetKeyName(1, "icons8-paramètres-96.png");
            this.imageList_tab.Images.SetKeyName(2, "icons8-marqueur-de-plan-96.png");
            this.imageList_tab.Images.SetKeyName(3, "icons8-terminal-96.png");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::Retro.Bot.Properties.Resources.coeur;
            this.pictureBox2.Location = new System.Drawing.Point(7, 539);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // darkLabel4
            // 
            this.darkLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(36, 543);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(36, 16);
            this.darkLabel4.TabIndex = 14;
            this.darkLabel4.Text = "Vie :";
            // 
            // darkLabel5
            // 
            this.darkLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(300, 543);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(64, 16);
            this.darkLabel5.TabIndex = 17;
            this.darkLabel5.Text = "Energie :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = global::Retro.Bot.Properties.Resources.eclair;
            this.pictureBox3.Location = new System.Drawing.Point(271, 539);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // darkLabel6
            // 
            this.darkLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(592, 543);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(46, 16);
            this.darkLabel6.TabIndex = 20;
            this.darkLabel6.Text = "Pods :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox4.Image = global::Retro.Bot.Properties.Resources.balance_balance;
            this.pictureBox4.Location = new System.Drawing.Point(563, 539);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 23);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.Image = global::Retro.Bot.Properties.Resources.collecte_de_pieces;
            this.pictureBox5.Location = new System.Drawing.Point(837, 539);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(23, 23);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // darkLabel7
            // 
            this.darkLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.darkLabel7.AutoSize = true;
            this.darkLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(866, 543);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(58, 16);
            this.darkLabel7.TabIndex = 23;
            this.darkLabel7.Text = "Kamas :";
            // 
            // label_kamas
            // 
            this.label_kamas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_kamas.AutoSize = true;
            this.label_kamas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_kamas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_kamas.Location = new System.Drawing.Point(927, 543);
            this.label_kamas.Name = "label_kamas";
            this.label_kamas.Size = new System.Drawing.Size(14, 16);
            this.label_kamas.TabIndex = 24;
            this.label_kamas.Text = "0";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.Image = global::Retro.Bot.Properties.Resources.icons8_position_96;
            this.pictureBox6.Location = new System.Drawing.Point(990, 539);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(23, 23);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 25;
            this.pictureBox6.TabStop = false;
            // 
            // label_position
            // 
            this.label_position.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_position.AutoSize = true;
            this.label_position.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_position.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_position.Location = new System.Drawing.Point(1060, 543);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(33, 16);
            this.label_position.TabIndex = 27;
            this.label_position.Text = "[0:0]";
            // 
            // darkLabel9
            // 
            this.darkLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.darkLabel9.AutoSize = true;
            this.darkLabel9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(1019, 543);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(38, 16);
            this.darkLabel9.TabIndex = 26;
            this.darkLabel9.Text = "Pos :";
            // 
            // progress_pods
            // 
            this.progress_pods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progress_pods.CustomText = "";
            this.progress_pods.DisplayStyle = Retro.Bot.Forms.UC.ProgressBarDisplayText.CustomText;
            this.progress_pods.Location = new System.Drawing.Point(644, 539);
            this.progress_pods.Maximum = 100;
            this.progress_pods.Minimum = 0;
            this.progress_pods.Name = "progress_pods";
            this.progress_pods.Size = new System.Drawing.Size(182, 23);
            this.progress_pods.TabIndex = 21;
            this.progress_pods.Value = 0;
            // 
            // progress_energy
            // 
            this.progress_energy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progress_energy.CustomText = "";
            this.progress_energy.DisplayStyle = Retro.Bot.Forms.UC.ProgressBarDisplayText.CustomText;
            this.progress_energy.Location = new System.Drawing.Point(370, 539);
            this.progress_energy.Maximum = 100;
            this.progress_energy.Minimum = 0;
            this.progress_energy.Name = "progress_energy";
            this.progress_energy.Size = new System.Drawing.Size(182, 23);
            this.progress_energy.TabIndex = 18;
            this.progress_energy.Value = 0;
            // 
            // progress_life
            // 
            this.progress_life.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progress_life.CustomText = "";
            this.progress_life.DisplayStyle = Retro.Bot.Forms.UC.ProgressBarDisplayText.CustomText;
            this.progress_life.Location = new System.Drawing.Point(78, 539);
            this.progress_life.Maximum = 100;
            this.progress_life.Minimum = 0;
            this.progress_life.Name = "progress_life";
            this.progress_life.Size = new System.Drawing.Size(182, 23);
            this.progress_life.TabIndex = 15;
            this.progress_life.Value = 0;
            // 
            // tabControl_data
            // 
            this.tabControl_data.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_data.Controls.Add(this.tab_console);
            this.tabControl_data.Controls.Add(this.tab_fight);
            this.tabControl_data.Controls.Add(this.tab_map);
            this.tabControl_data.Controls.Add(this.tab_setting);
            this.tabControl_data.ImageList = this.imageList_tab;
            this.tabControl_data.ItemSize = new System.Drawing.Size(48, 36);
            this.tabControl_data.Location = new System.Drawing.Point(7, 80);
            this.tabControl_data.Multiline = true;
            this.tabControl_data.Name = "tabControl_data";
            this.tabControl_data.SelectedIndex = 0;
            this.tabControl_data.Size = new System.Drawing.Size(1104, 448);
            this.tabControl_data.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_data.TabIndex = 12;
            // 
            // tab_console
            // 
            this.tab_console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tab_console.Controls.Add(this.btn_send);
            this.tab_console.Controls.Add(this.textbox_chat);
            this.tab_console.Controls.Add(this.combobox_chat);
            this.tab_console.Controls.Add(this.rtb_chat);
            this.tab_console.ImageIndex = 3;
            this.tab_console.Location = new System.Drawing.Point(40, 4);
            this.tab_console.Name = "tab_console";
            this.tab_console.Padding = new System.Windows.Forms.Padding(3);
            this.tab_console.Size = new System.Drawing.Size(1060, 440);
            this.tab_console.TabIndex = 2;
            this.tab_console.Text = "tab_console";
            // 
            // btn_send
            // 
            this.btn_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(883, 412);
            this.btn_send.Name = "btn_send";
            this.btn_send.Padding = new System.Windows.Forms.Padding(5);
            this.btn_send.Size = new System.Drawing.Size(171, 23);
            this.btn_send.TabIndex = 28;
            this.btn_send.Text = "Envoyer";
            // 
            // textbox_chat
            // 
            this.textbox_chat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textbox_chat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_chat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_chat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textbox_chat.Location = new System.Drawing.Point(158, 414);
            this.textbox_chat.Name = "textbox_chat";
            this.textbox_chat.Size = new System.Drawing.Size(719, 20);
            this.textbox_chat.TabIndex = 2;
            // 
            // combobox_chat
            // 
            this.combobox_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.combobox_chat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.combobox_chat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_chat.FormattingEnabled = true;
            this.combobox_chat.Items.AddRange(new object[] {
            "Général",
            "Equipe",
            "Groupe",
            "Guilde",
            "Recrutement",
            "Commerce"});
            this.combobox_chat.Location = new System.Drawing.Point(6, 413);
            this.combobox_chat.Name = "combobox_chat";
            this.combobox_chat.Size = new System.Drawing.Size(146, 21);
            this.combobox_chat.TabIndex = 1;
            // 
            // rtb_chat
            // 
            this.rtb_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.rtb_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_chat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_chat.Location = new System.Drawing.Point(6, 3);
            this.rtb_chat.Name = "rtb_chat";
            this.rtb_chat.Size = new System.Drawing.Size(1048, 403);
            this.rtb_chat.TabIndex = 0;
            this.rtb_chat.Text = "";
            this.rtb_chat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_chat_KeyDown);
            // 
            // tab_fight
            // 
            this.tab_fight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tab_fight.ImageIndex = 0;
            this.tab_fight.Location = new System.Drawing.Point(40, 4);
            this.tab_fight.Name = "tab_fight";
            this.tab_fight.Padding = new System.Windows.Forms.Padding(3);
            this.tab_fight.Size = new System.Drawing.Size(1060, 440);
            this.tab_fight.TabIndex = 3;
            this.tab_fight.Text = "tab_fight";
            // 
            // tab_map
            // 
            this.tab_map.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tab_map.ImageIndex = 2;
            this.tab_map.Location = new System.Drawing.Point(40, 4);
            this.tab_map.Name = "tab_map";
            this.tab_map.Padding = new System.Windows.Forms.Padding(3);
            this.tab_map.Size = new System.Drawing.Size(1060, 440);
            this.tab_map.TabIndex = 4;
            this.tab_map.Text = "tab_map";
            // 
            // tab_setting
            // 
            this.tab_setting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tab_setting.ImageIndex = 1;
            this.tab_setting.Location = new System.Drawing.Point(40, 4);
            this.tab_setting.Name = "tab_setting";
            this.tab_setting.Padding = new System.Windows.Forms.Padding(3);
            this.tab_setting.Size = new System.Drawing.Size(1060, 440);
            this.tab_setting.TabIndex = 5;
            this.tab_setting.Text = "tab_settings";
            // 
            // progress_level
            // 
            this.progress_level.CustomText = "";
            this.progress_level.DisplayStyle = Retro.Bot.Forms.UC.ProgressBarDisplayText.CustomText;
            this.progress_level.Location = new System.Drawing.Point(128, 40);
            this.progress_level.Maximum = 100;
            this.progress_level.Minimum = 0;
            this.progress_level.Name = "progress_level";
            this.progress_level.Size = new System.Drawing.Size(107, 23);
            this.progress_level.TabIndex = 10;
            this.progress_level.Value = 0;
            // 
            // AccountUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.label_position);
            this.Controls.Add(this.darkLabel9);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label_kamas);
            this.Controls.Add(this.darkLabel7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.progress_pods);
            this.Controls.Add(this.darkLabel6);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.progress_energy);
            this.Controls.Add(this.darkLabel5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.progress_life);
            this.Controls.Add(this.darkLabel4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tabControl_data);
            this.Controls.Add(this.label_area);
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
            this.Size = new System.Drawing.Size(1117, 569);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.tabControl_data.ResumeLayout(false);
            this.tab_console.ResumeLayout(false);
            this.tab_console.PerformLayout();
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
        private DarkUI.Controls.DarkLabel label_area;
        private DotNetBarTabControl tabControl_data;
        private System.Windows.Forms.ImageList imageList_tab;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private CustomProgressBar progress_life;
        private CustomProgressBar progress_energy;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private CustomProgressBar progress_pods;
        private DarkUI.Controls.DarkLabel darkLabel6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private DarkUI.Controls.DarkLabel label_kamas;
        private System.Windows.Forms.PictureBox pictureBox6;
        private DarkUI.Controls.DarkLabel label_position;
        private DarkUI.Controls.DarkLabel darkLabel9;
        private System.Windows.Forms.TabPage tab_console;
        private System.Windows.Forms.TabPage tab_fight;
        private System.Windows.Forms.TabPage tab_map;
        private System.Windows.Forms.TabPage tab_setting;
        private DarkUI.Controls.DarkComboBox combobox_chat;
        private DarkUI.Controls.DarkButton btn_send;
        private DarkUI.Controls.DarkTextBox textbox_chat;
        public System.Windows.Forms.RichTextBox rtb_chat;
    }
}
