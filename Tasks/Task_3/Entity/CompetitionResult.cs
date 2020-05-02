using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Task_3.Entity
{
    class CompetitionResult
    {
        private String _Title;
        private Double _Score;

        public CompetitionResult(string title, double score)
        {
            _Title = title;
            _Score = score;
        }

        public String Title
        {
            get
            {
                return _Title;
            }
        }

        public Double Score
        {
            get
            {
                return _Score;
            }
        }

    }
}
