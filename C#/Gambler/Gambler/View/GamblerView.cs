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
    public partial class GamblerView : Form
    {
        public GamblerView()
        {
            InitializeComponent();
        }
        private Controller.GamblerController gmblrController = new Controller.GamblerController();
        
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMoney money = new AddMoney();
            money.ShowDialog();
            if (money.DialogResult == System.Windows.Forms.DialogResult.OK)
                gmblrController.fillWallet(money.fundsToAdd);
            txtbxGmblrFnds.Text = gmblrController.getMoney().ToString();
        }

        private void GamblerView_Shown(object sender, EventArgs e)
        {
            txtbxGmblrID.Text = gmblrController.getID().ToString();
            txtbxGmblrFnds.Text = gmblrController.getMoney().ToString();
        }
    }
}
