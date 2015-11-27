namespace Gambler.View
{
    partial class OtherBets
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
            this.cmbbxMatches = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetBets = new System.Windows.Forms.Button();
            this.bttnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgrdvwListOfBets = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwListOfBets)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbbxMatches
            // 
            this.cmbbxMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbxMatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxMatches.FormattingEnabled = true;
            this.cmbbxMatches.Location = new System.Drawing.Point(96, 3);
            this.cmbbxMatches.Name = "cmbbxMatches";
            this.cmbbxMatches.Size = new System.Drawing.Size(273, 21);
            this.cmbbxMatches.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a match";
            // 
            // btnGetBets
            // 
            this.btnGetBets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetBets.Location = new System.Drawing.Point(375, 3);
            this.btnGetBets.Name = "btnGetBets";
            this.btnGetBets.Size = new System.Drawing.Size(87, 32);
            this.btnGetBets.TabIndex = 2;
            this.btnGetBets.Text = "Get Bets";
            this.btnGetBets.UseVisualStyleBackColor = true;
            this.btnGetBets.Click += new System.EventHandler(this.btnGetBets_Click);
            // 
            // bttnClose
            // 
            this.bttnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bttnClose.Location = new System.Drawing.Point(375, 351);
            this.bttnClose.Name = "bttnClose";
            this.bttnClose.Size = new System.Drawing.Size(87, 34);
            this.bttnClose.TabIndex = 3;
            this.bttnClose.Text = "Close";
            this.bttnClose.UseVisualStyleBackColor = true;
            this.bttnClose.Click += new System.EventHandler(this.bttnClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbbxMatches, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGetBets, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.bttnClose, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtgrdvwListOfBets, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(465, 388);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dtgrdvwListOfBets
            // 
            this.dtgrdvwListOfBets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtgrdvwListOfBets, 3);
            this.dtgrdvwListOfBets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdvwListOfBets.Location = new System.Drawing.Point(3, 41);
            this.dtgrdvwListOfBets.Name = "dtgrdvwListOfBets";
            this.dtgrdvwListOfBets.Size = new System.Drawing.Size(459, 304);
            this.dtgrdvwListOfBets.TabIndex = 5;
            // 
            // OtherBets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 388);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OtherBets";
            this.Text = "OtherBets";
            this.Shown += new System.EventHandler(this.OtherBets_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvwListOfBets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbbxMatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetBets;
        private System.Windows.Forms.Button bttnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtgrdvwListOfBets;
    }
}