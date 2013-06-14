using System;

namespace CalendarSystem
{
    public struct Command
    {
        public string CommandName { get; set; }

        public string[] Params { get; set; }

        public static Command Parse(string inputCommand)
        {
            if (inputCommand == null)
            {
                throw new ArgumentNullException("Input command can't be null.");
            }

            int commandNameEndIndex = inputCommand.IndexOf(' ');
            if (commandNameEndIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + inputCommand);
            }

            string commandName = inputCommand.Substring(0, commandNameEndIndex);
            string parametters = inputCommand.Substring(commandNameEndIndex + 1);

            string[] commandArguments = parametters.Split('|');

            for (int i = 0; i < commandArguments.Length; i++)
            {
                parametters = commandArguments[i];
                commandArguments[i] = parametters.Trim();
            }

            Command parsedCommand = new Command { CommandName = commandName, Params = commandArguments };
            return parsedCommand;
        }
    }
}