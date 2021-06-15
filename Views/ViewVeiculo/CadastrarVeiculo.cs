using System;
using Models;
using Dados;
using System.Windows.Forms;

namespace Locadora
{
    public partial class CadastroV : Form
    {
        VeiculoModels veiculo;
        public CadastroV(Form parent, int id = 0)
        {
            try
            {
                veiculo = VeiculoController.GetVeiculo(id);
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
                if ((rtxt_Marca.Text != string.Empty)
                && (rtxt_Modelo.Text != string.Empty)
                && (mtxt_AnoFab.Text != string.Empty)
                && (cb_ValorLocacaoVeiculo.Text != string.Empty)
                && (num_EstoqueVeiculo.Value != 0))
                {
                    if (veiculo == null)
                    {
                        VeiculoController.CadastrarVeiculo(
                        rtxt_Marca.Text,
                        rtxt_Modelo.Text,
                        mtxt_AnoFab.Text,
                        cb_ValorLocacaoVeiculo.Text == "R$ 50,00"
                            ? 50.00
                            : cb_ValorLocacaoVeiculo.Text == "R$ 100,00"
                                ? 100.00
                                : cb_ValorLocacaoVeiculo.Text == "R$ 150,00"
                                    ? 150.00
                                    : cb_ValorLocacaoVeiculo.Text == "R$ 200,00"
                                        ? 200.00
                                        : 250.00,
                                        (int)num_EstoqueVeiculo.Value
                        );
                        MessageBox.Show("Cadastrado Com Sucesso!");

                    }
                    else
                    {
                        VeiculoController.UpdateVeiculo(
                        veiculo.IdVeiculo,
                        rtxt_Marca.Text,
                        rtxt_Modelo.Text,
                        mtxt_AnoFab.Text,
                        cb_ValorLocacaoVeiculo.Text == "R$ 50,00"
                            ? 50.00
                            : cb_ValorLocacaoVeiculo.Text == "R$ 100,00"
                                ? 100.00
                                : cb_ValorLocacaoVeiculo.Text == "R$ 150,00"
                                    ? 150.00
                                    : cb_ValorLocacaoVeiculo.Text == "R$ 200,00"
                                        ? 200.00
                                        : 250.00,
                                        (int)num_EstoqueVeiculo.Value
                        );
                        MessageBox.Show("Alteração Feita!");
                    }
                    this.Close();
                    this.parent.Show();
                }
                else
                {
                    MessageBox.Show("Preencha Todos Os Campos!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Preencha Todos Os Campos!");
            }
        }

        private void btn_CancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            this.rtxt_Marca.Text = veiculo.Marca;
            this.rtxt_Modelo.Text = veiculo.Modelo;
            this.mtxt_AnoFab.Text = veiculo.Ano;
            this.cb_ValorLocacaoVeiculo.SelectedValue = veiculo.ValorLocacaoVeiculo;
            this.num_EstoqueVeiculo.Value = veiculo.EstoqueVeiculo;
        }
    }
}