using Lab_tasks.Tasks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Task_2
{
    class Function
    {
        private Double _A;
        private Double _B;

        public Double Calculate(Double X) 
        {
            return Math.Abs(X - _A) * (Math.Pow(Math.Sin(_B), 2) + Math.Tan(X));
        }

        public void Tabulate(Double xStart, Double xEnd, Double xStep)
        {
            DynamicTable table = new DynamicTable(ToString(), new String[] { "X", "Result" }, new int[] { 15, 15 });
            StringBuilder resultingString = new StringBuilder();
            resultingString.Append(table.TableHead());
            Double x = xStart;
            Boolean isEndGreater = xStart < xEnd;
            while (isEndGreater ? (x <= xEnd + xStep) : (x >= xEnd - xStep)) 
            {
                resultingString.Append(table.TableLine(new Double[] { x, Math.Round(Calculate(x), 5)}));
                x = isEndGreater ? (x + xStep) : (x - xStep);
            }
            resultingString.Append(table.TableDown());
            PrintingUtils.PrintCalculationResults(resultingString.ToString());
        }

        public static void InputArgs(out Double xStart, out Double xEnd, out Double xStep)
        {
            Console.Write("Введите начальное значение аргумента = ");
            xStart = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите конечное значение аргумента = ");
            xEnd = Convert.ToDouble(Console.ReadLine());
            xStep = 0;
            bool isStepInCorrect = true;
            while (isStepInCorrect)
            {
                Console.Write("Введите шаг изменения аргумента = ");
                xStep = Convert.ToDouble(Console.ReadLine());
                if (xStep > 0)
                {
                    isStepInCorrect = false;
                }
                else
                {
                    PrintingUtils.PrintError("Шаг отрицательный или нулевой! Повторите ввод");
                }
            }
        }

        override public String ToString()
        {
            return $"|x - {_A}|(sin\xB2{_B} + tg x)";
        }

        public Double A 
        {
            get 
            {
                return _A;
            }
            set
            {
                _A = value;
            }
        }

        public Double B
        {
            get
            {
                return _B;
            }

            set
            {
                _B = value;
            }
        }
    }
}
