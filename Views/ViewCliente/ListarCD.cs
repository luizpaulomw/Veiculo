using System;
using Models;
using Dados;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Locadora
{
    public partial class ListaC: Form
    {
         Sistema.ListView lv_ListaClientes;
         Sistema.Button btn_ListaSair;
        Form parent;

        public void InitializeComponent(Form parent)
        {
            this.BackColor = Color.LightGray;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 380);
            this.parent = parent;

            this.lv_ListaClientes = new  Sistema.ListView();
            this.lv_ListaClientes.Location = new Point(20, 20);
            this.lv_ListaClientes.Size = new Size(440, 250);
            ListViewItem clientes = new ListViewItem();
            List<ClienteModels> clientesLista = ClienteDados.GetClientes();
            foreach (var cliente in clientesLista)
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaClientes.Items.Add(lv_ListaCliente);
            }
            this.lv_ListaClientes.MultiSelect = false;
            this.lv_ListaClientes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            this.lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            this.lv_ListaClientes.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            this.btn_ListaSair = new  Sistema.Button();
            this.btn_ListaSair.Location = new Point(170, 280);
            this.btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.Click += new EventHandler(btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }
    }
}