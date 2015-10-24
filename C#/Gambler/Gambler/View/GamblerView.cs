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
        private Controller.GamblerController gmblrController;
        
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectToBookie bookie = new ConnectToBookie();
            bookie.ShowDialog();
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
            this.gmblrController = new Controller.GamblerController(setName.name, setName.address, setName.portNumber);
            txtbxGmblrFnds.Text = "€" + this.gmblrController.getMoney().ToString();
            txtbxGmblrID.Text = this.gmblrController.getID();
        }

    }
}
