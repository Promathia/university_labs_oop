using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_tasks.Tasks;
using Lab_tasks.Tasks.Utils;

namespace Lab_tasks.Task_1
{
    class Task_1_1 : ITask
    {
        public void runTask() {
            Console.Write("Введите x = ");
            Double x = Double.Parse(Console.ReadLine());  
            Console.Write("Введите a = ");
            Double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b = ");
            Double b = Convert.ToDouble(Console.ReadLine());
            Double f = -(a / (2 * b)) + ((1.3 + x) / (a + Math.Pow(b, 3)));
            PrintingUtils.PrintCalculationResults(
                $"Для x={x} a={a} b={b}",
                $"f={f}");
        }
    }
}
