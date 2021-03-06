﻿using Gambler.Controller;
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
    public partial class SetName : BaseConnectForm
    {
        public SetName() : base()
        {
            InitializeComponent();
        }
        public string PersonsName { get; protected set; }
        
        private void bttnOK_Click(object sender, EventArgs e)
        {
            PersonsName = txtbxName.Text;
            checkValidPortNo(txtbxPortNo.Text);
            if (checkComboValidIP(listOfCombos))
                textToIPAddress(cmbxIP1.Text, cmbxIP2.Text, cmbxIP3.Text, cmbxIP4.Text);
            else
                Address = null;
            this.Close();
        }
        private void SetName_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool failure = false;
            StringBuilder sb = new StringBuilder();
            sb = ipNameAndPortErrorCheck(out failure, sb);
            if (PersonsName == null || PersonsName == string.Empty)
            {
                failure = true;
                sb.Append("\nPlease enter a name");
            }
            if (failure)
                MessageBox.Show("There was some errors:" + sb.ToString() + "\nPlease correct them and press OK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = failure;
        }
        private void SetName_Shown(object sender, EventArgs e)
        {
            listOfCombos = new List<ComboBox>();
            listOfCombos.Add(cmbxIP1);
            listOfCombos.Add(cmbxIP2);
            listOfCombos.Add(cmbxIP3);
            listOfCombos.Add(cmbxIP4);
            changeComboBoxesToDefault();
        }
    }
}
