using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kacper
{
    public class GridStorage
    {
        public int Rows {get; }
        public int Columns { get; }
        public bool[,] JsonCells { get; set; }

        public GridStorage(int Rows, int Columns, bool[,] JsonCells)
        {
            this.Rows = Rows;
            this.Columns = Columns;
            this.JsonCells = JsonCells;
        }
    }
}
