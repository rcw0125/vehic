using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehIC_WF
{
    public partial class DlgClassWord : Form
    {
        public DlgClassWord()
        {
            InitializeComponent();
        }

        private string _ClassWord = "";
        public string ClassWord
        {
            get { return _ClassWord; }
            set { _ClassWord = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ClassWord = txtClassWord.Text.Trim();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
