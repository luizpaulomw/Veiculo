using System;
using System.Windows.Forms;

namespace Locadora
{
    public partial class ListaVeiculo : Form
    {
        public ListaVeiculo(Form parent)
        {
            InitializeComponent(parent);
        }

        private void btn_ListaSairClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
