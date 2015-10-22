using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Umbraco.DataExport
{
    public partial class FormErrorlog : Form
    {
        private StringBuilder _log = new StringBuilder();
        public FormErrorlog ()
        {
            InitializeComponent();
        }

        public FormErrorlog ( StringBuilder log ) : this()
        {
            this._log = log;
        }

        private void FormErrorlog_Load ( object sender, EventArgs e )
        {
            this.textBoxLog.Text = _log.ToString();
        }

        private void buttonClose_Click ( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}