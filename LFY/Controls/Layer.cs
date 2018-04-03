namespace LFY.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Text;

    internal class Layer : ICloneable
    {
        internal FastBitmap _bitmap;
        private FastBitmap _mask;
        private int _offsetx;
        private int _offsety;
        public double _opacity;

        public Layer(FastBitmap bitmap)
        {
            this._bitmap = bitmap;
            this._opacity = 1.0;
        }

        public Layer(int width, int height)
        {
            this._bitmap = new FastBitmap(width, height, PixelFormat.Format32bppArgb);
            this.Clear(Color.Transparent);
            this._opacity = 1.0;
        }

        public void BumpMap(Layer bumpmap, int azimuth, int elevation, int bevelwidth, bool lightzalways1)
        {
            bumpmap._bitmap.Lock();
            this._bitmap.Lock();
            for (int i = 0; i < this._bitmap.Height; i++)
            {
                for (int j = 0; j < this._bitmap.Width; j++)
                {
                    byte[] buffer = new byte[] { this.GetBumpMapPixel(bumpmap._bitmap, j - 1, i - 1), this.GetBumpMapPixel(bumpmap._bitmap, j - 1, i), this.GetBumpMapPixel(bumpmap._bitmap, j - 1, i + 1), this.GetBumpMapPixel(bumpmap._bitmap, j + 1, i - 1), this.GetBumpMapPixel(bumpmap._bitmap, j + 1, i), this.GetBumpMapPixel(bumpmap._bitmap, j + 1, i + 1) };
                    float num3 = ((((buffer[0] + buffer[1]) + buffer[2]) - buffer[3]) - buffer[4]) - buffer[5];
                    buffer[0] = this.GetBumpMapPixel(bumpmap._bitmap, j - 1, i + 1);
                    buffer[1] = this.GetBumpMapPixel(bumpmap._bitmap, j, i + 1);
                    buffer[2] = this.GetBumpMapPixel(bumpmap._bitmap, j + 1, i + 1);
                    buffer[3] = this.GetBumpMapPixel(bumpmap._bitmap, j - 1, i - 1);
                    buffer[4] = this.GetBumpMapPixel(bumpmap._bitmap, j, i - 1);
                    buffer[5] = this.GetBumpMapPixel(bumpmap._bitmap, j + 1, i - 1);
                    float num4 = ((((buffer[0] + buffer[1]) + buffer[2]) - buffer[3]) - buffer[4]) - buffer[5];
                    float num5 = 1530f / ((float) bevelwidth);
                    float num6 = (float) Math.Sqrt((double) (((num3 * num3) + (num4 * num4)) + (num5 * num5)));
                    if (num6 != 0f)
                    {
                        num3 /= num6;
                        num4 /= num6;
                        num5 /= num6;
                    }
                    double d = (((double) azimuth) / 180.0) * 3.1415926535897931;
                    double num8 = (((double) elevation) / 180.0) * 3.1415926535897931;
                    float num9 = (float) (Math.Cos(d) * Math.Cos(num8));
                    float num10 = (float) (Math.Sin(d) * Math.Cos(num8));
                    float num11 = 1f;
                    if (!lightzalways1)
                    {
                        num11 = (float) Math.Sin(num8);
                    }
                    float num12 = 0f;
                    num12 += num3 * num9;
                    num12 += num4 * num10;
                    num12 += num5 * num11;
                    Color pixel = this._bitmap.GetPixel(j, i);
                    float r = pixel.R;
                    float g = pixel.G;
                    float b = pixel.B;
                    r *= num12;
                    g *= num12;
                    b *= num12;
                    byte red = (byte) Math.Min(Math.Round((double) r), 255.0);
                    byte green = (byte) Math.Min(Math.Round((double) g), 255.0);
                    byte blue = (byte) Math.Min(Math.Round((double) b), 255.0);
                    this._bitmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
            }
            this._bitmap.Unlock();
            bumpmap._bitmap.Unlock();
        }

        public void Clear(Color c)
        {
            this._bitmap.Lock();
            for (int i = 0; i < this._bitmap.Height; i++)
            {
                for (int j = 0; j < this._bitmap.Width; j++)
                {
                    this._bitmap.SetPixel(j, i, c);
                }
            }
            this._bitmap.Unlock();
        }

        public object Clone()
        {
            Layer layer = new Layer(this._bitmap.Width, this._bitmap.Height);
            layer._bitmap = (FastBitmap) this._bitmap.Clone();
            return layer;
        }

        public void DrawText(int x, int y, string text, Font font, Brush brush)
        {
            Graphics graphics = Graphics.FromImage(this._bitmap._bitmap);
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, brush, (float) x, (float) y, StringFormat.GenericTypographic);
            graphics.Dispose();
        }

        public void DrawText(int x, int y, int width, int height, string text, Font font, Brush brush, StringFormat format)
        {
            Graphics graphics = Graphics.FromImage(this._bitmap._bitmap);
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            RectangleF layoutRectangle = new RectangleF((float) x, (float) y, (float) width, (float) height);
            graphics.DrawString(text, font, brush, layoutRectangle, format);
            graphics.Dispose();
        }

        public void FillEllipse(int x, int y, int width, int height, Brush brush)
        {
            Graphics graphics = Graphics.FromImage(this._bitmap._bitmap);
            graphics.FillEllipse(brush, x, y, width, height);
            graphics.Dispose();
        }

        public void FillRectangle(int x, int y, int width, int height, Brush brush)
        {
            Graphics graphics = Graphics.FromImage(this._bitmap._bitmap);
            graphics.FillRectangle(brush, x, y, width, height);
            graphics.Dispose();
        }

        private byte GetBumpMapPixel(FastBitmap bmp, int x, int y)
        {
            if (x < 0)
            {
                x = 0;
            }
            if (x > (this._bitmap.Width - 1))
            {
                x = this._bitmap.Width - 1;
            }
            if (y < 0)
            {
                y = 0;
            }
            if (y > (this._bitmap.Height - 1))
            {
                y = this._bitmap.Height - 1;
            }
            return bmp.GetIntensity(x, y);
        }

        public Color GetPixel(int x, int y)
        {
            return this._bitmap.GetPixel(x, y);
        }

        public void Invert()
        {
            this._bitmap.Lock();
            for (int i = 0; i < this._bitmap.Height; i++)
            {
                for (int j = 0; j < this._bitmap.Width; j++)
                {
                    Color pixel = this._bitmap.GetPixel(j, i);
                    this._bitmap.SetPixel(j, i, Color.FromArgb(pixel.A, 0xff - pixel.R, 0xff - pixel.G, 0xff - pixel.B));
                }
            }
            this._bitmap.Unlock();
        }

        public FastBitmap Bitmap
        {
            get
            {
                return this._bitmap;
            }
        }

        public FastBitmap Mask
        {
            get
            {
                return this._mask;
            }
            set
            {
                this._mask = value;
            }
        }

        public int OffsetX
        {
            get
            {
                return this._offsetx;
            }
            set
            {
                this._offsetx = value;
            }
        }

        public int OffsetY
        {
            get
            {
                return this._offsety;
            }
            set
            {
                this._offsety = value;
            }
        }

        public double Opacity
        {
            get
            {
                return this._opacity;
            }
            set
            {
                this._opacity = value;
            }
        }
    }
}

