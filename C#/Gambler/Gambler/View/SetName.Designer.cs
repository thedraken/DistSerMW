namespace Gambler.View
{
    partial class SetName
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
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbxPortNo = new System.Windows.Forms.TextBox();
            this.cmbxIP1 = new System.Windows.Forms.ComboBox();
            this.cmbxIP2 = new System.Windows.Forms.ComboBox();
            this.cmbxIP3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxIP4 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(85, 6);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(178, 20);
            this.txtbxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // bttnOK
            // 
            this.bttnOK.Location = new System.Drawing.Point(188, 81);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 2;
            this.bttnOK.Text = "OK";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP Address";
            // 
            // txtbxPortNo
            // 
            this.txtbxPortNo.Location = new System.Drawing.Point(85, 58);
            this.txtbxPortNo.Name = "txtbxPortNo";
            this.txtbxPortNo.Size = new System.Drawing.Size(178, 20);
            this.txtbxPortNo.TabIndex = 5;
            // 
            // cmbxIP1
            // 
            this.cmbxIP1.FormattingEnabled = true;
            this.cmbxIP1.Location = new System.Drawing.Point(85, 31);
            this.cmbxIP1.Name = "cmbxIP1";
            this.cmbxIP1.Size = new System.Drawing.Size(40, 21);
            this.cmbxIP1.TabIndex = 6;
            // 
            // cmbxIP2
            // 
            this.cmbxIP2.FormattingEnabled = true;
            this.cmbxIP2.Location = new System.Drawing.Point(131, 32);
            this.cmbxIP2.Name = "cmbxIP2";
            this.cmbxIP2.Size = new System.Drawing.Size(40, 21);
            this.cmbxIP2.TabIndex = 7;
            // 
            // cmbxIP3
            // 
            this.cmbxIP3.FormattingEnabled = true;
            this.cmbxIP3.Location = new System.Drawing.Point(177, 32);
            this.cmbxIP3.Name = "cmbxIP3";
            this.cmbxIP3.Size = new System.Drawing.Size(40, 21);
            this.cmbxIP3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Port No.";
            // 
            // cmbxIP4
            // 
            this.cmbxIP4.FormattingEnabled = true;
            this.cmbxIP4.Location = new System.Drawing.Point(223, 32);
            this.cmbxIP4.Name = "cmbxIP4";
            this.cmbxIP4.Size = new System.Drawing.Size(40, 21);
            this.cmbxIP4.TabIndex = 10;
            // 
            // SetName
            // 
            this.AcceptButton = this.bttnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 116);
            this.Controls.Add(this.cmbxIP4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxIP3);
            this.Controls.Add(this.cmbxIP2);
            this.Controls.Add(this.cmbxIP1);
            this.Controls.Add(this.txtbxPortNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.PersonsName = "SetName";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gambler\'s details";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetName_FormClosing);
            this.Shown += new System.EventHandler(this.SetName_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxPortNo;
        private System.Windows.Forms.ComboBox cmbxIP1;
        private System.Windows.Forms.ComboBox cmbxIP2;
        private System.Windows.Forms.ComboBox cmbxIP3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxIP4;
    }
}