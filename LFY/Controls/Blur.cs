namespace LFY.Controls
{
    using System;

    internal class Blur
    {
        public static void ApplyTo(FastBitmap bitmap, int horz, int vert)
        {
            float num;
            int num8;
            int num9;
            int num10;
            float num11;
            float num13;
            int num15;
            byte num17;
            byte num18;
            byte num19;
            byte num20;
            FastBitmap bitmap2 = (FastBitmap) bitmap.Clone();
            bitmap.Lock();
            bitmap2.Lock();
            int width = bitmap.Width;
            int height = bitmap.Height;
            double a = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            bool hasAlpha = bitmap.HasAlpha;
            float[] numArray = new float[(horz * 2) + 1];
            numArray[horz] = 1f;
            int index = 0;
            while (index < horz)
            {
                num13 = Sigmoid((float) index, 0f, (float) ((horz + 1) / 2), (float) (horz + 1));
                numArray[index] = num13;
                numArray[(horz * 2) - index] = num13;
                index++;
            }
            int y = 0;
            while (y < bitmap.Height)
            {
                num15 = 0;
                while (num15 < bitmap.Width)
                {
                    a = 0.0;
                    num5 = 0.0;
                    num6 = 0.0;
                    num7 = 0.0;
                    num = 0f;
                    for (index = 0; index < ((horz * 2) + 1); index++)
                    {
                        int x = (num15 - horz) + index;
                        if (x < 0)
                        {
                            index += -x;
                            x = 0;
                        }
                        if (x > (width - 1))
                        {
                            break;
                        }
                        num8 = bitmap.GetPixelInt32(x, y);
                        num11 = numArray[index];
                        a += ((num8 >> 0x10) & 0xff) * num11;
                        num5 += ((num8 >> 8) & 0xff) * num11;
                        num6 += (num8 & 0xff) * num11;
                        if (hasAlpha)
                        {
                            num10 = (num8 >> 0x18) & 0xff;
                            a /= 255.0 * num10;
                            num5 /= 255.0 * num10;
                            num6 /= 255.0 * num10;
                            num7 += num10 * num11;
                        }
                        num += num11;
                    }
                    a /= (double) num;
                    num5 /= (double) num;
                    num6 /= (double) num;
                    num7 /= (double) num;
                    num17 = (byte) Math.Round(a);
                    num18 = (byte) Math.Round(num5);
                    num19 = (byte) Math.Round(num6);
                    num20 = (byte) Math.Round(num7);
                    if (num17 > 0xff)
                    {
                        num17 = 0xff;
                    }
                    if (num18 > 0xff)
                    {
                        num18 = 0xff;
                    }
                    if (num19 > 0xff)
                    {
                        num19 = 0xff;
                    }
                    if (num20 > 0xff)
                    {
                        num20 = 0xff;
                    }
                    num9 = num20;
                    num9 = num9 << 8;
                    num9 |= num17;
                    num9 = num9 << 8;
                    num9 |= num18;
                    num9 = num9 << 8;
                    num9 |= num19;
                    bitmap2.SetPixelInt32(num15, y, num9);
                    num15++;
                }
                y++;
            }
            numArray = new float[(vert * 2) + 1];
            numArray[vert] = 1f;
            index = 0;
            while (index < vert)
            {
                num13 = Sigmoid((float) index, 0f, (float) ((vert + 1) / 2), (float) (vert + 1));
                numArray[index] = num13;
                numArray[(vert * 2) - index] = num13;
                index++;
            }
            for (num15 = 0; num15 < bitmap.Width; num15++)
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    a = 0.0;
                    num5 = 0.0;
                    num6 = 0.0;
                    num7 = 0.0;
                    num = 0f;
                    for (index = 0; index < ((vert * 2) + 1); index++)
                    {
                        int num21 = (y - vert) + index;
                        if (num21 < 0)
                        {
                            index += -num21;
                            num21 = 0;
                        }
                        if (num21 > (height - 1))
                        {
                            break;
                        }
                        num8 = bitmap2.GetPixelInt32(num15, num21);
                        num11 = numArray[index];
                        a += ((num8 >> 0x10) & 0xff) * num11;
                        num5 += ((num8 >> 8) & 0xff) * num11;
                        num6 += (num8 & 0xff) * num11;
                        if (hasAlpha)
                        {
                            num10 = (num8 >> 0x18) & 0xff;
                            a /= 255.0 * num10;
                            num5 /= 255.0 * num10;
                            num6 /= 255.0 * num10;
                            num7 += num10 * num11;
                        }
                        num += num11;
                    }
                    a /= (double) num;
                    num5 /= (double) num;
                    num6 /= (double) num;
                    num7 /= (double) num;
                    num17 = (byte) Math.Round(a);
                    num18 = (byte) Math.Round(num5);
                    num19 = (byte) Math.Round(num6);
                    num20 = (byte) Math.Round(num7);
                    if (num17 > 0xff)
                    {
                        num17 = 0xff;
                    }
                    if (num18 > 0xff)
                    {
                        num18 = 0xff;
                    }
                    if (num19 > 0xff)
                    {
                        num19 = 0xff;
                    }
                    if (num20 > 0xff)
                    {
                        num20 = 0xff;
                    }
                    num9 = num20;
                    num9 = num9 << 8;
                    num9 |= num17;
                    num9 = num9 << 8;
                    num9 |= num18;
                    num9 = num9 << 8;
                    num9 |= num19;
                    bitmap.SetPixelInt32(num15, y, num9);
                }
            }
            bitmap2.Dispose();
            bitmap.Unlock();
        }

        private static float Sigmoid(float x, float alpha, float beta, float gamma)
        {
            if (x <= alpha)
            {
                return 0f;
            }
            if ((x >= alpha) && (x <= beta))
            {
                return (2f * (((x - alpha) / (gamma - alpha)) * ((x - alpha) / (gamma - alpha))));
            }
            if ((x >= beta) && (x <= gamma))
            {
                return (1f - (2f * (((x - gamma) / (gamma - alpha)) * ((x - gamma) / (gamma - alpha)))));
            }
            return 1f;
        }
    }
}

