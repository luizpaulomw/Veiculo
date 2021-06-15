using System;
using Models;
using Dados;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Locadora
{
    public partial class CadastroL : Form
    {
        public CadastroL(Form parent)
        {
            InitializeComponent(parent);
        }

        public void RefreshForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.RefreshForm));
            }
            Application.DoEvents();
        }

        private void keypressed1(Object o, KeyPressEventArgs e)
        {
            lv_ListaClientes.Items.Clear();
            List<ClienteModels> listaCliente = (from cliente in ClienteDados.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text, StringComparison.OrdinalIgnoreCase) select cliente).ToList();
            ListViewItem clientes = new ListViewItem();
            foreach (ClienteModels cliente in listaCliente)
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaClientes.Items.Add(lv_ListaCliente);
            }
            this.Refresh();
            Application.DoEvents();
        }

        private void keypressed2(Object o, KeyPressEventArgs e)
        {
            lv_ListaVeiculos.Items.Clear();
            List<VeiculoModels> listaVeiculo = (from veiculo in VeiculoController.GetVeiculos() where veiculo.Marca.Contains(rtxt_BuscaVeiculo.Text, StringComparison.OrdinalIgnoreCase) select veiculo).ToList();
            ListViewItem veiculos = new ListViewItem();
            foreach (VeiculoModels veiculo in listaVeiculo)
            {
                ListViewItem lv_ListaVeiculo = new ListViewItem(veiculo.IdVeiculo.ToString());
                lv_ListaVeiculo.SubItems.Add(veiculo.Marca);
                lv_ListaVeiculo.SubItems.Add(veiculo.Modelo);
                lv_ListaVeiculo.SubItems.Add(veiculo.Ano);
                lv_ListaVeiculo.SubItems.Add(veiculo.ValorLocacaoVeiculo.ToString());
                lv_ListaVeiculo.SubItems.Add(veiculo.EstoqueVeiculo.ToString());
                lv_ListaVeiculos.Items.Add(lv_ListaVeiculo);
            }
            this.Refresh();
            Application.DoEvents();
        }

        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                if ((lv_ListaClientes.SelectedItems.Count > 0) && (lv_ListaVeiculos.CheckedItems.Count > 0))
                {
                    string IdCliente = this.lv_ListaClientes.SelectedItems[0].Text;
                    ClienteModels cliente = ClienteDados.GetCliente(Int32.Parse(IdCliente));
                    LocacaoModels locacao = LocacaoController.Add(cliente);

                    foreach (ListViewItem Veiculo in this.lv_ListaVeiculos.CheckedItems)
                    {
                        VeiculoModels veiculo = VeiculoController.GetVeiculo(Int32.Parse(Veiculo.Text));
                        locacao.AdicionarVeiculo(veiculo);
                    }
                    MessageBox.Show("OK!");
                    this.Close();
                    this.parent.Show();
                }
                else
                {
                    MessageBox.Show("Selecione o Cliente e  Um Veiculo!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Selecione o Cliente e  Um Veiculo!");
            }
        }

        private void btn_CancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}