using System;
using Models;
using Dados;
using System.Windows.Forms;

namespace Locadora
{
    public partial class ClienteDetalhe : Form
    {
        public ClienteDetalhe(Form parent, ClienteModels cliente)
        {
            InitializeComponent(parent, cliente);
        }
        private void btn_SairDetalheClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
        private void btn_UpdateClienteClick(object sender, EventArgs e)
        {
            CadastroC btn_UpdateClienteClick = new CadastroC(this, idCliente);
            btn_UpdateClienteClick.Show();
        }
        private void btn_DeleteClienteClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir ?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ClienteDados.DeleteCliente(idCliente);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}