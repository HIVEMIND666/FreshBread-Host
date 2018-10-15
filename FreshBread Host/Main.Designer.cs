namespace FreshBread_Host
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clients = new System.Windows.Forms.DataGridView();
            this.builderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clients)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.builderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clients
            // 
            this.clients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clients.BackgroundColor = System.Drawing.Color.White;
            this.clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.clients.Location = new System.Drawing.Point(0, 28);
            this.clients.MultiSelect = false;
            this.clients.Name = "clients";
            this.clients.RowHeadersVisible = false;
            this.clients.RowTemplate.Height = 24;
            this.clients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clients.Size = new System.Drawing.Size(943, 521);
            this.clients.TabIndex = 2;
            this.clients.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clients_MouseClick);
            // 
            // builderToolStripMenuItem
            // 
            this.builderToolStripMenuItem.Name = "builderToolStripMenuItem";
            this.builderToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.builderToolStripMenuItem.Text = "Builder";
            this.builderToolStripMenuItem.Click += new System.EventHandler(this.builderToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 549);
            this.Controls.Add(this.clients);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.DataGridView clients;
        private System.Windows.Forms.ToolStripMenuItem builderToolStripMenuItem;
    }
}