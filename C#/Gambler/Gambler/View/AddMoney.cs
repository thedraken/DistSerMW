using System;
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
        private bool allowClose = false;
        private void bttnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            float fundsToAdd;
            if (txtbxFundsToAdd.Text.Length > 0 && Controller.FunctionController.getInstance().isFloat(txtbxFundsToAdd.Text, out fundsToAdd) && fundsToAdd > 0)
            {
                this.FundsToAdd = fundsToAdd;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                allowClose = true;
                this.Close();
            }
            else
                MessageBox.Show("Please enter a positive double value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        public float FundsToAdd { get; private set; }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            allowClose = true;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void AddMoney_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !allowClose;
        }
    }
}
