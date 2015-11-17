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
            this.components = new System.ComponentModel.Container();
            this.mnStrp = new System.Windows.Forms.MenuStrip();
            this.bookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tblLytPnl = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrp = new System.Windows.Forms.StatusStrip();
            this.tlstrpPrgssBr = new System.Windows.Forms.ToolStripProgressBar();
            this.tlstrpStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlstrpUpdateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttnRefresh = new System.Windows.Forms.Button();
            this.txtbxGmblrFnds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxGmblrID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgrdvwBookies = new System.Windows.Forms.DataGridView();
            this.BookieID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookieSayHello = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgrdvwBets = new System.Windows.Forms.DataGridView();
            this.tmrRefreshBets = new System.Windows.Forms.Timer(this.components);
            this.bttnPlcBet = new System.Windows.Forms.Button();
            this.mnStrp.SuspendLayout();
            this.tblLytPnl.SuspendLayout();
            this.statusStrp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwBookies)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwBets)).BeginInit();
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
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
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
            this.tblLytPnl.Controls.Add(this.statusStrp, 0, 3);
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
            // statusStrp
            // 
            this.statusStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpPrgssBr,
            this.tlstrpStatusLabel,
            this.tlstrpUpdateLabel});
            this.statusStrp.Location = new System.Drawing.Point(0, 473);
            this.statusStrp.Name = "statusStrp";
            this.statusStrp.Size = new System.Drawing.Size(976, 21);
            this.statusStrp.TabIndex = 5;
            this.statusStrp.Text = "statusStrip1";
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
            // tlstrpUpdateLabel
            // 
            this.tlstrpUpdateLabel.Name = "tlstrpUpdateLabel";
            this.tlstrpUpdateLabel.Size = new System.Drawing.Size(85, 16);
            this.tlstrpUpdateLabel.Text = "Updates: None";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bttnRefresh);
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
            // bttnRefresh
            // 
            this.bttnRefresh.Location = new System.Drawing.Point(889, 40);
            this.bttnRefresh.Name = "bttnRefresh";
            this.bttnRefresh.Size = new System.Drawing.Size(75, 23);
            this.bttnRefresh.TabIndex = 7;
            this.bttnRefresh.Text = "Refresh";
            this.bttnRefresh.UseVisualStyleBackColor = true;
            this.bttnRefresh.Click += new System.EventHandler(this.bttnRefresh_Click);
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
            this.groupBox2.Controls.Add(this.dtgrdvwBookies);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(970, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connected Bookies";
            // 
            // dtgrdvwBookies
            // 
            this.dtgrdvwBookies.AllowUserToAddRows = false;
            this.dtgrdvwBookies.AllowUserToDeleteRows = false;
            this.dtgrdvwBookies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdvwBookies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookieID,
            this.IPAddress,
            this.Port,
            this.bookieSayHello});
            this.dtgrdvwBookies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdvwBookies.Location = new System.Drawing.Point(3, 16);
            this.dtgrdvwBookies.Name = "dtgrdvwBookies";
            this.dtgrdvwBookies.ReadOnly = true;
            this.dtgrdvwBookies.Size = new System.Drawing.Size(964, 156);
            this.dtgrdvwBookies.TabIndex = 0;
            this.dtgrdvwBookies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdvwBookies_CellClick);
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
            // bookieSayHello
            // 
            this.bookieSayHello.HeaderText = "Say Hello";
            this.bookieSayHello.Name = "bookieSayHello";
            this.bookieSayHello.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bttnPlcBet);
            this.groupBox3.Controls.Add(this.dtgrdvwBets);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(970, 209);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Open Matches";
            // 
            // dtgrdvwBets
            // 
            this.dtgrdvwBets.AllowUserToAddRows = false;
            this.dtgrdvwBets.AllowUserToDeleteRows = false;
            this.dtgrdvwBets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdvwBets.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgrdvwBets.Location = new System.Drawing.Point(3, 16);
            this.dtgrdvwBets.Name = "dtgrdvwBets";
            this.dtgrdvwBets.ReadOnly = true;
            this.dtgrdvwBets.Size = new System.Drawing.Size(964, 154);
            this.dtgrdvwBets.TabIndex = 3;
            // 
            // tmrRefreshBets
            // 
            this.tmrRefreshBets.Interval = 1000;
            this.tmrRefreshBets.Tick += new System.EventHandler(this.tmrRefreshBets_Tick);
            // 
            // bttnPlcBet
            // 
            this.bttnPlcBet.Location = new System.Drawing.Point(889, 177);
            this.bttnPlcBet.Name = "bttnPlcBet";
            this.bttnPlcBet.Size = new System.Drawing.Size(75, 23);
            this.bttnPlcBet.TabIndex = 4;
            this.bttnPlcBet.Text = "Place bet";
            this.bttnPlcBet.UseVisualStyleBackColor = true;
            this.bttnPlcBet.Click += new System.EventHandler(this.bttnPlcBet_Click);
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
            this.statusStrp.ResumeLayout(false);
            this.statusStrp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwBookies)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwBets)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxGmblrID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxGmblrFnds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgrdvwBets;
        private System.Windows.Forms.DataGridView dtgrdvwBookies;
        private System.Windows.Forms.StatusStrip statusStrp;
        private System.Windows.Forms.ToolStripProgressBar tlstrpPrgssBr;
        private System.Windows.Forms.Button bttnRefresh;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpUpdateLabel;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpStatusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookieID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewButtonColumn bookieSayHello;
        private System.Windows.Forms.Timer tmrRefreshBets;
        private System.Windows.Forms.Button bttnPlcBet;
    }
}

