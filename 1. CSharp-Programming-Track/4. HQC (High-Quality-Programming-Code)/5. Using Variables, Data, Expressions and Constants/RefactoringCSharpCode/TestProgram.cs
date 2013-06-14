// ##########################################################
// # <copyright file="TestProgram.cs" company="Telerik Academy">
// # Copyright (c) 2013 Telerik Academy. All rights reserved.
// # </copyright>
// ##########################################################
namespace RefactoringCSharpCode
{
    using System;

    /// <summary>
    /// Class for testing <see cref="StatisticPrinter"/>
    /// </summary>
    public class TestProgram
    {
        public static void Main()
        {
            double[] numbers = { 5, 10, 15, -3.0, 1000 };
            StatisticPrinter printer = new StatisticPrinter();
            printer.PrintStatistics(numbers);
        }
    }
}
