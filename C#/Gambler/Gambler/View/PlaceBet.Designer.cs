namespace Gambler.View
{
    partial class PlaceBet
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
            this.cmbxMatch = new System.Windows.Forms.ComboBox();
            this.rdbttnTeamA = new System.Windows.Forms.RadioButton();
            this.rdbttnTeamB = new System.Windows.Forms.RadioButton();
            this.txtbxAmnt = new System.Windows.Forms.TextBox();
            this.bttnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.rdBttnDraw = new System.Windows.Forms.RadioButton();
            this.txtbxAmountIfWon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbxMatch
            // 
            this.cmbxMatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMatch.FormattingEnabled = true;
            this.cmbxMatch.Location = new System.Drawing.Point(102, 12);
            this.cmbxMatch.Name = "cmbxMatch";
            this.cmbxMatch.Size = new System.Drawing.Size(281, 21);
            this.cmbxMatch.TabIndex = 0;
            this.cmbxMatch.SelectedIndexChanged += new System.EventHandler(this.cmbxMatch_SelectedIndexChanged);
            // 
            // rdbttnTeamA
            // 
            this.rdbttnTeamA.AutoSize = true;
            this.rdbttnTeamA.Enabled = false;
            this.rdbttnTeamA.Location = new System.Drawing.Point(12, 39);
            this.rdbttnTeamA.Name = "rdbttnTeamA";
            this.rdbttnTeamA.Size = new System.Drawing.Size(14, 13);
            this.rdbttnTeamA.TabIndex = 1;
            this.rdbttnTeamA.TabStop = true;
            this.rdbttnTeamA.UseVisualStyleBackColor = true;
            this.rdbttnTeamA.Click += new System.EventHandler(this.rdbttn_Click);
            // 
            // rdbttnTeamB
            // 
            this.rdbttnTeamB.AutoSize = true;
            this.rdbttnTeamB.Enabled = false;
            this.rdbttnTeamB.Location = new System.Drawing.Point(170, 39);
            this.rdbttnTeamB.Name = "rdbttnTeamB";
            this.rdbttnTeamB.Size = new System.Drawing.Size(14, 13);
            this.rdbttnTeamB.TabIndex = 2;
            this.rdbttnTeamB.TabStop = true;
            this.rdbttnTeamB.UseVisualStyleBackColor = true;
            this.rdbttnTeamB.Click += new System.EventHandler(this.rdbttn_Click);
            // 
            // txtbxAmnt
            // 
            this.txtbxAmnt.Location = new System.Drawing.Point(102, 58);
            this.txtbxAmnt.Name = "txtbxAmnt";
            this.txtbxAmnt.Size = new System.Drawing.Size(283, 20);
            this.txtbxAmnt.TabIndex = 3;
            this.txtbxAmnt.TextChanged += new System.EventHandler(this.txtbxAmnt_TextChanged);
            // 
            // bttnOK
            // 
            this.bttnOK.Enabled = false;
            this.bttnOK.Location = new System.Drawing.Point(310, 119);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 4;
            this.bttnOK.Text = "OK";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select match";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter amount";
            // 
            // bttnCancel
            // 
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Location = new System.Drawing.Point(12, 119);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 7;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // rdBttnDraw
            // 
            this.rdBttnDraw.AutoSize = true;
            this.rdBttnDraw.Enabled = false;
            this.rdBttnDraw.Location = new System.Drawing.Point(298, 37);
            this.rdBttnDraw.Name = "rdBttnDraw";
            this.rdBttnDraw.Size = new System.Drawing.Size(50, 17);
            this.rdBttnDraw.TabIndex = 8;
            this.rdBttnDraw.TabStop = true;
            this.rdBttnDraw.Text = "Draw";
            this.rdBttnDraw.UseVisualStyleBackColor = true;
            this.rdBttnDraw.Click += new System.EventHandler(this.rdbttn_Click);
            // 
            // txtbxAmountIfWon
            // 
            this.txtbxAmountIfWon.Enabled = false;
            this.txtbxAmountIfWon.Location = new System.Drawing.Point(102, 84);
            this.txtbxAmountIfWon.Name = "txtbxAmountIfWon";
            this.txtbxAmountIfWon.Size = new System.Drawing.Size(283, 20);
            this.txtbxAmountIfWon.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Expected returns";
            // 
            // PlaceBet
            // 
            this.AcceptButton = this.bttnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(395, 154);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbxAmountIfWon);
            this.Controls.Add(this.rdBttnDraw);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.txtbxAmnt);
            this.Controls.Add(this.rdbttnTeamB);
            this.Controls.Add(this.rdbttnTeamA);
            this.Controls.Add(this.cmbxMatch);
            this.Name = "PlaceBet";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Place Bet";
            this.Shown += new System.EventHandler(this.PlaceBet_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxMatch;
        private System.Windows.Forms.RadioButton rdbttnTeamA;
        private System.Windows.Forms.RadioButton rdbttnTeamB;
        private System.Windows.Forms.TextBox txtbxAmnt;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.RadioButton rdBttnDraw;
        private System.Windows.Forms.TextBox txtbxAmountIfWon;
        private System.Windows.Forms.Label label3;
    }
}