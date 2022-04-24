
namespace BibReader
{
    partial class AddSymbol
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
            this.cbSymbol = new System.Windows.Forms.ComboBox();
            this.tbOther = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.nudRepeat = new System.Windows.Forms.NumericUpDown();
            this.chbSeveral = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeat)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSymbol
            // 
            this.cbSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSymbol.FormattingEnabled = true;
            this.cbSymbol.Location = new System.Drawing.Point(13, 25);
            this.cbSymbol.Name = "cbSymbol";
            this.cbSymbol.Size = new System.Drawing.Size(146, 21);
            this.cbSymbol.TabIndex = 0;
            this.cbSymbol.SelectedIndexChanged += new System.EventHandler(this.cbSymbol_SelectedIndexChanged);
            // 
            // tbOther
            // 
            this.tbOther.Enabled = false;
            this.tbOther.Location = new System.Drawing.Point(13, 52);
            this.tbOther.MaxLength = 50;
            this.tbOther.Name = "tbOther";
            this.tbOther.Size = new System.Drawing.Size(146, 20);
            this.tbOther.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Символ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Число повторений";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(21, 141);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(62, 23);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(89, 141);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(66, 23);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // nudRepeat
            // 
            this.nudRepeat.Location = new System.Drawing.Point(13, 92);
            this.nudRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRepeat.Name = "nudRepeat";
            this.nudRepeat.Size = new System.Drawing.Size(146, 20);
            this.nudRepeat.TabIndex = 7;
            this.nudRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chbSeveral
            // 
            this.chbSeveral.AutoSize = true;
            this.chbSeveral.Location = new System.Drawing.Point(13, 118);
            this.chbSeveral.Name = "chbSeveral";
            this.chbSeveral.Size = new System.Drawing.Size(82, 17);
            this.chbSeveral.TabIndex = 8;
            this.chbSeveral.Text = "Несколько";
            this.chbSeveral.UseVisualStyleBackColor = true;
            this.chbSeveral.CheckedChanged += new System.EventHandler(this.chbSeveral_CheckedChanged);
            // 
            // AddSymbol
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(177, 173);
            this.Controls.Add(this.chbSeveral);
            this.Controls.Add(this.nudRepeat);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOther);
            this.Controls.Add(this.cbSymbol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSymbol";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Символ";
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSymbol;
        private System.Windows.Forms.TextBox tbOther;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.NumericUpDown nudRepeat;
        private System.Windows.Forms.CheckBox chbSeveral;
    }
}