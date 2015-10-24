using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmaking.Commands
{
    public class ExitCommand : Command
    {

        public ExitCommand(CommandProcessor commandProcessor) : base(commandProcessor, "exit")
        {
        }

        public override void process(String[] args)
        {
            Console.WriteLine("Exiting ...");
            // tell associated CommandProcessor to exit
            getCommandProcessor().exit();
        }

        public override void showHelp()
        {
            Console.WriteLine("exit — terminate the application");
        }
    }
}
