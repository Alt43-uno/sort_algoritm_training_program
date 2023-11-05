namespace SortAlgorithms
{
    partial class AlgoInfo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.algo_title = new System.Windows.Forms.Label();
            this.algo_image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.algo_image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 572);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // algo_title
            // 
            this.algo_title.AutoSize = true;
            this.algo_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.algo_title.Location = new System.Drawing.Point(9, 22);
            this.algo_title.Name = "algo_title";
            this.algo_title.Size = new System.Drawing.Size(66, 24);
            this.algo_title.TabIndex = 1;
            this.algo_title.Text = "label1";
            // 
            // algo_image
            // 
            this.algo_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.algo_image.Image = global::SortAlgorithms.Properties.Resources.bitonicSort;
            this.algo_image.Location = new System.Drawing.Point(426, 66);
            this.algo_image.Name = "algo_image";
            this.algo_image.Size = new System.Drawing.Size(362, 572);
            this.algo_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.algo_image.TabIndex = 2;
            this.algo_image.TabStop = false;
            // 
            // AlgoInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.algo_image);
            this.Controls.Add(this.algo_title);
            this.Controls.Add(this.panel1);
            this.Name = "AlgoInfo";
            this.Text = "AlgoInfo";
            this.Load += new System.EventHandler(this.AlgoInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.algo_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label algo_title;
        private System.Windows.Forms.PictureBox algo_image;
    }
}