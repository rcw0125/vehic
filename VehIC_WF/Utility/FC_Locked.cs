namespace VehIC_WF.Utility
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FC_Locked : UserControl
    {
        private IContainer components = null;
        private Panel panel1;

        public FC_Locked()
        {
            this.InitializeComponent();
            this.panel1.Paint += new PaintEventHandler(this.ON_Paint);
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
            this.panel1 = new Panel();
            base.SuspendLayout();
            this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x385, 0x264);
            this.panel1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(8f, 16f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("楷体_GB2312", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Margin = new Padding(4);
            base.Name = "FC_Locked";
            base.Size = new Size(0x385, 0x264);
            base.ResumeLayout(false);
        }

        private void ON_Paint(object sender, PaintEventArgs e)
        {
            string text = "系统已经被锁定";
            Graphics graphics = this.panel1.CreateGraphics();
            Brush black = Brushes.Black;
            Brush white = Brushes.White;
            Font font = new Font("楷体_GB2312", 50f, FontStyle.Regular);
            graphics.Clear(SystemColors.Control);
            SizeF ef = graphics.MeasureString(text, font);
            float x = (base.Width - ef.Width) / 2f;
            float y = (base.Height - ef.Height) / 2f;
            graphics.DrawString(text, font, black, (float) (x + 1f), (float) (y + 1f));
            graphics.DrawString(text, font, white, x, y);
        }
    }
}

