using Lab_tasks.Task_2;
using Lab_tasks.Tasks.Task_2.Entity;
using Lab_tasks.Tasks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_2
{
    class Task_2_2 : ITask
    {
        public void runTask()
        {
            List<QadraticFunction> functions = CreateQuadraticFunctions();
            PrintQuadraticFunctions(functions);
            CompareFunctionsRoots(functions);
            SelectAndChangeFunction(functions);
        }

        private void SelectAndChangeFunction(List<QadraticFunction> functions)
        {
            Console.Write($"Выберете уравнение для изменений (всего уравнений {functions.Count()}): ");
            int index = Int32.Parse(Console.ReadLine());
            if (index > functions.Count)
            {
                PrintingUtils.PrintError("Индекс уравнения больше их количества");
                SelectAndChangeFunction(functions);
                return;
            }
            QadraticFunction func = functions.ElementAt(index - 1);
            ModifyFunction(func);
            String rootsResult;
            GetRootsResult(func, out rootsResult);
            PrintingUtils.PrintCalculationResults($"Корни измененного уравнения {func.ToString()}: {rootsResult}");
        }

        private void ModifyFunction(QadraticFunction qadraticFunction)
        {
            Console.Write("Введите a = ");
            Double a = Double.Parse(Console.ReadLine());
            Console.Write("Введите b = ");
            Double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите c = ");
            Double c = Convert.ToDouble(Console.ReadLine());
            qadraticFunction.A = a;
            qadraticFunction.B = b;
            qadraticFunction.C = c;
        }

        private void CompareFunctionsRoots(List<QadraticFunction> functions)
        {
            QadraticFunction f1 = functions.ElementAt(0);
            QadraticFunction f2 = functions.ElementAt(1);
            QadraticFunction f3 = functions.ElementAt(2);
            Console.WriteLine($"Резльтат сравнение корней второго и третьего уравнения {QadraticFunction.IsRootsEqual(f2, f3)}");
            Console.WriteLine($"Резльтат сравнение корней первого и третьего уравнения {QadraticFunction.IsRootsEqual(f1, f3)}");
        }

        private void PrintQuadraticFunctions(List<QadraticFunction> functions)
        {
            DynamicTable table = new DynamicTable("Квадратные уравнения", new string[] { "Уравнение", "Дискриминант", "Корни" }, new int[] { 30, 30, 30 });
            StringBuilder resultingString = new StringBuilder();
            resultingString.Append(table.TableHead());
            foreach (QadraticFunction func in functions)
            {
                String rootsResult;
                GetRootsResult(func, out rootsResult);
                String[] lineConent = new string[] { func.ToString(), func.GetDiscriminant().ToString(), rootsResult };
                resultingString.Append(table.TableLine(lineConent));
            }
            resultingString.Append(table.TableDown());
            PrintingUtils.PrintCalculationResults(resultingString.ToString());
        }

        private void GetRootsResult(QadraticFunction func, out String rootsResult)
        {
            Double[] roots = func.CalculateRoots();
            if (roots == null)
            {
                rootsResult = "нет решения";
            }
            else
            {
                rootsResult = String.Join(",", roots);
            }
        }

        private List<QadraticFunction> CreateQuadraticFunctions()
        {
            List<QadraticFunction> functions = new List<QadraticFunction>();
            functions.Add(new QadraticFunction(1, 2, 3));
            for (int i = 0; i < 2; i++)
            {
                PopulateQudraticFunctions(functions);
            }
            return functions;
        }

        private void PopulateQudraticFunctions(List<QadraticFunction> functions)
        {
            Console.Write("Введите a = ");
            Double a = Double.Parse(Console.ReadLine());
            Console.Write("Введите b = ");
            Double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите c = ");
            Double c = Convert.ToDouble(Console.ReadLine());
            QadraticFunction func = TryGetQuadraticFunction(a, b, c);
            if (func == null)
            {
                PrintingUtils.PrintError("Ошибка ввода: коэффициенты 'а', 'b' равны 0, 'c' не равно 0");
                PopulateQudraticFunctions(functions);
            }
            else
            {
                functions.Add(func);
                Console.WriteLine(func.ToString());
            }
        }

        private QadraticFunction TryGetQuadraticFunction(double a, double b, double c)
        {
            try
            {
                return new QadraticFunction(a, b, c);
            }
            catch(ArgumentException e) {
                return null;
            }
        }
    }
}
