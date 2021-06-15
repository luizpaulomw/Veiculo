using System;
using Models;
using Dados;
using System.Windows.Forms;

namespace Locadora
{
    public partial class CadastroC: Form
    {
        ClienteModels cliente;
        public CadastroC(Form parent, int id = 0)
        {
            try
            {
                cliente = ClienteDados.GetCliente(id);
            }
            catch
            {

            }
            InitializeComponent(parent, id > 0);
        }

        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                if ((rtxt_NomeCliente.Text != string.Empty)
                && (mtxt_DataNasc.Text != string.Empty)
                && (mtxt_CpfCLiente.Text != string.Empty)
                && (cb_DiasDevol.Text != string.Empty))
                {
                    if (cliente == null)
                    {
                        ClienteDados.CadastrarCliente(
                        rtxt_NomeCliente.Text,
                        mtxt_DataNasc.Text,
                        mtxt_CpfCLiente.Text,
                        cb_DiasDevol.Text == "2 Dia"
                         ? 1
                      : cb_DiasDevol.Text == "4 Dias"
                         ? 2
                      : cb_DiasDevol.Text == "6 Dias"
                         ? 3
                      : cb_DiasDevol.Text == "8 Dias"
                          ? 4
                          : 10
                        );
                        MessageBox.Show(" Cadastado!");

                    }
                    else
                    {
                        ClienteDados.AtualizaCliente(
                        cliente.IdCliente,
                        rtxt_NomeCliente.Text,
                         mtxt_DataNasc.Text,
                        mtxt_CpfCLiente.Text,
                        cb_DiasDevol.Text == "2 Dia"
                         ? 1
                       : cb_DiasDevol.Text == "4 Dias"
                        ? 2
                       : cb_DiasDevol.Text == "6 Dias"
                        ? 3
                       : cb_DiasDevol.Text == "8 Dias"
                         ? 4
                         : 10
                        );
                        MessageBox.Show("Alteração!");
                    }
                    this.Close();
                    this.parent.Show();
                }
                else
                {
                    MessageBox.Show(" Erro!");
                }

                }
                 catch (Exception er)
                {
                MessageBox.Show(er.Message, " Erro!");
                }
        }

        private void btn_CancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            this.rtxt_NomeCliente.Text = cliente.NomeCliente;
            this.mtxt_DataNasc.Text = cliente.DataNascimento;
            this.mtxt_CpfCLiente.Text = cliente.CpfCliente;
            this.cb_DiasDevol.SelectedValue = cliente.DiasDevolucao;
        }
    }
}