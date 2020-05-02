using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_3.Entity
{
    class Sportsman
    {
        private String _Surname;
        private String _YearOfBirth;
        private CompetitionResult[] _CompetitionResults;

        public Sportsman(string surname, string yearOfBirth, CompetitionResult[] competitionResults)
        {
            _Surname = surname;
            _YearOfBirth = yearOfBirth;
            _CompetitionResults = competitionResults;
        }

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

        public CompetitionResult this[int index]
        {
            get
            {
                return _CompetitionResults[index];
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Sportsman sportsman &&
                   _Surname == sportsman._Surname &&
                   _YearOfBirth == sportsman._YearOfBirth;
        }

        public override int GetHashCode()
        {
            int hashCode = 1150741442;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_YearOfBirth);
            return hashCode;
        }
    }
}
