using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_5.Entity
{
    class Trainee : Human, IComparable
    {

        private String _EducationalEstablishment;
        private Double[] _Marks;

        public Trainee(string surname, string yearOfBirth, Status status, String educationalEstablishment, Double[] marks) : 
            base(surname, yearOfBirth, status)
        {
            _EducationalEstablishment = educationalEstablishment;
            _Marks = marks;
        }

        public String EducationalEstablishment
        {
            get
            {
                return _EducationalEstablishment;
            }
        }

        public int CompareTo(object obj)
        {
            Trainee t = (Trainee)obj;
            return String.Compare(this.Surname, t.Surname, comparisonType: StringComparison.OrdinalIgnoreCase);
        }

        public override string Svedenija()
        {
            if (_Marks != null)
            {
                double sum = 0;
                foreach (double mark in _Marks)
                {
                    sum = sum + mark;
                }
                return $"{sum / _Marks.Length}";
            }
            return "";
        }
    }
}
