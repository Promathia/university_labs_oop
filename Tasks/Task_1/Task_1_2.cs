using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_tasks.Tasks;
using Lab_tasks.Tasks.Utils;

namespace Lab_tasks.Task_1
{
    class Task_1_2 : ITask
    {
        public void runTask() {
            Double f;
            Console.Write("Введите x = ");
            Double x = Double.Parse(Console.ReadLine());  
            Console.Write("Введите z = ");
            Double z = Convert.ToDouble(Console.ReadLine());
            if (z >= 0)
            {
                f = (1.3 + z) / (x + Math.Pow(z, 3));
            }
            else if (z > -6 && z < -3)
            {
                f = 3 * Math.Pow((z + x), 2);
            }
            else {
                f = -(z / 2 * x);
            }
            PrintingUtils.PrintCalculationResults(
                $"Для x={x} z={z}", 
                $"f={f}");
        }
    }
}
