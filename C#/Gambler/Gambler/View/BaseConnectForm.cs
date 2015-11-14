using Gambler.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gambler.View
{
    public class BaseConnectForm : Form
    {
        public BaseConnectForm()
        {
            this.Address = IPAddress.Loopback;
        }
        private int ipMin = 1;
        private int ipMax = 255;
        protected List<ComboBox> listOfCombos;
        public IPAddress Address { get; protected set; }
        public int PortNumber { get; protected set; }
        protected bool checkComboValidIP(List<ComboBox> listOfCombos)
        {
            foreach (ComboBox cmbx in listOfCombos)
            {
                if (!FunctionController.getInstance().isInt(cmbx.Text))
                    return false;
                if (int.Parse(cmbx.Text) > 255 || int.Parse(cmbx.Text) < 0)
                    return false;
            }
            return true;
        }
        protected void checkValidPortNo(string text)
        {
            if (FunctionController.getInstance().isInt(text))
                PortNumber = int.Parse(text);
            else
                PortNumber = int.MinValue;
        }
        protected StringBuilder ipNameAndPortErrorCheck(out bool failure, StringBuilder sb)
        {
            failure = false;
            if (PortNumber == int.MinValue || PortNumber < 3000)
            {
                failure = true;
                sb.Append("\nPlease enter a port number greater than 3000");
            }
            if (Address == null)
            {
                failure = true;
                sb.Append("\nPlease enter a valid IP address");
            }
            return sb;
        }
        protected void textToIPAddress(string oct1, string oct2, string oct3, string oct4)
        {
            string toConvert = oct1 + "." + oct2 + "." + oct3 + "." + oct4;
            IPAddress temp;
            if (IPAddress.TryParse(toConvert, out temp))
                Address = temp;
            else
                Address = null;
        }
        protected void changeComboBoxesToDefault()
        {
            string[] split = Address.ToString().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = ipMin; i <= ipMax; i++)
                listOfCombos.ForEach(t => t.Items.Add(i));
            for (int i = 0; i < split.Count(); i++)
            {
                if (FunctionController.getInstance().isInt(split[i]))
                    listOfCombos.Where(t => t.Name.Contains((i + 1).ToString())).First().Text = split[i];
            }
        }

    }
}
