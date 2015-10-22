using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Reflection;
using System.Resources;
using System.IO;
using System.Threading;

namespace Umbraco.DataExport
{
    /// <summary>
    /// The main form.
    /// </summary>
	public partial class FormMain : Form
    {
        #region Fields
        private ArrayList _tableNames = new ArrayList();
        private ArrayList _identityTables = new ArrayList();
        private BackgroundWorker _worker;
		private bool _cancel;
        private StringBuilder _log = new StringBuilder();
        #endregion

        #region Ctor
        public FormMain()
		{
			InitializeComponent();
			this.InitializeTables();
            this.InitializeIdentityTables();
        }
        #endregion

        #region Initialize tables
        /// <summary>
        /// Setup our list of tables to copy from
        /// </summary>
        private void InitializeTables ()
        {
            _tableNames.Add( "cmsContent" );
            _tableNames.Add( "cmsContentType" );
            _tableNames.Add( "cmsContentTypeAllowedContentType" );
            _tableNames.Add( "cmsContentVersion" );
            _tableNames.Add( "cmsContentXml" );
            _tableNames.Add( "cmsDataType" );
            _tableNames.Add( "cmsDataTypePreValues" );
            _tableNames.Add( "cmsDictionary" );
            _tableNames.Add( "cmsDocument" );
            _tableNames.Add( "cmsDocumentType" );
            _tableNames.Add( "cmsLanguageText" );
            _tableNames.Add( "cmsMacro" );
            _tableNames.Add( "cmsMacroProperty" );
            _tableNames.Add( "cmsMacroPropertyType" );
            _tableNames.Add( "cmsMember" );
            _tableNames.Add( "cmsMember2MemberGroup" );
            _tableNames.Add( "cmsMemberType" );
            _tableNames.Add( "cmsPropertyData" );
            _tableNames.Add( "cmsPropertyType" );
            _tableNames.Add( "cmsStylesheet" );
            _tableNames.Add( "cmsStylesheetProperty" );
            _tableNames.Add( "cmsTab" );
            _tableNames.Add( "cmsTemplate" );
            _tableNames.Add( "umbracoApp" );
            _tableNames.Add( "umbracoAppTree" );
            _tableNames.Add( "umbracoDomains" );
            _tableNames.Add( "umbracoLanguage" );
            _tableNames.Add( "umbracoLog" );
            _tableNames.Add( "umbracoNode" );
            _tableNames.Add( "umbracoRelation" );
            _tableNames.Add( "umbracoRelationType" );
            _tableNames.Add( "umbracoStatEntry" );
            _tableNames.Add( "umbracoStatSession" );
            _tableNames.Add( "umbracoStylesheet" );
            _tableNames.Add( "umbracoStylesheetProperty" );
            _tableNames.Add( "umbracoUser" );
            _tableNames.Add( "umbracoUser2app" );
            _tableNames.Add( "umbracoUser2NodeNotify" );
            _tableNames.Add( "umbracoUser2NodePermission" );
            _tableNames.Add( "umbracoUser2userGroup" );
            _tableNames.Add( "umbracoUserGroup" );
            _tableNames.Add( "umbracoUserLogins" );
            _tableNames.Add( "umbracoUserType" );
        }

        /// <summary>
        /// The list of tables that require INSERT IDENTITY ON/OFF
        /// </summary>
        private void InitializeIdentityTables ()
        {
            _identityTables.Add( "cmsContent" );
            _identityTables.Add( "cmsContentType" );
            _identityTables.Add( "cmsContentVersion" );
            _identityTables.Add( "cmsDataType" );
            _identityTables.Add( "cmsDataTypePreValues" );
            _identityTables.Add( "cmsDictionary" );
            _identityTables.Add( "cmsLanguageText" );
            _identityTables.Add( "cmsMacro" );
            _identityTables.Add( "cmsMacroProperty" );
            _identityTables.Add( "cmsMacroPropertyType" );
            _identityTables.Add( "cmsMemberType" );
            _identityTables.Add( "cmsPropertyData" );
            _identityTables.Add( "cmsPropertyType" );
            _identityTables.Add( "cmsTab" );
            _identityTables.Add( "cmsTemplate" );

            _identityTables.Add( "umbracoDomains" );
            _identityTables.Add( "umbracoLanguage" );
            _identityTables.Add( "umbracoLog" );
            _identityTables.Add( "umbracoNode" );
            _identityTables.Add( "umbracoRelation" );
            _identityTables.Add( "umbracoRelationType" );
            _identityTables.Add( "umbracoStatSession" );
            _identityTables.Add( "umbracoStylesheetProperty" );
            _identityTables.Add( "umbracoUser" );
            _identityTables.Add( "umbacoUserGroup" );
            _identityTables.Add( "umbracoUserType" );
        }
        #endregion

