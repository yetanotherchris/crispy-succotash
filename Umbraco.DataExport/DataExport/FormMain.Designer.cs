namespace Umbraco.DataExport
{
	partial class FormMain
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
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FormMain ) );
            this.buttonBackup = new System.Windows.Forms.Button();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxCreate = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxDateFormat = new System.Windows.Forms.CheckBox();
            this.textBoxDateFormat = new System.Windows.Forms.TextBox();
            this.checkBoxSingleFile = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOutputDir = new System.Windows.Forms.TextBox();
            this.buttonDotDot = new System.Windows.Forms.Button();
            this.checkBoxIgnoreLogTable = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBackup
            // 
            this.buttonBackup.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.buttonBackup.Location = new System.Drawing.Point( 331, 176 );
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size( 75, 23 );
            this.buttonBackup.TabIndex = 0;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler( this.buttonCopy_Click );
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point( 153, 13 );
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size( 344, 21 );
            this.textBoxSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 3, 16 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 142, 13 );
            this.label1.TabIndex = 3;
            this.label1.Text = "Database connection string:";
            // 
            // checkBoxCreate
            // 
            this.checkBoxCreate.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.checkBoxCreate.AutoSize = true;
            this.checkBoxCreate.Checked = true;
            this.checkBoxCreate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCreate.Location = new System.Drawing.Point( 153, 64 );
            this.checkBoxCreate.Name = "checkBoxCreate";
            this.checkBoxCreate.Size = new System.Drawing.Size( 212, 17 );
            this.checkBoxCreate.TabIndex = 6;
            this.checkBoxCreate.Text = "Script create/drop of database objects";
            this.checkBoxCreate.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1} );
            this.statusStrip1.Location = new System.Drawing.Point( 0, 207 );
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size( 502, 22 );
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size( 0, 17 );
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.buttonClose.Location = new System.Drawing.Point( 412, 176 );
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size( 75, 23 );
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler( this.buttonClose_Click );
            // 
            // checkBoxDateFormat
            // 
            this.checkBoxDateFormat.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.checkBoxDateFormat.AutoSize = true;
            this.checkBoxDateFormat.Location = new System.Drawing.Point( 153, 128 );
            this.checkBoxDateFormat.Name = "checkBoxDateFormat";
            this.checkBoxDateFormat.Size = new System.Drawing.Size( 103, 17 );
            this.checkBoxDateFormat.TabIndex = 12;
            this.checkBoxDateFormat.Text = "Set dateformat:";
            this.checkBoxDateFormat.UseVisualStyleBackColor = true;
            this.checkBoxDateFormat.CheckedChanged += new System.EventHandler( this.checkBoxDateFormat_CheckedChanged );
            // 
            // textBoxDateFormat
            // 
            this.textBoxDateFormat.Enabled = false;
            this.textBoxDateFormat.Location = new System.Drawing.Point( 169, 152 );
            this.textBoxDateFormat.Name = "textBoxDateFormat";
            this.textBoxDateFormat.Size = new System.Drawing.Size( 50, 21 );
            this.textBoxDateFormat.TabIndex = 13;
            this.textBoxDateFormat.Text = "dmy";
            // 
            // checkBoxSingleFile
            // 
            this.checkBoxSingleFile.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.checkBoxSingleFile.AutoSize = true;
            this.checkBoxSingleFile.Location = new System.Drawing.Point( 153, 85 );
            this.checkBoxSingleFile.Name = "checkBoxSingleFile";
            this.checkBoxSingleFile.Size = new System.Drawing.Size( 153, 17 );
            this.checkBoxSingleFile.TabIndex = 14;
            this.checkBoxSingleFile.Text = "Make a single file per table";
            this.checkBoxSingleFile.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 3, 40 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 91, 13 );
            this.label3.TabIndex = 16;
            this.label3.Text = "Output directory:";
            // 
            // textBoxOutputDir
            // 
            this.textBoxOutputDir.Location = new System.Drawing.Point( 153, 37 );
            this.textBoxOutputDir.Name = "textBoxOutputDir";
            this.textBoxOutputDir.Size = new System.Drawing.Size( 202, 21 );
            this.textBoxOutputDir.TabIndex = 15;
            // 
            // buttonDotDot
            // 
            this.buttonDotDot.Location = new System.Drawing.Point( 361, 35 );
            this.buttonDotDot.Name = "buttonDotDot";
            this.buttonDotDot.Size = new System.Drawing.Size( 27, 23 );
            this.buttonDotDot.TabIndex = 17;
            this.buttonDotDot.Text = "...";
            this.buttonDotDot.UseVisualStyleBackColor = true;
            this.buttonDotDot.Click += new System.EventHandler( this.buttonDotDot_Click );
            // 
            // checkBoxIgnoreLogTable
            // 
            this.checkBoxIgnoreLogTable.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.checkBoxIgnoreLogTable.AutoSize = true;
            this.checkBoxIgnoreLogTable.Checked = true;
            this.checkBoxIgnoreLogTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreLogTable.Location = new System.Drawing.Point( 153, 105 );
            this.checkBoxIgnoreLogTable.Name = "checkBoxIgnoreLogTable";
            this.checkBoxIgnoreLogTable.Size = new System.Drawing.Size( 183, 17 );
            this.checkBoxIgnoreLogTable.TabIndex = 18;
            this.checkBoxIgnoreLogTable.Text = "Ignore log, stat, userlogin tables";
            this.checkBoxIgnoreLogTable.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 502, 229 );
            this.Controls.Add( this.checkBoxIgnoreLogTable );
            this.Controls.Add( this.buttonDotDot );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.textBoxOutputDir );
            this.Controls.Add( this.checkBoxSingleFile );
            this.Controls.Add( this.textBoxDateFormat );
            this.Controls.Add( this.checkBoxDateFormat );
            this.Controls.Add( this.buttonClose );
            this.Controls.Add( this.statusStrip1 );
            this.Controls.Add( this.checkBoxCreate );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.textBoxSource );
            this.Controls.Add( this.buttonBackup );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Umbraco Data Export Tool";
            this.statusStrip1.ResumeLayout( false );
            this.statusStrip1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxCreate;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.CheckBox checkBoxDateFormat;
        private System.Windows.Forms.TextBox textBoxDateFormat;
        private System.Windows.Forms.CheckBox checkBoxSingleFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOutputDir;
        private System.Windows.Forms.Button buttonDotDot;
        private System.Windows.Forms.CheckBox checkBoxIgnoreLogTable;
	}
}

