using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTools
{
    public class TextBox20Char: TextBox
    {
        public TextBox20Char()
        {
            this.KeyPress += TextBox20Char_KeyPress;
        }
        private void TextBox20Char_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && this.Text.Length > 20)
            {
                e.Handled = true;
            }
        }
    }
}
