using System;
using Models;
using Dados;
using System.Windows.Forms;

namespace Locadora
{
    public partial class LocacaoDetalhe : Form
    {
        public LocacaoDetalhe(Form parent, LocacaoModels locacao)
        {
            InitializeComponent(parent, locacao);
        }

        private void btn_SairDetalheClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

         private void btn_DeleteClienteClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Realmente Exluir Esse Cliente?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    LocacaoModels.DeleteLocacao(idLocacao);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }
        }
    }
