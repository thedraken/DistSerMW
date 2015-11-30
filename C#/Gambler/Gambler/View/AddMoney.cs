﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gambler.View
{
    public partial class AddMoney : Form
    {
        public AddMoney()
        {
            InitializeComponent();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            float fundsToAdd;
            if (txtbxFundsToAdd.Text.Length > 0 && Controller.FunctionController.getInstance().isFloat(txtbxFundsToAdd.Text, out fundsToAdd))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Error", "Please enter a double value", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public float fundsToAdd { get; private set; }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
