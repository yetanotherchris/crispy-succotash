using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLifeWinforms
{
    public class CellRenderer
    {
        Graphics _graphics;
        Bitmap _backBuffer;
        int _gridSize;
        int _cellRectSize;
        int _maxGenerations;
        int _cellCount;
        int _sleepTime;

        public CellRenderer(Graphics graphics, int generationsPerSecond, int maxGenerations, int gridSize, int cellRectSize)
        {
            _graphics = graphics;
            _maxGenerations = maxGenerations;
            _backBuffer = new Bitmap(gridSize * cellRectSize, gridSize * cellRectSize);
            _gridSize = gridSize;
            _cellRectSize = cellRectSize;
            _cellCount = gridSize;
            _cellCount *= _cellCount;

            if (generationsPerSecond > 0)
                _sleepTime = 1000 / generationsPerSecond;
        }

        public void Paint(int generationNumber, List<Point> points)
        {
            Graphics graphics = Graphics.FromImage(_backBuffer);
            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, _gridSize * _cellRectSize, _gridSize * _cellRectSize));
           
			int population = 0;
			foreach (Point point in points)
			{
				Rectangle rectangle = new Rectangle(point.X * _cellRectSize, point.Y * _cellRectSize, _cellRectSize, _cellRectSize);
				graphics.FillRectangle(new SolidBrush(Color.LightGreen), rectangle);
				graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);

				//graphics.FillEllipse(new SolidBrush(Color.LightGreen), rectangle);
				//graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black)), rectangle);
				population++;
			}

            graphics.DrawString(string.Format("Generation: {0}/{1}. Population: {2}. Gridsize: {3}",
                                        generationNumber, _maxGenerations, population, _cellCount),
                                new Font("Arial", 9f),
                                new SolidBrush(Color.Gray), new PointF(5, 5));

            try
            {
                _graphics.DrawImageUnscaled(_backBuffer, 0, 0);
            }
            catch { }

            if (_sleepTime > 0)
                Thread.Sleep(_sleepTime);
        }
    }
}
