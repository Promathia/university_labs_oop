using Lab_tasks.Tasks.Task_5.Entity;
using Lab_tasks.Tasks.Utils;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_5.Service.impl
{
    class HumanCreatorImpl : IHumanCreator
    {
        public Human CreateHuman(string line)
        {
            String[] values = line.Split(';');
            String surname = values[0];
            String yearOfBirth = values[1];
            Status status = (Status)Enum.Parse(typeof(Status), values[2], true);
            switch (status) 
            {
                case Status.STUDENT:
                    {
                        return CreateStudentInstance(surname, yearOfBirth, values);
                    }
                case Status.PUPIL:
                    {
                        return CreatePupilInstance(surname, yearOfBirth, values);
                    }
                case Status.WORKER:
                    {
                        return CreateWorkerInstance(surname, yearOfBirth, values);
                    }
                default:
                    {
                        PrintingUtils.PrintError($"Такой статус {values[2]} невозможно создать");
                        return null;
                    } 
            }
        }

        private Human CreateStudentInstance(string surname, string yearOfBirth, string[] values)
        {
            String educationalEstablishment = values[3];
            String group = values[4];
            Double[] marks = Array.ConvertAll(values[5].Split(','), Double.Parse);
            return new Student(surname, yearOfBirth, Status.STUDENT, educationalEstablishment, group, marks);
        }

        private Human CreatePupilInstance(string surname, string yearOfBirth, string[] values)
        {
            String educationalEstablishment = values[3];
            int classNumber = Convert.ToInt32(values[4]);
            Double[] marks = Array.ConvertAll(values[5].Split(','), Double.Parse);
            return new Pupil(surname, yearOfBirth, Status.PUPIL, educationalEstablishment, classNumber, marks);
        }

        private Human CreateWorkerInstance(string surname, string yearOfBirth, string[] values)
        {
            String workLocation = values[3];
            String title = values[4];
            Double[] salary = Array.ConvertAll(values[5].Split(','), Double.Parse);
            if (salary == null || salary.Length < 12)
            {
                PrintingUtils.PrintError($"Работник по фамилии {surname} не дополучил зарплату");
                return null;
            }
            return new Worker(surname, yearOfBirth, Status.WORKER, workLocation, title, salary);
        }
    }
}
