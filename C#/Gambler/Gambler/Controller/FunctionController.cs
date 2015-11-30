using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gambler.Controller
{
    class FunctionController
    {
        private FunctionController()
        {

        }
        private static readonly object syncLock = new object();
        private static FunctionController instance;
        public static FunctionController getInstance()
        {
            lock (syncLock)
            {
                if (instance == null)
                    instance = new FunctionController();
            }
            return instance;
        }
        public bool isDouble(string value, out double ret)
        {
            if (Double.TryParse(value, out ret))
                return true;
            return false;
        }
        public bool isFloat(string value, out float ret)
        {
            if (float.TryParse(value, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out ret))
                return true;
            return false;
        }
        public bool isInt(string value, out int ret)
        {
            if (Int32.TryParse(value, out ret))
                return true;
            return false;
        }

    }
}
