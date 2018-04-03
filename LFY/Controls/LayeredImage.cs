namespace LFY.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    internal class LayeredImage
    {
        private Layer _activelayer;
        private Color _backcolor;
        private Bitmap _checkerboard;
        private Color _forecolor;
        private int _height;
        private LFY.Controls.Layers _layers;
        private LFY.Controls.Selection _selection;
        private int _width;

        public LayeredImage(int width, int height)
        {
            this._width = width;
            this._height = height;
            this._layers = new LFY.Controls.Layers(this);
            this._selection = new LFY.Controls.Selection(width, height);
            this._activelayer = null;
            this._forecolor = Color.Black;
            this._backcolor = Color.White;
            this._checkerboard = new Bitmap(0x20, 0x20, PixelFormat.Format24bppRgb);
            Color color = Color.FromArgb(0x66, 0x66, 0x66);
            Color color2 = Color.FromArgb(0x99, 0x99, 0x99);
            for (int i = 0; i < 0x20; i++)
            {
                for (int j = 0; j < 0x20; j++)
                {
                    if (((i < 0x10) && (j < 0x10)) || ((i >= 0x10) && (j >= 0x10)))
                    {
                        this._checkerboard.SetPixel(j, i, color2);
                    }
                    else
                    {
                        this._checkerboard.SetPixel(j, i, color);
                    }
                }
            }
            Graphics graphics = Graphics.FromImage(this._layers.Add()._bitmap._bitmap);
            TextureBrush brush = new TextureBrush(this._checkerboard);
            graphics.FillRectangle(brush, 0, 0, this._width, this._height);
            brush.Dispose();
            graphics.Dispose();
        }

        public void Fill()
        {
            this.Fill(0, 0, 0, 0, FillType.Normal);
        }

        public void Fill(int x0, int y0, int x1, int y1, FillType type)
        {
            try
            {
                this._selection._bitmap.Lock();
                this._activelayer._bitmap.Lock();
                for (int i = 0; i < this._selection._bitmap.Height; i++)
                {
                    for (int j = 0; j < this._selection._bitmap.Width; j++)
                    {
                        Color pixel = this._selection._bitmap.GetPixel(j, i);
                        if ((pixel.R != 0) && ((((j >= this._activelayer.OffsetX) && (j <= ((this._activelayer.OffsetX + this._activelayer._bitmap.Width) - 1))) && (i >= this._activelayer.OffsetY)) && (i <= ((this._activelayer.OffsetY + this._activelayer._bitmap.Height) - 1))))
                        {
                            Color transparent = Color.Transparent;
                            switch (type)
                            {
                                case FillType.Normal:
                                    transparent = this._backcolor;
                                    break;

                                case FillType.Linear:
                                    transparent = this.FillLinear(x0, y0, x1, y1, j, i);
                                    break;

                                case FillType.Radial:
                                    transparent = this.FillRadial(x0, y0, x1, y1, j, i);
                                    break;
                            }
                            Color color3 = this._activelayer._bitmap.GetPixel(j - this._activelayer.OffsetX, i - this._activelayer.OffsetY);
                            double r = 0.0;
                            double g = 0.0;
                            double b = 0.0;
                            double num6 = 0.0;
                            double num7 = ((double) color3.A) / 255.0;
                            double num8 = ((double) transparent.A) / 255.0;
                            num8 *= ((double) pixel.R) / 255.0;
                            if (color3.A == 0)
                            {
                                r = transparent.R;
                                g = transparent.G;
                                b = transparent.B;
                            }
                            else
                            {
                                r = (color3.R * (1.0 - num8)) + (transparent.R * num8);
                                g = (color3.G * (1.0 - num8)) + (transparent.G * num8);
                                b = (color3.B * (1.0 - num8)) + (transparent.B * num8);
                            }
                            num6 = num7 + ((1.0 - num7) * num8);
                            num6 *= 255.0;
                            if (num6 > 255.0)
                            {
                                num6 = 255.0;
                            }
                            if (r > 255.0)
                            {
                                r = 255.0;
                            }
                            if (g > 255.0)
                            {
                                g = 255.0;
                            }
                            if (b > 255.0)
                            {
                                b = 255.0;
                            }
                            Color c = Color.FromArgb((byte) num6, (byte) r, (byte) g, (byte) b);
                            this._activelayer._bitmap.SetPixel(j, i, c);
                        }
                    }
                }
            }
            finally
            {
                this._selection._bitmap.Unlock();
                this._activelayer._bitmap.Unlock();
            }
        }

        private Color FillLinear(int x0, int y0, int x1, int y1, int x, int y)
        {
            double num = Math.Sqrt((double) (((x1 - x0) * (x1 - x0)) + ((y1 - y0) * (y1 - y0))));
            int num2 = 1;
            if (((x1 > x0) && (y1 < y0)) || ((x0 > x1) && (y1 > y0)))
            {
                num2 = -1;
            }
            if (x1 == x0)
            {
                x1 += y1 - y0;
                y1 = y0;
            }
            else if (y1 == y0)
            {
                y1 += x0 - x1;
                x1 = x0;
            }
            else
            {
                double num3 = -1.0 / ((double) ((y1 - y0) / (x1 - x0)));
                y1 = (int) Math.Round((double) ((x1 * num3) + (y0 - (x0 * num3))));
            }
            if ((num2 * ((((y0 - y1) * x) + ((x1 - x0) * y)) + ((x0 * y1) - (x1 * y0)))) < 0)
            {
                return this._forecolor;
            }
            double num4 = Math.Abs((int) (((x1 - x0) * (y0 - y)) - ((x0 - x) * (y1 - y0))));
            num4 /= Math.Sqrt((double) (((x1 - x0) * (x1 - x0)) + ((y1 - y0) * (y1 - y0))));
            num4 /= num;
            if (num4 > 1.0)
            {
                return this._backcolor;
            }
            double num5 = (this._forecolor.R * (1.0 - num4)) + (this._backcolor.R * num4);
            double num6 = (this._forecolor.G * (1.0 - num4)) + (this._backcolor.G * num4);
            double num7 = (this._forecolor.B * (1.0 - num4)) + (this._backcolor.B * num4);
            double num8 = (this._forecolor.A * (1.0 - num4)) + (this._backcolor.A * num4);
            if (num5 > 255.0)
            {
                num5 = 255.0;
            }
            if (num6 > 255.0)
            {
                num6 = 255.0;
            }
            if (num7 > 255.0)
            {
                num7 = 255.0;
            }
            if (num8 > 255.0)
            {
                num8 = 255.0;
            }
            return Color.FromArgb((byte) num8, (byte) num5, (byte) num6, (byte) num7);
        }

        private Color FillRadial(int x0, int y0, int x1, int y1, int x, int y)
        {
            double num = Math.Sqrt((double) (((x1 - x0) * (x1 - x0)) + ((y1 - y0) * (y1 - y0))));
            double num2 = Math.Sqrt((double) (((x - x0) * (x - x0)) + ((y - y0) * (y - y0)))) / num;
            double num3 = (this._forecolor.R * (1.0 - num2)) + (this._backcolor.R * num2);
            double num4 = (this._forecolor.G * (1.0 - num2)) + (this._backcolor.G * num2);
            double num5 = (this._forecolor.B * (1.0 - num2)) + (this._backcolor.B * num2);
            if (num3 > 255.0)
            {
                num3 = 255.0;
            }
            if (num4 > 255.0)
            {
                num4 = 255.0;
            }
            if (num5 > 255.0)
            {
                num5 = 255.0;
            }
            return Color.FromArgb((byte) num3, (byte) num4, (byte) num5);
        }

        internal FastBitmap Flatten()
        {
            Layer layer;
            FastBitmap bitmap = new FastBitmap(this._width, this._height, PixelFormat.Format24bppRgb);
            bitmap.Lock();
            int num = 0;
            while (num < this._layers.Count)
            {
                layer = this._layers[num];
                layer._bitmap.Lock();
                if (layer.Mask != null)
                {
                    layer.Mask.Lock();
                }
                num++;
            }
            for (int i = 0; i < this._height; i++)
            {
                for (int j = 0; j < this._width; j++)
                {
                    Color pixel = this._layers[0]._bitmap.GetPixel(j, i);
                    num = 1;
                    while (num < this._layers.Count)
                    {
                        Layer layer2 = this._layers[num];
                        Color transparent = Color.Transparent;
                        if ((((j >= layer2.OffsetX) && (j <= ((layer2.OffsetX + layer2._bitmap.Width) - 1))) && (i >= layer2.OffsetY)) && (i <= ((layer2.OffsetY + layer2._bitmap.Height) - 1)))
                        {
                            transparent = layer2._bitmap.GetPixel(j - layer2.OffsetX, i - layer2.OffsetY);
                        }
                        if (((transparent.A == 0xff) && (layer2.Opacity == 1.0)) && (layer2.Mask == null))
                        {
                            pixel = transparent;
                        }
                        else
                        {
                            double num7 = (((double) transparent.A) / 255.0) * layer2.Opacity;
                            if (layer2.Mask != null)
                            {
                                num7 *= ((double) layer2.Mask.GetIntensity(j, i)) / 255.0;
                            }
                            double a = (transparent.R * num7) + (pixel.R * (1.0 - num7));
                            double num5 = (transparent.G * num7) + (pixel.G * (1.0 - num7));
                            double num6 = (transparent.B * num7) + (pixel.B * (1.0 - num7));
                            a = Math.Round(a);
                            num5 = Math.Round(num5);
                            num6 = Math.Round(num6);
                            a = Math.Min(a, 255.0);
                            num5 = Math.Min(num5, 255.0);
                            num6 = Math.Min(num6, 255.0);
                            pixel = Color.FromArgb((byte) a, (byte) num5, (byte) num6);
                        }
                        num++;
                    }
                    bitmap.SetPixel(j, i, pixel);
                }
            }
            for (num = 0; num < this._layers.Count; num++)
            {
                layer = this._layers[num];
                layer._bitmap.Unlock();
                if (layer.Mask != null)
                {
                    layer.Mask.Unlock();
                }
            }
            bitmap.Unlock();
            return bitmap;
        }

        public Layer ActiveLayer
        {
            get
            {
                return this._activelayer;
            }
            set
            {
                this._activelayer = value;
            }
        }

        public Color BackColor
        {
            get
            {
                return this._backcolor;
            }
            set
            {
                this._backcolor = value;
            }
        }

        public Color ForeColor
        {
            get
            {
                return this._forecolor;
            }
            set
            {
                this._forecolor = value;
            }
        }

        public int Height
        {
            get
            {
                return this._height;
            }
        }

        public LFY.Controls.Layers Layers
        {
            get
            {
                return this._layers;
            }
        }

        public LFY.Controls.Selection Selection
        {
            get
            {
                return this._selection;
            }
        }

        public int Width
        {
            get
            {
                return this._width;
            }
        }
    }
}

