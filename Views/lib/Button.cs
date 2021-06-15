using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema
{
    public class Button : System.Windows.Forms.Button
    {

        public Button()
        {
            this.Size = new Size(150, 50);
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.MouseLeave += new EventHandler(this.btn_MouseLeave);
        }

        
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(128, 3, 186)
;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0x80, 0x03, 0xBA)

;
        }
    }
}