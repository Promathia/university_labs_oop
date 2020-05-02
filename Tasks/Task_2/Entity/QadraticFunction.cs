using Lab_tasks.Tasks.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_2.Entity
{
    class QadraticFunction
    {
        private Double _A;
        private Double _B;
        private Double _C;
        private Double Discriminant;
        private Double[] Roots;

        public QadraticFunction()
        {
            //TODO (not clear from the instructions)
        }

        public QadraticFunction(double a, double b, double c)
        {
            ValidateInputs(a, b, c);
            _A = a;
            _B = b;
            _C = c;
        }

        private void ValidateInputs(double a, double b, double c)
        {
            if (a == 0 && b == 0 && c != 0) 
            {
                throw new ArgumentException();
            }
        }

        public Double GetDiscriminant()
        {
            Discriminant = Math.Pow(_B, 2) - 4 * _A * _C;
            return Discriminant;
        }

        public Double[] CalculateRoots()
        {
            Roots = new Double[2];
            Discriminant = GetDiscriminant();
            if (Discriminant > 0)
            {
                Roots[0] = Math.Round((-_B + Math.Sqrt(Discriminant)) / (2 * _A), 5);
                Roots[1] = Math.Round((-_B - Math.Sqrt(Discriminant)) / (2 * _A), 5);
            }
            else if (Discriminant == 0)
            {
                Roots[0] = Roots[1] = -_B / (2 * _A);
            }
            else 
            {
                Roots = null;
            }
            return Roots;
        }

        public static Boolean IsRootsEqual(QadraticFunction f1, QadraticFunction f2)
        {
            if (f1 == f2) //same reference passed
            {
                return true;
            }
            if (f1 == null && f2 == null)
            {
                return true;
            }
            if (f1 == null || f2 == null)
            {
                return false;
            }
            Double[] f1Roots = f1.CalculateRoots();
            Double[] f2Roots = f2.CalculateRoots();
            if (f1Roots == null && f2Roots == null)
            {
                return true;
            }
            if (f1Roots == null || f2Roots == null)
            {
                return false;
            }
            return f1Roots.SequenceEqual(f2Roots);
        }

        override public String ToString()
        {
            return $"{_A}x\xB2 + {_B}x - {_C} = 0";
        }

        public Double A
        {
            set
            {
                _A = value;
            }
        }

        public Double B
        {
            set
            {
                _B = value;
            }
        }

        public Double C
        {
            set
            {
                _C = value;
            }
        }
    }
}
