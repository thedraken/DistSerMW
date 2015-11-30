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
        public float Amount { get; private set; }
        public Model.Match Match { get; private set; }
        public float Odds { get; private set; }
        public PlaceBet(List<Model.Match> listOfMatches)
        {
            InitializeComponent();
            this._listOfMatches = listOfMatches;
            Amount = 0;
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
            if (rdbttnTeamA.Checked || rdbttnTeamB.Checked || rdBttnDraw.Checked)
            {

                if (rdbttnTeamA.Checked)
                {
                    Odds = this.Match.OddsA;
                    this.TeamName = this.Match.TeamA;
                }
                else if (rdbttnTeamB.Checked)
                {
                    Odds = this.Match.OddsB;
                    this.TeamName = this.Match.TeamB;
                }
                else
                {
                    Odds = this.Match.OddsDraw;
                    this.TeamName = "draw";
                }
            }
            else
            {
                success = false;
                sb.Append("\nPlease select at one of the teams, or a draw, to bet on");
            }
            if (txtbxAmnt.Text.Trim() != string.Empty)
            {
                float value;
                if (Controller.FunctionController.getInstance().isFloat(txtbxAmnt.Text, out value) && value > 0)
                    this.Amount = value;
                else
                {
                    success = false;
                    sb.Append("\nPlease enter a positive decimal value for the bet");
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
            rdBttnDraw.Enabled = true;
            bttnOK.Enabled = true;
        }
        private void txtbxAmnt_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (!Controller.FunctionController.getInstance().isFloat(txtbxAmnt.Text, out value) && !txtbxAmnt.Text.Equals(string.Empty))
                txtbxAmnt.Text = Amount.ToString();
            else if (!txtbxAmnt.Text.Equals(string.Empty))
                Amount = value;
            updateExpectedOutCome();
        }
        private void updateExpectedOutCome()
        {
            if ((rdbttnTeamA.Checked || rdbttnTeamB.Checked || rdBttnDraw.Checked)&& Amount > 0)
            {
                if (rdbttnTeamA.Checked)
                    txtbxAmountIfWon.Text = (((Model.Match)cmbxMatch.SelectedItem).OddsA * Amount).ToString();
                else if (rdbttnTeamB.Checked)
                    txtbxAmountIfWon.Text = (((Model.Match)cmbxMatch.SelectedItem).OddsB * Amount).ToString();
                else
                    txtbxAmountIfWon.Text = (((Model.Match)cmbxMatch.SelectedItem).OddsDraw * Amount).ToString();
            }
        }
        private void rdbttn_Click(object sender, EventArgs e)
        {
            updateExpectedOutCome();
        }
    }
}
