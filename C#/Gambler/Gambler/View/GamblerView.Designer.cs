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
            this.walletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tblLytPnl = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxGmblrFnds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxGmblrID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgrdvwBets = new System.Windows.Forms.DataGridView();
            this.gtgrdvwBookies = new System.Windows.Forms.DataGridView();
            this.BookieID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetBookieID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamAOdds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamBOdds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Limit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetPlaced = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PlaceBet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlstrpPrgssBr = new System.Windows.Forms.ToolStripProgressBar();
            this.tlstrpStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnStrp.SuspendLayout();
            this.tblLytPnl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gtgrdvwBookies)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnStrp
            // 
            this.mnStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookieToolStripMenuItem,
            this.walletToolStripMenuItem});
            this.mnStrp.Location = new System.Drawing.Point(0, 0);
            this.mnStrp.Name = "mnStrp";
            this.mnStrp.Size = new System.Drawing.Size(976, 24);
            this.mnStrp.TabIndex = 0;
            this.mnStrp.Text = "menuStrip1";
            // 
            // bookieToolStripMenuItem
            // 
            this.bookieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
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
            this.tblLytPnl.Controls.Add(this.statusStrip1, 0, 3);
            this.tblLytPnl.Controls.Add(this.groupBox1, 0, 0);
            this.tblLytPnl.Controls.Add(this.groupBox2, 0, 1);
            this.tblLytPnl.Controls.Add(this.groupBox3, 0, 2);
            this.tblLytPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLytPnl.Location = new System.Drawing.Point(0, 24);
            this.tblLytPnl.Name = "tblLytPnl";
            this.tblLytPnl.RowCount = 4;
            this.tblLytPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.81818F));
            this.tblLytPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.18182F));
            this.tblLytPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tblLytPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLytPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLytPnl.Size = new System.Drawing.Size(976, 494);
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
            this.groupBox1.Size = new System.Drawing.Size(970, 71);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gtgrdvwBookies);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(970, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connected Bookies";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgrdvwBets);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(970, 209);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Open bets";
            // 
            // dtgrdvwBets
            // 
            this.dtgrdvwBets.AllowUserToAddRows = false;
            this.dtgrdvwBets.AllowUserToDeleteRows = false;
            this.dtgrdvwBets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdvwBets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BetBookieID,
            this.BetID,
            this.TeamAID,
            this.TeamAOdds,
            this.TeamBID,
            this.TeamBOdds,
            this.Limit,
            this.BetPlaced,
            this.PlaceBet});
            this.dtgrdvwBets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdvwBets.Location = new System.Drawing.Point(3, 16);
            this.dtgrdvwBets.Name = "dtgrdvwBets";
            this.dtgrdvwBets.ReadOnly = true;
            this.dtgrdvwBets.Size = new System.Drawing.Size(964, 190);
            this.dtgrdvwBets.TabIndex = 3;
            // 
            // gtgrdvwBookies
            // 
            this.gtgrdvwBookies.AllowUserToAddRows = false;
            this.gtgrdvwBookies.AllowUserToDeleteRows = false;
            this.gtgrdvwBookies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gtgrdvwBookies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookieID,
            this.IPAddress,
            this.Port});
            this.gtgrdvwBookies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtgrdvwBookies.Location = new System.Drawing.Point(3, 16);
            this.gtgrdvwBookies.Name = "gtgrdvwBookies";
            this.gtgrdvwBookies.ReadOnly = true;
            this.gtgrdvwBookies.Size = new System.Drawing.Size(964, 156);
            this.gtgrdvwBookies.TabIndex = 0;
            // 
            // BookieID
            // 
            this.BookieID.HeaderText = "Bookie ID";
            this.BookieID.Name = "BookieID";
            this.BookieID.ReadOnly = true;
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IP Address";
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            // 
            // Port
            // 
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            // 
            // BetBookieID
            // 
            this.BetBookieID.HeaderText = "Bookie ID";
            this.BetBookieID.Name = "BetBookieID";
            this.BetBookieID.ReadOnly = true;
            // 
            // BetID
            // 
            this.BetID.HeaderText = "Bet ID";
            this.BetID.Name = "BetID";
            this.BetID.ReadOnly = true;
            // 
            // TeamAID
            // 
            this.TeamAID.HeaderText = "Team A";
            this.TeamAID.Name = "TeamAID";
            this.TeamAID.ReadOnly = true;
            // 
            // TeamAOdds
            // 
            this.TeamAOdds.HeaderText = "Team A Odds";
            this.TeamAOdds.Name = "TeamAOdds";
            this.TeamAOdds.ReadOnly = true;
            // 
            // TeamBID
            // 
            this.TeamBID.HeaderText = "Team B";
            this.TeamBID.Name = "TeamBID";
            this.TeamBID.ReadOnly = true;
            // 
            // TeamBOdds
            // 
            this.TeamBOdds.HeaderText = "Team B Odds";
            this.TeamBOdds.Name = "TeamBOdds";
            this.TeamBOdds.ReadOnly = true;
            // 
            // Limit
            // 
            this.Limit.HeaderText = "Limit";
            this.Limit.Name = "Limit";
            this.Limit.ReadOnly = true;
            // 
            // BetPlaced
            // 
            this.BetPlaced.HeaderText = "Bet Placed?";
            this.BetPlaced.Name = "BetPlaced";
            this.BetPlaced.ReadOnly = true;
            // 
            // PlaceBet
            // 
            this.PlaceBet.HeaderText = "Place Bet";
            this.PlaceBet.Name = "PlaceBet";
            this.PlaceBet.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpPrgssBr,
            this.tlstrpStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(976, 21);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlstrpPrgssBr
            // 
            this.tlstrpPrgssBr.Name = "tlstrpPrgssBr";
            this.tlstrpPrgssBr.Size = new System.Drawing.Size(100, 15);
            // 
            // tlstrpStatusLabel
            // 
            this.tlstrpStatusLabel.Name = "tlstrpStatusLabel";
            this.tlstrpStatusLabel.Size = new System.Drawing.Size(74, 16);
            this.tlstrpStatusLabel.Text = "Status: None";
            // 
            // GamblerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 518);
            this.Controls.Add(this.tblLytPnl);
            this.Controls.Add(this.mnStrp);
            this.MainMenuStrip = this.mnStrp;
            this.Name = "GamblerView";
            this.Text = "Gambler";
            this.Shown += new System.EventHandler(this.GamblerView_Shown);
            this.mnStrp.ResumeLayout(false);
            this.mnStrp.PerformLayout();
            this.tblLytPnl.ResumeLayout(false);
            this.tblLytPnl.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gtgrdvwBookies)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnStrp;
        private System.Windows.Forms.ToolStripMenuItem bookieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tblLytPnl;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxGmblrID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxGmblrFnds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgrdvwBets;
        private System.Windows.Forms.DataGridView gtgrdvwBookies;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookieID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetBookieID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamAOdds;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamBOdds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Limit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BetPlaced;
        private System.Windows.Forms.DataGridViewButtonColumn PlaceBet;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tlstrpPrgssBr;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpStatusLabel;
    }
}

