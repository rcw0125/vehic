namespace VehIC_WF.Utility
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ProgressControl : Control
    {
        private Bitmap m_bmp;
        private Brush m_brushBack;
        private Brush m_brushBar;
        private Brush m_brushFore;
        private Brush m_brushShadow;
        private Font m_font;
        private Pen m_penFrame;
        private Pen m_penShadow;
        private int m_position = 0;
        private int m_ticks = 1;

        public ProgressControl()
        {
            base.Hide();
            this.ForeColor = Color.Black;
            this.BackColor = Const.BackColor;
            this.CreateGdiObjects();
        }

        public void Close()
        {
            base.Hide();
            this.Position = 0;
        }

        private void CreateGdiObjects()
        {
            this.m_penShadow = new Pen(Const.BarShadowColor);
            this.m_penFrame = new Pen(Const.BarFrameColor);
            this.m_brushShadow = new SolidBrush(Const.BarShadowColor);
            this.m_brushBack = new SolidBrush(Color.FromArgb(0xe1, 0xe1, 210));
            this.m_brushFore = new SolidBrush(this.ForeColor);
            this.m_brushBar = new SolidBrush(Const.BarColor);
            this.m_font = new Font("Arial", 9f, FontStyle.Regular);
        }

        private void CreateMemoryBitmap()
        {
            if (((this.m_bmp == null) || (this.m_bmp.Width != base.Width)) || (this.m_bmp.Height != base.Height))
            {
                this.m_bmp = new Bitmap(base.Width, base.Height);
            }
        }

        private void DrawFrame(Graphics g)
        {
            g.Clear(this.BackColor);
            Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            g.DrawRectangle(this.m_penShadow, rect);
            rect.Inflate(-1, -1);
            g.DrawRectangle(this.m_penFrame, rect);
        }

        private void DrawProgress(Graphics g)
        {
            Rectangle rect = new Rectangle(10, 10, (base.Width - 4) - 20, 0x12);
            Rectangle rectangle2 = rect;
            rectangle2.Offset(4, 4);
            g.FillRectangle(this.m_brushShadow, rectangle2);
            g.FillRectangle(this.m_brushBack, rect);
            if (this.m_ticks > 0)
            {
                Rectangle rectangle3 = rect;
                rectangle3.Width = (this.m_position * rect.Width) / this.m_ticks;
                g.FillRectangle(this.m_brushBar, rectangle3);
            }
            g.DrawRectangle(this.m_penFrame, rect);
            g.DrawString(this.Text, this.m_font, this.m_brushFore, 10f, (float) (rectangle2.Bottom + 5));
        }

        public void NextPosition(string text)
        {
            this.Text = text;
            this.Position++;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.CreateMemoryBitmap();
            Graphics g = Graphics.FromImage(this.m_bmp);
            this.DrawFrame(g);
            this.DrawProgress(g);
            e.Graphics.DrawImage(this.m_bmp, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            base.Left = 10;
            base.Width = base.Parent.Width - 20;
            base.Top = (base.Parent.Height / 2) + 10;
            base.Height = 60;
            base.BringToFront();
        }

        public void ShowInFront()
        {
            base.BringToFront();
            base.Show();
        }

        public int Position
        {
            get
            {
                return this.m_position;
            }
            set
            {
                this.m_position = Math.Max(0, value);
                this.m_position = Math.Min(this.m_ticks, value);
                base.Invalidate();
                base.Update();
            }
        }

        public int Ticks
        {
            get
            {
                return this.m_ticks;
            }
            set
            {
                this.m_ticks = value;
                base.Invalidate();
                base.Update();
            }
        }

        private class Const
        {
            public static Color BackColor = Color.FromArgb(240, 240, 230);
            public static Color BarColor = Color.FromArgb(160, 100, 0);
            public static Color BarFrameColor = Color.FromArgb(140, 140, 90);
            public const int BarHeight = 0x12;
            public static Color BarShadowColor = Color.FromArgb(80, 80, 50);
            public const int BarShadowSize = 4;
            public const int BufferSpace = 10;
            public const int Height = 60;
            public const string MessageFontName = "Arial";
            public const int MesssageFontSize = 9;
            public const int ParentBufferSpace = 10;
        }
    }
}

