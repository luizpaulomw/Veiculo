using System;
using Models;
using Dados;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Locadora
{
    partial class ListaLocacao : Form
    {
         Sistema.ListView lv_ListaLocacoes;
        Sistema.Button btn_ListaSair;
        Form parent;

        
        public void InitializeComponent(Form parent)
        {

            this.BackColor = Color.LightGray;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 380);
            this.parent = parent;

            this.lv_ListaLocacoes = new  Sistema.ListView();
            this.lv_ListaLocacoes.Location = new Point(20, 20);
            this.lv_ListaLocacoes.Size = new Size(540, 250);
            ListViewItem locacoes = new ListViewItem();
            List<LocacaoModels> locacoesLista = LocacaoController.GetLocacoes();
            foreach (var locacao in locacoesLista)
            {
                ListViewItem lv_ListaLocacao = new ListViewItem(locacao.IdLocacao.ToString());
                ClienteModels cliente = ClienteDados.GetCliente(locacao.IdCliente);
                lv_ListaLocacao.SubItems.Add(cliente.NomeCliente.ToString());
                lv_ListaLocacao.SubItems.Add(cliente.CpfCliente.ToString());
                lv_ListaLocacao.SubItems.Add(locacao.DataLocacao.ToString("dd/MM/yyyy"));
                lv_ListaLocacao.SubItems.Add(locacao.CalculoDataDevol().ToString("dd/MM/yyyy"));
                lv_ListaLocacao.SubItems.Add(locacao.QtdeVeiculos().ToString());
                lv_ListaLocacao.SubItems.Add(locacao.ValorTotal().ToString("C2"));
                lv_ListaLocacoes.Items.Add(lv_ListaLocacao);
            }
            this.lv_ListaLocacoes.MultiSelect = false;
            this.lv_ListaLocacoes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Locatário", -2, HorizontalAlignment.Left);
            this.lv_ListaLocacoes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Data Locação", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Data Devolução", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Qtde Veiculos", -2, HorizontalAlignment.Center);
            this.lv_ListaLocacoes.Columns.Add("Total", -2, HorizontalAlignment.Left);
            this.Controls.Add(lv_ListaLocacoes);

            this.btn_ListaSair = new  Sistema.Button();
            this.btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.Location = new Point(200, 280);
            this.btn_ListaSair.Click += new EventHandler(this.btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }
    }
}