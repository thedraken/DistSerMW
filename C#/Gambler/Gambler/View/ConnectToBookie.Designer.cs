namespace Gambler.View
{
    partial class ConnectToBookie
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
            this.cmbxIP4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxIP3 = new System.Windows.Forms.ComboBox();
            this.cmbxIP2 = new System.Windows.Forms.ComboBox();
            this.cmbxIP1 = new System.Windows.Forms.ComboBox();
            this.txtbxPortNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnOK = new System.Windows.Forms.Button();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbxIP4
            // 
            this.cmbxIP4.FormattingEnabled = true;
            this.cmbxIP4.Location = new System.Drawing.Point(220, 5);
            this.cmbxIP4.Name = "cmbxIP4";
            this.cmbxIP4.Size = new System.Drawing.Size(40, 21);
            this.cmbxIP4.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Port No.";
            // 
            // cmbxIP3
            // 
            this.cmbxIP3.FormattingEnabled = true;
            this.cmbxIP3.Location = new System.Drawing.Point(174, 5);
            this.cmbxIP3.Name = "cmbxIP3";
            this.cmbxIP3.Size = new System.Drawing.Size(40, 21);
            this.cmbxIP3.TabIndex = 16;
            // 
            // cmbxIP2
            // 
            this.cmbxIP2.FormattingEnabled = true;
            this.cmbxIP2.Location = new System.Drawing.Point(128, 5);
            this.cmbxIP2.Name = "cmbxIP2";
            this.cmbxIP2.Size = new System.Drawing.Size(40, 21);
            this.cmbxIP2.TabIndex = 15;
            // 
            // cmbxIP1
            // 
            this.cmbxIP1.FormattingEnabled = true;
            this.cmbxIP1.Location = new System.Drawing.Point(82, 4);
            this.cmbxIP1.Name = "cmbxIP1";
            this.cmbxIP1.Size = new System.Drawing.Size(40, 21);
            this.cmbxIP1.TabIndex = 14;
            // 
            // txtbxPortNo
            // 
            this.txtbxPortNo.Location = new System.Drawing.Point(82, 31);
            this.txtbxPortNo.Name = "txtbxPortNo";
            this.txtbxPortNo.Size = new System.Drawing.Size(178, 20);
            this.txtbxPortNo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "IP Address";
            // 
            // bttnOK
            // 
            this.bttnOK.Location = new System.Drawing.Point(185, 54);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 11;
            this.bttnOK.Text = "OK";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // bttnCancel
            // 
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Location = new System.Drawing.Point(12, 54);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 19;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // ConnectToBookie
            // 
            this.AcceptButton = this.bttnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(269, 85);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.cmbxIP4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxIP3);
            this.Controls.Add(this.cmbxIP2);
            this.Controls.Add(this.cmbxIP1);
            this.Controls.Add(this.txtbxPortNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bttnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConnectToBookie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter bookie\'s address";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectToBookie_FormClosing);
            this.Shown += new System.EventHandler(this.ConnectToBookie_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxIP4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxIP3;
        private System.Windows.Forms.ComboBox cmbxIP2;
        private System.Windows.Forms.ComboBox cmbxIP1;
        private System.Windows.Forms.TextBox txtbxPortNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.Button bttnCancel;
    }
}