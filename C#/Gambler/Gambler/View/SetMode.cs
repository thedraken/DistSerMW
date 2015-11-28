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
    public partial class SetMode : Form
    {
        public SetMode(List<Model.Bookie> listOfBookies)
        {
            InitializeComponent();
            this.ListOfBookies = listOfBookies;
        }
        public List<Model.Bookie> ListOfBookies { get; private set; }

        private void SetMode_Shown(object sender, EventArgs e)
        {
            cmbbxBookie.DataSource = ListOfBookies;
            cmbbxMode.DataSource = Enum.GetValues(typeof(JSON_RPC_Server.ServiceMode));
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            if (cmbbxBookie.SelectedValue != null && cmbbxMode.SelectedValue != null)
            {
                JSON_RPC_Server.ServiceMode mode = (JSON_RPC_Server.ServiceMode)Enum.Parse(typeof(JSON_RPC_Server.ServiceMode), cmbbxMode.SelectedValue.ToString());
                Model.Bookie b = (Model.Bookie)cmbbxBookie.SelectedValue;
                b.setMode(mode);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        private void cmbbxBookie_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxBookie.SelectedValue != null)
                {
                    cmbbxMode.Enabled = true;
                    Model.Bookie b = (Model.Bookie)cmbbxBookie.SelectedValue;
                    cmbbxMode.SelectedValue = b.Mode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
