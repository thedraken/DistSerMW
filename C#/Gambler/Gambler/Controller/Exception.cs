using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Controller
{
    public abstract class BaseException : Exception
    {
        public BaseException(string message)
        {
            this._message = message;
        }
        private string _message;

        public override string Message
        {
            get
            {
                return this._message;
            }
        }
    }

    public class GamblerAlreadyExists :BaseException
    {
        public GamblerAlreadyExists()
            : base("The gambler already exisits, please use another name")
        {

        }
    }
}
