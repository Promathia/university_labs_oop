using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Utils
{
    class PrintingUtils
    {
        public static void PrintCalculationResults(params String[] values)
        {
            doPrintWithColors(ConsoleColor.Green, values);
        }

        public static void PrintError(params String[] values)
        {
            doPrintWithColors(ConsoleColor.Red, values);
        }

        private static void doPrintWithColors(ConsoleColor startColor, params String[] values)
        {
            Console.ForegroundColor = startColor;
            foreach (String value in values)
            {
                Console.WriteLine(value);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
