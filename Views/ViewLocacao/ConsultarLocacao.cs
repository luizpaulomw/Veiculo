using System;
using Models;
using Dados;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Locadora
{
    public partial class ConsultaLocacao : Form
    {
        public ConsultaLocacao(Form parent)
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


        private void keypressed(Object o, KeyPressEventArgs e)
        {
            lv_ListaLocacoes.Items.Clear();
            List<ClienteModels> listaCliente = (from cliente in ClienteDados.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text, StringComparison.OrdinalIgnoreCase) select cliente).ToList();
            ListViewItem clientes = new ListViewItem();
            foreach (ClienteModels cliente in listaCliente)
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaLocacoes.Items.Add(lv_ListaCliente);
            }
            this.Refresh();
            Application.DoEvents();
        }

        private void btn_ListaConsultaClick(object sender, EventArgs e)
        {
            try
            {
                string IdLocacao = this.lv_ListaLocacoes.SelectedItems[0].Text;
                LocacaoModels locacao = LocacaoController.GetLocacao(Int32.Parse(IdLocacao));
                LocacaoDetalhe btn_ListaConsultaClick = new LocacaoDetalhe(this, locacao);
                btn_ListaConsultaClick.Show();
            }
            catch
            {
                MessageBox.Show("Selecione Uma Locação!");
            }
        }

        private void btn_ListaSairClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}