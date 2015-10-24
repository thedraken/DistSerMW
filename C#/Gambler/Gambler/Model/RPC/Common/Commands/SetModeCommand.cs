using JSON_RPC_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmaking.Commands
{
    public abstract class SetModeCommand : Command
    {

        public SetModeCommand(CommandProcessor commandProcessor) : base(commandProcessor, "set_mode")
        {
        }

        public override void process(String[] args)
        {
            // extract arguments
            String bookieID = args[0];
            String serviceModeString = args[1];
            ServiceMode serviceMode;

            try
            {
                // try to convert from string
                serviceMode = (ServiceMode)Enum.Parse(typeof(ServiceMode), args[1], true);
            }
            catch (ArgumentException ex)
            {
                // try to convert from integer value
                try
                {
                    int serviceModeOrdinal = Int32.Parse(serviceModeString);
                    serviceMode = (ServiceMode)serviceModeOrdinal;
                }
                catch (FormatException ex2)
                {
                    Console.Error.WriteLine("Wrong mode. Please try:");
                    showHelp();
                    return;
                }
            }
            processSetMode(bookieID, serviceMode);
        }

        public abstract void processSetMode(String partnerID, ServiceMode serviceMode);

    }
}
