using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_5.Entity
{
    class Worker : Human
    {
        private String _WorkLocation;
        private String _Title;
        private Double[] _YearSalary;

        public Worker(string surname, string yearOfBirth, Status status, String workLocation, String title, Double[] yearSalary) : 
            base(surname, yearOfBirth, status)
        {
            _WorkLocation = workLocation;
            _Title = title;
            _YearSalary = yearSalary;
        }

        public String WorkLocation
        {
            get
            {
                return _WorkLocation;
            }
        }

        public String Title
        {
            get
            {
                return _Title;
            }
        }

        public Double[] YearSalary
        {
            get
            {
                return _YearSalary;
            }
        }

        public override string Svedenija()
        {
            return _YearSalary.Max().ToString();
        }

        public override string ToString()
        {
            return $"{Surname};{WorkLocation};{Title};{Status};{YearOfBirth};{Svedenija()}";
        }
    }
}
