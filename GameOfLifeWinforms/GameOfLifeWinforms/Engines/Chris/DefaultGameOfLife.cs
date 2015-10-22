using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeWinforms
{
    public class DefaultGameOfLife : GameOfLife
    {
		int _spawnChanceAtStart;
        Cell[,] _cells;
        int _arraySize;

        static Random _random = new Random();

		public override void Setup(int spawnChanceAtStart, int gridSize)
        {
			_spawnChanceAtStart = spawnChanceAtStart;
			_arraySize = gridSize;
            _cells = new Cell[_arraySize, _arraySize];

            // Populate
            for (int x = 0; x < _arraySize; x++)
            {
                for (int y = 0; y < _arraySize; y++)
                {
                    bool active = _random.Next(1, 100) <= _spawnChanceAtStart;
                    Cell cell = new Cell(x, y, active, _cells);
                    _cells[x, y] = cell;
                }
            }

			System.GC.KeepAlive(_cells);
        }

        public override void NewGeneration(CellRenderer renderer, int generationNumber)
        {
			System.GC.KeepAlive(_cells);

            // Calculate the new state
            List<Point> points = new List<Point>();

            for (int x = 0; x < _arraySize; x++)
            {
				for (int y = 0; y < _arraySize; y++)
				{
					Cell cell = _cells[x, y];

					if (cell.IsAlive)
					{
						points.Add(cell.Point);
					}

					if (cell.ShouldDie())
					{
						cell.DieNextGen();
					}
					else
					{
						cell.LiveNextGen();
					}
				}
            }

			for (int x = 0; x < _arraySize; x++)
			{
				for (int y = 0; y < _arraySize; y++)
				{
					_cells[x, y].UpdateFromLastGen();
				}
			}

            renderer.Paint(generationNumber, points);
        }
    }
}
