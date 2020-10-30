using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeEx
{
    public class Row
    {
        public List<Cell> Cells { get; set; }
        public Row()
        {
            Cells = new List<Cell>();
        }
        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
        }
        public void InsertCell(int index, Cell cell, int ColumnCount)
        {
            if (index < 0 || index >= ColumnCount) throw new ArgumentOutOfRangeException("Invalid Index value: must be greater than zero and less than Column count");
            Cells.Insert(index, cell);
        }
    }
}
