namespace System.Windows.Forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxBitmap(typeof(LabelWithDivider)), ToolboxItem(true)]
    public class LabelWithDivider : Label
    {
        private int m_gap;

        protected void Draw3DLine(Graphics g, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(SystemPens.ControlDark, x1, y1, x2, y2);
            g.DrawLine(SystemPens.ControlLightLight, x1, y1 + 1, x2, y2 + 1);
        }

        protected HorizontalAlignment GetHorizontalAlignment()
        {
            if (((this.TextAlign == ContentAlignment.TopLeft) || (this.TextAlign == ContentAlignment.MiddleLeft)) || (this.TextAlign == ContentAlignment.BottomLeft))
            {
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    return HorizontalAlignment.Right;
                }
                return HorizontalAlignment.Left;
            }
            if (((this.TextAlign == ContentAlignment.TopRight) || (this.TextAlign == ContentAlignment.MiddleRight)) || (this.TextAlign == ContentAlignment.BottomRight))
            {
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    return HorizontalAlignment.Left;
                }
                return HorizontalAlignment.Right;
            }
            return HorizontalAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.PlaceLine(e.Graphics);
            base.OnPaint(e);
        }

        protected void PlaceLine(Graphics g)
        {
            SizeF ef = g.MeasureString(this.Text, this.Font);
            int num = 0;
            int width = base.Width;
            switch (this.GetHorizontalAlignment())
            {
                case HorizontalAlignment.Left:
                    num = ((int) ef.Width) + this.m_gap;
                    break;

                case HorizontalAlignment.Right:
                    width = (base.Width - ((int) ef.Width)) - this.m_gap;
                    break;

                case HorizontalAlignment.Center:
                    width = ((base.Width - ((int) ef.Width)) / 2) - this.m_gap;
                    break;
            }
            int num3 = ((int) ef.Height) / 2;
            if (((this.TextAlign == ContentAlignment.MiddleLeft) || (this.TextAlign == ContentAlignment.MiddleCenter)) || (this.TextAlign == ContentAlignment.MiddleRight))
            {
                num3 = base.Height / 2;
            }
            else if (((this.TextAlign == ContentAlignment.BottomLeft) || (this.TextAlign == ContentAlignment.BottomCenter)) || (this.TextAlign == ContentAlignment.BottomRight))
            {
                num3 = (base.Height - ((int) (ef.Height / 2f))) - 2;
            }
            this.Draw3DLine(g, num, num3, width, num3);
            if (((this.TextAlign == ContentAlignment.TopCenter) || (this.TextAlign == ContentAlignment.MiddleCenter)) || (this.TextAlign == ContentAlignment.BottomCenter))
            {
                num = ((base.Width + ((int) ef.Width)) / 2) + this.m_gap;
                width = base.Width;
                this.Draw3DLine(g, num, num3, width, num3);
            }
        }

        [DefaultValue(0), Category("Appearance"), Description("Gap between text and divider line."), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Gap
        {
            get
            {
                return this.m_gap;
            }
            set
            {
                this.m_gap = value;
                base.Invalidate();
            }
        }
    }
}

