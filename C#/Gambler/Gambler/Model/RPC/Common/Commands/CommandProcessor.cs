using Bookmaking.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmaking.Commands
{
    /**
 * Reads command lines from the console and triggers execution
 * of the associated Command instance. Requires previous registration
 * of all possible Command objects. This first token entered on
 * a command line determines the command to be executed. The
 * remaining tokens will be passed as arguments to the Command's
 * process method.
 * A CommandProcessor is executed in the context of a separate Thread.
 */
    public class CommandProcessor
    {

        // directory of registered commands
        private Dictionary<String, Command> commands;

        // process commands as long as running is true
        private bool running;

        /**
         * Create a CommandProcessor as a separate thread. Need to invoke
         * the start method on a CommandProcessor to launch command processing.
         * Registers two commands by default: exit and help.
         */
        public CommandProcessor()
        {
            commands = new Dictionary<String, Command>();
            running = true;
            new ExitCommand(this);
            new HelpCommand(this);
        }

        /**
         * Register a Command object.
         * @param commandName	name used to invoke the Command
         * @param command		Command to be invoked
         */
        public void register(String commandName, Command command)
        {
            commands.Add(commandName, command);
        }

        /**
         * Finish command processing.
         */
        public void exit()
        {
            running = false;
        }

        public void showHelp()
        {
            // Iterate through the complete Dictionary
            foreach (KeyValuePair<string, Command> cmd in commands)
            {
                cmd.Value.showHelp();
            }
        }

        /**
         * Main loop accepting and processing commands entered via the console
         */
        public void run()
        {
            while (running)
            {
                // read next command line to be executed from the console
                String commandLine = Console.ReadLine();
                Command command;

                char[] delims = { ' ' };
                // The splitted input, the command is located in the token[0] and the following positions of
                // the array are the parameters,
                // example: connect => token[0] , [Bookie IP] => token[1] , [Bookie Port] => token[2]
                String[] tokens = commandLine.Split(delims);

                // tokens[0] contains the command; try to find matching command
                if (commands.ContainsKey(tokens[0]))
                {
                    command = commands[tokens[0]];
                    // create arguments array by removing command token
                    String[] args = new String[tokens.Length];
                    Array.Copy(tokens, 1, args, 0, tokens.Length - 1);
                    try
                    {
                        // process the command
                        command.process(args);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Error executing the command. Maybe a syntax error? You might want to try:");
                        command.showHelp();
                    }
                }
                else
                    Console.Error.WriteLine("unknown command: " + tokens[0] + ". You might find the 'help' command useful.");
            }




        }
    }
}
