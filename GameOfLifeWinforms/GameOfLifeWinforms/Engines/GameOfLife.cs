using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeWinforms
{
	public abstract class GameOfLife
	{
		public abstract void Setup(int spawnChanceAtStart, int gridSize);
		public abstract void NewGeneration(CellRenderer renderer, int generationNumber);
	}
}
