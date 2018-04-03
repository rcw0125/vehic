namespace LFY.Windows.Controls
{
    using LFY.Windows.Controls.Design;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [Designer(typeof(BevelLineDesigner))]
    public class BevelLine : Control
    {
        private int angle;
        private int bevelLineWidth;
        private bool blend;
        private Color bottomLineColor;
        private System.Windows.Forms.Orientation orientation;
        private Color topLineColor;

        public event EventHandler OrientationChanged;

        public BevelLine()
        {
            base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.bevelLineWidth = 1;
            this.topLineColor = SystemColors.ControlDark;
            this.bottomLineColor = SystemColors.ControlLightLight;
            this.orientation = System.Windows.Forms.Orientation.Horizontal;
            this.blend = false;
            this.angle = 90;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle;
            Rectangle rectangle2;
            Rectangle rectangle3;
            Graphics graphics = e.Graphics;
            SolidBrush brush = new SolidBrush(this.topLineColor);
            SolidBrush brush2 = new SolidBrush(this.bottomLineColor);
            if (this.orientation == System.Windows.Forms.Orientation.Horizontal)
            {
                if (this.blend)
                {
                    rectangle = new Rectangle(0, 0, base.Width, base.Height);
                    graphics.FillRectangle(new LinearGradientBrush(rectangle, this.topLineColor, this.bottomLineColor, (float) this.angle, false), rectangle);
                }
                else
                {
                    rectangle2 = new Rectangle(0, 0, base.Width, this.bevelLineWidth);
                    rectangle3 = new Rectangle(0, this.bevelLineWidth, base.Width, this.bevelLineWidth * 2);
                    graphics.FillRectangle(brush, rectangle2);
                    graphics.FillRectangle(brush2, rectangle3);
                }
            }
            else if (this.blend)
            {
                rectangle = new Rectangle(0, 0, base.Width, base.Height);
                graphics.FillRectangle(new LinearGradientBrush(rectangle, this.topLineColor, this.bottomLineColor, (float) this.angle, false), rectangle);
            }
            else
            {
                rectangle2 = new Rectangle(0, 0, this.bevelLineWidth, base.Height);
                rectangle3 = new Rectangle(this.bevelLineWidth, 0, this.bevelLineWidth * 2, base.Height);
                graphics.FillRectangle(brush, rectangle2);
                graphics.FillRectangle(brush2, rectangle3);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.orientation == System.Windows.Forms.Orientation.Horizontal)
            {
                base.Height = this.bevelLineWidth * 2;
            }
            else
            {
                base.Width = this.bevelLineWidth * 2;
            }
            base.Invalidate();
        }

        [Description(""), Browsable(false)]
        public int Angle
        {
            get
            {
                return this.angle;
            }
            set
            {
                this.angle = value;
                base.Invalidate();
            }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        [Description("The width of each line."), DefaultValue(1)]
        public int BevelLineWidth
        {
            get
            {
                return this.bevelLineWidth;
            }
            set
            {
                this.bevelLineWidth = value;
                this.OnResize(null);
            }
        }

        [Description("If true then the two colors will be blended together."), DefaultValue(false)]
        public bool Blend
        {
            get
            {
                return this.blend;
            }
            set
            {
                this.blend = value;
                base.Invalidate();
            }
        }

        [Description(""), DefaultValue(typeof(Color), "ControlLightLight")]
        public Color BottomLineColor
        {
            get
            {
                return this.bottomLineColor;
            }
            set
            {
                this.bottomLineColor = value;
                base.Invalidate();
            }
        }

        [Browsable(false)]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [DefaultValue(0), Description("")]
        public System.Windows.Forms.Orientation Orientation
        {
            get
            {
                return this.orientation;
            }
            set
            {
                this.orientation = value;
                if (this.orientation == System.Windows.Forms.Orientation.Horizontal)
                {
                    base.Width = base.Height;
                    this.Angle = 90;
                }
                else
                {
                    base.Height = base.Width;
                    this.Angle = 0;
                }
                this.OnResize(null);
                if (this.OrientationChanged != null)
                {
                    this.OrientationChanged(this, new EventArgs());
                }
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [DefaultValue(typeof(Color), "ControlDark"), Description("")]
        public Color TopLineColor
        {
            get
            {
                return this.topLineColor;
            }
            set
            {
                this.topLineColor = value;
                base.Invalidate();
            }
        }
    }
}

