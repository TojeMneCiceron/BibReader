using BibReader.Readers.BibReaders;
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
    public partial class AddSourceForm : Form
    {
        public Source Source { get; set; }
        List<SymbolWithRepeatition> symbols = new List<SymbolWithRepeatition>();
        public AddSourceForm(Source source, string bibTexString)
        {
            InitializeComponent();

            if (!(source is null))
            {
                tbName.Text = source.Name;
                tbRegexRaw.Text = source.Pattern;
                tbFirstTag.Text = source.FirstTag;
                chbHasDoubleBracketsOpening.Checked = source.HasDoubleBracketsOpening;
                chbHasDoubleBracketsClosing.Checked = source.HasDoubleBracketsClosing;
                chbTagCapital.Checked = source.TagCapital;
                chbTagValueSpaces.Checked = source.TagValueSpaces;
                //chbHasAsterisks.Checked = source.HasAsterisks;
            }

            tbBibTexString.Text = bibTexString;
        }

        private string DeleteExtraSpaces(string str)
        {
            return Regex.Replace(DeleteBorderSpaces(str), "\\s+", " ");
        }

        private string DeleteBorderSpaces(string str)
        {
            return Regex.Replace(Regex.Replace(str, "^\\s+", ""), "\\s+$", "");
        }

        private string SymbolsToRegex()
        {
            if (symbols.Count == 0)
                return "";
            return symbols.Select(x => x.Regex()).Aggregate((x, y) => $"{x}{y}");
        }
        private string SymbolsToRegexSimplified()
        {
            if (symbols.Count == 0)
                return "";
            return symbols.Select(x => x.ToString()).Aggregate((x, y) => $"{x}{y}");
        }

        private bool IsValidRegex(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern)) return false;

            try
            {
                Regex.Match("", pattern);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        private void btAddSymbol_Click(object sender, EventArgs e)
        {
            var addSym = new AddSymbol();

            if (addSym.ShowDialog() != DialogResult.OK)
                return;

            var newSym = new SymbolWithRepeatition(addSym.Symbol, addSym.Repeat);
            symbols.Add(newSym);
            tbRegexSimplified.Text += newSym;
            btDeleteLastSymbol.Enabled = true;
        }

        private void btDeleteLastSymbol_Click(object sender, EventArgs e)
        {
            tbRegexSimplified.Text = tbRegexSimplified.Text.Substring(0,
                tbRegexSimplified.Text.LastIndexOf(symbols.Last().ToString()));

            symbols.Remove(symbols.Last());

            btDeleteLastSymbol.Enabled = symbols.Count > 0;
            btAddSymbol.Enabled = true;
        }

        private void chbUseConstructor_CheckedChanged(object sender, EventArgs e)
        {
            tbRegexRaw.Enabled = !chbUseConstructor.Checked;
            btAddSymbol.Enabled = 
                btAddSymbol.Visible = 
                btDeleteLastSymbol.Visible = 
                tbRegexSimplified.Visible = chbUseConstructor.Checked;
            btDeleteLastSymbol.Enabled = chbUseConstructor.Checked && symbols.Count > 0;

            tbRegexSimplified.Text = chbUseConstructor.Checked ? SymbolsToRegexSimplified() : "";
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            string sName = DeleteExtraSpaces(tbName.Text);

            if (sName == "")
            {
                MessageBox.Show("Введите название источника", "Ошибка");
                return;
            }

            if (!chbUseConstructor.Checked && !IsValidRegex(tbRegexRaw.Text))
            {
                MessageBox.Show("Введите корректное регулярное выражение", "Ошибка");
                return;
            }

            if (chbUseConstructor.Checked && tbRegexSimplified.Text == "")
            {
                MessageBox.Show("Постройте регулярное выражение", "Ошибка");
                return;
            }

            string firstTag = DeleteExtraSpaces(tbFirstTag.Text);

            if (firstTag == "")
            {
                MessageBox.Show("Введите название первого тега", "Ошибка");
                return;
            }

            Source = new Source(sName,
                chbUseConstructor.Checked ? SymbolsToRegex() : tbRegexRaw.Text,
                firstTag,
                chbHasDoubleBracketsOpening.Checked,
                chbHasDoubleBracketsClosing.Checked,
                chbTagCapital.Checked,
                chbTagValueSpaces.Checked,
                false);
                
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    public class SymbolWithRepeatition: Symbol
    {
        public SymbolWithRepeatition(Symbol symbol, string repeat) : base(symbol.SymbolSimplified, symbol.SymbolRegex)
        {
            Repeat = repeat;
        }

        public string Repeat { get; set; }

        public string Regex()
        {
            return SymbolRegex + Repeat;
        }
        public override string ToString()
        {
            return $"[{SymbolSimplified}]" + Repeat;
        }
    }
}
