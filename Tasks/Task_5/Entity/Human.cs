using Lab_tasks.Tasks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_5.Entity
{
    abstract class Human
    {
        private String _Surname;
        private String _YearOfBirth;
        private Status _Status;

        protected Human(string surname, string yearOfBirth, Status status)
        {
            _Surname = surname;
            _YearOfBirth = yearOfBirth;
            _Status = status;
        }

        public abstract String Svedenija();

        public String Surname
        {
            get
            {
                return _Surname;
            }
        }
        public String YearOfBirth
        {
            get
            {
                return _YearOfBirth;
            }
        }
        public Status Status
        {
            get
            {
                return _Status;
            }
        }

        public override string ToString()
        {
            return $"{_Surname};{_Status};{_YearOfBirth};{Svedenija()}";
        }
    }
}
