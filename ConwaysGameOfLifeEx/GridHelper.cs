using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeEx
{
    public class GridHelper
    {
        public static void Display(Grid grid)
        {
            foreach (Row row in grid.GridObj)
            {
                foreach (Cell cell in row.Cells)
                {
                    Console.Write(cell.ToString());
                }
                Console.WriteLine();
            }
        }
        public static void Copy(Grid sourceGrid, Grid targetGrid)
        {
            MatchSchema(sourceGrid, targetGrid);
            targetGrid.ReInitialize();
            AssignCellValues(sourceGrid, targetGrid);
        }

        private static void AssignCellValues(Grid sourceGrid, Grid targetGrid)
        {
            for (int i = 0; i < sourceGrid.RowCount; i++)
            {
                for (int j = 0; j < sourceGrid.ColumnCount; j++)
                {
                    targetGrid[i, j].IsAlive = sourceGrid[i, j].IsAlive;
                }
            }
        }

        private static void MatchSchema(Grid sourceGrid, Grid targetGrid)
        {
            while (targetGrid.RowCount < sourceGrid.RowCount)
            {
                Row newRow = new Row();
                for (int k = 0; k < targetGrid.ColumnCount; k++)
                {
                    Cell newCell = new Cell(false);
                    newRow.AddCell(newCell);
                }
                targetGrid.AddRow(newRow);
            }
            while (targetGrid.ColumnCount < sourceGrid.ColumnCount)
            {
                Cell cell = new Cell(false);
                for (int k = 0; k < targetGrid.RowCount; k++)
                {
                    targetGrid[k].AddCell(cell);
                }
                targetGrid.ColumnCount += 1;
            }

        }
    }
}
