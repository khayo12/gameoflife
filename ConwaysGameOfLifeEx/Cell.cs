using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeEx
{
    public class Cell
    {
        public Boolean IsAlive { get; set; }
        public Cell(Boolean isAlive)
        {
            IsAlive = isAlive;
        }
        public override string ToString()
        {
            return (IsAlive ? " X " : " - ");
        }
    }
}
