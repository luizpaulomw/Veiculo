using System;
using Models;
using Dados;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Locadora
{
    partial class ConsultaLocacao : Form
    {
         Sistema.Label lbl_NomeLocacao;
         Sistema.ToolTip tt_BuscaCliente;
         Sistema.RichTextBox rtxt_BuscaCliente;
         Sistema.ListView lv_ListaLocacoes;
         Sistema.Button btn_ListaConsulta;
         Sistema.Button btn_ListaSair;
        Form parent;

        public void InitializeComponent(Form parent)
        {

            this.BackColor = Color.LightGray;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 360);
            this.parent = parent;

            this.lbl_NomeLocacao = new  Sistema.Label();
            this.lbl_NomeLocacao.Text = "Busca Por Cliente :";
            this.lbl_NomeLocacao.Location = new Point(20, 20);
            this.Controls.Add(lbl_NomeLocacao);

            this.tt_BuscaCliente = new  Sistema.ToolTip();

            this.rtxt_BuscaCliente = new  Sistema.RichTextBox();
            this.rtxt_BuscaCliente.Location = new Point(150, 20);
            this.Controls.Add(rtxt_BuscaCliente);
            this.tt_BuscaCliente.SetToolTip(rtxt_BuscaCliente, "Digite o nome ou selecione abaixo");
            this.rtxt_BuscaCliente.KeyPress += new KeyPressEventHandler(keypressed);

            this.lv_ListaLocacoes = new  Sistema.ListView();
            this.lv_ListaLocacoes.Location = new Point(20, 50);
            this.lv_ListaLocacoes.Size = new Size(440, 185);
            List<ClienteModels> listaCliente = (from cliente in ClienteDados.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text) select cliente).ToList();
            ListViewItem locacoes = new ListViewItem();
            foreach (LocacaoModels locacao in LocacaoController.GetLocacoes())
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

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            this.btn_ListaConsulta = new  Sistema.Button();
            this.btn_ListaConsulta.Location = new Point(80, 250);
            this.btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.Click += new EventHandler(this.btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            this.btn_ListaSair = new Sistema.Button();
            this.btn_ListaSair.Location = new Point(260, 250);
            this.btn_ListaSair.Text = "CANCELAR";
            this.btn_ListaSair.Click += new EventHandler(this.btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }
    }
}