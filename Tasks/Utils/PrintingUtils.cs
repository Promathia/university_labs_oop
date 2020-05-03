using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Utils
{
    class PrintingUtils
    {
        public static void PrintCalculationResults(Boolean isCreateNewLine, params String[] values)
        {
            doPrintWithColors(isCreateNewLine, ConsoleColor.Green, values);
        }
        public static void PrintCalculationResults(params String[] values)
        {
            PrintCalculationResults(true, values);
        }

        public static void PrintWithColor(Boolean isCreateNewLine, ConsoleColor startColor, params String[] values)
        {
            doPrintWithColors(isCreateNewLine, startColor, values);
        }

        public static void PrintError(params String[] values)
        {
            doPrintWithColors(true, ConsoleColor.Red, values);
        }

        private static void doPrintWithColors(Boolean isCreateNewLine, ConsoleColor startColor, params String[] values)
        {
            Console.ForegroundColor = startColor;
            foreach (String value in values)
            {
                if (isCreateNewLine)
                {
                    Console.WriteLine(value);
                }
                else
                {
                    Console.Write(value);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
