using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_tasks.Tasks;
using Lab_tasks.Tasks.Utils;

namespace Lab_tasks.Task_1
{
    class Task_1_4 : ITask
    {
        public void runTask() {
            Console.WriteLine("Введите, сколько раз необходимо вычеслить функцию:");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++) {
                calculateAndPrintResult(readInput());
            }
        }

        private void calculateAndPrintResult(List<Double> vars) {
            Double x = vars.ElementAt(0), y = vars.ElementAt(1), z = vars.ElementAt(0);
            Double f = (Math.Pow(Math.Sin(z), 2) + Math.Tan(z)) - (Math.Sqrt(Math.Abs(x - y)) / 2.1);
            PrintingUtils.PrintCalculationResults(
                $"Для x={x} y={y} z={z}",
                $"f={f}");
        }

        private List<Double> readInput() {
            List<Double> result = new List<Double>();
            Console.Write("Введите x = ");
            result.Add(Double.Parse(Console.ReadLine()));
            Console.Write("Введите y = ");
            result.Add(Convert.ToDouble(Console.ReadLine()));
            Console.Write("Введите z = ");
            result.Add(Convert.ToDouble(Console.ReadLine()));
            return result;
        } 
    }
}
