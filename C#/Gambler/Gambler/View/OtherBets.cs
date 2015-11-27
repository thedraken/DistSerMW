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
    public partial class OtherBets : Form
    {
        public OtherBets(List<Model.Match> listOfMatches, Controller.BookieController bkController)
        {
            InitializeComponent();
            this._listOfMatches = listOfMatches;
            this._bkController = bkController;
        }
        private List<Model.Match> _listOfMatches = new List<Model.Match>();
        private Controller.BookieController _bkController;
        private void btnGetBets_Click(object sender, EventArgs e)
        {
            if (cmbbxMatches.SelectedItem != null)
            {
                Model.Match match = (Model.Match)cmbbxMatches.SelectedItem;
                List<Model.Bet> listOfBetsPlaced = _bkController.getMatchBets(match);
                var dataSource = new BindingSource();
                dataSource.DataSource = listOfBetsPlaced;
                dtgrdvwListOfBets.DataSource = dataSource;
            }
        }

        private void bttnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OtherBets_Shown(object sender, EventArgs e)
        {
            foreach (Model.Match m in _listOfMatches)
                cmbbxMatches.Items.Add(m);
        }
    }
}
