namespace LFY
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(AGauge), "AGauge.bmp"), Description("Displays a value on an analog gauge. Raises an event if the value enters one of the definable ranges."), DefaultEvent("ValueInRangeChanged")]
    public class AGauge : Control
    {
        private IContainer components = null;
        private bool drawGaugeBackground = true;
        private float fontBoundY1;
        private float fontBoundY2;
        private Bitmap gaugeBitmap;
        private Color m_BaseArcColor;
        private int m_BaseArcRadius;
        private int m_BaseArcStart;
        private int m_BaseArcSweep;
        private int m_BaseArcWidth;
        private Color[] m_CapColor;
        private byte m_CapIdx = 1;
        private Point[] m_CapPosition;
        private string[] m_CapText;
        private Point m_Center;
        private float m_MaxValue;
        private float m_MinValue;
        private NeedleColorEnum m_NeedleColor1;
        private Color m_NeedleColor2;
        private int m_NeedleRadius;
        private int m_NeedleType;
        private int m_NeedleWidth;
        private Color[] m_RangeColor;
        private bool[] m_RangeEnabled;
        private float[] m_RangeEndValue;
        private byte m_RangeIdx;
        private int[] m_RangeInnerRadius;
        private int[] m_RangeOuterRadius;
        private float[] m_RangeStartValue;
        private Color m_ScaleLinesInterColor;
        private int m_ScaleLinesInterInnerRadius;
        private int m_ScaleLinesInterOuterRadius;
        private int m_ScaleLinesInterWidth;
        private Color m_ScaleLinesMajorColor;
        private int m_ScaleLinesMajorInnerRadius;
        private int m_ScaleLinesMajorOuterRadius;
        private float m_ScaleLinesMajorStepValue;
        private int m_ScaleLinesMajorWidth;
        private Color m_ScaleLinesMinorColor;
        private int m_ScaleLinesMinorInnerRadius;
        private int m_ScaleLinesMinorNumOf;
        private int m_ScaleLinesMinorOuterRadius;
        private int m_ScaleLinesMinorWidth;
        private Color m_ScaleNumbersColor;
        private string m_ScaleNumbersFormat;
        private int m_ScaleNumbersRadius;
        private int m_ScaleNumbersRotation;
        private int m_ScaleNumbersStartScaleLine;
        private int m_ScaleNumbersStepScaleLines;
        private float m_value;
        private bool[] m_valueIsInRange = new bool[5];
        private const byte NUMOFCAPS = 5;
        private const byte NUMOFRANGES = 5;
        private const byte ZERO = 0;

        [Description("This event is raised if the value falls into a defined range.")]
        public event ValueInRangeChangedDelegate ValueInRangeChanged;

        public AGauge()
        {
            this.m_CapColor = new Color[] { Color.Black, Color.Black, Color.Black, Color.Black, Color.Black };
            this.m_CapText = new string[] { "", "", "", "", "" };
            this.m_CapPosition = new Point[] { new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10) };
            this.m_Center = new Point(100, 100);
            this.m_MinValue = -100f;
            this.m_MaxValue = 400f;
            this.m_BaseArcColor = Color.Gray;
            this.m_BaseArcRadius = 80;
            this.m_BaseArcStart = 0x87;
            this.m_BaseArcSweep = 270;
            this.m_BaseArcWidth = 2;
            this.m_ScaleLinesInterColor = Color.Black;
            this.m_ScaleLinesInterInnerRadius = 0x49;
            this.m_ScaleLinesInterOuterRadius = 80;
            this.m_ScaleLinesInterWidth = 1;
            this.m_ScaleLinesMinorNumOf = 9;
            this.m_ScaleLinesMinorColor = Color.Gray;
            this.m_ScaleLinesMinorInnerRadius = 0x4b;
            this.m_ScaleLinesMinorOuterRadius = 80;
            this.m_ScaleLinesMinorWidth = 1;
            this.m_ScaleLinesMajorStepValue = 50f;
            this.m_ScaleLinesMajorColor = Color.Black;
            this.m_ScaleLinesMajorInnerRadius = 70;
            this.m_ScaleLinesMajorOuterRadius = 80;
            this.m_ScaleLinesMajorWidth = 2;
            bool[] flagArray = new bool[5];
            flagArray[0] = true;
            flagArray[1] = true;
            this.m_RangeEnabled = flagArray;
            this.m_RangeColor = new Color[] { Color.LightGreen, Color.Red, Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control) };
            float[] numArray = new float[5];
            numArray[0] = -100f;
            numArray[1] = 300f;
            this.m_RangeStartValue = numArray;
            numArray = new float[5];
            numArray[0] = 300f;
            numArray[1] = 400f;
            this.m_RangeEndValue = numArray;
            this.m_RangeInnerRadius = new int[] { 70, 70, 70, 70, 70 };
            this.m_RangeOuterRadius = new int[] { 80, 80, 80, 80, 80 };
            this.m_ScaleNumbersRadius = 0x5f;
            this.m_ScaleNumbersColor = Color.Black;
            this.m_ScaleNumbersStepScaleLines = 1;
            this.m_ScaleNumbersRotation = 0;
            this.m_NeedleType = 0;
            this.m_NeedleRadius = 80;
            this.m_NeedleColor1 = NeedleColorEnum.Gray;
            this.m_NeedleColor2 = Color.DimGray;
            this.m_NeedleWidth = 2;
            this.InitializeComponent();
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FindFontBounds()
        {
            int num2;
            SolidBrush brush = new SolidBrush(Color.White);
            SolidBrush brush2 = new SolidBrush(Color.Black);
            Bitmap image = new Bitmap(5, 5);
            SizeF ef = Graphics.FromImage(image).MeasureString("0123456789", this.Font, -1, StringFormat.GenericTypographic);
            image = new Bitmap((int) ef.Width, (int) ef.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.FillRectangle(brush, 0f, 0f, ef.Width, ef.Height);
            graphics.DrawString("0123456789", this.Font, brush2, 0f, 0f, StringFormat.GenericTypographic);
            this.fontBoundY1 = 0f;
            this.fontBoundY2 = 0f;
            int y = 0;
            bool flag = false;
            while ((y < image.Height) && !flag)
            {
                num2 = 0;
                while ((num2 < image.Width) && !flag)
                {
                    if (image.GetPixel(num2, y) != brush.Color)
                    {
                        this.fontBoundY1 = y;
                        flag = true;
                    }
                    num2++;
                }
                y++;
            }
            y = image.Height - 1;
            flag = false;
            while ((0 < y) && !flag)
            {
                for (num2 = 0; (num2 < image.Width) && !flag; num2++)
                {
                    if (image.GetPixel(num2, y) != brush.Color)
                    {
                        this.fontBoundY2 = y;
                        flag = true;
                    }
                }
                y--;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if ((base.Width >= 10) && (base.Height >= 10))
            {
                PointF[] tfArray;
                Brush white;
                Brush brush2;
                Brush brush3;
                Brush brush4;
                Brush brush5;
                if (this.drawGaugeBackground)
                {
                    int num5;
                    this.drawGaugeBackground = false;
                    this.FindFontBounds();
                    this.gaugeBitmap = new Bitmap(base.Width, base.Height, pe.Graphics);
                    Graphics graphics = Graphics.FromImage(this.gaugeBitmap);
                    graphics.FillRectangle(new SolidBrush(this.BackColor), base.ClientRectangle);
                    if (this.BackgroundImage != null)
                    {
                        switch (this.BackgroundImageLayout)
                        {
                            case ImageLayout.None:
                                graphics.DrawImageUnscaled(this.BackgroundImage, 0, 0);
                                break;

                            case ImageLayout.Tile:
                            {
                                int x = 0;
                                int y = 0;
                                while (x < base.Width)
                                {
                                    for (y = 0; y < base.Height; y += this.BackgroundImage.Height)
                                    {
                                        graphics.DrawImageUnscaled(this.BackgroundImage, x, y);
                                    }
                                    x += this.BackgroundImage.Width;
                                }
                                break;
                            }
                            case ImageLayout.Center:
                                graphics.DrawImageUnscaled(this.BackgroundImage, (base.Width / 2) - (this.BackgroundImage.Width / 2), (base.Height / 2) - (this.BackgroundImage.Height / 2));
                                break;

                            case ImageLayout.Stretch:
                                graphics.DrawImage(this.BackgroundImage, 0, 0, base.Width, base.Height);
                                break;

                            case ImageLayout.Zoom:
                                if ((this.BackgroundImage.Width / base.Width) >= (this.BackgroundImage.Height / base.Height))
                                {
                                    graphics.DrawImage(this.BackgroundImage, 0, 0, base.Width, base.Width);
                                    break;
                                }
                                graphics.DrawImage(this.BackgroundImage, 0, 0, base.Height, base.Height);
                                break;
                        }
                    }
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    GraphicsPath path = new GraphicsPath();
                    for (num5 = 0; num5 < 5; num5++)
                    {
                        if ((this.m_RangeEndValue[num5] > this.m_RangeStartValue[num5]) && this.m_RangeEnabled[num5])
                        {
                            float startAngle = this.m_BaseArcStart + (((this.m_RangeStartValue[num5] - this.m_MinValue) * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue));
                            float sweepAngle = ((this.m_RangeEndValue[num5] - this.m_RangeStartValue[num5]) * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue);
                            path.Reset();
                            path.AddPie(new Rectangle(this.m_Center.X - this.m_RangeOuterRadius[num5], this.m_Center.Y - this.m_RangeOuterRadius[num5], 2 * this.m_RangeOuterRadius[num5], 2 * this.m_RangeOuterRadius[num5]), startAngle, sweepAngle);
                            path.Reverse();
                            path.AddPie(new Rectangle(this.m_Center.X - this.m_RangeInnerRadius[num5], this.m_Center.Y - this.m_RangeInnerRadius[num5], 2 * this.m_RangeInnerRadius[num5], 2 * this.m_RangeInnerRadius[num5]), startAngle, sweepAngle);
                            path.Reverse();
                            graphics.SetClip(path);
                            graphics.FillPie(new SolidBrush(this.m_RangeColor[num5]), new Rectangle(this.m_Center.X - this.m_RangeOuterRadius[num5], this.m_Center.Y - this.m_RangeOuterRadius[num5], 2 * this.m_RangeOuterRadius[num5], 2 * this.m_RangeOuterRadius[num5]), startAngle, sweepAngle);
                        }
                    }
                    graphics.SetClip(base.ClientRectangle);
                    if (this.m_BaseArcRadius > 0)
                    {
                        graphics.DrawArc(new Pen(this.m_BaseArcColor, (float) this.m_BaseArcWidth), new Rectangle(this.m_Center.X - this.m_BaseArcRadius, this.m_Center.Y - this.m_BaseArcRadius, 2 * this.m_BaseArcRadius, 2 * this.m_BaseArcRadius), (float) this.m_BaseArcStart, (float) this.m_BaseArcSweep);
                    }
                    string text = "";
                    float num6 = 0f;
                    for (int i = 0; num6 <= (this.m_MaxValue - this.m_MinValue); i++)
                    {
                        text = (this.m_MinValue + num6).ToString(this.m_ScaleNumbersFormat);
                        graphics.ResetTransform();
                        SizeF ef = graphics.MeasureString(text, this.Font, -1, StringFormat.GenericTypographic);
                        path.Reset();
                        path.AddEllipse(new Rectangle(this.m_Center.X - this.m_ScaleLinesMajorOuterRadius, this.m_Center.Y - this.m_ScaleLinesMajorOuterRadius, 2 * this.m_ScaleLinesMajorOuterRadius, 2 * this.m_ScaleLinesMajorOuterRadius));
                        path.Reverse();
                        path.AddEllipse(new Rectangle(this.m_Center.X - this.m_ScaleLinesMajorInnerRadius, this.m_Center.Y - this.m_ScaleLinesMajorInnerRadius, 2 * this.m_ScaleLinesMajorInnerRadius, 2 * this.m_ScaleLinesMajorInnerRadius));
                        path.Reverse();
                        graphics.SetClip(path);
                        graphics.DrawLine(new Pen(this.m_ScaleLinesMajorColor, (float) this.m_ScaleLinesMajorWidth), (float) this.Center.X, (float) this.Center.Y, (float) (this.Center.X + ((2 * this.m_ScaleLinesMajorOuterRadius) * Math.Cos(((this.m_BaseArcStart + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) * 3.1415926535897931) / 180.0))), (float) (this.Center.Y + ((2 * this.m_ScaleLinesMajorOuterRadius) * Math.Sin(((this.m_BaseArcStart + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) * 3.1415926535897931) / 180.0))));
                        path.Reset();
                        path.AddEllipse(new Rectangle(this.m_Center.X - this.m_ScaleLinesMinorOuterRadius, this.m_Center.Y - this.m_ScaleLinesMinorOuterRadius, 2 * this.m_ScaleLinesMinorOuterRadius, 2 * this.m_ScaleLinesMinorOuterRadius));
                        path.Reverse();
                        path.AddEllipse(new Rectangle(this.m_Center.X - this.m_ScaleLinesMinorInnerRadius, this.m_Center.Y - this.m_ScaleLinesMinorInnerRadius, 2 * this.m_ScaleLinesMinorInnerRadius, 2 * this.m_ScaleLinesMinorInnerRadius));
                        path.Reverse();
                        graphics.SetClip(path);
                        if (num6 < (this.m_MaxValue - this.m_MinValue))
                        {
                            for (int j = 1; j <= this.m_ScaleLinesMinorNumOf; j++)
                            {
                                if (((this.m_ScaleLinesMinorNumOf % 2) == 1) && (((this.m_ScaleLinesMinorNumOf / 2) + 1) == j))
                                {
                                    path.Reset();
                                    path.AddEllipse(new Rectangle(this.m_Center.X - this.m_ScaleLinesInterOuterRadius, this.m_Center.Y - this.m_ScaleLinesInterOuterRadius, 2 * this.m_ScaleLinesInterOuterRadius, 2 * this.m_ScaleLinesInterOuterRadius));
                                    path.Reverse();
                                    path.AddEllipse(new Rectangle(this.m_Center.X - this.m_ScaleLinesInterInnerRadius, this.m_Center.Y - this.m_ScaleLinesInterInnerRadius, 2 * this.m_ScaleLinesInterInnerRadius, 2 * this.m_ScaleLinesInterInnerRadius));
                                    path.Reverse();
                                    graphics.SetClip(path);
                                    graphics.DrawLine(new Pen(this.m_ScaleLinesInterColor, (float) this.m_ScaleLinesInterWidth), (float) this.Center.X, (float) this.Center.Y, (float) (this.Center.X + ((2 * this.m_ScaleLinesInterOuterRadius) * Math.Cos((((this.m_BaseArcStart + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) + (((float) (j * this.m_BaseArcSweep)) / (((this.m_MaxValue - this.m_MinValue) / this.m_ScaleLinesMajorStepValue) * (this.m_ScaleLinesMinorNumOf + 1)))) * 3.1415926535897931) / 180.0))), (float) (this.Center.Y + ((2 * this.m_ScaleLinesInterOuterRadius) * Math.Sin((((this.m_BaseArcStart + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) + (((float) (j * this.m_BaseArcSweep)) / (((this.m_MaxValue - this.m_MinValue) / this.m_ScaleLinesMajorStepValue) * (this.m_ScaleLinesMinorNumOf + 1)))) * 3.1415926535897931) / 180.0))));
                                    path.Reset();
                                    path.AddEllipse(new Rectangle(this.m_Center.X - this.m_ScaleLinesMinorOuterRadius, this.m_Center.Y - this.m_ScaleLinesMinorOuterRadius, 2 * this.m_ScaleLinesMinorOuterRadius, 2 * this.m_ScaleLinesMinorOuterRadius));
                                    path.Reverse();
                                    path.AddEllipse(new Rectangle(this.m_Center.X - this.m_ScaleLinesMinorInnerRadius, this.m_Center.Y - this.m_ScaleLinesMinorInnerRadius, 2 * this.m_ScaleLinesMinorInnerRadius, 2 * this.m_ScaleLinesMinorInnerRadius));
                                    path.Reverse();
                                    graphics.SetClip(path);
                                }
                                else
                                {
                                    graphics.DrawLine(new Pen(this.m_ScaleLinesMinorColor, (float) this.m_ScaleLinesMinorWidth), (float) this.Center.X, (float) this.Center.Y, (float) (this.Center.X + ((2 * this.m_ScaleLinesMinorOuterRadius) * Math.Cos((((this.m_BaseArcStart + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) + (((float) (j * this.m_BaseArcSweep)) / (((this.m_MaxValue - this.m_MinValue) / this.m_ScaleLinesMajorStepValue) * (this.m_ScaleLinesMinorNumOf + 1)))) * 3.1415926535897931) / 180.0))), (float) (this.Center.Y + ((2 * this.m_ScaleLinesMinorOuterRadius) * Math.Sin((((this.m_BaseArcStart + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) + (((float) (j * this.m_BaseArcSweep)) / (((this.m_MaxValue - this.m_MinValue) / this.m_ScaleLinesMajorStepValue) * (this.m_ScaleLinesMinorNumOf + 1)))) * 3.1415926535897931) / 180.0))));
                                }
                            }
                        }
                        graphics.SetClip(base.ClientRectangle);
                        if (this.m_ScaleNumbersRotation != 0)
                        {
                            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                            graphics.RotateTransform((90f + this.m_BaseArcStart) + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue)));
                        }
                        graphics.TranslateTransform((float) (this.Center.X + (this.m_ScaleNumbersRadius * Math.Cos(((this.m_BaseArcStart + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) * 3.1415926535897931) / 180.0))), (float) (this.Center.Y + (this.m_ScaleNumbersRadius * Math.Sin(((this.m_BaseArcStart + ((num6 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) * 3.1415926535897931) / 180.0))), MatrixOrder.Append);
                        if (i >= (this.ScaleNumbersStartScaleLine - 1))
                        {
                            graphics.DrawString(text, this.Font, new SolidBrush(this.m_ScaleNumbersColor), -ef.Width / 2f, -this.fontBoundY1 - (((this.fontBoundY2 - this.fontBoundY1) + 1f) / 2f), StringFormat.GenericTypographic);
                        }
                        num6 += this.m_ScaleLinesMajorStepValue;
                    }
                    graphics.ResetTransform();
                    graphics.SetClip(base.ClientRectangle);
                    if (this.m_ScaleNumbersRotation != 0)
                    {
                        graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
                    }
                    for (num5 = 0; num5 < 5; num5++)
                    {
                        if (this.m_CapText[num5] != "")
                        {
                            graphics.DrawString(this.m_CapText[num5], this.Font, new SolidBrush(this.m_CapColor[num5]), (float) this.m_CapPosition[num5].X, (float) this.m_CapPosition[num5].Y, StringFormat.GenericTypographic);
                        }
                    }
                }
                pe.Graphics.DrawImageUnscaled(this.gaugeBitmap, 0, 0);
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                float num9 = (this.m_BaseArcStart + ((int) (((this.m_value - this.m_MinValue) * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue)))) % 360;
                double d = (num9 * 3.1415926535897931) / 180.0;
                switch (this.m_NeedleType)
                {
                    case 0:
                    {
                        tfArray = new PointF[3];
                        white = Brushes.White;
                        brush2 = Brushes.White;
                        brush3 = Brushes.White;
                        brush4 = Brushes.White;
                        brush5 = Brushes.White;
                        int green = (int) ((((num9 + 225f) % 180f) * 100f) / 180f);
                        int num12 = (int) ((((num9 + 135f) % 180f) * 100f) / 180f);
                        pe.Graphics.FillEllipse(new SolidBrush(this.m_NeedleColor2), (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                        switch (this.m_NeedleColor1)
                        {
                            case NeedleColorEnum.Gray:
                                white = new SolidBrush(Color.FromArgb(80 + green, 80 + green, 80 + green));
                                brush2 = new SolidBrush(Color.FromArgb(180 - green, 180 - green, 180 - green));
                                brush3 = new SolidBrush(Color.FromArgb(80 + num12, 80 + num12, 80 + num12));
                                brush4 = new SolidBrush(Color.FromArgb(180 - num12, 180 - num12, 180 - num12));
                                pe.Graphics.DrawEllipse(Pens.Gray, (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                                break;

                            case NeedleColorEnum.Red:
                                white = new SolidBrush(Color.FromArgb(0x91 + green, green, green));
                                brush2 = new SolidBrush(Color.FromArgb(0xf5 - green, 100 - green, 100 - green));
                                brush3 = new SolidBrush(Color.FromArgb(0x91 + num12, num12, num12));
                                brush4 = new SolidBrush(Color.FromArgb(0xf5 - num12, 100 - num12, 100 - num12));
                                pe.Graphics.DrawEllipse(Pens.Red, (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                                break;

                            case NeedleColorEnum.Green:
                                white = new SolidBrush(Color.FromArgb(green, 0x91 + green, green));
                                brush2 = new SolidBrush(Color.FromArgb(100 - green, 0xf5 - green, 100 - green));
                                brush3 = new SolidBrush(Color.FromArgb(num12, 0x91 + num12, num12));
                                brush4 = new SolidBrush(Color.FromArgb(100 - num12, 0xf5 - num12, 100 - num12));
                                pe.Graphics.DrawEllipse(Pens.Green, (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                                break;

                            case NeedleColorEnum.Blue:
                                white = new SolidBrush(Color.FromArgb(green, green, 0x91 + green));
                                brush2 = new SolidBrush(Color.FromArgb(100 - green, 100 - green, 0xf5 - green));
                                brush3 = new SolidBrush(Color.FromArgb(num12, num12, 0x91 + num12));
                                brush4 = new SolidBrush(Color.FromArgb(100 - num12, 100 - num12, 0xf5 - num12));
                                pe.Graphics.DrawEllipse(Pens.Blue, (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                                break;

                            case NeedleColorEnum.Yellow:
                                white = new SolidBrush(Color.FromArgb(0x91 + green, 0x91 + green, green));
                                brush2 = new SolidBrush(Color.FromArgb(0xf5 - green, 0xf5 - green, 100 - green));
                                brush3 = new SolidBrush(Color.FromArgb(0x91 + num12, 0x91 + num12, num12));
                                brush4 = new SolidBrush(Color.FromArgb(0xf5 - num12, 0xf5 - num12, 100 - num12));
                                pe.Graphics.DrawEllipse(Pens.Violet, (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                                break;

                            case NeedleColorEnum.Violet:
                                white = new SolidBrush(Color.FromArgb(0x91 + green, green, 0x91 + green));
                                brush2 = new SolidBrush(Color.FromArgb(0xf5 - green, 100 - green, 0xf5 - green));
                                brush3 = new SolidBrush(Color.FromArgb(0x91 + num12, num12, 0x91 + num12));
                                brush4 = new SolidBrush(Color.FromArgb(0xf5 - num12, 100 - num12, 0xf5 - num12));
                                pe.Graphics.DrawEllipse(Pens.Violet, (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                                break;

                            case NeedleColorEnum.Magenta:
                                white = new SolidBrush(Color.FromArgb(green, 0x91 + green, 0x91 + green));
                                brush2 = new SolidBrush(Color.FromArgb(100 - green, 0xf5 - green, 0xf5 - green));
                                brush3 = new SolidBrush(Color.FromArgb(num12, 0x91 + num12, 0x91 + num12));
                                brush4 = new SolidBrush(Color.FromArgb(100 - num12, 0xf5 - num12, 0xf5 - num12));
                                pe.Graphics.DrawEllipse(Pens.Magenta, (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                                break;
                        }
                        break;
                    }
                    case 1:
                    {
                        Point point = new Point(this.Center.X - ((int) ((this.m_NeedleRadius / 8) * Math.Cos(d))), this.Center.Y - ((int) ((this.m_NeedleRadius / 8) * Math.Sin(d))));
                        Point point2 = new Point(this.Center.X + ((int) (this.m_NeedleRadius * Math.Cos(d))), this.Center.Y + ((int) (this.m_NeedleRadius * Math.Sin(d))));
                        pe.Graphics.FillEllipse(new SolidBrush(this.m_NeedleColor2), (int) (this.Center.X - (this.m_NeedleWidth * 3)), (int) (this.Center.Y - (this.m_NeedleWidth * 3)), (int) (this.m_NeedleWidth * 6), (int) (this.m_NeedleWidth * 6));
                        switch (this.m_NeedleColor1)
                        {
                            case NeedleColorEnum.Gray:
                                pe.Graphics.DrawLine(new Pen(Color.DarkGray, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point2.X, point2.Y);
                                pe.Graphics.DrawLine(new Pen(Color.DarkGray, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point.X, point.Y);
                                return;

                            case NeedleColorEnum.Red:
                                pe.Graphics.DrawLine(new Pen(Color.Red, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point2.X, point2.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Red, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point.X, point.Y);
                                return;

                            case NeedleColorEnum.Green:
                                pe.Graphics.DrawLine(new Pen(Color.Green, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point2.X, point2.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Green, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point.X, point.Y);
                                return;

                            case NeedleColorEnum.Blue:
                                pe.Graphics.DrawLine(new Pen(Color.Blue, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point2.X, point2.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Blue, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point.X, point.Y);
                                return;

                            case NeedleColorEnum.Yellow:
                                pe.Graphics.DrawLine(new Pen(Color.Yellow, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point2.X, point2.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Yellow, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point.X, point.Y);
                                return;

                            case NeedleColorEnum.Violet:
                                pe.Graphics.DrawLine(new Pen(Color.Violet, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point2.X, point2.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Violet, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point.X, point.Y);
                                return;

                            case NeedleColorEnum.Magenta:
                                pe.Graphics.DrawLine(new Pen(Color.Magenta, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point2.X, point2.Y);
                                pe.Graphics.DrawLine(new Pen(Color.Magenta, (float) this.m_NeedleWidth), this.Center.X, this.Center.Y, point.X, point.Y);
                                return;
                        }
                        return;
                    }
                    default:
                        return;
                }
                if (Math.Floor((double) ((float) (((double) ((num9 + 225f) % 360f)) / 180.0))) == 0.0)
                {
                    brush5 = white;
                    white = brush2;
                    brush2 = brush5;
                }
                if (Math.Floor((double) ((float) (((double) ((num9 + 135f) % 360f)) / 180.0))) == 0.0)
                {
                    brush4 = brush3;
                }
                tfArray[0].X = (float) (this.Center.X + (this.m_NeedleRadius * Math.Cos(d)));
                tfArray[0].Y = (float) (this.Center.Y + (this.m_NeedleRadius * Math.Sin(d)));
                tfArray[1].X = (float) (this.Center.X - ((this.m_NeedleRadius / 20) * Math.Cos(d)));
                tfArray[1].Y = (float) (this.Center.Y - ((this.m_NeedleRadius / 20) * Math.Sin(d)));
                tfArray[2].X = (float) ((this.Center.X - ((this.m_NeedleRadius / 5) * Math.Cos(d))) + ((this.m_NeedleWidth * 2) * Math.Cos(d + 1.5707963267948966)));
                tfArray[2].Y = (float) ((this.Center.Y - ((this.m_NeedleRadius / 5) * Math.Sin(d))) + ((this.m_NeedleWidth * 2) * Math.Sin(d + 1.5707963267948966)));
                pe.Graphics.FillPolygon(white, tfArray);
                tfArray[2].X = (float) ((this.Center.X - ((this.m_NeedleRadius / 5) * Math.Cos(d))) + ((this.m_NeedleWidth * 2) * Math.Cos(d - 1.5707963267948966)));
                tfArray[2].Y = (float) ((this.Center.Y - ((this.m_NeedleRadius / 5) * Math.Sin(d))) + ((this.m_NeedleWidth * 2) * Math.Sin(d - 1.5707963267948966)));
                pe.Graphics.FillPolygon(brush2, tfArray);
                tfArray[0].X = (float) (this.Center.X - (((this.m_NeedleRadius / 20) - 1) * Math.Cos(d)));
                tfArray[0].Y = (float) (this.Center.Y - (((this.m_NeedleRadius / 20) - 1) * Math.Sin(d)));
                tfArray[1].X = (float) ((this.Center.X - ((this.m_NeedleRadius / 5) * Math.Cos(d))) + ((this.m_NeedleWidth * 2) * Math.Cos(d + 1.5707963267948966)));
                tfArray[1].Y = (float) ((this.Center.Y - ((this.m_NeedleRadius / 5) * Math.Sin(d))) + ((this.m_NeedleWidth * 2) * Math.Sin(d + 1.5707963267948966)));
                tfArray[2].X = (float) ((this.Center.X - ((this.m_NeedleRadius / 5) * Math.Cos(d))) + ((this.m_NeedleWidth * 2) * Math.Cos(d - 1.5707963267948966)));
                tfArray[2].Y = (float) ((this.Center.Y - ((this.m_NeedleRadius / 5) * Math.Sin(d))) + ((this.m_NeedleWidth * 2) * Math.Sin(d - 1.5707963267948966)));
                pe.Graphics.FillPolygon(brush4, tfArray);
                tfArray[0].X = (float) (this.Center.X - ((this.m_NeedleRadius / 20) * Math.Cos(d)));
                tfArray[0].Y = (float) (this.Center.Y - ((this.m_NeedleRadius / 20) * Math.Sin(d)));
                tfArray[1].X = (float) (this.Center.X + (this.m_NeedleRadius * Math.Cos(d)));
                tfArray[1].Y = (float) (this.Center.Y + (this.m_NeedleRadius * Math.Sin(d)));
                pe.Graphics.DrawLine(new Pen(this.m_NeedleColor2), (float) this.Center.X, (float) this.Center.Y, tfArray[0].X, tfArray[0].Y);
                pe.Graphics.DrawLine(new Pen(this.m_NeedleColor2), (float) this.Center.X, (float) this.Center.Y, tfArray[1].X, tfArray[1].Y);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            this.drawGaugeBackground = true;
            this.Refresh();
        }

        public bool AllowDrop
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public bool AutoSize
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                this.drawGaugeBackground = true;
                this.Refresh();
            }
        }

        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
                this.drawGaugeBackground = true;
                this.Refresh();
            }
        }

        [Browsable(true), Description("The color of the base arc."), Category("AGauge")]
        public Color BaseArcColor
        {
            get
            {
                return this.m_BaseArcColor;
            }
            set
            {
                if (this.m_BaseArcColor != value)
                {
                    this.m_BaseArcColor = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Category("AGauge"), Description("The radius of the base arc.")]
        public int BaseArcRadius
        {
            get
            {
                return this.m_BaseArcRadius;
            }
            set
            {
                if (this.m_BaseArcRadius != value)
                {
                    this.m_BaseArcRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Category("AGauge"), Description("The start angle of the base arc."), Browsable(true)]
        public int BaseArcStart
        {
            get
            {
                return this.m_BaseArcStart;
            }
            set
            {
                if (this.m_BaseArcStart != value)
                {
                    this.m_BaseArcStart = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Category("AGauge"), Description("The sweep angle of the base arc."), Browsable(true)]
        public int BaseArcSweep
        {
            get
            {
                return this.m_BaseArcSweep;
            }
            set
            {
                if (this.m_BaseArcSweep != value)
                {
                    this.m_BaseArcSweep = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The width of the base arc."), Browsable(true), Category("AGauge")]
        public int BaseArcWidth
        {
            get
            {
                return this.m_BaseArcWidth;
            }
            set
            {
                if (this.m_BaseArcWidth != value)
                {
                    this.m_BaseArcWidth = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [RefreshProperties(RefreshProperties.All), Description("The caption index. set this to a value of 0 up to 4 to change the corresponding caption's properties."), Category("AGauge"), Browsable(true)]
        public byte Cap_Idx
        {
            get
            {
                return this.m_CapIdx;
            }
            set
            {
                if (((this.m_CapIdx != value) && (0 <= value)) && (value < 5))
                {
                    this.m_CapIdx = value;
                }
            }
        }

        [Description("The color of the caption text."), Category("AGauge"), Browsable(true)]
        private Color CapColor
        {
            get
            {
                return this.m_CapColor[this.m_CapIdx];
            }
            set
            {
                if (this.m_CapColor[this.m_CapIdx] != value)
                {
                    this.m_CapColor[this.m_CapIdx] = value;
                    this.CapColors = this.m_CapColor;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(false)]
        public Color[] CapColors
        {
            get
            {
                return this.m_CapColor;
            }
            set
            {
                this.m_CapColor = value;
            }
        }

        [Browsable(true), Description("The position of the caption."), Category("AGauge")]
        public Point CapPosition
        {
            get
            {
                return this.m_CapPosition[this.m_CapIdx];
            }
            set
            {
                if (this.m_CapPosition[this.m_CapIdx] != value)
                {
                    this.m_CapPosition[this.m_CapIdx] = value;
                    this.CapsPosition = this.m_CapPosition;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(false)]
        public Point[] CapsPosition
        {
            get
            {
                return this.m_CapPosition;
            }
            set
            {
                this.m_CapPosition = value;
            }
        }

        [Browsable(false)]
        public string[] CapsText
        {
            get
            {
                return this.m_CapText;
            }
            set
            {
                for (int i = 0; i < 5; i++)
                {
                    this.m_CapText[i] = value[i];
                }
            }
        }

        [Category("AGauge"), Browsable(true), Description("The text of the caption.")]
        public string CapText
        {
            get
            {
                return this.m_CapText[this.m_CapIdx];
            }
            set
            {
                if (this.m_CapText[this.m_CapIdx] != value)
                {
                    this.m_CapText[this.m_CapIdx] = value;
                    this.CapsText = this.m_CapText;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Category("AGauge"), Browsable(true), Description("The center of the gauge (in the control's client area).")]
        public Point Center
        {
            get
            {
                return this.m_Center;
            }
            set
            {
                if (this.m_Center != value)
                {
                    this.m_Center = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                this.drawGaugeBackground = true;
                this.Refresh();
            }
        }

        public bool ForeColor
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public bool ImeMode
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        [Browsable(true), Category("AGauge"), Description("The maximum value to show on the scale.")]
        public float MaxValue
        {
            get
            {
                return this.m_MaxValue;
            }
            set
            {
                if ((this.m_MaxValue != value) && (value > this.m_MinValue))
                {
                    this.m_MaxValue = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The minimum value to show on the scale."), Browsable(true), Category("AGauge")]
        public float MinValue
        {
            get
            {
                return this.m_MinValue;
            }
            set
            {
                if ((this.m_MinValue != value) && (value < this.m_MaxValue))
                {
                    this.m_MinValue = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Category("AGauge"), Description("The first color of the needle."), Browsable(true)]
        public NeedleColorEnum NeedleColor1
        {
            get
            {
                return this.m_NeedleColor1;
            }
            set
            {
                if (this.m_NeedleColor1 != value)
                {
                    this.m_NeedleColor1 = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Description("The second color of the needle."), Category("AGauge")]
        public Color NeedleColor2
        {
            get
            {
                return this.m_NeedleColor2;
            }
            set
            {
                if (this.m_NeedleColor2 != value)
                {
                    this.m_NeedleColor2 = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Category("AGauge"), Description("The radius of the needle.")]
        public int NeedleRadius
        {
            get
            {
                return this.m_NeedleRadius;
            }
            set
            {
                if (this.m_NeedleRadius != value)
                {
                    this.m_NeedleRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Category("AGauge"), Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
        public int NeedleType
        {
            get
            {
                return this.m_NeedleType;
            }
            set
            {
                if (this.m_NeedleType != value)
                {
                    this.m_NeedleType = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The width of the needle."), Browsable(true), Category("AGauge")]
        public int NeedleWidth
        {
            get
            {
                return this.m_NeedleWidth;
            }
            set
            {
                if (this.m_NeedleWidth != value)
                {
                    this.m_NeedleWidth = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Description("The range index. set this to a value of 0 up to 4 to change the corresponding range's properties."), Category("AGauge"), RefreshProperties(RefreshProperties.All)]
        public byte Range_Idx
        {
            get
            {
                return this.m_RangeIdx;
            }
            set
            {
                if (((this.m_RangeIdx != value) && (0 <= value)) && (value < 5))
                {
                    this.m_RangeIdx = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Description("The color of the range."), Category("AGauge")]
        public Color RangeColor
        {
            get
            {
                return this.m_RangeColor[this.m_RangeIdx];
            }
            set
            {
                if (this.m_RangeColor[this.m_RangeIdx] != value)
                {
                    this.m_RangeColor[this.m_RangeIdx] = value;
                    this.RangesColor = this.m_RangeColor;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("Enables or disables the range selected by Range_Idx."), Browsable(true), Category("AGauge")]
        public bool RangeEnabled
        {
            get
            {
                return this.m_RangeEnabled[this.m_RangeIdx];
            }
            set
            {
                if (this.m_RangeEnabled[this.m_RangeIdx] != value)
                {
                    this.m_RangeEnabled[this.m_RangeIdx] = value;
                    this.RangesEnabled = this.m_RangeEnabled;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Description("The end value of the range. Must be greater than RangeStartValue."), Category("AGauge")]
        public float RangeEndValue
        {
            get
            {
                return this.m_RangeEndValue[this.m_RangeIdx];
            }
            set
            {
                if ((this.m_RangeEndValue[this.m_RangeIdx] != value) && (this.m_RangeStartValue[this.m_RangeIdx] < value))
                {
                    this.m_RangeEndValue[this.m_RangeIdx] = value;
                    this.RangesEndValue = this.m_RangeEndValue;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Category("AGauge"), Description("The inner radius of the range."), Browsable(true)]
        public int RangeInnerRadius
        {
            get
            {
                return this.m_RangeInnerRadius[this.m_RangeIdx];
            }
            set
            {
                if (this.m_RangeInnerRadius[this.m_RangeIdx] != value)
                {
                    this.m_RangeInnerRadius[this.m_RangeIdx] = value;
                    this.RangesInnerRadius = this.m_RangeInnerRadius;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The inner radius of the range."), Browsable(true), Category("AGauge")]
        public int RangeOuterRadius
        {
            get
            {
                return this.m_RangeOuterRadius[this.m_RangeIdx];
            }
            set
            {
                if (this.m_RangeOuterRadius[this.m_RangeIdx] != value)
                {
                    this.m_RangeOuterRadius[this.m_RangeIdx] = value;
                    this.RangesOuterRadius = this.m_RangeOuterRadius;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(false)]
        public Color[] RangesColor
        {
            get
            {
                return this.m_RangeColor;
            }
            set
            {
                this.m_RangeColor = value;
            }
        }

        [Browsable(false)]
        public bool[] RangesEnabled
        {
            get
            {
                return this.m_RangeEnabled;
            }
            set
            {
                this.m_RangeEnabled = value;
            }
        }

        [Browsable(false)]
        public float[] RangesEndValue
        {
            get
            {
                return this.m_RangeEndValue;
            }
            set
            {
                this.m_RangeEndValue = value;
            }
        }

        [Browsable(false)]
        public int[] RangesInnerRadius
        {
            get
            {
                return this.m_RangeInnerRadius;
            }
            set
            {
                this.m_RangeInnerRadius = value;
            }
        }

        [Browsable(false)]
        public int[] RangesOuterRadius
        {
            get
            {
                return this.m_RangeOuterRadius;
            }
            set
            {
                this.m_RangeOuterRadius = value;
            }
        }

        [Browsable(false)]
        public float[] RangesStartValue
        {
            get
            {
                return this.m_RangeStartValue;
            }
            set
            {
                this.m_RangeStartValue = value;
            }
        }

        [Browsable(true), Category("AGauge"), Description("The start value of the range, must be less than RangeEndValue.")]
        public float RangeStartValue
        {
            get
            {
                return this.m_RangeStartValue[this.m_RangeIdx];
            }
            set
            {
                if ((this.m_RangeStartValue[this.m_RangeIdx] != value) && (value < this.m_RangeEndValue[this.m_RangeIdx]))
                {
                    this.m_RangeStartValue[this.m_RangeIdx] = value;
                    this.RangesStartValue = this.m_RangeStartValue;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The color of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines."), Browsable(true), Category("AGauge")]
        public Color ScaleLinesInterColor
        {
            get
            {
                return this.m_ScaleLinesInterColor;
            }
            set
            {
                if (this.m_ScaleLinesInterColor != value)
                {
                    this.m_ScaleLinesInterColor = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The inner radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines."), Category("AGauge"), Browsable(true)]
        public int ScaleLinesInterInnerRadius
        {
            get
            {
                return this.m_ScaleLinesInterInnerRadius;
            }
            set
            {
                if (this.m_ScaleLinesInterInnerRadius != value)
                {
                    this.m_ScaleLinesInterInnerRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Description("The outer radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines."), Category("AGauge")]
        public int ScaleLinesInterOuterRadius
        {
            get
            {
                return this.m_ScaleLinesInterOuterRadius;
            }
            set
            {
                if (this.m_ScaleLinesInterOuterRadius != value)
                {
                    this.m_ScaleLinesInterOuterRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The width of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines."), Browsable(true), Category("AGauge")]
        public int ScaleLinesInterWidth
        {
            get
            {
                return this.m_ScaleLinesInterWidth;
            }
            set
            {
                if (this.m_ScaleLinesInterWidth != value)
                {
                    this.m_ScaleLinesInterWidth = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Category("AGauge"), Description("The color of the major scale lines.")]
        public Color ScaleLinesMajorColor
        {
            get
            {
                return this.m_ScaleLinesMajorColor;
            }
            set
            {
                if (this.m_ScaleLinesMajorColor != value)
                {
                    this.m_ScaleLinesMajorColor = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The inner radius of the major scale lines."), Browsable(true), Category("AGauge")]
        public int ScaleLinesMajorInnerRadius
        {
            get
            {
                return this.m_ScaleLinesMajorInnerRadius;
            }
            set
            {
                if (this.m_ScaleLinesMajorInnerRadius != value)
                {
                    this.m_ScaleLinesMajorInnerRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The outer radius of the major scale lines."), Browsable(true), Category("AGauge")]
        public int ScaleLinesMajorOuterRadius
        {
            get
            {
                return this.m_ScaleLinesMajorOuterRadius;
            }
            set
            {
                if (this.m_ScaleLinesMajorOuterRadius != value)
                {
                    this.m_ScaleLinesMajorOuterRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The step value of the major scale lines."), Browsable(true), Category("AGauge")]
        public float ScaleLinesMajorStepValue
        {
            get
            {
                return this.m_ScaleLinesMajorStepValue;
            }
            set
            {
                if ((this.m_ScaleLinesMajorStepValue != value) && (value > 0f))
                {
                    this.m_ScaleLinesMajorStepValue = Math.Max(Math.Min(value, this.m_MaxValue), this.m_MinValue);
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The width of the major scale lines."), Browsable(true), Category("AGauge")]
        public int ScaleLinesMajorWidth
        {
            get
            {
                return this.m_ScaleLinesMajorWidth;
            }
            set
            {
                if (this.m_ScaleLinesMajorWidth != value)
                {
                    this.m_ScaleLinesMajorWidth = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The color of the minor scale lines."), Browsable(true), Category("AGauge")]
        public Color ScaleLinesMinorColor
        {
            get
            {
                return this.m_ScaleLinesMinorColor;
            }
            set
            {
                if (this.m_ScaleLinesMinorColor != value)
                {
                    this.m_ScaleLinesMinorColor = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The inner radius of the minor scale lines."), Browsable(true), Category("AGauge")]
        public int ScaleLinesMinorInnerRadius
        {
            get
            {
                return this.m_ScaleLinesMinorInnerRadius;
            }
            set
            {
                if (this.m_ScaleLinesMinorInnerRadius != value)
                {
                    this.m_ScaleLinesMinorInnerRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Description("The number of minor scale lines."), Category("AGauge")]
        public int ScaleLinesMinorNumOf
        {
            get
            {
                return this.m_ScaleLinesMinorNumOf;
            }
            set
            {
                if (this.m_ScaleLinesMinorNumOf != value)
                {
                    this.m_ScaleLinesMinorNumOf = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Category("AGauge"), Description("The outer radius of the minor scale lines.")]
        public int ScaleLinesMinorOuterRadius
        {
            get
            {
                return this.m_ScaleLinesMinorOuterRadius;
            }
            set
            {
                if (this.m_ScaleLinesMinorOuterRadius != value)
                {
                    this.m_ScaleLinesMinorOuterRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Browsable(true), Description("The width of the minor scale lines."), Category("AGauge")]
        public int ScaleLinesMinorWidth
        {
            get
            {
                return this.m_ScaleLinesMinorWidth;
            }
            set
            {
                if (this.m_ScaleLinesMinorWidth != value)
                {
                    this.m_ScaleLinesMinorWidth = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The color of the scale numbers."), Browsable(true), Category("AGauge")]
        public Color ScaleNumbersColor
        {
            get
            {
                return this.m_ScaleNumbersColor;
            }
            set
            {
                if (this.m_ScaleNumbersColor != value)
                {
                    this.m_ScaleNumbersColor = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Category("AGauge"), Browsable(true), Description("The format of the scale numbers.")]
        public string ScaleNumbersFormat
        {
            get
            {
                return this.m_ScaleNumbersFormat;
            }
            set
            {
                if (this.m_ScaleNumbersFormat != value)
                {
                    this.m_ScaleNumbersFormat = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The radius of the scale numbers."), Category("AGauge"), Browsable(true)]
        public int ScaleNumbersRadius
        {
            get
            {
                return this.m_ScaleNumbersRadius;
            }
            set
            {
                if (this.m_ScaleNumbersRadius != value)
                {
                    this.m_ScaleNumbersRadius = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Category("AGauge"), Browsable(true), Description("The angle relative to the tangent of the base arc at a scale line that is used to rotate numbers. set to 0 for no rotation or e.g. set to 90.")]
        public int ScaleNumbersRotation
        {
            get
            {
                return this.m_ScaleNumbersRotation;
            }
            set
            {
                if (this.m_ScaleNumbersRotation != value)
                {
                    this.m_ScaleNumbersRotation = value;
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The number of the scale line to start writing numbers next to."), Category("AGauge"), Browsable(true)]
        public int ScaleNumbersStartScaleLine
        {
            get
            {
                return this.m_ScaleNumbersStartScaleLine;
            }
            set
            {
                if (this.m_ScaleNumbersStartScaleLine != value)
                {
                    this.m_ScaleNumbersStartScaleLine = Math.Max(value, 1);
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Description("The number of scale line steps for writing numbers."), Browsable(true), Category("AGauge")]
        public int ScaleNumbersStepScaleLines
        {
            get
            {
                return this.m_ScaleNumbersStepScaleLines;
            }
            set
            {
                if (this.m_ScaleNumbersStepScaleLines != value)
                {
                    this.m_ScaleNumbersStepScaleLines = Math.Max(value, 1);
                    this.drawGaugeBackground = true;
                    this.Refresh();
                }
            }
        }

        [Category("AGauge"), Description("The value."), Browsable(true)]
        public float Value
        {
            get
            {
                return this.m_value;
            }
            set
            {
                if (this.m_value != value)
                {
                    this.m_value = Math.Min(Math.Max(value, this.m_MinValue), this.m_MaxValue);
                    if (base.DesignMode)
                    {
                        this.drawGaugeBackground = true;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (((this.m_RangeStartValue[i] <= this.m_value) && (this.m_value <= this.m_RangeEndValue[i])) && this.m_RangeEnabled[i])
                        {
                            if (!this.m_valueIsInRange[i] && (this.ValueInRangeChanged != null))
                            {
                                this.ValueInRangeChanged(this, new ValueInRangeChangedEventArgs(i));
                            }
                        }
                        else
                        {
                            this.m_valueIsInRange[i] = false;
                        }
                    }
                    this.Refresh();
                }
            }
        }

        public enum NeedleColorEnum
        {
            Gray,
            Red,
            Green,
            Blue,
            Yellow,
            Violet,
            Magenta
        }

        public delegate void ValueInRangeChangedDelegate(object sender, AGauge.ValueInRangeChangedEventArgs e);

        public class ValueInRangeChangedEventArgs : EventArgs
        {
            public int valueInRange;

            public ValueInRangeChangedEventArgs(int valueInRange)
            {
                this.valueInRange = valueInRange;
            }
        }
    }
}

