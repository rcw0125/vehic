namespace VehIC_WF.ICManage
{
    using AxSHDocVw;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmWebDialog : Form
    {
        private AxWebBrowser axWebBrowser1;
        private IContainer components = null;
        private string URL = string.Empty;

        public FrmWebDialog(string url)
        {
            this.InitializeComponent();
            this.URL = url;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmWebDialog_Load(object sender, EventArgs e)
        {
            this.axWebBrowser1.Navigate(this.URL);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmWebDialog));
            this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
            this.axWebBrowser1.BeginInit();
            base.SuspendLayout();
            this.axWebBrowser1.Dock = DockStyle.Fill;
            this.axWebBrowser1.Enabled = true;
            this.axWebBrowser1.Location = new Point(0, 0);
            this.axWebBrowser1.OcxState = (AxHost.State) resources.GetObject("axWebBrowser1.OcxState");
            this.axWebBrowser1.Size = new Size(0x35e, 0x23f);
            this.axWebBrowser1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x35e, 0x23f);
            base.Controls.Add(this.axWebBrowser1);
            base.Name = "FrmWebDialog";
            this.Text = "FrmWebDialog";
            base.Load += new EventHandler(this.FrmWebDialog_Load);
            this.axWebBrowser1.EndInit();
            base.ResumeLayout(false);
        }
    }
}

