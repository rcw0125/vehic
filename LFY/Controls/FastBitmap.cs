namespace LFY.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    internal class FastBitmap : IDisposable, ICloneable
    {
        internal Bitmap _bitmap;
        private BitmapData _bitmapData;

        private FastBitmap()
        {
        }

        public FastBitmap(string filename)
        {
            this._bitmap = new Bitmap(filename);
        }

        public FastBitmap(int width, int height, PixelFormat fmt)
        {
            this._bitmap = new Bitmap(width, height, fmt);
        }

        public object Clone()
        {
            FastBitmap bitmap = new FastBitmap();
            bitmap._bitmap = (Bitmap) this._bitmap.Clone();
            return bitmap;
        }

        public void CopyTo(FastBitmap bitmap, int destx, int desty, int srcx, int srcy, int width, int height)
        {
            try
            {
                this.Lock();
                bitmap.Lock();
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Color pixel = this.GetPixel(srcx + j, srcy + i);
                        bitmap.SetPixel(destx + j, desty + i, pixel);
                    }
                }
            }
            finally
            {
                this.Unlock();
                bitmap.Unlock();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.Unlock();
            if (disposing)
            {
                this._bitmap.Dispose();
            }
        }

        ~FastBitmap()
        {
            this.Dispose(false);
        }

        public byte GetIntensity(int x, int y)
        {
            Color pixel = this.GetPixel(x, y);
            return (byte) ((((pixel.R * 0.3) + (pixel.G * 0.59)) + (pixel.B * 0.11)) + 0.5);
        }

        public unsafe Color GetPixel(int x, int y)
        {
            byte* numPtr;
            if (this._bitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                numPtr = (byte*)new IntPtr(((this._bitmapData.Scan0.ToInt32() + (y * this._bitmapData.Stride)) + (x * 4)));
                return Color.FromArgb(numPtr[3], numPtr[2], numPtr[1], numPtr[0]);
            }
            if (this._bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                numPtr = (byte*)new IntPtr(((this._bitmapData.Scan0.ToInt32() + (y * this._bitmapData.Stride)) + (x * 3)));
                return Color.FromArgb(numPtr[2], numPtr[1], numPtr[0]);
            }
            return Color.Empty;
        }

        public unsafe int GetPixelInt32(int x, int y)
        {
            byte* numPtr;
            int num;
            if (this._bitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                numPtr = (byte*)new IntPtr((this._bitmapData.Scan0.ToInt32() + (y * this._bitmapData.Stride)) + (x * 4));
                num = numPtr[3];
                num = num << 8;
                num |= numPtr[2];
                num = num << 8;
                num |= numPtr[1];
                num = num << 8;
                return (num | numPtr[0]);
            }
            if (this._bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                numPtr = (byte*)new IntPtr(((this._bitmapData.Scan0.ToInt32() + (y * this._bitmapData.Stride)) + (x * 3)));
                num = numPtr[2];
                num = num << 8;
                num |= numPtr[1];
                num = num << 8;
                return (num | numPtr[0]);
            }
            return -1;
        }

        public void Lock()
        {
            this._bitmapData = this._bitmap.LockBits(new Rectangle(0, 0, this._bitmap.Width, this._bitmap.Height), ImageLockMode.ReadWrite, this._bitmap.PixelFormat);
        }

        public void Save(string filename)
        {
            this._bitmap.Save(filename);
        }

        public void Save(string filename, ImageFormat format)
        {
            this._bitmap.Save(filename, format);
        }

        public unsafe void SetPixel(int x, int y, Color c)
        {
            byte* numPtr;
            if (this._bitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                numPtr = (byte*)new IntPtr(((this._bitmapData.Scan0.ToInt32() + (y * this._bitmapData.Stride)) + (x * 4)));
                numPtr[0] = c.B;
                numPtr[1] = c.G;
                numPtr[2] = c.R;
                numPtr[3] = c.A;
            }
            if (this._bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                numPtr = (byte*)new IntPtr(((this._bitmapData.Scan0.ToInt32() + (y * this._bitmapData.Stride)) + (x * 3)));
                numPtr[0] = c.B;
                numPtr[1] = c.G;
                numPtr[2] = c.R;
            }
        }

        public unsafe void SetPixelInt32(int x, int y, int color)
        {
            byte* numPtr;
            if (this._bitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                numPtr = (byte*)new IntPtr(((this._bitmapData.Scan0.ToInt32() + (y * this._bitmapData.Stride)) + (x * 4)));
                numPtr[0] = (byte) (color & 0xff);
                numPtr[1] = (byte) ((color >> 8) & 0xff);
                numPtr[2] = (byte) ((color >> 0x10) & 0xff);
                numPtr[3] = (byte) ((color >> 0x18) & 0xff);
            }
            if (this._bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                numPtr = (byte*)new IntPtr(((this._bitmapData.Scan0.ToInt32() + (y * this._bitmapData.Stride)) + (x * 3)));
                numPtr[0] = (byte) (color & 0xff);
                numPtr[1] = (byte) ((color >> 8) & 0xff);
                numPtr[2] = (byte) ((color >> 0x10) & 0xff);
            }
        }

        public void Unlock()
        {
            if (this._bitmapData != null)
            {
                this._bitmap.UnlockBits(this._bitmapData);
                this._bitmapData = null;
            }
        }

        public bool HasAlpha
        {
            get
            {
                return (this._bitmap.PixelFormat == PixelFormat.Format32bppArgb);
            }
        }

        public int Height
        {
            get
            {
                return this._bitmap.Height;
            }
        }

        public int Width
        {
            get
            {
                return this._bitmap.Width;
            }
        }
    }
}

