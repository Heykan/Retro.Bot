namespace Retro.Bot.Forms
{
    partial class ProcessSelectorForm
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
            this.imagelist_process = new System.Windows.Forms.ImageList(this.components);
            this.btn_select = new DarkUI.Controls.DarkButton();
            this.listview_process = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // imagelist_process
            // 
            this.imagelist_process.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagelist_process.ImageSize = new System.Drawing.Size(32, 32);
            this.imagelist_process.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(0, 415);
            this.btn_select.Name = "btn_select";
            this.btn_select.Padding = new System.Windows.Forms.Padding(5);
            this.btn_select.Size = new System.Drawing.Size(558, 23);
            this.btn_select.TabIndex = 1;
            this.btn_select.Text = "Selectionner le processus";
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // listview_process
            // 
            this.listview_process.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.listview_process.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_process.Dock = System.Windows.Forms.DockStyle.Top;
            this.listview_process.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.listview_process.HideSelection = false;
            this.listview_process.LargeImageList = this.imagelist_process;
            this.listview_process.Location = new System.Drawing.Point(0, 0);
            this.listview_process.Name = "listview_process";
            this.listview_process.Size = new System.Drawing.Size(558, 409);
            this.listview_process.TabIndex = 2;
            this.listview_process.UseCompatibleStateImageBehavior = false;
            this.listview_process.SelectedIndexChanged += new System.EventHandler(this.listview_process_SelectedIndexChanged);
            // 
            // ProcessSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 450);
            this.Controls.Add(this.listview_process);
            this.Controls.Add(this.btn_select);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProcessSelectorForm";
            this.Text = "RetroBot - Selectionner une instance de dofus";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imagelist_process;
        private DarkUI.Controls.DarkButton btn_select;
        private System.Windows.Forms.ListView listview_process;
    }
}