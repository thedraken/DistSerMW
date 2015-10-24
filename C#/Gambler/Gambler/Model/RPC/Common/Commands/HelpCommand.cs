using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmaking.Commands
{
    public class HelpCommand : Command
    {

        public HelpCommand(CommandProcessor commandProcessor) : base(commandProcessor, "help")
        {
        }

        public override void process(String[] args)
        {
            Console.WriteLine("The following commands are available:");
            getCommandProcessor().showHelp();
        }

        public override void showHelp()
        {
            Console.WriteLine("help — print this list of available commands");
        }

    }
}
