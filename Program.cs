using Lab_tasks.Task_1;
using Lab_tasks.Task_2;
using Lab_tasks.Task_5;
using Lab_tasks.Tasks;
using Lab_tasks.Tasks.Task_2;
using Lab_tasks.Tasks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks
{
    class Program
    {
        static Program()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Год:     2020");
            Console.WriteLine("Группа:  ЗИС-20");
            Console.WriteLine("Студент: Иван Акуленко");
            Console.WriteLine("Вариант: 7\n");
        }
        static void Main(string[] args)
        {
            Dictionary<String, ITask> tasks = GetAvailableTasks();
            try
            {
                ExecuteProgram(tasks);
            }
            catch (FormatException e)
            {
                PrintingUtils.PrintError("Неверный ввод данных");
                TryRepeatProgram(tasks);
            }
            catch (OverflowException e)
            {
                PrintingUtils.PrintError("Слишком большое число");
                TryRepeatProgram(tasks);
            }
        }

        private static void ExecuteProgram(Dictionary<String, ITask> tasks)
        {
            String taskNumber = GetTaskNumber();
            if (!tasks.ContainsKey(taskNumber))
            {
                PrintingUtils.PrintError("Такой задачи не существует или формат не соблюден, попробуйте еще раз");
                ExecuteProgram(tasks);
            }
            else
            {
                ITask task;
                tasks.TryGetValue(taskNumber, out task);
                task.runTask();
                TryRepeatProgram(tasks);
            }
        }

        private static void TryRepeatProgram(Dictionary<String, ITask> tasks)
        {
            if (ShouldRepeatProgram())
            {
                ExecuteProgram(tasks);
            }
        }

        private static bool ShouldRepeatProgram()
        {
            Console.Write("Введите '+' для продолжения программы: ");
            String choice = Console.ReadLine();
            return choice.Equals("+");
        }

        private static string GetTaskNumber()
        {
            Console.Write("Введите номер задачи в формате 'задача_подзадача': ");
            return Console.ReadLine();
        }

        private static Dictionary<String, ITask> GetAvailableTasks()
        {
            Dictionary<String, ITask> tasks = new Dictionary<String, ITask>();
            tasks.Add("1_1", new Task_1_1());
            tasks.Add("1_2", new Task_1_2());
            tasks.Add("1_3", new Task_1_3());
            tasks.Add("1_4", new Task_1_4());
            tasks.Add("2_1", new Task_2_1());
            tasks.Add("2_2", new Task_2_2());
            tasks.Add("3_1", new Task_3_1());
            tasks.Add("5_1", new Task_5_1());
            return tasks;
        }
    }
}
