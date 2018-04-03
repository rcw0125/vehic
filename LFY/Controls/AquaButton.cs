namespace LFY.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class AquaButton : UserControl
    {
        private Color bkcolor = Color.SteelBlue;
        private int blurx = 8;
        private int blury = 8;
        private Color bordercolor = Color.FromArgb(0x8f, 190, 0xe8);
        private int borderfillx0;
        private int borderfillx1;
        private int borderfilly0;
        private int borderfilly1;
        private int borderwidth = 5;
        private int buttoncolorheight;
        private int buttoncolorwidth;
        private int buttoncolorx;
        private int buttoncolory;
        private int buttonheight;
        private int buttonwidth;
        public Color CCC = Color.FromArgb(-1);
        private Container components = null;
        private bool dropshadow = true;
        private int featherleft = 10;
        private int feathertop = 0x18;
        private string fontface = "Arial";
        private int fontsize = 12;
        private string fontstyle = "";
        private int height;
        private int highlightfilly0;
        private int highlightfilly1;
        private int highlightheight;
        private int highlightwidth;
        private int highlightx;
        private int highlighty;
        private Color m_buttonColour = Color.FromArgb(0xa3, 0xdb, 0x1d);
        protected System.Drawing.Image m_image;
        protected System.Drawing.Image m_nofocusImage;
        private string m_text = "Not Set";
        private Color m_textColour = Color.Black;
        private int margin;
        private PictureBox pictureBox;
        private int shadeleftheight;
        private int shadeleftwidth;
        private int shadeleftx;
        private int shadelefty;
        private double shadeopacity = 0.3;
        private int shadetopheight;
        private int shadetopwidth;
        private int shadetopx;
        private int shadetopy;
        private int shadowoffsetx = 4;
        private int shadowoffsety = 4;
        private double shadowopacity = 0.75;
        private double texttrans = 0.75;
        private int width;

        public event EventHandler Click;

        public AquaButton()
        {
            this.InitializeComponent();
            this.BackColor = this.pictureBox.BackColor = this.CCC;
            this.initialise();
            this.redrawButton();
        }

        private void AquaButton_FontChanged(object sender, EventArgs e)
        {
            this.redrawButton();
        }

        protected virtual void CreateBaseImages()
        {
            this.m_image = this.CreateImage(this.m_buttonColour);
            this.m_nofocusImage = this.CreateImage(Color.Transparent);
            this.Image = this.m_image;
        }

        protected virtual Bitmap CreateImage(Color colour)
        {
            int num;
            if (this.m_text == "Not Set")
            {
                return null;
            }
            string path = Environment.GetEnvironmentVariable("TEMP") + @"\Aqua\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string str2 = string.Concat(new object[] { path, this.cleanedName, this.width, "x", this.height, "_", colour.ToString(), "-", this.Font.Size, this.m_textColour.ToString(), ".Png" });
            if (File.Exists(str2))
            {
                return new Bitmap(str2);
            }
            LayeredImage image = new LayeredImage(this.width, this.height);
            image.Layers.Add().Clear(this.CCC);
            if (this.dropshadow)
            {
                Layer layer2 = image.Layers.Add();
                image.ActiveLayer = layer2;
                image.BackColor = Color.Black;
                image.Selection.SelectEllipse(this.margin, this.margin, this.buttonwidth, this.buttonheight, LFY.Controls.SelectionMode.Replace);
                image.Fill();
                Blur.ApplyTo(layer2.Bitmap, this.blurx, this.blury);
                layer2.OffsetX = this.shadowoffsetx;
                layer2.OffsetY = this.shadowoffsety;
                layer2.Opacity = this.shadowopacity;
            }
            Layer layer3 = image.Layers.Add();
            image.Selection.SelectEllipse(this.margin, this.margin, this.buttonwidth, this.buttonheight, LFY.Controls.SelectionMode.Replace);
            image.ActiveLayer = layer3;
            image.ForeColor = this.bordercolor;
            image.BackColor = Color.Black;
            image.Fill(this.borderfillx0, this.borderfilly0, this.borderfillx1, this.borderfilly1, FillType.Radial);
            image.Selection.SelectEllipse(this.buttoncolorx, this.buttoncolory, this.buttoncolorwidth, this.buttoncolorheight, LFY.Controls.SelectionMode.Replace);
            image.BackColor = colour;
            image.Fill();
            Layer layer4 = image.Layers.Add();
            image.ActiveLayer = layer4;
            image.Selection.SelectEllipse(this.buttoncolorx - 2, this.buttoncolory - 2, this.buttoncolorwidth + 4, this.buttoncolorheight + 4, LFY.Controls.SelectionMode.Replace);
            image.Selection.SelectEllipse(this.shadeleftx, this.shadelefty, this.shadeleftwidth, this.shadeleftheight, LFY.Controls.SelectionMode.Subtract);
            image.Selection.Feather(this.featherleft);
            image.BackColor = Color.Black;
            image.Fill();
            layer4.Opacity = this.shadeopacity;
            image.Selection.SelectEllipse(this.buttoncolorx - 2, this.buttoncolory - 2, this.buttoncolorwidth + 4, this.buttoncolorheight + 4, LFY.Controls.SelectionMode.Replace);
            image.Selection.SelectEllipse(this.shadetopx, this.shadetopy, this.shadetopwidth, this.shadetopheight, LFY.Controls.SelectionMode.Subtract);
            image.Selection.Feather(this.feathertop);
            image.Fill();
            FastBitmap bitmap = new FastBitmap(this.width, this.height, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(bitmap._bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush brush2 = new SolidBrush(Color.White);
            graphics.FillRectangle(brush, 0, 0, this.width, this.height);
            graphics.FillEllipse(brush2, this.buttoncolorx, this.buttoncolory, this.buttoncolorwidth, this.buttoncolorheight);
            brush2.Dispose();
            brush.Dispose();
            graphics.Dispose();
            layer4.Mask = bitmap;
            Layer layer5 = image.Layers.Add();
            FontStyle regular = FontStyle.Regular;
            for (num = 0; num < this.fontstyle.Length; num++)
            {
                char ch = this.fontstyle[num];
                if (ch != 'b')
                {
                    switch (ch)
                    {
                        case 'r':
                        {
                            regular = regular;
                            continue;
                        }
                        case 's':
                        {
                            regular |= FontStyle.Strikeout;
                            continue;
                        }
                        case 't':
                        {
                            continue;
                        }
                        case 'u':
                        {
                            regular |= FontStyle.Underline;
                            continue;
                        }
                        case 'i':
                            goto Label_047E;
                    }
                }
                else
                {
                    regular |= FontStyle.Bold;
                }
                continue;
            Label_047E:
                regular |= FontStyle.Italic;
            }
            Font font = new Font(this.fontface, (float) this.fontsize, regular);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.None;
            SolidBrush brush3 = new SolidBrush(this.m_textColour);
            StringBuilder builder = new StringBuilder(this.m_text.Length);
            for (num = 0; num < this.m_text.Length; num++)
            {
                if (this.m_text[num] == '\\')
                {
                    if ((num + 1) < this.m_text.Length)
                    {
                        if (this.m_text[num + 1] == 'n')
                        {
                            builder.Append(Environment.NewLine);
                            num++;
                        }
                        else if (this.m_text[num + 1] == '\\')
                        {
                            builder.Append('\\');
                            num++;
                        }
                        else
                        {
                            builder.Append('\\');
                        }
                    }
                    else
                    {
                        builder.Append('\\');
                    }
                }
                else
                {
                    builder.Append(this.m_text[num]);
                }
            }
            layer5.DrawText(0, 0, this.width, this.height, builder.ToString(), base.Font, brush3, format);
            brush3.Dispose();
            font.Dispose();
            layer5.Opacity = 1.0 - this.texttrans;
            Layer layer6 = image.Layers.Add();
            image.ActiveLayer = layer6;
            image.ForeColor = Color.White;
            image.BackColor = Color.Transparent;
            image.Selection.SelectEllipse(this.highlightx, this.highlighty, this.highlightwidth, this.highlightheight, LFY.Controls.SelectionMode.Replace);
            image.Fill(0, this.highlightfilly0, 0, this.highlightfilly1, FillType.Linear);
            FastBitmap bitmap2 = image.Flatten();
            ImageFormat png = ImageFormat.Png;
            try
            {
                bitmap2.Save(str2, png);
            }
            catch (Exception)
            {
            }
            return bitmap2._bitmap;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void initialise()
        {
            this.texttrans = 0.75;
            this.bkcolor = Color.White;
            this.bordercolor = Color.FromArgb(0x8f, 190, 0xe8);
            this.fontface = "Arial";
            this.fontstyle = "";
            this.dropshadow = false;
            this.blurx = 8;
            this.blury = 8;
            this.shadowoffsetx = 4;
            this.shadowoffsety = 4;
            this.margin = 1;
            this.margin = 1;
            this.width = base.Width;
            this.height = base.Height;
            this.buttonwidth = this.width - (this.margin * 2);
            this.buttonheight = this.height - (this.margin * 2);
            this.borderwidth = Math.Min(this.width, this.height) / 20;
            this.shadowopacity = 0.75;
            this.borderfillx0 = this.margin + (this.width / 4);
            this.borderfilly0 = this.margin + (this.height / 4);
            this.borderfillx1 = this.width - this.margin;
            this.borderfilly1 = this.height - this.margin;
            this.buttoncolorx = this.margin + this.borderwidth;
            this.buttoncolory = this.margin + this.borderwidth;
            this.buttoncolorwidth = this.buttonwidth - (this.borderwidth * 2);
            this.buttoncolorheight = this.buttonheight - (this.borderwidth * 2);
            this.shadeleftx = this.margin + 10;
            this.shadelefty = this.margin + this.borderwidth;
            this.shadeleftwidth = this.buttoncolorwidth;
            this.shadeleftheight = this.buttoncolorheight;
            this.shadeopacity = 0.3;
            this.featherleft = 10;
            this.feathertop = 0x18;
            this.shadetopx = this.margin + this.borderwidth;
            this.shadetopy = (this.margin + this.borderwidth) + 20;
            this.shadetopwidth = this.buttoncolorwidth;
            this.shadetopheight = this.buttoncolorheight;
            this.highlightx = this.width / 4;
            this.highlighty = this.borderwidth + ((this.height - (2 * this.borderwidth)) / 8);
            this.highlightwidth = this.width / 2;
            this.highlightheight = (((this.height - (2 * this.borderwidth)) * 3) / 8) - this.highlighty;
            this.highlightfilly0 = this.highlighty;
            this.highlightfilly1 = (this.highlightfilly0 + this.highlightheight) - 4;
            this.fontsize = 12;
        }

        private void InitializeComponent()
        {
            this.pictureBox = new PictureBox();
            base.SuspendLayout();
            this.pictureBox.Cursor = Cursors.Hand;
            this.pictureBox.Dock = DockStyle.Fill;
            this.pictureBox.Location = new Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new Size(150, 150);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new EventHandler(this.pictureBox_Click);
            this.pictureBox.Resize += new EventHandler(this.pictureBox_Resize);
            this.pictureBox.MouseEnter += new EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new EventHandler(this.pictureBox_MouseLeave);
            base.Controls.Add(this.pictureBox);
            base.Name = "AquaButton";
            base.FontChanged += new EventHandler(this.AquaButton_FontChanged);
            base.ResumeLayout(false);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, new EventArgs());
            }
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            this.Image = this.m_nofocusImage;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            this.Image = this.m_image;
        }

        private void pictureBox_Resize(object sender, EventArgs e)
        {
            this.redrawButton();
        }

        private void redrawButton()
        {
            this.initialise();
            this.CreateBaseImages();
        }

        public Color ButtonColour
        {
            get
            {
                return this.m_buttonColour;
            }
            set
            {
                this.m_buttonColour = value;
                this.redrawButton();
            }
        }

        [Browsable(true), DefaultValue("Not Set"), Description(@"The text visible on the control. Use \n for line breaks")]
        public string ButtonText
        {
            get
            {
                return this.m_text;
            }
            set
            {
                base.Text = "not set";
                this.initialise();
                this.m_text = value;
                this.redrawButton();
            }
        }

        private string cleanedName
        {
            get
            {
                return this.m_text.Replace(@"\n", " ");
            }
        }

        [Browsable(true), Description("Sets and gets size of the text")]
        public float FontSize
        {
            get
            {
                return this.Font.Size;
            }
            set
            {
                this.Font = new System.Drawing.Font(this.Font.FontFamily.Name, value);
                this.redrawButton();
            }
        }

        public System.Drawing.Image Image
        {
            set
            {
                this.pictureBox.Image = value;
            }
        }

        [Description("The colour of the text"), Browsable(true)]
        public Color TextColour
        {
            get
            {
                return this.m_textColour;
            }
            set
            {
                this.m_textColour = value;
                this.redrawButton();
            }
        }
    }
}

