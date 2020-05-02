using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_tasks.Task_2;
using Lab_tasks.Tasks;
using Lab_tasks.Tasks.Utils;

namespace Lab_tasks.Task_2
{
    class Task_2_1 : ITask
    {
        public void runTask()
        {
            for (int i = 0; i < 2; i++)
            {
                CreateAndCalculateFunction();
            }
        }

        private void CreateAndCalculateFunction()
        {
            Function function = new Function();
            Console.Write("Введите параметр А = ");
            function.A = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите параметр В = ");
            function.B = Convert.ToDouble(Console.ReadLine());
            calculateFunctionWithDifferentParams(function);
            calculateFunctionWithTabulation(function);
        }

        private void calculateFunctionWithTabulation(Function function)
        {
            Double xStart;
            Double xEnd;
            Double xStep;
            Function.InputArgs(out xStart, out xEnd, out xStep);
            function.Tabulate(xStart, xEnd, xStep);
        }

        private void calculateFunctionWithDifferentParams(Function function)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Введите x = ");
                Double x = Convert.ToDouble(Console.ReadLine());
                PrintingUtils.PrintCalculationResults(
                    $"Для функции: {function.ToString()} и x = {x}",
                    $"результат = {function.Calculate(x)}");
            }
        }
    }
}
