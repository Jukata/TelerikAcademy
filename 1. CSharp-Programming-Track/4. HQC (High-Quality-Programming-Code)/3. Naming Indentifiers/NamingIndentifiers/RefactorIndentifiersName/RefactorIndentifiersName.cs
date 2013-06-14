namespace RefactorIndentifiersName
{
    using System;

    internal class RefactorIndentifiersName
    {
        public const int MaxCount = 6;

        public static void Main()
        {
            ConsolePrinter consolePrinter = new ConsolePrinter();
            consolePrinter.Print(true);
        }

        private class ConsolePrinter
        {
            internal void Print(bool value)
            {
                string valueAsString = value.ToString();
                Console.WriteLine(valueAsString);
            }
        }
    }
}
