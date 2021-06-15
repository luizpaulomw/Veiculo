using System;
using Models;
using Dados;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Locadora
{
    public partial class ConsultaVeiculo : Form
    {
        public ConsultaVeiculo(Form parent)
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
            lv_ListaVeiculos.Items.Clear();
            List<VeiculoModels> listaVeiculo = (from veiculo in VeiculoController.GetVeiculos() where veiculo.Marca.Contains(rtxt_ConsultaVeiculo.Text, StringComparison.OrdinalIgnoreCase) select veiculo).ToList();
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


        private void btn_ListaConsultaClick(object sender, EventArgs e)
        {
            try
            {
                string IdVeiculo = this.lv_ListaVeiculos.SelectedItems[0].Text;
                VeiculoModels veiculo = VeiculoController.GetVeiculo(Int32.Parse(IdVeiculo));
                VeiculoDetalhe btn_ListaConsultaClick = new VeiculoDetalhe(this, veiculo);
                 btn_ListaConsultaClick.Show();
            }
            catch
            {
                MessageBox.Show("Selecione Um Veiculo!");
            }
        }

        private void btn_ListaSairClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}