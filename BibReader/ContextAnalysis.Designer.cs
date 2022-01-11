namespace BibReader
{
    partial class ContextAnalysis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControlForAnalisys = new System.Windows.Forms.TabControl();
            this.tpSynopsis = new System.Windows.Forms.TabPage();
            this.lvStopwords = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbEditRule = new System.Windows.Forms.GroupBox();
            this.btReAnalysis = new System.Windows.Forms.Button();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chSynopsis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lvSynopsis = new System.Windows.Forms.ListView();
            this.tbContext = new System.Windows.Forms.TextBox();
            this.tpConcepts = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvConcepts = new System.Windows.Forms.ListView();
            this.tbThesaurus = new System.Windows.Forms.TabPage();
            this.lvThesaurus = new System.Windows.Forms.ListView();
            this.tbNames = new System.Windows.Forms.TabPage();
            this.lvOrganization = new System.Windows.Forms.ListView();
            this.lvPerson = new System.Windows.Forms.ListView();
            this.btSaveDiagram = new System.Windows.Forms.Button();
            this.btСonnection = new System.Windows.Forms.Button();
            this.pGraphic = new System.Windows.Forms.PictureBox();
            this.tabControlForAnalisys.SuspendLayout();
            this.tpSynopsis.SuspendLayout();
            this.gbEditRule.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chSynopsis)).BeginInit();
            this.tpConcepts.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbThesaurus.SuspendLayout();
            this.tbNames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlForAnalisys
            // 
            this.tabControlForAnalisys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlForAnalisys.Controls.Add(this.tpSynopsis);
            this.tabControlForAnalisys.Controls.Add(this.tpConcepts);
            this.tabControlForAnalisys.Controls.Add(this.tbThesaurus);
            this.tabControlForAnalisys.Controls.Add(this.tbNames);
            this.tabControlForAnalisys.Location = new System.Drawing.Point(686, 3);
            this.tabControlForAnalisys.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlForAnalisys.Name = "tabControlForAnalisys";
            this.tabControlForAnalisys.SelectedIndex = 0;
            this.tabControlForAnalisys.Size = new System.Drawing.Size(521, 677);
            this.tabControlForAnalisys.TabIndex = 5;
            this.tabControlForAnalisys.SelectedIndexChanged += new System.EventHandler(this.tabControlForAnalisys_SelectedIndexChanged);
            // 
            // tpSynopsis
            // 
            this.tpSynopsis.Controls.Add(this.lvStopwords);
            this.tpSynopsis.Controls.Add(this.gbEditRule);
            this.tpSynopsis.Controls.Add(this.panel1);
            this.tpSynopsis.Controls.Add(this.tbContext);
            this.tpSynopsis.Location = new System.Drawing.Point(4, 22);
            this.tpSynopsis.Margin = new System.Windows.Forms.Padding(2);
            this.tpSynopsis.Name = "tpSynopsis";
            this.tpSynopsis.Padding = new System.Windows.Forms.Padding(2);
            this.tpSynopsis.Size = new System.Drawing.Size(513, 651);
            this.tpSynopsis.TabIndex = 0;
            this.tpSynopsis.Text = "Краткий обзор";
            this.tpSynopsis.UseVisualStyleBackColor = true;
            // 
            // lvStopwords
            // 
            this.lvStopwords.AllowDrop = true;
            this.lvStopwords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name});
            this.lvStopwords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvStopwords.FullRowSelect = true;
            this.lvStopwords.GridLines = true;
            this.lvStopwords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvStopwords.HideSelection = false;
            this.lvStopwords.Location = new System.Drawing.Point(5, 217);
            this.lvStopwords.MultiSelect = false;
            this.lvStopwords.Name = "lvStopwords";
            this.lvStopwords.Size = new System.Drawing.Size(197, 250);
            this.lvStopwords.TabIndex = 16;
            this.lvStopwords.UseCompatibleStateImageBehavior = false;
            this.lvStopwords.View = System.Windows.Forms.View.Details;
            this.lvStopwords.SelectedIndexChanged += new System.EventHandler(this.lvStopwords_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = " Стоп слово";
            this.name.Width = 127;
            // 
            // gbEditRule
            // 
            this.gbEditRule.Controls.Add(this.btReAnalysis);
            this.gbEditRule.Controls.Add(this.tbValue);
            this.gbEditRule.Controls.Add(this.btDelete);
            this.gbEditRule.Controls.Add(this.btAdd);
            this.gbEditRule.Location = new System.Drawing.Point(5, 473);
            this.gbEditRule.Name = "gbEditRule";
            this.gbEditRule.Size = new System.Drawing.Size(196, 173);
            this.gbEditRule.TabIndex = 9;
            this.gbEditRule.TabStop = false;
            this.gbEditRule.Text = "Редактирование списка стоп-слов";
            // 
            // btReAnalysis
            // 
            this.btReAnalysis.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btReAnalysis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReAnalysis.Enabled = false;
            this.btReAnalysis.Location = new System.Drawing.Point(8, 115);
            this.btReAnalysis.Name = "btReAnalysis";
            this.btReAnalysis.Size = new System.Drawing.Size(178, 52);
            this.btReAnalysis.TabIndex = 11;
            this.btReAnalysis.Text = "Выполнить анализ с использованием списка стоп-слов";
            this.btReAnalysis.UseVisualStyleBackColor = false;
            this.btReAnalysis.Click += new System.EventHandler(this.btReAnalysis_Click);
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(8, 34);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(178, 20);
            this.tbValue.TabIndex = 10;
            this.tbValue.TextChanged += new System.EventHandler(this.tbValue_TextChanged);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDelete.Enabled = false;
            this.btDelete.Location = new System.Drawing.Point(8, 86);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(178, 26);
            this.btDelete.TabIndex = 2;
            this.btDelete.Text = "Удалить";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDeleteStopword_Click);
            // 
            // btAdd
            // 
            this.btAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.Enabled = false;
            this.btAdd.Location = new System.Drawing.Point(8, 58);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(178, 26);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = false;
            this.btAdd.Click += new System.EventHandler(this.btAddStopword_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chSynopsis);
            this.panel1.Controls.Add(this.lvSynopsis);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 206);
            this.panel1.TabIndex = 7;
            // 
            // chSynopsis
            // 
            this.chSynopsis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chSynopsis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chSynopsis.BackImageTransparentColor = System.Drawing.Color.White;
            this.chSynopsis.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chSynopsis.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chSynopsis.Legends.Add(legend1);
            this.chSynopsis.Location = new System.Drawing.Point(155, 13);
            this.chSynopsis.Name = "chSynopsis";
            this.chSynopsis.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chSynopsis.Series.Add(series1);
            this.chSynopsis.Size = new System.Drawing.Size(343, 201);
            this.chSynopsis.TabIndex = 2;
            this.chSynopsis.Text = "Понятия";
            // 
            // lvSynopsis
            // 
            this.lvSynopsis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSynopsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSynopsis.HideSelection = false;
            this.lvSynopsis.Location = new System.Drawing.Point(2, 3);
            this.lvSynopsis.Margin = new System.Windows.Forms.Padding(2);
            this.lvSynopsis.Name = "lvSynopsis";
            this.lvSynopsis.Size = new System.Drawing.Size(148, 198);
            this.lvSynopsis.TabIndex = 0;
            this.lvSynopsis.UseCompatibleStateImageBehavior = false;
            this.lvSynopsis.View = System.Windows.Forms.View.Details;
            this.lvSynopsis.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvSynopsis_DrawColumnHeader);
            this.lvSynopsis.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvSynopsis_DrawSubItem);
            // 
            // tbContext
            // 
            this.tbContext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContext.Location = new System.Drawing.Point(206, 217);
            this.tbContext.Margin = new System.Windows.Forms.Padding(2);
            this.tbContext.Multiline = true;
            this.tbContext.Name = "tbContext";
            this.tbContext.ReadOnly = true;
            this.tbContext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbContext.Size = new System.Drawing.Size(301, 429);
            this.tbContext.TabIndex = 6;
            // 
            // tpConcepts
            // 
            this.tpConcepts.Controls.Add(this.panel2);
            this.tpConcepts.Location = new System.Drawing.Point(4, 22);
            this.tpConcepts.Margin = new System.Windows.Forms.Padding(2);
            this.tpConcepts.Name = "tpConcepts";
            this.tpConcepts.Padding = new System.Windows.Forms.Padding(2);
            this.tpConcepts.Size = new System.Drawing.Size(513, 651);
            this.tpConcepts.TabIndex = 1;
            this.tpConcepts.Text = "Общее представление";
            this.tpConcepts.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lvConcepts);
            this.panel2.Location = new System.Drawing.Point(4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(505, 641);
            this.panel2.TabIndex = 8;
            // 
            // lvConcepts
            // 
            this.lvConcepts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lvConcepts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvConcepts.HideSelection = false;
            this.lvConcepts.Location = new System.Drawing.Point(-1, 2);
            this.lvConcepts.Margin = new System.Windows.Forms.Padding(2);
            this.lvConcepts.Name = "lvConcepts";
            this.lvConcepts.Size = new System.Drawing.Size(502, 635);
            this.lvConcepts.TabIndex = 6;
            this.lvConcepts.UseCompatibleStateImageBehavior = false;
            this.lvConcepts.View = System.Windows.Forms.View.Details;
            this.lvConcepts.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvConcepts_DrawColumnHeader);
            this.lvConcepts.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvConcepts_DrawSubItem);
            // 
            // tbThesaurus
            // 
            this.tbThesaurus.Controls.Add(this.lvThesaurus);
            this.tbThesaurus.Location = new System.Drawing.Point(4, 22);
            this.tbThesaurus.Margin = new System.Windows.Forms.Padding(2);
            this.tbThesaurus.Name = "tbThesaurus";
            this.tbThesaurus.Padding = new System.Windows.Forms.Padding(2);
            this.tbThesaurus.Size = new System.Drawing.Size(513, 651);
            this.tbThesaurus.TabIndex = 2;
            this.tbThesaurus.Text = "Тезаурус";
            this.tbThesaurus.UseVisualStyleBackColor = true;
            // 
            // lvThesaurus
            // 
            this.lvThesaurus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvThesaurus.HideSelection = false;
            this.lvThesaurus.Location = new System.Drawing.Point(4, 5);
            this.lvThesaurus.Margin = new System.Windows.Forms.Padding(2);
            this.lvThesaurus.Name = "lvThesaurus";
            this.lvThesaurus.Size = new System.Drawing.Size(505, 642);
            this.lvThesaurus.TabIndex = 3;
            this.lvThesaurus.UseCompatibleStateImageBehavior = false;
            this.lvThesaurus.View = System.Windows.Forms.View.Details;
            // 
            // tbNames
            // 
            this.tbNames.Controls.Add(this.lvOrganization);
            this.tbNames.Controls.Add(this.lvPerson);
            this.tbNames.Location = new System.Drawing.Point(4, 22);
            this.tbNames.Name = "tbNames";
            this.tbNames.Size = new System.Drawing.Size(513, 651);
            this.tbNames.TabIndex = 3;
            this.tbNames.Text = "Имена";
            this.tbNames.UseVisualStyleBackColor = true;
            // 
            // lvOrganization
            // 
            this.lvOrganization.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOrganization.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOrganization.HideSelection = false;
            this.lvOrganization.Location = new System.Drawing.Point(254, 5);
            this.lvOrganization.Margin = new System.Windows.Forms.Padding(2);
            this.lvOrganization.Name = "lvOrganization";
            this.lvOrganization.Size = new System.Drawing.Size(253, 644);
            this.lvOrganization.TabIndex = 2;
            this.lvOrganization.UseCompatibleStateImageBehavior = false;
            this.lvOrganization.View = System.Windows.Forms.View.Details;
            // 
            // lvPerson
            // 
            this.lvPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPerson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPerson.HideSelection = false;
            this.lvPerson.Location = new System.Drawing.Point(4, 5);
            this.lvPerson.Margin = new System.Windows.Forms.Padding(2);
            this.lvPerson.Name = "lvPerson";
            this.lvPerson.Size = new System.Drawing.Size(246, 644);
            this.lvPerson.TabIndex = 1;
            this.lvPerson.UseCompatibleStateImageBehavior = false;
            this.lvPerson.View = System.Windows.Forms.View.Details;
            // 
            // btSaveDiagram
            // 
            this.btSaveDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveDiagram.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btSaveDiagram.Location = new System.Drawing.Point(522, 643);
            this.btSaveDiagram.Margin = new System.Windows.Forms.Padding(2);
            this.btSaveDiagram.Name = "btSaveDiagram";
            this.btSaveDiagram.Size = new System.Drawing.Size(159, 37);
            this.btSaveDiagram.TabIndex = 13;
            this.btSaveDiagram.Text = "Сохранить диаграмму";
            this.btSaveDiagram.UseVisualStyleBackColor = false;
            this.btSaveDiagram.Click += new System.EventHandler(this.btSaveDiagram_Click);
            // 
            // btСonnection
            // 
            this.btСonnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btСonnection.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btСonnection.Location = new System.Drawing.Point(359, 643);
            this.btСonnection.Margin = new System.Windows.Forms.Padding(2);
            this.btСonnection.Name = "btСonnection";
            this.btСonnection.Size = new System.Drawing.Size(159, 37);
            this.btСonnection.TabIndex = 14;
            this.btСonnection.Text = "Показать связи";
            this.btСonnection.UseVisualStyleBackColor = false;
            this.btСonnection.Click += new System.EventHandler(this.btConnection_Click);
            // 
            // pGraphic
            // 
            this.pGraphic.Location = new System.Drawing.Point(3, 3);
            this.pGraphic.Name = "pGraphic";
            this.pGraphic.Size = new System.Drawing.Size(678, 635);
            this.pGraphic.TabIndex = 15;
            this.pGraphic.TabStop = false;
            // 
            // ContextAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 687);
            this.Controls.Add(this.pGraphic);
            this.Controls.Add(this.btСonnection);
            this.Controls.Add(this.btSaveDiagram);
            this.Controls.Add(this.tabControlForAnalisys);
            this.MaximumSize = new System.Drawing.Size(1224, 726);
            this.MinimumSize = new System.Drawing.Size(1224, 726);
            this.Name = "ContextAnalysis";
            this.Text = "Контекстный анализ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContextAnalysis_FormClosed);
            this.Load += new System.EventHandler(this.ContextAnalysis_Load);
            this.Shown += new System.EventHandler(this.ContextAnalysis_Shown);
            this.tabControlForAnalisys.ResumeLayout(false);
            this.tpSynopsis.ResumeLayout(false);
            this.tpSynopsis.PerformLayout();
            this.gbEditRule.ResumeLayout(false);
            this.gbEditRule.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chSynopsis)).EndInit();
            this.tpConcepts.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tbThesaurus.ResumeLayout(false);
            this.tbNames.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pGraphic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlForAnalisys;
        private System.Windows.Forms.TabPage tpSynopsis;
        private System.Windows.Forms.ListView lvSynopsis;
        private System.Windows.Forms.TabPage tpConcepts;
        private System.Windows.Forms.TabPage tbThesaurus;
        private System.Windows.Forms.ListView lvThesaurus;
        private System.Windows.Forms.TextBox tbContext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvConcepts;
        private System.Windows.Forms.TabPage tbNames;
        private System.Windows.Forms.ListView lvPerson;
        private System.Windows.Forms.DataVisualization.Charting.Chart chSynopsis;
        private System.Windows.Forms.ListView lvOrganization;
        private System.Windows.Forms.Button btSaveDiagram;
        private System.Windows.Forms.ListView lvStopwords;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.GroupBox gbEditRule;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btСonnection;
        private System.Windows.Forms.Button btReAnalysis;
        private System.Windows.Forms.PictureBox pGraphic;
    }
}