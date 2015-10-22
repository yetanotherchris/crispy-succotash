namespace ThreadingExamples
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

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
			this.buttonLaunch = new System.Windows.Forms.Button();
			this.buttonAbort = new System.Windows.Forms.Button();
			this.buttonJoin = new System.Windows.Forms.Button();
			this.buttonInterrupt = new System.Windows.Forms.Button();
			this.buttonEvent = new System.Windows.Forms.Button();
			this.buttonAction = new System.Windows.Forms.Button();
			this.buttonAsync = new System.Windows.Forms.Button();
			this.buttonAsync2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonWeb = new System.Windows.Forms.Button();
			this.buttonBeginInvoke = new System.Windows.Forms.Button();
			this.buttonInvoke = new System.Windows.Forms.Button();
			this.buttonWaitHandle = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonLaunch
			// 
			this.buttonLaunch.Location = new System.Drawing.Point(13, 13);
			this.buttonLaunch.Name = "buttonLaunch";
			this.buttonLaunch.Size = new System.Drawing.Size(75, 23);
			this.buttonLaunch.TabIndex = 0;
			this.buttonLaunch.Text = "Launch";
			this.buttonLaunch.UseVisualStyleBackColor = true;
			this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
			// 
			// buttonAbort
			// 
			this.buttonAbort.Location = new System.Drawing.Point(95, 13);
			this.buttonAbort.Name = "buttonAbort";
			this.buttonAbort.Size = new System.Drawing.Size(75, 23);
			this.buttonAbort.TabIndex = 1;
			this.buttonAbort.Text = "Abort";
			this.buttonAbort.UseVisualStyleBackColor = true;
			this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
			// 
			// buttonJoin
			// 
			this.buttonJoin.Location = new System.Drawing.Point(177, 13);
			this.buttonJoin.Name = "buttonJoin";
			this.buttonJoin.Size = new System.Drawing.Size(75, 23);
			this.buttonJoin.TabIndex = 2;
			this.buttonJoin.Text = "Join";
			this.buttonJoin.UseVisualStyleBackColor = true;
			this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
			// 
			// buttonInterrupt
			// 
			this.buttonInterrupt.Location = new System.Drawing.Point(258, 13);
			this.buttonInterrupt.Name = "buttonInterrupt";
			this.buttonInterrupt.Size = new System.Drawing.Size(75, 23);
			this.buttonInterrupt.TabIndex = 3;
			this.buttonInterrupt.Text = "Interupt";
			this.buttonInterrupt.UseVisualStyleBackColor = true;
			this.buttonInterrupt.Click += new System.EventHandler(this.buttonInterrupt_Click);
			// 
			// buttonEvent
			// 
			this.buttonEvent.Location = new System.Drawing.Point(22, 83);
			this.buttonEvent.Name = "buttonEvent";
			this.buttonEvent.Size = new System.Drawing.Size(75, 23);
			this.buttonEvent.TabIndex = 4;
			this.buttonEvent.Text = "Event";
			this.buttonEvent.UseVisualStyleBackColor = true;
			this.buttonEvent.Click += new System.EventHandler(this.buttonEvent_Click);
			// 
			// buttonAction
			// 
			this.buttonAction.Location = new System.Drawing.Point(122, 82);
			this.buttonAction.Name = "buttonAction";
			this.buttonAction.Size = new System.Drawing.Size(75, 23);
			this.buttonAction.TabIndex = 5;
			this.buttonAction.Text = "Action";
			this.buttonAction.UseVisualStyleBackColor = true;
			this.buttonAction.Click += new System.EventHandler(this.buttonAction_Click);
			// 
			// buttonAsync
			// 
			this.buttonAsync.Location = new System.Drawing.Point(222, 83);
			this.buttonAsync.Name = "buttonAsync";
			this.buttonAsync.Size = new System.Drawing.Size(75, 23);
			this.buttonAsync.TabIndex = 6;
			this.buttonAsync.Text = "ASync";
			this.buttonAsync.UseVisualStyleBackColor = true;
			this.buttonAsync.Click += new System.EventHandler(this.buttonAsync_Click);
			// 
			// buttonAsync2
			// 
			this.buttonAsync2.Location = new System.Drawing.Point(303, 83);
			this.buttonAsync2.Name = "buttonAsync2";
			this.buttonAsync2.Size = new System.Drawing.Size(141, 23);
			this.buttonAsync2.TabIndex = 7;
			this.buttonAsync2.Text = "Async with result";
			this.buttonAsync2.UseVisualStyleBackColor = true;
			this.buttonAsync2.Click += new System.EventHandler(this.buttonAsync2_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(22, 156);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(451, 204);
			this.textBox1.TabIndex = 8;
			// 
			// buttonWeb
			// 
			this.buttonWeb.Location = new System.Drawing.Point(22, 127);
			this.buttonWeb.Name = "buttonWeb";
			this.buttonWeb.Size = new System.Drawing.Size(75, 23);
			this.buttonWeb.TabIndex = 9;
			this.buttonWeb.Text = "HttpRequest";
			this.buttonWeb.UseVisualStyleBackColor = true;
			this.buttonWeb.Click += new System.EventHandler(this.buttonWeb_Click);
			// 
			// buttonBeginInvoke
			// 
			this.buttonBeginInvoke.Location = new System.Drawing.Point(122, 127);
			this.buttonBeginInvoke.Name = "buttonBeginInvoke";
			this.buttonBeginInvoke.Size = new System.Drawing.Size(120, 23);
			this.buttonBeginInvoke.TabIndex = 10;
			this.buttonBeginInvoke.Text = "Control.BeginInvoke";
			this.buttonBeginInvoke.UseVisualStyleBackColor = true;
			this.buttonBeginInvoke.Click += new System.EventHandler(this.buttonBeginInvoke_Click);
			// 
			// buttonInvoke
			// 
			this.buttonInvoke.Location = new System.Drawing.Point(282, 127);
			this.buttonInvoke.Name = "buttonInvoke";
			this.buttonInvoke.Size = new System.Drawing.Size(75, 23);
			this.buttonInvoke.TabIndex = 11;
			this.buttonInvoke.Text = "Invoke";
			this.buttonInvoke.UseVisualStyleBackColor = true;
			this.buttonInvoke.Click += new System.EventHandler(this.buttonInvoke_Click);
			// 
			// buttonWaitHandle
			// 
			this.buttonWaitHandle.Location = new System.Drawing.Point(22, 52);
			this.buttonWaitHandle.Name = "buttonWaitHandle";
			this.buttonWaitHandle.Size = new System.Drawing.Size(91, 23);
			this.buttonWaitHandle.TabIndex = 12;
			this.buttonWaitHandle.Text = "WaitHandle";
			this.buttonWaitHandle.UseVisualStyleBackColor = true;
			this.buttonWaitHandle.Click += new System.EventHandler(this.buttonWaitHandle_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(503, 386);
			this.Controls.Add(this.buttonWaitHandle);
			this.Controls.Add(this.buttonInvoke);
			this.Controls.Add(this.buttonBeginInvoke);
			this.Controls.Add(this.buttonWeb);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonAsync2);
			this.Controls.Add(this.buttonAsync);
			this.Controls.Add(this.buttonAction);
			this.Controls.Add(this.buttonEvent);
			this.Controls.Add(this.buttonInterrupt);
			this.Controls.Add(this.buttonJoin);
			this.Controls.Add(this.buttonAbort);
			this.Controls.Add(this.buttonLaunch);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonLaunch;
		private System.Windows.Forms.Button buttonAbort;
		private System.Windows.Forms.Button buttonJoin;
		private System.Windows.Forms.Button buttonInterrupt;
		private System.Windows.Forms.Button buttonEvent;
		private System.Windows.Forms.Button buttonAction;
		private System.Windows.Forms.Button buttonAsync;
		private System.Windows.Forms.Button buttonAsync2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button buttonWeb;
		private System.Windows.Forms.Button buttonBeginInvoke;
		private System.Windows.Forms.Button buttonInvoke;
		private System.Windows.Forms.Button buttonWaitHandle;
	}
}