        #region Button clicks
        private void buttonCopy_Click(object sender, EventArgs e)
		{
			//
			// Toggle between Backup and Cancel for the button
			//
			if ( this.buttonBackup.Text == "Cancel" )
			{
                // Cancel clicked
				this.buttonBackup.Text = "Backup";
				this._cancel = true;
				return;
			}
			else
			{
                //
                // Check for valid data
                //
                if ( this.textBoxSource.Text == "" )
                {
                    MessageBox.Show( "Please enter a connection string", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    return;
                }
                else if ( this.textBoxOutputDir.Text == "" )
                {
                    MessageBox.Show( "Please choose a folder to save the SQL scripts to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    return;
                }
                else if ( this.checkBoxDateFormat.Checked && this.textBoxDateFormat.Text == "" )
                {
                    MessageBox.Show( "Please enter a dateformat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    return;
                }

				this.buttonBackup.Text = "Cancel";
				this._cancel = false;

                // Start the worker thread
				_worker = new BackgroundWorker();
				_worker.DoWork += new DoWorkEventHandler( _worker_DoWork );
				_worker.RunWorkerAsync();
			}
		}

        private void buttonDotDot_Click ( object sender, EventArgs e )
        {
            //
            // Select a folder to put the SQL files to
            //
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.Description = "Select a folder to backup the database to";
            if ( dialog.ShowDialog() == DialogResult.OK )
            {
                this.textBoxOutputDir.Text = dialog.SelectedPath;
            }
        }

        private void buttonClose_Click ( object sender, EventArgs e )
        {
            this.Close();
        }

        private void checkBoxDateFormat_CheckedChanged ( object sender, EventArgs e )
        {
            this.textBoxDateFormat.Enabled = this.checkBoxDateFormat.Checked;
        }
        #endregion

        #region Background worker
        private void _worker_DoWork ( object sender, DoWorkEventArgs e )
        {
            this.ScriptUmbraco();
        }
        #endregion

        #region Main scripting routine
        /// <summary>
		/// The bit that does it all.
		/// </summary>
		private void ScriptUmbraco()
		{
            if ( this.InvokeRequired )
            {
                MethodInvoker invoker = new MethodInvoker( this.ScriptUmbraco );
                this.Invoke( invoker );
                return;
            }

            // Some starting variables
            bool scriptDb = this.checkBoxCreate.Checked;
            bool filePerTable = this.checkBoxSingleFile.Checked;
            bool setDateFormat = this.checkBoxDateFormat.Checked;
            string path = this.textBoxOutputDir.Text;
            string sourceDsn = this.textBoxSource.Text;
            bool errors = false;

            // Clear the log
            this.ClearLog();

            //
            // Delete Step1,Step2,Step3
            //
            try
            {
                File.Delete( string.Format( @"{0}\{1}", path, "Step1.sql" ) );
                File.Delete( string.Format( @"{0}\{1}", path, "Step2.sql" ) );
                File.Delete( string.Format( @"{0}\{1}", path, "Step3.sql" ) );
            }
            catch ( IOException e )
            {
                this.Log( e );
                errors = true;
            }

            // This holds the entire insert statement
            StringBuilder insertStmt = new StringBuilder();

            this.toolStripStatusLabel1.Text = "Scripting objects";

            //
            // Script the drop/create objects if asked for
            //
            if ( scriptDb )
            {
                try
                {
                    StreamWriter writer = new StreamWriter( string.Format( @"{0}\{1}", path, "Step1.sql" ), false, Encoding.Unicode );
                    writer.Write(this.GetCreateObjectsSql());
                    writer.WriteLine( "" );
                    writer.WriteLine("/* CREATE VIEWS */");
                    writer.Write(this.GetCreateViewsSql());
                    writer.Close();
                }
                catch ( IOException e )
                {
                    this.Log( e );
                    errors = true;
                }
            }

            // Return if the cancel button is pushed
            if ( this._cancel )
                return;

            // Default the dateformat
            if ( setDateFormat )
                insertStmt.AppendLine( string.Format( "SET DATEFORMAT {0}", this.textBoxDateFormat.Text ) );

            try
            {
                using ( SqlConnection sourceConnection = new SqlConnection( sourceDsn ) )
                {
                    // Open the source
                    sourceConnection.Open();
                    SqlCommand insertCommand = new SqlCommand();

                    // Loop through all tables we have
                    for ( int i = 0; i < _tableNames.Count; i++ )
                    {
                        // Return if the cancel button is pushed
                        if ( this._cancel )
                            return;

                        //
                        // Set up the statements to use
                        //
                        string tableName = _tableNames[i].ToString();
                        string sql = string.Format( "SELECT * FROM {0}", tableName );
                        string identityOn = string.Format( "SET IDENTITY_INSERT [{0}] ON", tableName );
                        string identityOff = string.Format( "SET IDENTITY_INSERT [{0}] OFF", tableName );

                        //
                        // Check for log tables etc. and ignore if set
                        //
                        if ( ( tableName == "umbracoLog" || tableName == "umbracoUserLogins" || tableName == "umbracoStatSession" ) &&
                            this.checkBoxIgnoreLogTable.Checked )
                        {
                                continue;
                        }

                        this.toolStripStatusLabel1.Text = string.Format( "Getting data from {0}", tableName );
                        Application.DoEvents();

                        //
                        // Grab column names for this table
                        //
                        SqlCommand command = new SqlCommand( sql, sourceConnection );

                        SqlDataAdapter adapter = new SqlDataAdapter( command );
                        DataSet ds = new DataSet();
                        adapter.Fill( ds );
                        string colNames = "";

                        for ( int n = 0; n < ds.Tables[0].Columns.Count; n++ )
                        {
                            colNames += "[" + ds.Tables[0].Columns[n].ColumnName + "],";
                        }

                        // Remove the last comma
                        colNames = colNames.Remove( colNames.Length - 1 );

                        //
                        // Work out if the table needs SET_IDENTITY on/off
                        //
                        bool identity = false;
                        if ( this._identityTables.Contains( tableName ) )
                            identity = true;

                        // Get the number of rows in the table, so the toolstrip
                        // can give an indication of progress
                        SqlCommand countCommand = new SqlCommand( string.Format( "SELECT COUNT(*) FROM {0}", tableName ), sourceConnection );
                        int rowCount = (int) countCommand.ExecuteScalar();
                        int j = 0;

                        // Append ON if it has an identity
                        if ( identity && rowCount > 0 )
                            insertStmt.AppendLine( identityOn );

                        //
                        // Go through all rows
                        //
                        SqlDataReader reader = command.ExecuteReader();

                        while ( reader.Read() )
                        {
                            // Return if the cancel button is pushed
                            if ( this._cancel )
                                return;

                            int cols = reader.FieldCount;
                            StringBuilder colVals = new StringBuilder();

                            this.toolStripStatusLabel1.Text = string.Format( "Getting data from {0} {1}/{2}", tableName, j, rowCount );
                            Application.DoEvents();

                            //
                            // Loop through all columns and grab their values
                            //
                            for ( int n = 0; n < cols; n++ )
                            {
                                string comma = ",";

                                // Remove the last comma
                                if ( n == cols - 1 )
                                    comma = "";

                                StringBuilder valBuilder = new StringBuilder();
                                if ( reader[n].GetType() == typeof( Boolean ) )
                                {
                                    if ( (bool) reader[n] )
                                        valBuilder.Append( "1" );
                                    else
                                        valBuilder.Append( "0" );
                                }
                                else if ( reader[n] == DBNull.Value )
                                {
                                    valBuilder.Append( "NULL" );
                                }
                                else
                                {
                                    valBuilder.AppendFormat( "'{0}'", reader[n].ToString().Replace( "'", "''" ) );
                                }

                                colVals.AppendFormat( "{0}{1}", valBuilder.ToString(), comma );
                            }

                            // Add to the big statement
                            insertStmt.AppendFormat( "INSERT INTO {0} ({1}) VALUES ({2})\r\n", tableName, colNames, colVals.ToString() );

                            j++;
                        }

                        // Append OFF if it has an identity
                        if ( identity && rowCount > 0 )
                            insertStmt.AppendLine( identityOff );

                        // Close the reader explicitly
                        reader.Close();

                        // Save to disk
                        if ( filePerTable && insertStmt.Length > 0 )
                        {
                            // Delete any existing
                            File.Delete( string.Format( @"{0}\{1}.sql", path, tableName ) );

                            try
                            {
                                StreamWriter writer = new StreamWriter( string.Format( @"{0}\{1}.sql", path, tableName ), false, Encoding.Unicode );
                                writer.Write( insertStmt.ToString() );
                                writer.Close();

                                // Reset the script buffer
                                insertStmt = new StringBuilder();
                            }
                            catch ( IOException e )
                            {
                                this.Log( e );
                            }

                        }
                    }
                }
            }
            catch ( SqlException e )
            {
                this.Log( e );
                errors = true;
            }

            if ( !errors )
            {
                //
                // Save to single data file
                //
                if ( !filePerTable )
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(string.Format( @"{0}\{1}", path, "Step2.sql" ),false,Encoding.Unicode );
                        writer.Write( insertStmt.ToString() );
                        writer.Close();
                    }
                    catch ( Exception e )
                    {
                        this.Log( e );
                        errors = true;
                    }
                }


                //
                // Script the foreign keys
                //
                if ( scriptDb )
                {
                    this.toolStripStatusLabel1.Text = "Saving data file...";
                    Application.DoEvents();

                    try
                    {
                        StreamWriter writer = new StreamWriter( string.Format( @"{0}\{1}", path, "Step3.sql" ), false, Encoding.Unicode );
                        writer.Write( this.GetCreateKeysSql() );
                        writer.Close();
                    }
                    catch ( IOException e )
                    {
                        this.Log( e );
                        errors = true;
                    }
                }
            }

            this.buttonBackup.Text = "Backup";
            this.buttonBackup.Enabled = true;
            this._cancel = false;

            // Recycle the builder
            insertStmt = new StringBuilder();
            this.toolStripStatusLabel1.Text = "Done";

            //
            // Show the log window if there were errors
            // 
            if ( errors )
            {
                DialogResult result = MessageBox.Show("The backup completed but with errors. It is advised that you don't run any of the scripts unless you expected the errors.\n\n Do you want to see the error log?","Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if ( result == DialogResult.Yes )
                {
                    FormErrorlog formLog = new FormErrorlog(this._log);
                    formLog.Show();
                }
            }
        }
        #endregion

        #region Logging
        private void ClearLog ()
        {
            this._log = new StringBuilder();
        }

        private void Log ( Exception e )
        {
            this._log.AppendLine( string.Format("[{0}] {1}",DateTime.Now.ToString("dd/MM/yy HH:mm"),e.Message) );
        }

        #endregion

        #region Sql script execution
        private string GetCreateObjectsSql ( )
        {
            try
            {
                Stream stream = this.GetType().Assembly.GetManifestResourceStream( "Umbraco.DataExport.Resources.Create2000.sql" );
                StreamReader streamReader = new StreamReader( stream );
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();

                return result;
            }
			catch ( Exception e )
			{
				this.Log( e );
                return "";
			}
        }

        private string GetCreateKeysSql ()
        {
            try
            {
                Stream stream = this.GetType().Assembly.GetManifestResourceStream( "Umbraco.DataExport.Resources.CreateKeys2000.sql" );
                StreamReader streamReader = new StreamReader( stream );
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();

                return result;
            }
            catch ( Exception e )
            {
                this.Log( e );
                return "";
            }
        }

        private string GetCreateViewsSql ()
        {
            try
            {
                Stream stream = this.GetType().Assembly.GetManifestResourceStream( "Umbraco.DataExport.Resources.CreateViews2000.sql" );
                StreamReader streamReader = new StreamReader( stream );
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();

                return result;
            }
            catch ( Exception e )
            {
                this.Log( e );
                return "";
            }
        }
		#endregion
	}
}