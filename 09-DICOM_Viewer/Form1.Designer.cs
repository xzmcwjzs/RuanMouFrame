namespace _09_DICOM_Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripClose = new System.Windows.Forms.ToolStripButton();
            this.listViewDICOM = new System.Windows.Forms.ListView();
            this.GroupTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ElementTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBoxDICOM = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDICOM)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpen,
            this.toolStripClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOpen.ForeColor = System.Drawing.Color.Black;
            this.toolStripOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpen.Image")));
            this.toolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.Size = new System.Drawing.Size(125, 24);
            this.toolStripOpen.Text = "打开DICOM图像";
            this.toolStripOpen.Click += new System.EventHandler(this.toolStripOpen_Click);
            // 
            // toolStripClose
            // 
            this.toolStripClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClose.Image")));
            this.toolStripClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClose.Name = "toolStripClose";
            this.toolStripClose.Size = new System.Drawing.Size(43, 24);
            this.toolStripClose.Text = "清空";
            // 
            // listViewDICOM
            // 
            this.listViewDICOM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GroupTag,
            this.ElementTag,
            this.Value});
            this.listViewDICOM.Location = new System.Drawing.Point(12, 30);
            this.listViewDICOM.Name = "listViewDICOM";
            this.listViewDICOM.Size = new System.Drawing.Size(289, 600);
            this.listViewDICOM.TabIndex = 1;
            this.listViewDICOM.UseCompatibleStateImageBehavior = false;
            this.listViewDICOM.View = System.Windows.Forms.View.Details;
            // 
            // GroupTag
            // 
            this.GroupTag.Text = "GroupTag";
            this.GroupTag.Width = 105;
            // 
            // ElementTag
            // 
            this.ElementTag.Text = "ElementTag";
            this.ElementTag.Width = 131;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 93;
            // 
            // pictureBoxDICOM
            // 
            this.pictureBoxDICOM.Location = new System.Drawing.Point(382, 30);
            this.pictureBoxDICOM.Name = "pictureBoxDICOM";
            this.pictureBoxDICOM.Size = new System.Drawing.Size(417, 595);
            this.pictureBoxDICOM.TabIndex = 2;
            this.pictureBoxDICOM.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 637);
            this.Controls.Add(this.pictureBoxDICOM);
            this.Controls.Add(this.listViewDICOM);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "DICOM Viewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDICOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripOpen;
        private System.Windows.Forms.ToolStripButton toolStripClose;
        private System.Windows.Forms.ListView listViewDICOM;
        private System.Windows.Forms.ColumnHeader GroupTag;
        private System.Windows.Forms.ColumnHeader ElementTag;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.PictureBox pictureBoxDICOM;
    }
}

