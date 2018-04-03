namespace VehIC_WF.Utility
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FC_Head : UserControl
    {
        private IContainer components = null;
      //  public string ErrorInfo = string.Empty;
        private Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
     //   public bool ShowErrorMsg = false;

        public FC_Head()
        {
            this.InitializeComponent();
          //  this.panel1.Paint += new PaintEventHandler(this.ON_Paint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 612);
            this.panel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("楷体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(93, 109);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 48);
            this.labelControl1.TabIndex = 0;
            // 
            // FC_Head
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Name = "FC_Head";
            this.Size = new System.Drawing.Size(901, 612);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        public void ShowMsg(string msg,bool error)
        {
            this.labelControl1.Text = msg;
        }

        //private void ON_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics graphics = this.panel1.CreateGraphics();
        //    graphics.Clear(SystemColors.Control);
        //    if (this.ShowErrorMsg)
        //    {
        //        string errorInfo = this.ErrorInfo;
        //        Brush red = Brushes.Red;
        //        Brush white = Brushes.White;
        //        Font font = new Font("楷体_GB2312", 40f, FontStyle.Regular);
        //        SizeF ef = graphics.MeasureString(errorInfo, font);
        //        float x = (base.Width - ef.Width) / 2f;
        //        float y = (base.Height - ef.Height) / 2f;
        //        graphics.DrawString(errorInfo, font, red, (float) (x + 1f), (float) (y + 1f));
        //        graphics.DrawString(errorInfo, font, white, x, y);
        //    }
        //}
    }
}

