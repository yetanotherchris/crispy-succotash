using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
	class Program
	{
		static int _generationsPerSecond = 10;
		static int _maxGenerations = 100;
		static int _gridSize = 50;
		static int _birthChanceAtStart = 65; // percentage
		static Cell[,] _cells;

		static Random _random = new Random();

		static void Main(string[] args)
		{
			_cells = new Cell[_gridSize, _gridSize];

			// Population
			for (int x = 0; x < _gridSize; x++)
			{
				for (int y = 0; y < _gridSize; y++)
				{
					bool active = _random.Next(1, 100) <= _birthChanceAtStart;
					Cell cell = new Cell(x, y, active, _cells);
					_cells[x, y] = cell;
				}
			}

			// Generations
			for (int g = 0; g < _maxGenerations; g++)
			{
				Paint(g);
				Thread.Sleep(1000 / _generationsPerSecond);

				for (int x = 0; x < _gridSize; x++)
				{
					for (int y = 0; y < _gridSize; y++)
					{
						Cell cell = _cells[x, y];
						if (cell.IsDead())
							cell.Die();
						else
							cell.Ressurect();
					}
				}
			}
		}

		static void Paint(int generation)
		{
			Console.Clear();

			for (int x = 0; x < _gridSize; x++)
			{
				for (int y = 0; y < _gridSize; y++)
				{
					if (_cells[x, y].IsAlive)
					{
						Console.Write("o");
					}
					else
					{
						Console.Write(" ");
					}

					System.Diagnostics.Debug.WriteLine(_cells[x,y]);	
				}

				Console.WriteLine();
			}

			Console.WriteLine();
			Console.WriteLine();
			Console.Write("Generation: {0}", generation);
		}
	}

	public class Cell
	{
		private Cell[,] _cells;
		private Point _point;
		private string _log;

		public bool IsAlive { get; private set; }

		public Cell(int x, int y, bool isAlive, Cell[,] cells)
		{
			IsAlive = isAlive;

			_point = new Point(x, y);
			_cells = cells;
			_log = "";
		}

		public void Ressurect()
		{
			IsAlive = true;
		}

		public void Die()
		{
			IsAlive = false;
		}

		public bool IsDead()
		{
			IEnumerable<Cell> neighbours = GetNeighbours();
			bool isDead = true;

			if (IsAlive)
			{
				_log = "Alive, but no rules applied";

				int liveNeighbours = neighbours.Count(c => c.IsAlive);

				// 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
				if (liveNeighbours < 2)
				{
					_log = "Alive cell died from rule 1 (under population)";
					isDead = true;
				}

				// 2. Any live cell with two or three live neighbours lives on to the next generation.
				else if (liveNeighbours == 2 || liveNeighbours == 3)
				{
					_log = "Live cell stayed alive from rule 2 (2/3 live neighbours)";
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
				if (neighbours.Count(c => c != null && c.IsAlive) == 3)
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
			if (y > 0 && x+1 < _cells.GetUpperBound(0))
				neighbours.Add(_cells[x+1, y - 1]);

			// R
			if (x + 1 < _cells.GetUpperBound(0))
				neighbours.Add(_cells[x + 1, y]);

			// BR
			if (x + 1 < _cells.GetUpperBound(0) && y +1 < _cells.GetUpperBound(1))
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
			return string.Format("{0} {1}",  _point, _log);
		}
	}
}
