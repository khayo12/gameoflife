using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeEx
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the height of the board");
                var x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the width of the board");
                var y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the number of generations");
                var gen = Convert.ToInt32(Console.ReadLine());
                Game objLifeGame = new Game(x, y);
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        objLifeGame.ToggleGridCell(i, j);
                    }
                }
                objLifeGame.MaxGenerations = gen;
                objLifeGame.Init();
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. " + e);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
