using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_5.Entity
{
    class Student : Trainee
    {
        private String _Group;

        public Student(string surname, string yearOfBirth, Status status, string educationalEstablishment, string group, double[] marks) :
            base(surname, yearOfBirth, status, educationalEstablishment, marks)
        {
            _Group = group;
        }

        public String Group
        {
            get
            {
                return _Group;
            }
        }
        
        public override string ToString()
        {
            return $"{Surname};{EducationalEstablishment};{Group};{Status};{YearOfBirth};{Svedenija()}";
        }
    }
}
