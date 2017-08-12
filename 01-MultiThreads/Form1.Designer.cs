namespace _01_MultiThreads
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRed1 = new System.Windows.Forms.Label();
            this.lblRed2 = new System.Windows.Forms.Label();
            this.lblRed3 = new System.Windows.Forms.Label();
            this.lblRed4 = new System.Windows.Forms.Label();
            this.lblRed5 = new System.Windows.Forms.Label();
            this.lblRed6 = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.gboSSQ = new System.Windows.Forms.GroupBox();
            this.gboSSQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRed1
            // 
            this.lblRed1.AutoSize = true;
            this.lblRed1.ForeColor = System.Drawing.Color.Red;
            this.lblRed1.Location = new System.Drawing.Point(22, 67);
            this.lblRed1.Name = "lblRed1";
            this.lblRed1.Size = new System.Drawing.Size(23, 15);
            this.lblRed1.TabIndex = 0;
            this.lblRed1.Text = "00";
            // 
            // lblRed2
            // 
            this.lblRed2.AutoSize = true;
            this.lblRed2.ForeColor = System.Drawing.Color.Red;
            this.lblRed2.Location = new System.Drawing.Point(93, 67);
            this.lblRed2.Name = "lblRed2";
            this.lblRed2.Size = new System.Drawing.Size(23, 15);
            this.lblRed2.TabIndex = 0;
            this.lblRed2.Text = "00";
            // 
            // lblRed3
            // 
            this.lblRed3.AutoSize = true;
            this.lblRed3.ForeColor = System.Drawing.Color.Red;
            this.lblRed3.Location = new System.Drawing.Point(154, 67);
            this.lblRed3.Name = "lblRed3";
            this.lblRed3.Size = new System.Drawing.Size(23, 15);
            this.lblRed3.TabIndex = 0;
            this.lblRed3.Text = "00";
            // 
            // lblRed4
            // 
            this.lblRed4.AutoSize = true;
            this.lblRed4.ForeColor = System.Drawing.Color.Red;
            this.lblRed4.Location = new System.Drawing.Point(229, 67);
            this.lblRed4.Name = "lblRed4";
            this.lblRed4.Size = new System.Drawing.Size(23, 15);
            this.lblRed4.TabIndex = 0;
            this.lblRed4.Text = "00";
            // 
            // lblRed5
            // 
            this.lblRed5.AutoSize = true;
            this.lblRed5.ForeColor = System.Drawing.Color.Red;
            this.lblRed5.Location = new System.Drawing.Point(290, 67);
            this.lblRed5.Name = "lblRed5";
            this.lblRed5.Size = new System.Drawing.Size(23, 15);
            this.lblRed5.TabIndex = 0;
            this.lblRed5.Text = "00";
            // 
            // lblRed6
            // 
            this.lblRed6.AutoSize = true;
            this.lblRed6.ForeColor = System.Drawing.Color.Red;
            this.lblRed6.Location = new System.Drawing.Point(351, 67);
            this.lblRed6.Name = "lblRed6";
            this.lblRed6.Size = new System.Drawing.Size(23, 15);
            this.lblRed6.TabIndex = 0;
            this.lblRed6.Text = "00";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.ForeColor = System.Drawing.Color.Blue;
            this.lblBlue.Location = new System.Drawing.Point(468, 67);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(23, 15);
            this.lblBlue.TabIndex = 0;
            this.lblBlue.Text = "00";
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(207, 262);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 36);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Location = new System.Drawing.Point(411, 262);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(91, 36);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // gboSSQ
            // 
            this.gboSSQ.Controls.Add(this.lblRed3);
            this.gboSSQ.Controls.Add(this.lblRed1);
            this.gboSSQ.Controls.Add(this.lblRed2);
            this.gboSSQ.Controls.Add(this.lblBlue);
            this.gboSSQ.Controls.Add(this.lblRed4);
            this.gboSSQ.Controls.Add(this.lblRed6);
            this.gboSSQ.Controls.Add(this.lblRed5);
            this.gboSSQ.ForeColor = System.Drawing.Color.Black;
            this.gboSSQ.Location = new System.Drawing.Point(96, 33);
            this.gboSSQ.Name = "gboSSQ";
            this.gboSSQ.Size = new System.Drawing.Size(587, 190);
            this.gboSSQ.TabIndex = 3;
            this.gboSSQ.TabStop = false;
            this.gboSSQ.Text = "双色球结果区";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 463);
            this.Controls.Add(this.gboSSQ);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "Form1";
            this.Text = "双色球";
            this.gboSSQ.ResumeLayout(false);
            this.gboSSQ.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRed1;
        private System.Windows.Forms.Label lblRed2;
        private System.Windows.Forms.Label lblRed3;
        private System.Windows.Forms.Label lblRed4;
        private System.Windows.Forms.Label lblRed5;
        private System.Windows.Forms.Label lblRed6;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox gboSSQ;
    }
}

