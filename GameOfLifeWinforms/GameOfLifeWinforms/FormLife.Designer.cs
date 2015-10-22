namespace GameOfLifeWinforms
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxCellSize = new System.Windows.Forms.TextBox();
			this.buttonPause = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonRun = new System.Windows.Forms.Button();
			this.textBoxSpawnPercent = new System.Windows.Forms.TextBox();
			this.textBoxGenerationsPerSecond = new System.Windows.Forms.TextBox();
			this.textBoxGenerations = new System.Windows.Forms.TextBox();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(733, 657);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.LightGray;
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.textBoxCellSize);
			this.panel2.Controls.Add(this.buttonPause);
			this.panel2.Controls.Add(this.buttonStop);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.buttonRun);
			this.panel2.Controls.Add(this.textBoxSpawnPercent);
			this.panel2.Controls.Add(this.textBoxGenerationsPerSecond);
			this.panel2.Controls.Add(this.textBoxGenerations);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 586);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(733, 71);
			this.panel2.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(223, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 13);
			this.label4.TabIndex = 20;
			this.label4.Text = "Cell width/height";
			// 
			// textBoxCellSize
			// 
			this.textBoxCellSize.Location = new System.Drawing.Point(344, 41);
			this.textBoxCellSize.Name = "textBoxCellSize";
			this.textBoxCellSize.Size = new System.Drawing.Size(72, 20);
			this.textBoxCellSize.TabIndex = 19;
			this.textBoxCellSize.Text = "6";
			// 
			// buttonPause
			// 
			this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPause.Location = new System.Drawing.Point(565, 38);
			this.buttonPause.Name = "buttonPause";
			this.buttonPause.Size = new System.Drawing.Size(75, 23);
			this.buttonPause.TabIndex = 18;
			this.buttonPause.Text = "Pause";
			this.buttonPause.UseVisualStyleBackColor = true;
			this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStop.Location = new System.Drawing.Point(646, 38);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 17;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(223, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Initial spawn percent";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Generations per second";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Generations";
			// 
			// buttonRun
			// 
			this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRun.Location = new System.Drawing.Point(484, 39);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(75, 23);
			this.buttonRun.TabIndex = 13;
			this.buttonRun.Text = "Run";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
			// 
			// textBoxSpawnPercent
			// 
			this.textBoxSpawnPercent.Location = new System.Drawing.Point(344, 12);
			this.textBoxSpawnPercent.Name = "textBoxSpawnPercent";
			this.textBoxSpawnPercent.Size = new System.Drawing.Size(72, 20);
			this.textBoxSpawnPercent.TabIndex = 12;
			this.textBoxSpawnPercent.Text = "9";
			// 
			// textBoxGenerationsPerSecond
			// 
			this.textBoxGenerationsPerSecond.Location = new System.Drawing.Point(129, 39);
			this.textBoxGenerationsPerSecond.Name = "textBoxGenerationsPerSecond";
			this.textBoxGenerationsPerSecond.Size = new System.Drawing.Size(78, 20);
			this.textBoxGenerationsPerSecond.TabIndex = 11;
			this.textBoxGenerationsPerSecond.Text = "60";
			// 
			// textBoxGenerations
			// 
			this.textBoxGenerations.Location = new System.Drawing.Point(129, 12);
			this.textBoxGenerations.Name = "textBoxGenerations";
			this.textBoxGenerations.Size = new System.Drawing.Size(78, 20);
			this.textBoxGenerations.TabIndex = 10;
			this.textBoxGenerations.Text = "500";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(733, 657);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Life";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button buttonPause;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.TextBox textBoxSpawnPercent;
		private System.Windows.Forms.TextBox textBoxGenerationsPerSecond;
		private System.Windows.Forms.TextBox textBoxGenerations;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxCellSize;
	}
}

