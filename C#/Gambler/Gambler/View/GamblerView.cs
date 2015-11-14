using System;
using System.Collections.Generic;
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
                catch (Controller.GamblerAlreadyExists ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dtgrdvwBookies.Rows.Clear();
            foreach (Model.Bookie b in bkController.ListOfBookies)
                addBookieToDataGrid(b);
        }

        private void addBookieToDataGrid(Model.Bookie b)
        {
            dtgrdvwBookies.Rows.Add(b.iD, b.address.ToString(), b.portNo.ToString(), "Say hello");
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMoney money = new AddMoney();
            money.ShowDialog();
            if (money.DialogResult == System.Windows.Forms.DialogResult.OK)
                gmblrController.fillWallet(money.fundsToAdd);
            txtbxGmblrFnds.Text = "€" + gmblrController.getMoney().ToString();
        }

        private void GamblerView_Shown(object sender, EventArgs e)
        {
            SetName setName = new SetName();
            setName.ShowDialog();
            this.gmblrController = new Controller.GamblerController(setName.PersonsName, setName.Address, setName.PortNumber);
            txtbxGmblrFnds.Text = "€" + this.gmblrController.getMoney().ToString();
            txtbxGmblrID.Text = this.gmblrController.getID();
            bkController = new Controller.BookieController();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (bkController.updatePending())
                    backgroundWorker.ReportProgress(0, true);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tlstrpUpdateLabel.Text = "Updates: Pending";
            bttnRefresh.ForeColor = Color.Red;
        }

        private void bttnRefresh_Click(object sender, EventArgs e)
        {
            bttnRefresh.ForeColor = Color.Black;
            tlstrpUpdateLabel.Text = "Updates: None";
        }
    }
}
