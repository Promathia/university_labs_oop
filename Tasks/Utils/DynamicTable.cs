using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tasks.Tasks.Utils
{
    class DynamicTable
    {
        private String _TableHead;
        private String[] _ColNames;
        private int[] _ColSizes;

        public DynamicTable(String TableHead, String[] ColNames, int[] ColSizes)
        {
            _ColNames = ColNames;
            _ColSizes = ColSizes;
            _TableHead = TableHead;
        }

        public String TableHead()
        {
            StringBuilder head = new StringBuilder();
            head.Append($"{_TableHead}\n");
            head.Append("╔");
            for (int i = 0; i < _ColNames.Length; i++)
            {
                for (int y = 0; y < _ColSizes[i]; y++) head.Append("═");
                if (i == _ColNames.Length - 1)
                {
                    head.Append("╗\n");
                }
                else
                {
                    head.Append("╦");
                }
            }
            head.Append("║");
            for (int i = 0; i < _ColNames.Length; i++)
            {
                string s = "{0,-" + _ColSizes[i].ToString() + "}";
                head.AppendFormat(s, _ColNames[i]);
                if (i == _ColNames.Length - 1)
                {
                    head.Append("║\n");
                }
                else
                {
                    head.Append("║");
                }
            }
            head.Append("╠");
            for (int i = 0; i < _ColNames.Length; i++)
            {
                for (int y = 0; y < _ColSizes[i]; y++) head.Append("═");
                if (i == _ColNames.Length - 1)
                {
                    head.Append("╣\n");
                }
                else
                {
                    head.Append("╬");
                }
            }
            return head.ToString();
        }

        public String TableDown()
        {
            StringBuilder down = new StringBuilder();
            down.Append("╚");
            for (int i = 0; i < _ColNames.Length; i++)
            {
                for (int y = 0; y < _ColSizes[i]; y++) down.Append("═");
                if (i == _ColNames.Length - 1)
                {
                    down.Append("╝\n");
                }
                else
                {
                    down.Append("╩");
                }
            }
            return down.ToString();
        }

        public String TableLine(string[] data)
        {
            StringBuilder line = new StringBuilder();
            line.Append("║");
            for (int i = 0; i < _ColNames.Length; i++)
            {
                string s = "{0,-" + _ColSizes[i].ToString() + "}";
                line.AppendFormat(s, data[i]);
                if (i == _ColNames.Length - 1)
                {
                    line.Append("║\n");
                }
                else
                {
                    line.Append("║");
                }
            }
            return line.ToString();
        }

        public String TableLine(double[] data)
        {
            StringBuilder line = new StringBuilder();
            line.Append("║");
            for (int i = 0; i < _ColNames.Length; i++)
            {
                string s = "{0,-" + _ColSizes[i].ToString() + "}";
                line.AppendFormat(s, data[i]);
                if (i == _ColNames.Length - 1)
                {
                    line.Append("║\n");
                }
                else
                {
                    line.Append("║");
                }
            }
            return line.ToString();
        }
    }
}

