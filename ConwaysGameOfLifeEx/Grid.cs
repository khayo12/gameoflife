using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeEx
{
    public class Grid
    {
        public List<Row> GridObj { set; get; }
        public int ColumnCount { set; get; }
        public Cell this[int x, int y]
        {
            get { if (GridObj.Count <= x || ColumnCount <= y) throw new ArgumentOutOfRangeException("Argument out of bound"); return GridObj[x].Cells[y]; }
            set { if (GridObj.Count <= x || ColumnCount <= y) throw new ArgumentOutOfRangeException("Argument out of bound"); GridObj[x].Cells[y] = value; }
        }
        public Row this[int x]
        {
            get { if (GridObj.Count <= x) throw new ArgumentOutOfRangeException("Argument out of bound"); return GridObj[x]; }
            set { if (GridObj.Count <= x) throw new ArgumentOutOfRangeException("Argument out of bound"); GridObj[x] = value; }
        }
        public Grid(int rows, int columns)
        {
            Setup(rows, columns);
        }
        public int RowCount { get { return GridObj.Count; } }
        private void Setup(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException("Row and Column size must be greater than zero");
            GridObj = new List<Row>();
            for (int i = 0; i < rows; i++)
            {
                Row row = new Row();
                for (int j = 0; j < columns; j++)
                {
                    Cell cell = new Cell(false);
                    row.AddCell(cell);
                }
                GridObj.Add(row);
            }
            ColumnCount = columns;
        }
        public void ReInitialize()
        {
            Setup(RowCount, ColumnCount);
        }
        public void ToggleCell(int x, int y)
        {
            if (GridObj.Count <= x || ColumnCount <= y) throw new ArgumentNullException("Cell doesn't have data for required indexes");
            this[x, y].IsAlive = !this[x, y].IsAlive;
        }
        public void InsertRow(int index, Row row)
        {
            if (index < 0 || index >= RowCount) throw new ArgumentOutOfRangeException("Invalid Index value: must be greater than or equal to zero and less than Row count");
            GridObj.Insert(index, row);
        }
        public void AddRow(Row row)
        {
            GridObj.Add(row);
        }
    }
}
