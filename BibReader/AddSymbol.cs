using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader
{
    public partial class AddSymbol : Form
    {
        public Symbol Symbol { get; set; }
        public string Repeat { get; set; }
        public AddSymbol()
        {
            InitializeComponent();
            cbSymbol.Items.Add(new Symbol("Цифра", @"\d"));
            cbSymbol.Items.Add(new Symbol("Буква", @"\w"));
            //cbSymbol.Items.Add(new Symbol("\\", @"\"));
            cbSymbol.Items.Add(new Symbol(".", @"\."));
            cbSymbol.Items.Add(new Symbol("Другой символ", ""));
            cbSymbol.Items.Add(new Symbol("Любые символы", ".*"));
            cbSymbol.Items.Add(new Symbol("Подстрока", ""));
            cbSymbol.SelectedIndex = 0;
        }

        private string DeleteExtraSpaces(string str)
        {
            return Regex.Replace(DeleteBorderSpaces(str), "\\s+", " ");
        }

        private string DeleteBorderSpaces(string str)
        {
            return Regex.Replace(Regex.Replace(str, "^\\s+", ""), "\\s+$", "");
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (cbSymbol.Text == "Любые символы")
            {
                Symbol = (Symbol)cbSymbol.SelectedItem;
                Repeat = "";
            }
            else
            {
                if (cbSymbol.Text == "Другой символ" || cbSymbol.Text == "Подстрока")
                {
                    string other = DeleteExtraSpaces(tbOther.Text);

                    if (other == "")
                    {
                        MessageBox.Show("Введите символ", "Ошибка");
                        return;
                    }
                    else
                        Symbol = new Symbol(other, other);
                }
                else
                    Symbol = (Symbol)cbSymbol.SelectedItem;
                Repeat = chbSeveral.Checked ? "+" : cbSymbol.Text == "Подстрока" ? "" : "{" + nudRepeat.Value.ToString() + "}";
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbOther.Enabled = cbSymbol.Text == "Другой символ" || cbSymbol.Text == "Подстрока";
            tbOther.MaxLength = cbSymbol.Text == "Другой символ" ? 1 : 50;

            nudRepeat.Enabled = chbSeveral.Enabled = cbSymbol.Text != "Любые символы" && cbSymbol.Text != "Подстрока";
        }

        private void chbSeveral_CheckedChanged(object sender, EventArgs e)
        {
            nudRepeat.Enabled = !chbSeveral.Checked;
        }
    }

    public class Symbol
    {
        public Symbol(string symbolSimplified, string symbolRegex)
        {
            SymbolSimplified = symbolSimplified;
            SymbolRegex = symbolRegex;
        }

        public string SymbolSimplified { get; set; }
        public string SymbolRegex { get; set; }
        public override string ToString()
        {
            return SymbolSimplified;
        }
    }

}
