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
    public partial class PlaceBet : Form
    {
        public string TeamName { get; private set; }
        public double Amount { get; private set; }
        public Model.Match Match { get; private set; }
        public PlaceBet(List<Model.Match> listOfMatches)
        {
            InitializeComponent();
            this._listOfMatches = listOfMatches;
        }
        private List<Model.Match> _listOfMatches;
        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void bttnOK_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            bool success = true;
            this.Match = (Model.Match)cmbxMatch.SelectedItem;
            if (rdbttnTeamA.Checked || rdbttnTeamB.Checked)
                this.TeamName = rdbttnTeamA.Checked ? this.Match.TeamA : this.Match.TeamB;
            else
            {
                success = false;
                sb.Append("\nPlease select at one of the teams to bet on");
            }
            if (txtbxAmnt.Text.Trim() != string.Empty)
            {
                if (Controller.FunctionController.getInstance().isDouble(txtbxAmnt.Text))
                    this.Amount = Double.Parse(txtbxAmnt.Text);
                else
                {
                    success = false;
                    sb.Append("\nPlease enter a decimal value for the bet");
                }
                
            }
            else
            {
                success = false;
                sb.Append("\nPlease enter a value to bet");
            }
            if (success)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Please correct the following issues:" + sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void PlaceBet_Shown(object sender, EventArgs e)
        {
            foreach (Model.Match m in _listOfMatches)
                cmbxMatch.Items.Add(m);
        }
        private void cmbxMatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Match m = (Model.Match)cmbxMatch.SelectedItem;
            rdbttnTeamA.Text = m.TeamA;
            rdbttnTeamA.Checked = false;
            rdbttnTeamB.Text = m.TeamB;
            rdbttnTeamB.Checked = false;
            txtbxAmnt.Text = "";
            txtbxAmnt.Enabled = true;
            rdbttnTeamA.Enabled = true;
            rdbttnTeamB.Enabled = true;
            bttnOK.Enabled = true;
        }
    }
}
