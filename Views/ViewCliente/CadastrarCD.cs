using System;
using System.Drawing;
using System.Windows.Forms;

namespace Locadora
{
    partial class CadastroC : Form
    {
        Sistema.Label lbl_Nome;
        Sistema.Label lbl_DataNasc;
        Sistema.Label lbl_CPF;
        Sistema.Label lbl_DiasDevol;
        Sistema.RichTextBox rtxt_NomeCliente;
        Sistema.MaskedTextBox mtxt_DataNasc;
        Sistema.MaskedTextBox mtxt_CpfCLiente;
        ComboBox cb_DiasDevol;
        Sistema.Button btn_Confirmar;
        Sistema.Button btn_Cancelar;
        Form parent;

        public void InitializeComponent(Form parent, bool isUpdate)
        {
            this.BackColor = Color.LightGray;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(360, 300);
            this.parent = parent;

            if (isUpdate)
            {
                this.Load += new EventHandler(this.LoadForm);
            }

            this.lbl_Nome = new Sistema.Label();
            this.lbl_Nome.Text = "Nome :";
            this.lbl_Nome.Location = new Point(20, 20);
            this.Controls.Add(lbl_Nome);

            this.lbl_DataNasc = new Sistema.Label();
            this.lbl_DataNasc.Text = " Nascimento :";
            this.lbl_DataNasc.Location = new Point(20, 60);
            this.Controls.Add(lbl_DataNasc);

            this.lbl_CPF = new Sistema.Label();
            this.lbl_CPF.Text = "CPF :";
            this.lbl_CPF.Location = new Point(20, 100);
            this.Controls.Add(lbl_CPF);

            this.lbl_DiasDevol = new Sistema.Label();
            this.lbl_DiasDevol.Text = " Devolução :";
            this.lbl_DiasDevol.Location = new Point(20, 140);
            this.Controls.Add(lbl_DiasDevol);

            this.rtxt_NomeCliente = new Sistema.RichTextBox();
            this.rtxt_NomeCliente.Size = new Size(170, 20);
            this.Controls.Add(rtxt_NomeCliente);

            this.mtxt_DataNasc = new Sistema.MaskedTextBox();
            this.mtxt_DataNasc.Mask = "00/00/0000";
            this.mtxt_DataNasc.Location = new Point(150, 60);
            this.Controls.Add(mtxt_DataNasc);

            this.mtxt_CpfCLiente = new Sistema.MaskedTextBox();
            this.mtxt_CpfCLiente.Mask = "000,000,000-00";
            this.mtxt_CpfCLiente.ReadOnly = isUpdate;
            this.Controls.Add(mtxt_CpfCLiente);

            this.cb_DiasDevol = new ComboBox();
            this.cb_DiasDevol.Items.Add("2 Dia");
            this.cb_DiasDevol.Items.Add("4 Dias");
            this.cb_DiasDevol.Items.Add("6 Dias");
            this.cb_DiasDevol.Items.Add("8 Dias");
            this.cb_DiasDevol.Items.Add("1 Mes");
            this.cb_DiasDevol.AutoCompleteMode = AutoCompleteMode.Append;
            this.cb_DiasDevol.Location = new Point(10, 250);
            this.cb_DiasDevol.Size = new Size(20 , 300);
            this.Controls.Add(cb_DiasDevol);


            this.btn_Confirmar = new Sistema.Button();
            this.btn_Confirmar.Text = "CONFIRMAR";
            this.btn_Confirmar.Location = new Point(10, 190);
            this.btn_Confirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            this.Controls.Add(btn_Confirmar);

            this.btn_Cancelar = new Sistema.Button();
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.Location = new Point(180, 190);
            this.btn_Cancelar.Click += new EventHandler(this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }
    }
}