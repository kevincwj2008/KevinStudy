namespace LuceneIndex
{
    partial class Index
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectField = new System.Windows.Forms.TextBox();
            this.CreateIndexBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SegField = new System.Windows.Forms.TextBox();
            this.IndexCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "链接字符串：";
            // 
            // ConnectionString
            // 
            this.ConnectionString.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConnectionString.Location = new System.Drawing.Point(188, 18);
            this.ConnectionString.Name = "ConnectionString";
            this.ConnectionString.Size = new System.Drawing.Size(747, 30);
            this.ConnectionString.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "索引表(小写)：";
            // 
            // tableName
            // 
            this.tableName.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableName.Location = new System.Drawing.Point(188, 60);
            this.tableName.Name = "tableName";
            this.tableName.Size = new System.Drawing.Size(747, 30);
            this.tableName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "查询字段(小写)：";
            // 
            // SelectField
            // 
            this.SelectField.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectField.Location = new System.Drawing.Point(188, 106);
            this.SelectField.Name = "SelectField";
            this.SelectField.Size = new System.Drawing.Size(747, 30);
            this.SelectField.TabIndex = 3;
            // 
            // CreateIndexBtn
            // 
            this.CreateIndexBtn.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreateIndexBtn.Location = new System.Drawing.Point(188, 239);
            this.CreateIndexBtn.Name = "CreateIndexBtn";
            this.CreateIndexBtn.Size = new System.Drawing.Size(134, 32);
            this.CreateIndexBtn.TabIndex = 2;
            this.CreateIndexBtn.Text = "创建索引";
            this.CreateIndexBtn.UseVisualStyleBackColor = true;
            this.CreateIndexBtn.Click += new System.EventHandler(this.CreateIndexBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "分词字段(小写)：";
            // 
            // SegField
            // 
            this.SegField.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SegField.Location = new System.Drawing.Point(188, 149);
            this.SegField.Name = "SegField";
            this.SegField.Size = new System.Drawing.Size(747, 30);
            this.SegField.TabIndex = 4;
            // 
            // IndexCount
            // 
            this.IndexCount.AutoSize = true;
            this.IndexCount.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IndexCount.Location = new System.Drawing.Point(184, 200);
            this.IndexCount.Name = "IndexCount";
            this.IndexCount.Size = new System.Drawing.Size(93, 20);
            this.IndexCount.TabIndex = 0;
            this.IndexCount.Text = "创建索引";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 563);
            this.Controls.Add(this.CreateIndexBtn);
            this.Controls.Add(this.SegField);
            this.Controls.Add(this.SelectField);
            this.Controls.Add(this.tableName);
            this.Controls.Add(this.ConnectionString);
            this.Controls.Add(this.IndexCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Index";
            this.Text = "LuceneIndex";
            this.Load += new System.EventHandler(this.Index_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SelectField;
        private System.Windows.Forms.Button CreateIndexBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SegField;
        private System.Windows.Forms.Label IndexCount;
    }
}

