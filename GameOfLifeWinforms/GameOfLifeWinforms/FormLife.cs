using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifeWinforms
{
	public partial class Form1 : Form
	{
		Thread _thread;
		GameOfLife _gameOfLife;
        static Random _random = new Random();

		public Form1()
		{
			_gameOfLife = new DefaultGameOfLife();

			// Run this in release mode
			InitializeComponent();
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |
						  ControlStyles.UserPaint |
						  ControlStyles.DoubleBuffer, true);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			KillThread();
			base.OnClosing(e);
		}

		private void buttonRun_Click(object sender, EventArgs e)
		{
			int maxGenerations = int.Parse(textBoxGenerations.Text);
			int generationsPerSecond = int.Parse(textBoxGenerationsPerSecond.Text);
			int spawnChanceAtStart = int.Parse(textBoxSpawnPercent.Text);
			int cellSize = int.Parse(textBoxCellSize.Text);

			if (_thread != null)
			{
				if (_thread.ThreadState == ThreadState.Suspended)
				{
					_thread.Resume();
					return;
				}
				else
				{
					KillThread();
				}
			}

            int gridSize = panel1.Width;
            gridSize = (int)Math.Ceiling((double)gridSize / cellSize);


            CellRenderer renderer = new CellRenderer(panel1.CreateGraphics(), 
                                                    generationsPerSecond, 
                                                    maxGenerations,
                                                    gridSize,
                                                    cellSize);

			_gameOfLife.Setup(spawnChanceAtStart, gridSize);

			_thread = new Thread(() =>
			{
                // Generations
			    for (int genNum = 0; genNum < maxGenerations; genNum++)
			    {
					_gameOfLife.NewGeneration(renderer, genNum);
                }
			});
			_thread.Start();
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			KillThread();
		}

		private void buttonPause_Click(object sender, EventArgs e)
		{
			_thread.Suspend();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			KillThread();
			panel1.CreateGraphics().Clear(Color.White);
		}

		private void KillThread()
		{
			if (_thread != null)
			{
				try
				{
					_thread.Join(100);
					_thread.Abort();
				}
				catch { }
			}
		}
	}
}
