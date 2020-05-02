using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_tasks.Tasks;
using Lab_tasks.Tasks.Utils;

namespace Lab_tasks.Task_1
{
    class Task_1_3 : ITask
    {
        public void runTask() {
            Console.Write("Введите x-начальное = ");
            Double xStart = Double.Parse(Console.ReadLine());  
            Console.Write("Введите x-конечное = ");
            Double xEnd = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите шаг для x = ");
            Double xStep = Convert.ToDouble(Console.ReadLine());
            calculateResultsAndPrint(xStart, xEnd, xStep);
        }

        private void calculateResultsAndPrint(Double xStart, Double xEnd, Double xStep)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("┌───────────────────────────────┐");
            sb.AppendLine("│      x       │        f       │");
            sb.AppendLine("│───────────────────────────────│");
            Double x = xStart;
            while (x <= xEnd)
            {
                Double f = 2.1 + ((Math.Tan(x) - Math.Exp(-(x + 3))) / 1.05);
                sb.AppendFormat("│    {0,6:f2}    │    {1,8:f4}    │\n", x, Math.Round(f, 4));
                x += xStep;
            }
            sb.AppendLine("└───────────────────────────────┘");
            PrintingUtils.PrintCalculationResults(sb.ToString());
        }
    }
}
