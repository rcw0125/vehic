namespace LFY.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    internal class Selection
    {
        internal FastBitmap _bitmap;

        public Selection(int width, int height)
        {
            this._bitmap = new FastBitmap(width, height, PixelFormat.Format24bppRgb);
            this.Clear();
        }

        public void Clear()
        {
            try
            {
                this._bitmap.Lock();
                for (int i = 0; i < this._bitmap.Height; i++)
                {
                    for (int j = 0; j < this._bitmap.Width; j++)
                    {
                        this._bitmap.SetPixel(j, i, Color.Black);
                    }
                }
            }
            finally
            {
                this._bitmap.Unlock();
            }
        }

        public void Feather(int radius)
        {
            Blur.ApplyTo(this._bitmap, radius, radius);
        }

        public void SelectEllipse(int x, int y, int width, int height, SelectionMode mode)
        {
            if (mode == SelectionMode.Replace)
            {
                this.Clear();
            }
            Graphics graphics = Graphics.FromImage(this._bitmap._bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush((mode == SelectionMode.Subtract) ? Color.Black : Color.White);
            graphics.FillEllipse(brush, x, y, width, height);
            brush.Dispose();
            graphics.Dispose();
        }

        public void SelectRectangle(int x, int y, int width, int height)
        {
            this.Clear();
            Graphics graphics = Graphics.FromImage(this._bitmap._bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush(Color.Black);
            graphics.FillRectangle(brush, x, y, width, height);
            brush.Dispose();
            graphics.Dispose();
        }
    }
}

