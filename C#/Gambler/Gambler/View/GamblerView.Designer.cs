namespace Gambler.View
{
    partial class GamblerView
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
            this.mnStrp = new System.Windows.Forms.MenuStrip();
            this.bookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tblLytPnl = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxGmblrFnds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxGmblrID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.datagrdvwBets = new System.Windows.Forms.DataGridView();
            this.mnStrp.SuspendLayout();
            this.tblLytPnl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdvwBets)).BeginInit();
            this.SuspendLayout();
            // 
            // mnStrp
            // 
            this.mnStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookieToolStripMenuItem,
            this.walletToolStripMenuItem});
            this.mnStrp.Location = new System.Drawing.Point(0, 0);
            this.mnStrp.Name = "mnStrp";
            this.mnStrp.Size = new System.Drawing.Size(402, 24);
            this.mnStrp.TabIndex = 0;
            this.mnStrp.Text = "menuStrip1";
            // 
            // bookieToolStripMenuItem
            // 
            this.bookieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.bookieToolStripMenuItem.Name = "bookieToolStripMenuItem";
            this.bookieToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.bookieToolStripMenuItem.Text = "Bookie";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.connectToolStripMenuItem.Text = "Connect...";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect...";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // walletToolStripMenuItem
            // 
            this.walletToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillToolStripMenuItem});
            this.walletToolStripMenuItem.Name = "walletToolStripMenuItem";
            this.walletToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.walletToolStripMenuItem.Text = "Wallet";
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.fillToolStripMenuItem.Text = "Fill...";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.fillToolStripMenuItem_Click);
            // 
            // tblLytPnl
            // 
            this.tblLytPnl.ColumnCount = 1;
            this.tblLytPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLytPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLytPnl.Controls.Add(this.groupBox1, 0, 0);
            this.tblLytPnl.Controls.Add(this.datagrdvwBets, 0, 1);
            this.tblLytPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLytPnl.Location = new System.Drawing.Point(0, 24);
            this.tblLytPnl.Name = "tblLytPnl";
            this.tblLytPnl.RowCount = 2;
            this.tblLytPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.78873F));
            this.tblLytPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.21127F));
            this.tblLytPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLytPnl.Size = new System.Drawing.Size(402, 355);
            this.tblLytPnl.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbxGmblrFnds);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbxGmblrID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gambler details";
            // 
            // txtbxGmblrFnds
            // 
            this.txtbxGmblrFnds.Enabled = false;
            this.txtbxGmblrFnds.Location = new System.Drawing.Point(96, 43);
            this.txtbxGmblrFnds.Name = "txtbxGmblrFnds";
            this.txtbxGmblrFnds.Size = new System.Drawing.Size(294, 20);
            this.txtbxGmblrFnds.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gambler ID";
            // 
            // txtbxGmblrID
            // 
            this.txtbxGmblrID.Enabled = false;
            this.txtbxGmblrID.Location = new System.Drawing.Point(96, 13);
            this.txtbxGmblrID.Name = "txtbxGmblrID";
            this.txtbxGmblrID.Size = new System.Drawing.Size(294, 20);
            this.txtbxGmblrID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Funds available";
            // 
            // datagrdvwBets
            // 
            this.datagrdvwBets.AllowUserToAddRows = false;
            this.datagrdvwBets.AllowUserToDeleteRows = false;
            this.datagrdvwBets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrdvwBets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrdvwBets.Location = new System.Drawing.Point(3, 91);
            this.datagrdvwBets.Name = "datagrdvwBets";
            this.datagrdvwBets.ReadOnly = true;
            this.datagrdvwBets.Size = new System.Drawing.Size(396, 261);
            this.datagrdvwBets.TabIndex = 1;
            // 
            // GamblerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 379);
            this.Controls.Add(this.tblLytPnl);
            this.Controls.Add(this.mnStrp);
            this.MainMenuStrip = this.mnStrp;
            this.Name = "GamblerView";
            this.Text = "Gambler";
            this.Shown += new System.EventHandler(this.GamblerView_Shown);
            this.mnStrp.ResumeLayout(false);
            this.mnStrp.PerformLayout();
            this.tblLytPnl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrdvwBets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnStrp;
        private System.Windows.Forms.ToolStripMenuItem bookieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tblLytPnl;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxGmblrID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxGmblrFnds;
        private System.Windows.Forms.DataGridView datagrdvwBets;
    }
}

