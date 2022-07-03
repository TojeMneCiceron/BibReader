
namespace BibReader
{
    partial class AddSourceForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRegexRaw = new System.Windows.Forms.TextBox();
            this.tbRegexSimplified = new System.Windows.Forms.TextBox();
            this.chbUseConstructor = new System.Windows.Forms.CheckBox();
            this.btAddSymbol = new System.Windows.Forms.Button();
            this.btDeleteLastSymbol = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbHasDoubleBracketsOpening = new System.Windows.Forms.CheckBox();
            this.chbHasDoubleBracketsClosing = new System.Windows.Forms.CheckBox();
            this.chbTagCapital = new System.Windows.Forms.CheckBox();
            this.chbTagValueSpaces = new System.Windows.Forms.CheckBox();
            this.tbBibTexString = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.hp = new System.Windows.Forms.HelpProvider();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регулярное выражение";
            // 
            // tbRegexRaw
            // 
            this.tbRegexRaw.Location = new System.Drawing.Point(15, 79);
            this.tbRegexRaw.Name = "tbRegexRaw";
            this.tbRegexRaw.Size = new System.Drawing.Size(263, 20);
            this.tbRegexRaw.TabIndex = 2;
            // 
            // tbRegexSimplified
            // 
            this.tbRegexSimplified.BackColor = System.Drawing.Color.White;
            this.tbRegexSimplified.Enabled = false;
            this.tbRegexSimplified.Location = new System.Drawing.Point(15, 105);
            this.tbRegexSimplified.Name = "tbRegexSimplified";
            this.tbRegexSimplified.ReadOnly = true;
            this.tbRegexSimplified.Size = new System.Drawing.Size(263, 20);
            this.tbRegexSimplified.TabIndex = 4;
            this.tbRegexSimplified.Visible = false;
            // 
            // chbUseConstructor
            // 
            this.chbUseConstructor.AutoSize = true;
            this.chbUseConstructor.Location = new System.Drawing.Point(284, 82);
            this.chbUseConstructor.Name = "chbUseConstructor";
            this.chbUseConstructor.Size = new System.Drawing.Size(165, 17);
            this.chbUseConstructor.TabIndex = 3;
            this.chbUseConstructor.Text = "Использовать конструктор";
            this.chbUseConstructor.UseVisualStyleBackColor = true;
            this.chbUseConstructor.CheckedChanged += new System.EventHandler(this.chbUseConstructor_CheckedChanged);
            // 
            // btAddSymbol
            // 
            this.btAddSymbol.Enabled = false;
            this.btAddSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddSymbol.Location = new System.Drawing.Point(284, 103);
            this.btAddSymbol.Name = "btAddSymbol";
            this.btAddSymbol.Size = new System.Drawing.Size(31, 23);
            this.btAddSymbol.TabIndex = 5;
            this.btAddSymbol.Text = "+";
            this.tt.SetToolTip(this.btAddSymbol, "Добавить символ");
            this.btAddSymbol.UseVisualStyleBackColor = true;
            this.btAddSymbol.Visible = false;
            this.btAddSymbol.Click += new System.EventHandler(this.btAddSymbol_Click);
            // 
            // btDeleteLastSymbol
            // 
            this.btDeleteLastSymbol.Enabled = false;
            this.btDeleteLastSymbol.Location = new System.Drawing.Point(321, 103);
            this.btDeleteLastSymbol.Name = "btDeleteLastSymbol";
            this.btDeleteLastSymbol.Size = new System.Drawing.Size(31, 23);
            this.btDeleteLastSymbol.TabIndex = 6;
            this.btDeleteLastSymbol.Text = "—";
            this.tt.SetToolTip(this.btDeleteLastSymbol, "Удалить последний символ");
            this.btDeleteLastSymbol.UseVisualStyleBackColor = true;
            this.btDeleteLastSymbol.Visible = false;
            this.btDeleteLastSymbol.Click += new System.EventHandler(this.btDeleteLastSymbol_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(15, 40);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(263, 20);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Название источника";
            // 
            // tbFirstTag
            // 
            this.tbFirstTag.Location = new System.Drawing.Point(15, 146);
            this.tbFirstTag.Name = "tbFirstTag";
            this.tbFirstTag.Size = new System.Drawing.Size(263, 20);
            this.tbFirstTag.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Первый тег";
            // 
            // chbHasDoubleBracketsOpening
            // 
            this.chbHasDoubleBracketsOpening.AutoSize = true;
            this.chbHasDoubleBracketsOpening.Location = new System.Drawing.Point(15, 172);
            this.chbHasDoubleBracketsOpening.Name = "chbHasDoubleBracketsOpening";
            this.chbHasDoubleBracketsOpening.Size = new System.Drawing.Size(61, 17);
            this.chbHasDoubleBracketsOpening.TabIndex = 8;
            this.chbHasDoubleBracketsOpening.Text = "Есть {{";
            this.chbHasDoubleBracketsOpening.UseVisualStyleBackColor = true;
            // 
            // chbHasDoubleBracketsClosing
            // 
            this.chbHasDoubleBracketsClosing.AutoSize = true;
            this.chbHasDoubleBracketsClosing.Location = new System.Drawing.Point(15, 195);
            this.chbHasDoubleBracketsClosing.Name = "chbHasDoubleBracketsClosing";
            this.chbHasDoubleBracketsClosing.Size = new System.Drawing.Size(61, 17);
            this.chbHasDoubleBracketsClosing.TabIndex = 9;
            this.chbHasDoubleBracketsClosing.Text = "Есть }}";
            this.chbHasDoubleBracketsClosing.UseVisualStyleBackColor = true;
            // 
            // chbTagCapital
            // 
            this.chbTagCapital.AutoSize = true;
            this.chbTagCapital.Location = new System.Drawing.Point(104, 172);
            this.chbTagCapital.Name = "chbTagCapital";
            this.chbTagCapital.Size = new System.Drawing.Size(140, 17);
            this.chbTagCapital.TabIndex = 10;
            this.chbTagCapital.Text = "Теги с большой буквы";
            this.chbTagCapital.UseVisualStyleBackColor = true;
            // 
            // chbTagValueSpaces
            // 
            this.chbTagValueSpaces.AutoSize = true;
            this.chbTagValueSpaces.Location = new System.Drawing.Point(104, 195);
            this.chbTagValueSpaces.Name = "chbTagValueSpaces";
            this.chbTagValueSpaces.Size = new System.Drawing.Size(255, 17);
            this.chbTagValueSpaces.TabIndex = 11;
            this.chbTagValueSpaces.Text = "Есть пробелы между тегом, \"=\" и значением";
            this.chbTagValueSpaces.UseVisualStyleBackColor = true;
            // 
            // tbBibTexString
            // 
            this.tbBibTexString.BackColor = System.Drawing.Color.White;
            this.tbBibTexString.Location = new System.Drawing.Point(15, 218);
            this.tbBibTexString.Multiline = true;
            this.tbBibTexString.Name = "tbBibTexString";
            this.tbBibTexString.ReadOnly = true;
            this.tbBibTexString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBibTexString.Size = new System.Drawing.Size(426, 139);
            this.tbBibTexString.TabIndex = 15;
            this.tbBibTexString.TabStop = false;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(150, 363);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 12;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(231, 363);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 13;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // hp
            // 
            this.hp.HelpNamespace = "help.html";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(457, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // AddSourceForm
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(457, 398);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.tbBibTexString);
            this.Controls.Add(this.chbTagValueSpaces);
            this.Controls.Add(this.chbTagCapital);
            this.Controls.Add(this.chbHasDoubleBracketsClosing);
            this.Controls.Add(this.chbHasDoubleBracketsOpening);
            this.Controls.Add(this.tbFirstTag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btDeleteLastSymbol);
            this.Controls.Add(this.btAddSymbol);
            this.Controls.Add(this.chbUseConstructor);
            this.Controls.Add(this.tbRegexSimplified);
            this.Controls.Add(this.tbRegexRaw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.hp.SetHelpKeyword(this, "sources");
            this.hp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSourceForm";
            this.hp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Новый источник";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRegexRaw;
        private System.Windows.Forms.TextBox tbRegexSimplified;
        private System.Windows.Forms.CheckBox chbUseConstructor;
        private System.Windows.Forms.Button btAddSymbol;
        private System.Windows.Forms.Button btDeleteLastSymbol;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirstTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbHasDoubleBracketsOpening;
        private System.Windows.Forms.CheckBox chbHasDoubleBracketsClosing;
        private System.Windows.Forms.CheckBox chbTagCapital;
        private System.Windows.Forms.CheckBox chbTagValueSpaces;
        private System.Windows.Forms.TextBox tbBibTexString;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.HelpProvider hp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
    }
}