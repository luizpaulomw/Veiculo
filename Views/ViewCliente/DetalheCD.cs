using System;
using Models;
using Sistema;
using System.Drawing;
using System.Windows.Forms;

namespace Locadora
{
    partial class ClienteDetalhe : Form
    {
        Sistema.Label lbl_IdCliente;
        Sistema.Label lbl_Nome;
        Sistema.Label lbl_DataNasc;
         Sistema.Label lbl_CPF;
         Sistema.Label lbl_DiasDevol;
         Sistema.ButtonDetail btn_SairDetalhe;
         Sistema.ButtonDetail btn_UpdateCliente;
         Sistema.ButtonDetail btn_DeleteCliente;
        Form parent;

        int idCliente;
        ClienteModels clienteX;

        
        public void InitializeComponent(Form parent, ClienteModels cliente)
        {
            
            this.BackColor = Color.LightGray;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 290);
            this.idCliente = cliente.IdCliente;
            this.clienteX = cliente;
            this.parent = parent;
            
            this.lbl_IdCliente = new  Sistema.Label();
            this.lbl_IdCliente.Text = "ID do Cliente: " + cliente.IdCliente;
            this.lbl_IdCliente.Location = new Point(20, 20);
            this.lbl_IdCliente.Font = new Font(lbl_IdCliente.Font, FontStyle.Bold);
            this.lbl_IdCliente.ForeColor = Color.Black;
            this.Controls.Add(lbl_IdCliente);

            this.lbl_Nome = new  Sistema.Label();
            this.lbl_Nome.Text = "Nome: " + cliente.NomeCliente;
            this.lbl_Nome.Location = new Point(20, 50);
            this.lbl_Nome.Font = new Font(lbl_Nome.Font, FontStyle.Bold);
            this.lbl_Nome.ForeColor = Color.Black;
            this.Controls.Add(lbl_Nome);

            this.lbl_DataNasc = new  Sistema.Label();
            this.lbl_DataNasc.Text = "Data de Nascimento: " + cliente.DataNascimento;
            this.lbl_DataNasc.Location = new Point(20, 80);
            this.lbl_DataNasc.Font = new Font(lbl_DataNasc.Font, FontStyle.Bold);
            this.lbl_DataNasc.ForeColor = Color.Black;
            this.Controls.Add(lbl_DataNasc);

            this.lbl_CPF = new  Sistema.Label();
            this.lbl_CPF.Text = "CPF: " + cliente.CpfCliente;
            this.lbl_CPF.Location = new Point(20, 110);
            this.lbl_CPF.Font = new Font(lbl_CPF.Font, FontStyle.Bold);
            this.lbl_CPF.ForeColor = Color.Black;
            this.Controls.Add(lbl_CPF);

            this.lbl_DiasDevol = new  Sistema.Label();
            this.lbl_DiasDevol.Text = "Dias P/ Devolução: " + cliente.DiasDevolucao.ToString();
            this.lbl_DiasDevol.Location = new Point(20, 140);
            this.lbl_DiasDevol.Font = new Font(lbl_DiasDevol.Font, FontStyle.Bold);
            this.lbl_DiasDevol.ForeColor = Color.Black;
            this.Controls.Add(lbl_DiasDevol);
            
            this.btn_DeleteCliente = new  Sistema.ButtonDetail(ButtonType.Delete);
            this.btn_DeleteCliente.Text = "DELETAR";
            this.btn_DeleteCliente.Location = new Point(10, 180);
            this.btn_DeleteCliente.Size = new Size(140, 50);
            this.btn_DeleteCliente.BackColor = Color.DarkGray;
            this.btn_DeleteCliente.Click += new EventHandler(this.btn_DeleteClienteClick);
            this.Controls.Add(btn_DeleteCliente);
            
            this.btn_UpdateCliente = new  Sistema.ButtonDetail(ButtonType.Update);
            this.btn_UpdateCliente.Text = "ALTERAR";
            this.btn_UpdateCliente.Location = new Point(170, 180);
            this.btn_UpdateCliente.Size = new Size(140, 50);
            this.btn_UpdateCliente.BackColor = Color.DarkGray;
            this.btn_UpdateCliente.Click += new EventHandler(this.btn_UpdateClienteClick);
            this.Controls.Add(btn_UpdateCliente);
            
            this.btn_SairDetalhe = new  Sistema.ButtonDetail(ButtonType.Sair);
            this.btn_SairDetalhe.Text = "SAIR";
            this.btn_SairDetalhe.Location = new Point(330, 180);
            this.btn_SairDetalhe.Size = new Size(140, 50);
            this.btn_SairDetalhe.BackColor = Color.DarkGray;
            this.btn_SairDetalhe.Click += new EventHandler(this.btn_SairDetalheClick);
            this.Controls.Add(btn_SairDetalhe);
        }
    }
}