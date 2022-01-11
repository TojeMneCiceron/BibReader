namespace BibReader
{
    partial class ClassificationForm
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
            this.pictBox = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpText = new System.Windows.Forms.TabPage();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.tpFreqs = new System.Windows.Forms.TabPage();
            this.tbSaveFreqsInExcel = new System.Windows.Forms.Button();
            this.btDeleteItems = new System.Windows.Forms.Button();
            this.lvFreqs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPrevFindedLibItem = new System.Windows.Forms.Button();
            this.btNextFindedLibItem = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.tbRedraw = new System.Windows.Forms.Button();
            this.btSaveImage = new System.Windows.Forms.Button();
            this.nudWordsCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxImageIsBlack = new System.Windows.Forms.CheckBox();
            this.checkBoxFreq = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpText.SuspendLayout();
            this.tpFreqs.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWordsCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictBox
            // 
            this.pictBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictBox.Location = new System.Drawing.Point(596, 33);
            this.pictBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictBox.Name = "pictBox";
            this.pictBox.Size = new System.Drawing.Size(421, 318);
            this.pictBox.TabIndex = 1;
            this.pictBox.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpText);
            this.tabControl1.Controls.Add(this.tpFreqs);
            this.tabControl1.Location = new System.Drawing.Point(9, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 410);
            this.tabControl1.TabIndex = 2;
            // 
            // tpText
            // 
            this.tpText.Controls.Add(this.tbInfo);
            this.tpText.Location = new System.Drawing.Point(4, 22);
            this.tpText.Margin = new System.Windows.Forms.Padding(2);
            this.tpText.Name = "tpText";
            this.tpText.Padding = new System.Windows.Forms.Padding(2);
            this.tpText.Size = new System.Drawing.Size(574, 384);
            this.tpText.TabIndex = 0;
            this.tpText.Text = "Текст";
            this.tpText.UseVisualStyleBackColor = true;
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.Location = new System.Drawing.Point(4, 5);
            this.tbInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(566, 375);
            this.tbInfo.TabIndex = 0;
            // 
            // tpFreqs
            // 
            this.tpFreqs.Controls.Add(this.tbSaveFreqsInExcel);
            this.tpFreqs.Controls.Add(this.btDeleteItems);
            this.tpFreqs.Controls.Add(this.lvFreqs);
            this.tpFreqs.Controls.Add(this.groupBox1);
            this.tpFreqs.Location = new System.Drawing.Point(4, 22);
            this.tpFreqs.Margin = new System.Windows.Forms.Padding(2);
            this.tpFreqs.Name = "tpFreqs";
            this.tpFreqs.Padding = new System.Windows.Forms.Padding(2);
            this.tpFreqs.Size = new System.Drawing.Size(574, 384);
            this.tpFreqs.TabIndex = 1;
            this.tpFreqs.Text = "Частота";
            this.tpFreqs.UseVisualStyleBackColor = true;
            // 
            // tbSaveFreqsInExcel
            // 
            this.tbSaveFreqsInExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSaveFreqsInExcel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbSaveFreqsInExcel.Location = new System.Drawing.Point(5, 348);
            this.tbSaveFreqsInExcel.Margin = new System.Windows.Forms.Padding(2);
            this.tbSaveFreqsInExcel.Name = "tbSaveFreqsInExcel";
            this.tbSaveFreqsInExcel.Size = new System.Drawing.Size(108, 29);
            this.tbSaveFreqsInExcel.TabIndex = 19;
            this.tbSaveFreqsInExcel.Text = "Сохранить в Excel";
            this.tbSaveFreqsInExcel.UseVisualStyleBackColor = false;
            this.tbSaveFreqsInExcel.Click += new System.EventHandler(this.tbSaveFreqsInExcel_Click);
            // 
            // btDeleteItems
            // 
            this.btDeleteItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeleteItems.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btDeleteItems.Location = new System.Drawing.Point(5, 315);
            this.btDeleteItems.Margin = new System.Windows.Forms.Padding(2);
            this.btDeleteItems.Name = "btDeleteItems";
            this.btDeleteItems.Size = new System.Drawing.Size(108, 29);
            this.btDeleteItems.TabIndex = 1;
            this.btDeleteItems.Text = "Удалить";
            this.btDeleteItems.UseVisualStyleBackColor = false;
            this.btDeleteItems.Click += new System.EventHandler(this.btDeleteItems_Click);
            // 
            // lvFreqs
            // 
            this.lvFreqs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFreqs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvFreqs.FullRowSelect = true;
            this.lvFreqs.HideSelection = false;
            this.lvFreqs.Location = new System.Drawing.Point(5, 6);
            this.lvFreqs.Margin = new System.Windows.Forms.Padding(2);
            this.lvFreqs.Name = "lvFreqs";
            this.lvFreqs.Size = new System.Drawing.Size(562, 305);
            this.lvFreqs.TabIndex = 0;
            this.lvFreqs.UseCompatibleStateImageBehavior = false;
            this.lvFreqs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Слово";
            this.columnHeader1.Width = 295;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Количество";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 248;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btPrevFindedLibItem);
            this.groupBox1.Controls.Add(this.btNextFindedLibItem);
            this.groupBox1.Controls.Add(this.tbFind);
            this.groupBox1.Location = new System.Drawing.Point(318, 322);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(249, 51);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // btPrevFindedLibItem
            // 
            this.btPrevFindedLibItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btPrevFindedLibItem.Location = new System.Drawing.Point(182, 17);
            this.btPrevFindedLibItem.Margin = new System.Windows.Forms.Padding(2);
            this.btPrevFindedLibItem.Name = "btPrevFindedLibItem";
            this.btPrevFindedLibItem.Size = new System.Drawing.Size(29, 21);
            this.btPrevFindedLibItem.TabIndex = 17;
            this.btPrevFindedLibItem.Text = "<<";
            this.btPrevFindedLibItem.UseVisualStyleBackColor = false;
            this.btPrevFindedLibItem.Click += new System.EventHandler(this.btPrevFindedLibItem_Click);
            // 
            // btNextFindedLibItem
            // 
            this.btNextFindedLibItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btNextFindedLibItem.Location = new System.Drawing.Point(215, 17);
            this.btNextFindedLibItem.Margin = new System.Windows.Forms.Padding(2);
            this.btNextFindedLibItem.Name = "btNextFindedLibItem";
            this.btNextFindedLibItem.Size = new System.Drawing.Size(29, 21);
            this.btNextFindedLibItem.TabIndex = 16;
            this.btNextFindedLibItem.Text = ">>";
            this.btNextFindedLibItem.UseVisualStyleBackColor = false;
            this.btNextFindedLibItem.Click += new System.EventHandler(this.btNextFindedLibItem_Click);
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(10, 17);
            this.tbFind.Margin = new System.Windows.Forms.Padding(2);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(168, 20);
            this.tbFind.TabIndex = 14;
            // 
            // tbRedraw
            // 
            this.tbRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRedraw.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbRedraw.Location = new System.Drawing.Point(596, 355);
            this.tbRedraw.Margin = new System.Windows.Forms.Padding(2);
            this.tbRedraw.Name = "tbRedraw";
            this.tbRedraw.Size = new System.Drawing.Size(122, 32);
            this.tbRedraw.TabIndex = 1;
            this.tbRedraw.Text = "Перерисовать";
            this.tbRedraw.UseVisualStyleBackColor = false;
            this.tbRedraw.Click += new System.EventHandler(this.tbRedraw_Click);
            // 
            // btSaveImage
            // 
            this.btSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btSaveImage.Location = new System.Drawing.Point(596, 389);
            this.btSaveImage.Margin = new System.Windows.Forms.Padding(2);
            this.btSaveImage.Name = "btSaveImage";
            this.btSaveImage.Size = new System.Drawing.Size(122, 32);
            this.btSaveImage.TabIndex = 3;
            this.btSaveImage.Text = "Сохранить картинку";
            this.btSaveImage.UseVisualStyleBackColor = false;
            this.btSaveImage.Click += new System.EventHandler(this.btSaveImage_Click);
            // 
            // nudWordsCount
            // 
            this.nudWordsCount.Location = new System.Drawing.Point(4, 20);
            this.nudWordsCount.Margin = new System.Windows.Forms.Padding(2);
            this.nudWordsCount.Name = "nudWordsCount";
            this.nudWordsCount.Size = new System.Drawing.Size(101, 20);
            this.nudWordsCount.TabIndex = 4;
            this.nudWordsCount.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBoxImageIsBlack);
            this.groupBox2.Controls.Add(this.nudWordsCount);
            this.groupBox2.Location = new System.Drawing.Point(722, 355);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(131, 66);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Количество слов";
            // 
            // checkBoxImageIsBlack
            // 
            this.checkBoxImageIsBlack.AutoSize = true;
            this.checkBoxImageIsBlack.Location = new System.Drawing.Point(4, 44);
            this.checkBoxImageIsBlack.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxImageIsBlack.Name = "checkBoxImageIsBlack";
            this.checkBoxImageIsBlack.Size = new System.Drawing.Size(93, 17);
            this.checkBoxImageIsBlack.TabIndex = 5;
            this.checkBoxImageIsBlack.Text = "Черно-белый";
            this.checkBoxImageIsBlack.UseVisualStyleBackColor = true;
            // 
            // checkBoxFreq
            // 
            this.checkBoxFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFreq.AutoSize = true;
            this.checkBoxFreq.Location = new System.Drawing.Point(857, 360);
            this.checkBoxFreq.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxFreq.Name = "checkBoxFreq";
            this.checkBoxFreq.Size = new System.Drawing.Size(102, 17);
            this.checkBoxFreq.TabIndex = 6;
            this.checkBoxFreq.Text = "Слово+частота";
            this.checkBoxFreq.UseVisualStyleBackColor = true;
            // 
            // ClassificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 437);
            this.Controls.Add(this.checkBoxFreq);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbRedraw);
            this.Controls.Add(this.btSaveImage);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1027, 476);
            this.Name = "ClassificationForm";
            this.Text = "Классификация";
            this.Load += new System.EventHandler(this.ClusterizationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpText.ResumeLayout(false);
            this.tpText.PerformLayout();
            this.tpFreqs.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWordsCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpText;
        private System.Windows.Forms.TabPage tpFreqs;
        private System.Windows.Forms.ListView lvFreqs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btDeleteItems;
        private System.Windows.Forms.Button tbRedraw;
        private System.Windows.Forms.Button btSaveImage;
        private System.Windows.Forms.NumericUpDown nudWordsCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btPrevFindedLibItem;
        private System.Windows.Forms.Button btNextFindedLibItem;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxImageIsBlack;
        private System.Windows.Forms.Button tbSaveFreqsInExcel;
        private System.Windows.Forms.CheckBox checkBoxFreq;
        private System.Windows.Forms.TextBox tbInfo;
    }
}