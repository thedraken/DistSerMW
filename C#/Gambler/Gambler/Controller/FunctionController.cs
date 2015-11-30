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
        /// <summary>
        /// Checks to see if the value specified is a float
        /// </summary>
        /// <param name="value">True if float</param>
        /// <param name="ret">The value if it was a float</param>
        /// <returns></returns>
        public bool isFloat(string value, out float ret)
        {
            if (float.TryParse(value, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out ret))
                return true;
            return false;
        }
        /// <summary>
        /// Checks to see if the value specified is an int
        /// </summary>
        /// <param name="value">True if an int</param>
        /// <param name="ret">The value if it was an int</param>
        /// <returns></returns>
        public bool isInt(string value, out int ret)
        {
            if (Int32.TryParse(value, out ret))
                return true;
            return false;
        }

    }
}
