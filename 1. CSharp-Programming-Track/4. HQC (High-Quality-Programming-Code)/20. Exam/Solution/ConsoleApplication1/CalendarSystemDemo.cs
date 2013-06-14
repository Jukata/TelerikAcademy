using System;
using System.Text;

namespace CalendarSystem
{
    public class CalendarSystemDemo
    {
        public static void Main()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            CommandExecutor commandExecutor = new CommandExecutor(eventsManager);
            StringBuilder outputResult = new StringBuilder();

            while (true)
            {
                string commandType = Console.ReadLine();
                if (commandType == "End" || commandType == null)
                {
                    break;
                }

                // using StringBuilder and one Console.WriteLine instead of Console.WriteLine every time
                // because print on console is very slow operation
                Command currentCommand = Command.Parse(commandType);
                outputResult.AppendLine(commandExecutor.ProcessCommand(currentCommand));
            }

            Console.WriteLine(outputResult.ToString().Trim());
        }
    }
}