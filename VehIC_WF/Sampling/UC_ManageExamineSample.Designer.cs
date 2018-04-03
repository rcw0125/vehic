namespace VehIC_WF.Sampling
{
    partial class UC_ManageExamineSample
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uC_ExamineSample1 = new VehIC_WF.Sampling.UC_ExamineSample();
            this.SuspendLayout();
            // 
            // uC_ExamineSample1
            // 
            this.uC_ExamineSample1.Cylx = "普通抽样";
            this.uC_ExamineSample1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ExamineSample1.Location = new System.Drawing.Point(0, 0);
            this.uC_ExamineSample1.Name = "uC_ExamineSample1";
            this.uC_ExamineSample1.Size = new System.Drawing.Size(831, 677);
            this.uC_ExamineSample1.TabIndex = 0;
            this.uC_ExamineSample1.Load += new System.EventHandler(this.uC_ExamineSample1_Load);
            // 
            // UC_ManageExamineSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uC_ExamineSample1);
            this.Name = "UC_ManageExamineSample";
            this.Size = new System.Drawing.Size(831, 677);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_ExamineSample uC_ExamineSample1;
    }
}
