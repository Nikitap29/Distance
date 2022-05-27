
namespace Distance
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.zed = new ZedGraph.ZedGraphControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.zed2 = new ZedGraph.ZedGraphControl();
            this.button4 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Файл 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenFile1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 53);
            this.button2.TabIndex = 0;
            this.button2.Text = "Файл 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OpenFile2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 53);
            this.button3.TabIndex = 0;
            this.button3.Text = "Расстояние";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CalcDistances);
            // 
            // zed
            // 
            this.zed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zed.Location = new System.Drawing.Point(3, 3);
            this.zed.Name = "zed";
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(643, 344);
            this.zed.TabIndex = 1;
            this.zed.UseExtendedPrintDialog = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // zed2
            // 
            this.zed2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zed2.Location = new System.Drawing.Point(3, 3);
            this.zed2.Name = "zed2";
            this.zed2.ScrollGrace = 0D;
            this.zed2.ScrollMaxX = 0D;
            this.zed2.ScrollMaxY = 0D;
            this.zed2.ScrollMaxY2 = 0D;
            this.zed2.ScrollMinX = 0D;
            this.zed2.ScrollMinY = 0D;
            this.zed2.ScrollMinY2 = 0D;
            this.zed2.Size = new System.Drawing.Size(643, 92);
            this.zed2.TabIndex = 2;
            this.zed2.UseExtendedPrintDialog = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 53);
            this.button4.TabIndex = 0;
            this.button4.Text = "Гистограмма";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.DrawHist);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(138, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zed);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zed2);
            this.splitContainer1.Size = new System.Drawing.Size(654, 452);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 491);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private ZedGraph.ZedGraphControl zed;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private ZedGraph.ZedGraphControl zed2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

