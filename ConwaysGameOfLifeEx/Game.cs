using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeEx
{
    public class Game
    {
        private Grid _inputGrid;
        private Grid _outputGrid;
        public Grid InputGrid { get { return _inputGrid; } }
        public Grid OutputGrid { get { return _outputGrid; } }
        public int MaxGenerations = 1;
        private Task EvaluateCellTask;
        private Task EvaluateGridGrowthTask;
        public int RowCount { get { return InputGrid.RowCount; } }
        public int ColumnCount { get { return InputGrid.ColumnCount; } }
        public Game(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException("Row and Column size must be greater than zero");
            _inputGrid = new Grid(rows, columns);
            _outputGrid = new Grid(rows, columns);
            ReachableCell.InitializeReachableCells();
        }
        public void ToggleGridCell(int x, int y)
        {
            if (_inputGrid.RowCount <= x || _inputGrid.ColumnCount <= y) throw new ArgumentOutOfRangeException("Argument out of bound");
            _inputGrid.ToggleCell(x, y);
        }
        public void Init()
        {
            Start();
        }
        private void Start()
        {
            int currentGeneration = 0;
            GridHelper.Display(_inputGrid);
            do
            {
                currentGeneration++;
                ProcessGeneration();

                Console.WriteLine("Generation: " + currentGeneration);
                GridHelper.Display(_inputGrid);
            } while (currentGeneration < MaxGenerations);
        }
        private void ProcessGeneration()
        {
            SetNextGeneration();
            Tick();
            FlipGridState();
        }
        private void FlipGridState()
        {
            GridHelper.Copy(_outputGrid, _inputGrid);
            _outputGrid.ReInitialize();
        }
        private void Tick()
        {
            if (EvaluateGridGrowthTask != null)
            {
                EvaluateGridGrowthTask.Wait();
            }
        }
        private void SetNextGeneration()
        {
            if ((EvaluateCellTask == null) || (EvaluateCellTask != null && EvaluateCellTask.IsCompleted))
            {
                EvaluateCellTask = ChangeCellsState();
                EvaluateCellTask.Wait();
            }
            if ((EvaluateGridGrowthTask == null) || (EvaluateGridGrowthTask != null && EvaluateGridGrowthTask.IsCompleted))
            {
                EvaluateGridGrowthTask = ChangeGridState();
            }
        }
        private Task ChangeGridState()
        {
            return Task.Factory.StartNew(delegate ()
            {
                Rule.ChangeGridState(_inputGrid, _outputGrid);
            }
            );
        }
        private Task ChangeCellsState()
        {
            return Task.Factory.StartNew(() =>
            Parallel.For(0, _inputGrid.RowCount, x =>
            {
                Parallel.For(0, _inputGrid.ColumnCount, y =>
                {
                    Rule.ChangeCellsState(_inputGrid, _outputGrid, new CoOrdinates(x, y));
                });
            }));
        }
    }
}
