using Gambler.Controller;
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
    public partial class SetName : Form
    {
        public SetName()
        {
            InitializeComponent();
            address = IPAddress.Loopback;
        }
        private int ipMin = 1;
        private int ipMax = 255;
        private List<ComboBox> listOfCombos;
        public IPAddress address { get; private set; }
        public string name { get; private set; }
        public int portNumber { get; private set; }
        private void bttnOK_Click(object sender, EventArgs e)
        {
            name = txtbxName.Text;
            if (FunctionController.getInstance().isInt(txtbxPortNo.Text))
                portNumber = int.Parse(txtbxPortNo.Text);
            else
                portNumber = int.MinValue;
            bool ipSuccess = true;
            foreach (ComboBox cmbx in listOfCombos)
            {
                if (!FunctionController.getInstance().isInt(cmbx.Text))
                {
                    address = null;
                    ipSuccess = false;
                    break;
                }
                if (int.Parse(cmbx.Text) > 255 || int.Parse(cmbx.Text) < 0)
                {
                    address = null;
                    ipSuccess = false;
                    break;
                }
            }
            if (ipSuccess)
            {
                string toConvert = cmbxIP1.Text + "." + cmbxIP2.Text + "." + cmbxIP3.Text + "." + cmbxIP4.Text;
                IPAddress temp;
                if (IPAddress.TryParse(toConvert, out temp))
                    address = temp;
                else
                    address = null;
            }
            this.Close();
        }

        private void SetName_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool failure = false;
            StringBuilder sb = new StringBuilder();
            if (name == null || name == string.Empty)
            {
                failure = true;
                sb.Append("\nPlease enter a name");
            }
            if (portNumber == int.MinValue || portNumber < 3000)
            {
                failure = true;
                sb.Append("\nPlease enter a port number greater than 3000");
            }
            if (address == null)
            {
                failure = true;
                sb.Append("\nPlease enter a valid IP address");
            }
            if (failure)
                MessageBox.Show("There was some errors:" + sb.ToString() + "\nPlease correct them and press OK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = failure;
        }

        private void SetName_Shown(object sender, EventArgs e)
        {
            string[] split = address.ToString().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            listOfCombos = new List<ComboBox>();
            listOfCombos.Add(cmbxIP1);
            listOfCombos.Add(cmbxIP2);
            listOfCombos.Add(cmbxIP3);
            listOfCombos.Add(cmbxIP4);
            for (int i = ipMin; i <= ipMax; i++)
                listOfCombos.ForEach(t => t.Items.Add(i));
            for (int i = 0; i < split.Count(); i++)
            {
                if (FunctionController.getInstance().isInt(split[i]))
                    listOfCombos.Where(t => t.Name.Contains((i+1).ToString())).First().Text = split[i];
            }
        }
    }
}
