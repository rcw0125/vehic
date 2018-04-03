namespace VehIC_WF.Setting
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Common : UserControl
    {
        private IContainer components = null;

        public Common()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "Common";
            base.Size = new Size(0x236, 0x1d1);
            base.ResumeLayout(false);
        }
    }
}

