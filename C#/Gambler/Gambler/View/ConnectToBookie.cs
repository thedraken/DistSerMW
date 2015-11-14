using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gambler.View
{
    public partial class ConnectToBookie : BaseConnectForm
    {
        public ConnectToBookie():base()
        {
            InitializeComponent();
        }
        public DialogResult result { get; private set; }
        private void bttnOK_Click(object sender, EventArgs e)
        {
            checkValidPortNo(txtbxPortNo.Text);
            if (checkComboValidIP(listOfCombos))
                textToIPAddress(cmbxIP1.Text, cmbxIP2.Text, cmbxIP3.Text, cmbxIP4.Text);
            else
                Address = null;
            result = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ConnectToBookie_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                bool failure = false;
                StringBuilder sb = new StringBuilder();
                sb = ipNameAndPortErrorCheck(out failure, sb);
                if (failure)
                    MessageBox.Show("There was some errors:" + sb.ToString() + "\nPlease correct them and press OK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = failure;
            }
        }

        private void ConnectToBookie_Shown(object sender, EventArgs e)
        {
            listOfCombos = new List<ComboBox>();
            listOfCombos.Add(cmbxIP1);
            listOfCombos.Add(cmbxIP2);
            listOfCombos.Add(cmbxIP3);
            listOfCombos.Add(cmbxIP4);
            changeComboBoxesToDefault();
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            result = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
