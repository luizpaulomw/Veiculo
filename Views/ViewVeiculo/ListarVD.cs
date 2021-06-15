using System;
using Models;
using Dados;
using System.Drawing;
using System.Windows.Forms;

namespace Locadora
{
    public partial class ListaVeiculo : Form
    {
         Sistema.ListView lv_ListaVeiculos;
         Sistema.Button btn_ListaSair;
        Form parent;

        public void InitializeComponent(Form parent)
        {
            this.BackColor = Color.LightGray;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 380);
            this.parent = parent;

            this.lv_ListaVeiculos = new  Sistema.ListView();
            this.lv_ListaVeiculos.Location = new Point(20, 20);
            this.lv_ListaVeiculos.Size = new Size(440, 250);
            ListViewItem veiculos = new ListViewItem();
            foreach (var veiculo in VeiculoController.GetVeiculos())
            {
                ListViewItem lv_ListaVeiculo = new ListViewItem(veiculo.IdVeiculo.ToString());
                lv_ListaVeiculo.SubItems.Add(veiculo.Marca);
                lv_ListaVeiculo.SubItems.Add(veiculo.Modelo);
                lv_ListaVeiculo.SubItems.Add(veiculo.Ano);
                lv_ListaVeiculo.SubItems.Add(veiculo.ValorLocacaoVeiculo.ToString());
                lv_ListaVeiculo.SubItems.Add(veiculo.EstoqueVeiculo.ToString());
                lv_ListaVeiculos.Items.Add(lv_ListaVeiculo);
            }
            this.lv_ListaVeiculos.MultiSelect = false;
            this.lv_ListaVeiculos.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaVeiculos.Columns.Add("Marca", -2, HorizontalAlignment.Left);
            this.lv_ListaVeiculos.Columns.Add("Modelo", -2, HorizontalAlignment.Center);
            this.lv_ListaVeiculos.Columns.Add("Valor Locação", -2, HorizontalAlignment.Center);
            this.lv_ListaVeiculos.Columns.Add("Qtde Estoque", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaVeiculos);

            this.btn_ListaSair = new  Sistema.Button();
            this.btn_ListaSair.Location = new Point(170, 280);
            this.btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.Click += new EventHandler(btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }
    }
}