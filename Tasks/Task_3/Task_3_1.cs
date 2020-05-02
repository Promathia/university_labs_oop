using System;
using System.Collections.Generic;
using System.Text;
using Lab_tasks.Tasks;
using Lab_tasks.Tasks.Task_3.Entity;
using Lab_tasks.Tasks.Utils;

namespace Lab_tasks.Task_2
{
    class Task_3_1 : ITask
    {
        private readonly String[] Competitions = new String[] { "Лыжи", "Плавание", "Бег"};
        public void runTask()
        {
            Sportsman[] sportsmen = InitializeSportsMen();
            Dictionary<Sportsman, Double> sportsmenAndAverage = GetSportsmenAndAverageResult(sportsmen);
            PrintSportsmenAndAverageResult(sportsmenAndAverage);
            PrintResultsMoreThenValue(sportsmenAndAverage);
        }

        private void PrintResultsMoreThenValue(Dictionary<Sportsman, double> sportsmenAndAverage)
        {
            Console.Write("Введите среднее значения, для выборки спортсменов, превышающих данное значение: ");
            Double value = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Заданное значение - {value}");
            int averageCounter = 0;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<Sportsman, Double> entry in sportsmenAndAverage)
            {
                if (entry.Value > value)
                {
                    sb.AppendLine($"Спортсмен {entry.Key.Surname} и его среднее значение по соревнованиям: {Math.Round(entry.Value, 3)}");
                    averageCounter++;
                }
            }
            if (averageCounter > 0)
            {
                sb.Append($"Итого количество спортсменов со средним резльтатам больше заданного знаения: {averageCounter}");
            }
            else
            {
                sb.Append("Ни одного спортсмена не найдено");
            }
            PrintingUtils.PrintCalculationResults(sb.ToString());
        }

        private Dictionary<Sportsman, double> GetSportsmenAndAverageResult(Sportsman[] sportsmen)
        {
            Dictionary<Sportsman, double> map = new Dictionary<Sportsman, double>();
            foreach (Sportsman sp in sportsmen)
            {
                map.Add(sp, GetAverageResult(sp));
            }
            return map;
        }

        private void PrintSportsmenAndAverageResult(Dictionary<Sportsman, Double> sportsmenAndResults)
        {
            DynamicTable table = new DynamicTable(
                "Список спортсменов и их средние результаты по соревнованиям",
                new string[] { "Фамилия", "Год рождения", "Средний результат" },
                new int[] { 30, 20, 20});
            StringBuilder sb = new StringBuilder();
            sb.Append(table.TableHead());
            foreach (KeyValuePair<Sportsman, Double> entry in sportsmenAndResults)
            {
                sb.Append(table.TableLine(new string[] { entry.Key.Surname, entry.Key.YearOfBirth, Math.Round(entry.Value, 3).ToString() }));
            }
            sb.Append(table.TableDown());
            PrintingUtils.PrintCalculationResults(sb.ToString());
        }

        private Double GetAverageResult(Sportsman sportsman)
        {
            int totalCompetitions = Competitions.Length;
            Double sumOfScores = 0;
            for (int i = 0; i < totalCompetitions; i++)
            {
                sumOfScores = sumOfScores + sportsman[i].Score;
            }
            return sumOfScores / totalCompetitions;
        }

        private Sportsman[] InitializeSportsMen()
        {
            int count = GetHowManySportsmen();
            Sportsman[] sportsmen = new Sportsman[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write("Введите фамилию спортсмена: ");
                String surname = Console.ReadLine();
                Console.Write("Введите год рождения спортсмена: ");
                String year = Console.ReadLine();
                CompetitionResult[] results = InitializeCompetitionResults(surname);
                sportsmen[i] = new Sportsman(surname, year, results);
            }
            return sportsmen;
        }

        private CompetitionResult[] InitializeCompetitionResults(string surname)
        {
            int totalCompetitions = Competitions.Length;
            CompetitionResult[] results = new CompetitionResult[totalCompetitions];
            for (int i = 0; i < totalCompetitions; i++)
            {
                Console.Write($"Для спортсмена {surname} и соревнования {Competitions[i]} введите рзультат: ");
                Double result = Convert.ToDouble(Console.ReadLine());
                results[i] = new CompetitionResult(Competitions[i], result);
            }
            return results;            
        }

        private int GetHowManySportsmen()
        {
            Console.Write("Введите количество спортсменов: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}