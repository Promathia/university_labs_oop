using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_5.Entity
{
    class Pupil : Trainee
    {

        private int _ClassNumber;

        public Pupil(string surname, string yearOfBirth, Status status, string educationalEstablishment, int classNumber, double[] marks) : 
            base(surname, yearOfBirth, status, educationalEstablishment, marks)
        {
            _ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return _ClassNumber;
            }
        }
        public override string ToString()
        {
            return $"{Surname};{EducationalEstablishment};{ClassNumber};{Status};{YearOfBirth};{Svedenija()}";
        }
    }
}
