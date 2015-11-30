using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gambler.View
{
    public partial class GamblerView : Form
    {
        public GamblerView()
        {
            InitializeComponent();
        }
        private Controller.GamblerController gmblrController;
        private Controller.BookieController bkController;
        private int countOfWinnings = 0;
        private int countOfLoses = 0;
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectToBookie bookie = new ConnectToBookie();
            bookie.ShowDialog();
            if (bookie.result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    bkController.connectBookie(gmblrController.gmblr, bookie.Address, bookie.PortNumber);

                }
                catch (Exception ex)
                {
                    handleException(ex);
                }
            }
            dtgrdvwBookies.Rows.Clear();
            foreach (Model.Bookie b in bkController.ListOfBookies)
                addBookieToDataGrid(b);
        }
        private void addBookieToDataGrid(Model.Bookie b)
        {
            dtgrdvwBookies.Rows.Add(b.ID, b.Address.ToString(), b.PortNo.ToString(), "Say hello");
        }
        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddMoney money = new AddMoney();
                money.ShowDialog();
                if (money.DialogResult == System.Windows.Forms.DialogResult.OK)
                    gmblrController.fillWallet(money.FundsToAdd);
                txtbxGmblrFnds.Text = "€" + gmblrController.getMoney().ToString();
            }
            catch (Exception ex)
            {
                handleException(ex);
            }
        }
        private void GamblerView_Shown(object sender, EventArgs e)
        {
            SetName setName = new SetName();
            setName.ShowDialog();
            this.gmblrController = new Controller.GamblerController(setName.PersonsName, setName.Address, setName.PortNumber);
            txtbxGmblrFnds.Text = "€" + this.gmblrController.getMoney().ToString();
            txtbxGmblrID.Text = this.gmblrController.getID();
            bkController = new Controller.BookieController();
            tlstrpStatusLabel.Text = "Status: Listening on port: " + gmblrController.gmblr.PortNo;
            bkController.ListOfAllWinnings.CollectionChanged += handleNewWinnings;
            tmrRefreshBets.Start();
        }
        private void bttnRefresh_Click(object sender, EventArgs e)
        {
            bkController.refreshMatches();
        }
        private void dtgrdvwBookies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnTitle = dtgrdvwBookies.Columns[e.ColumnIndex].HeaderText;
            if (columnTitle == "Say Hello")
            {
                string bookieID = dtgrdvwBookies.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.bkController.sayHello(bookieID);

            }
        }
        /// <summary>
        /// The timer that upon tick will refresh the form with the latest data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRefreshBets_Tick(object sender, EventArgs e)
        {
            bkController.updateMatches();
            var dataSource = new BindingSource();
            dataSource.DataSource = bkController.ListOfMatches;
            dtgrdvwBets.DataSource = dataSource;
            txtbxGmblrFnds.Text = "€" + this.gmblrController.getMoney().ToString();
            int countOfWinningsNow = bkController.ListOfAllWinnings.Where(t=> t.Amount > 0).ToList().Count;
            if (countOfWinnings < countOfWinningsNow)
            {
                countOfWinnings = countOfWinningsNow;
                MessageBox.Show("You've won some money, it has been credited to your account", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            int countOfLosesNow = bkController.ListOfAllWinnings.Where(t => t.Amount == 0).ToList().Count;
            if (countOfLoses < countOfLosesNow)
            {
                countOfLoses = countOfLosesNow;
                MessageBox.Show("Some matches ended and you didn't win, better luck next time!", "Loser", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (bkController.ListOfBookies.Where(t => !t.Connected).Count() > 0)
            {
                bkController.removeClosedBookies();
                dtgrdvwBookies.Rows.Clear();
                foreach (Model.Bookie b in bkController.ListOfBookies)
                    addBookieToDataGrid(b);
            }
        }
        private void bttnPlcBet_Click(object sender, EventArgs e)
        {
            if (bkController.ListOfMatches.Count > 0)
            {
                //Have to clone the matches, to prevent us sending the updated odds. The system was being too live before!
                PlaceBet frm = new PlaceBet(bkController.getCloneOfMatches());
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        if (gmblrController.gmblr.Money >= frm.Amount)
                        {
                            bkController.placeBet(frm.Match, frm.TeamName, frm.Amount, frm.Odds);
                            //If we reach here, no exception was thrown, bet was placed and we can take the funds from the user's wallet
                            gmblrController.fillWallet(-frm.Amount);
                        }
                        else
                            throw new Controller.NotEnoughFunds(frm.Amount);
                    }
                    catch (Exception ex)
                    {
                        handleException(ex);
                    }
                }
            }
            else
                MessageBox.Show("No matches available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void GamblerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrRefreshBets.Stop();
            bkController.closeConnection();
            gmblrController.destroyConnection();
        }
        private void handleException(Exception ex)
        {
            MessageBox.Show("There was an error:\n"+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void handleNewWinnings(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var ni in e.NewItems)
            {
                Model.Winnings w = (Model.Winnings)ni;
                gmblrController.fillWallet(w.Amount);
            }
        }
        private void setModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bkController.ListOfBookies.Count > 0)
            {
                SetMode frm = new SetMode(bkController.ListOfBookies.ToList());
                frm.ShowDialog();
            }
        }
        private void bttnCheckBets_Click(object sender, EventArgs e)
        {
            if (bkController.ListOfMatches.Count > 0)
            {
                OtherBets frm = new OtherBets(bkController.ListOfMatches.ToList(), bkController);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("No matches available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
