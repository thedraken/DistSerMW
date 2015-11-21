namespace Gambler.View
{
    partial class SetMode
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbbxBookie = new System.Windows.Forms.ComboBox();
            this.cmbbxMode = new System.Windows.Forms.ComboBox();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.bttnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bookie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mode";
            // 
            // cmbbxBookie
            // 
            this.cmbbxBookie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxBookie.FormattingEnabled = true;
            this.cmbbxBookie.Location = new System.Drawing.Point(58, 6);
            this.cmbbxBookie.Name = "cmbbxBookie";
            this.cmbbxBookie.Size = new System.Drawing.Size(157, 21);
            this.cmbbxBookie.TabIndex = 2;
            this.cmbbxBookie.SelectedIndexChanged += new System.EventHandler(this.cmbbxBookie_SelectedIndexChanged);
            // 
            // cmbbxMode
            // 
            this.cmbbxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxMode.Enabled = false;
            this.cmbbxMode.FormattingEnabled = true;
            this.cmbbxMode.Location = new System.Drawing.Point(58, 33);
            this.cmbbxMode.Name = "cmbbxMode";
            this.cmbbxMode.Size = new System.Drawing.Size(157, 21);
            this.cmbbxMode.TabIndex = 3;
            // 
            // bttnCancel
            // 
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Location = new System.Drawing.Point(1, 72);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 4;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // bttnOK
            // 
            this.bttnOK.Location = new System.Drawing.Point(140, 72);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 5;
            this.bttnOK.Text = "OK";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // SetMode
            // 
            this.AcceptButton = this.bttnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(227, 107);
            this.ControlBox = false;
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.cmbbxMode);
            this.Controls.Add(this.cmbbxBookie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SetMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SetMode";
            this.Shown += new System.EventHandler(this.SetMode_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbbxBookie;
        private System.Windows.Forms.ComboBox cmbbxMode;
        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.Button bttnOK;
    }
}