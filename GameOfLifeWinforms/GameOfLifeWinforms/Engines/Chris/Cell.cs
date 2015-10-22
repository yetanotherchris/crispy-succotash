using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeWinforms
{
	public class Cell
	{
		private Cell[,] _cells;
		private Point _point;
		private string _log;
		private bool? _aliveNextGen;

		public bool IsAlive { get; private set; }
		public Point Point
		{
			get { return _point; }
			private set { _point = value; }
		}

		private Cell()
		{
		}

		public Cell(int x, int y, bool isAlive, Cell[,] cells)
		{
			IsAlive = isAlive;

			_point = new Point(x, y);
			_cells = cells;
			_log = "";
			_aliveNextGen = null;
		}

		public Cell Clone()
		{
			Cell cell = new Cell();
			cell.IsAlive = IsAlive;
			cell.Point = Point;
			cell._aliveNextGen = _aliveNextGen;
			cell._cells = _cells;

			return cell;
		}

		public void LiveNextGen()
		{
			_aliveNextGen = true;
		}

		public void DieNextGen()
		{
			_aliveNextGen = false;
		}

		public void UpdateFromLastGen()
		{
			if (_aliveNextGen.HasValue)
				IsAlive = _aliveNextGen.Value;
		}

		public bool ShouldDie()
		{
			IEnumerable<Cell> neighbours = GetNeighbours();
			bool isDead = false;
			int liveNeighbours = neighbours.Count(c => c.IsAlive);

			if (IsAlive)
			{
				_log = "Alive, but no rules applied";

				// 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
				if (liveNeighbours < 2)
				{
					_log = "Alive cell died from rule 1 (under population)";
					isDead = true;
				}

				// 2. Any live cell with two or three live neighbours lives on to the next generation.
				else if (liveNeighbours == 2 || liveNeighbours == 3)
				{
					_log = "Live cell stayed alive from rule 2 (2-3 live neighbours)";
					isDead = false;
				}

				// 3. Any live cell with more than three live neighbours dies, as if by overcrowding.
				else if (liveNeighbours > 3)
				{
					_log = "Live cell died from rule 3 (overcrowding)";
					isDead = true;
				}
			}
			else
			{
				// 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
				if (liveNeighbours == 3)
				{
					_log = "Dead cell came back to life from rule 4 (reproduction)";
					isDead = false;
				}
				else
				{
					_log = "I'm dead";
					isDead = true;
				}
			}

			return isDead;
		}

		public IEnumerable<Cell> GetNeighbours()
		{
			List<Cell> neighbours = new List<Cell>();

			// Clockwise from 9 o'clock
			int x = _point.X;
			int y = _point.Y;

			// L
			if (x > 0)
				neighbours.Add(_cells[x - 1, y]);

			// TL
			if (x > 0 && y > 0)
				neighbours.Add(_cells[x - 1, y - 1]);

			// T
			if (y > 0)
				neighbours.Add(_cells[x, y - 1]);

			// TR
			if (y > 0 && x + 1 < _cells.GetUpperBound(0))
				neighbours.Add(_cells[x + 1, y - 1]);

			// R
			if (x + 1 < _cells.GetUpperBound(0))
				neighbours.Add(_cells[x + 1, y]);

			// BR
			if (x + 1 < _cells.GetUpperBound(0) && y + 1 < _cells.GetUpperBound(1))
				neighbours.Add(_cells[x + 1, y + 1]);

			// B
			if (y + 1 < _cells.GetUpperBound(1))
				neighbours.Add(_cells[x, y + 1]);

			// BL
			if (x > 0 && y + 1 < _cells.GetUpperBound(1))
				neighbours.Add(_cells[x - 1, y + 1]);

			return neighbours;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", _point, _log);
		}
	}
}
