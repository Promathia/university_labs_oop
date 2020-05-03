using System;
using System.IO;
using System.Reflection;
using System.Text;
using Lab_tasks.Tasks;
using Lab_tasks.Tasks.Task_5.Entity;
using Lab_tasks.Tasks.Task_5.Service;
using Lab_tasks.Tasks.Task_5.Service.impl;
using Lab_tasks.Tasks.Utils;

namespace Lab_tasks.Task_5
{
    class Task_5_1 : ITask
    {
        public void runTask()
        {
            Human[] people = CreatePeople();
            PrintPeopleInfo(people);
            PrintTrainee(people);
            PrintNonAchievers(people);
            PrintStudentsPretendingForAwards(people);
        }

        private void PrintStudentsPretendingForAwards(Human[] people)
        {
            Console.Write("Введите Средний бал для студентов, претендующих на повышенную стипендию: ");
            Double mark = Convert.ToDouble(Console.ReadLine());
            Human[] students = Array.FindAll(people, p => (p.Status == Status.STUDENT));
            foreach (Student s in students)
            {
                if (Convert.ToDouble(s.Svedenija()) >= mark)
                {
                    PrintingUtils.PrintCalculationResults($"Студент {s.Surname} претендует на повышенную стипендию");
                }
            }
        }

        private void PrintNonAchievers(Human[] people)
        {
            Console.Write("Введите номер школы: ");
            int school = Convert.ToInt32(Console.ReadLine());
            Human[] pupils = Array.FindAll(people, p => (p.Status == Status.PUPIL));
            int counter = 0;
            String[] columnNames = new String[] {
                "Фамилия",
                "Школа",
                "Класс",
                "Статус",
                "Год рождения",
                "Дополнительные сведения" };
            int[] columnSize = new int[] { 20, 20, 15, 20, 15, 50 };
            DynamicTable dynamicTable = new DynamicTable("Список двоечников из заданной школы", columnNames, columnSize);
            PrintingUtils.PrintCalculationResults(false, dynamicTable.TableHead());
            foreach (Pupil p in pupils)
            {
                if (p.EducationalEstablishment.Contains(school.ToString()) && Convert.ToDouble(p.Svedenija()) <= 2)
                {
                    PrintingUtils.PrintCalculationResults(false, dynamicTable.TableLine(p.ToString().Split(';')));
                    counter++;
                }
            }
            PrintingUtils.PrintCalculationResults(false, dynamicTable.TableDown());
            PrintingUtils.PrintCalculationResults($"Всего двоечников: {counter}");
        }

        private void PrintTrainee(Human[] people)
        {
            String[] columnNames = new String[] {
                "Фамилия",
                "Статус"
            };
            int[] columnSize = new int[] { 20, 15 };
            DynamicTable dynamicTable = new DynamicTable("Отсортированный Список учеников", columnNames, columnSize);
            PrintingUtils.PrintCalculationResults(false, dynamicTable.TableHead());
            Human[] trainees = Array.FindAll(people, p => (p.Status == Status.PUPIL || p.Status == Status.STUDENT));
            Array.Sort(trainees);
            foreach (Human human in trainees)
            {
                PrintingUtils.PrintCalculationResults(false, dynamicTable.TableLine(new String[] { human.Surname, human.Status.ToString() }));
            }
            PrintingUtils.PrintCalculationResults(false, dynamicTable.TableDown());
        }

        private void PrintPeopleInfo(Human[] people)
        {
            String[] columnNames = new String[] {
                "Фамилия",
                "Статус",
                "Возраст",
                "Дополнительные сведения" };
            int[] columnSize = new int[] { 20, 15, 15, 50 };
            DynamicTable dynamicTable = new DynamicTable("Список граждан", columnNames, columnSize);
            PrintingUtils.PrintCalculationResults(false, dynamicTable.TableHead());
            DateTime today = DateTime.Today;
            foreach (Human human in people)
            {
                Human casted = (Human)human;
                int year = Convert.ToInt32(human.YearOfBirth);
                if (human.Status == Status.PUPIL && (today.Year - year) > 12)
                {
                    PrintingUtils.PrintWithColor(false, ConsoleColor.Yellow, dynamicTable.TableLine(casted.ToString().Split(';')));
                }
                else
                {
                    PrintingUtils.PrintCalculationResults(false, dynamicTable.TableLine(casted.ToString().Split(';')));
                }
            }
            PrintingUtils.PrintCalculationResults(false, dynamicTable.TableDown());
        }

        private Human[] CreatePeople()
        {
            IHumanCreator creator = new HumanCreatorImpl();
            String[] lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Tasks\Task_5\Resources\input.txt"));
            Human[] people = new Human[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                people[i] = creator.CreateHuman(lines[i]);
            }
            return people;
        }
    }
}