using System;
using System.Linq;
using Dados;
using Conexão_banco;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LocacaoModels
    {
      
        [Key] 
        public int IdLocacao { get; set; }
        public virtual ClienteModels Cliente { get; set; }
        [ForeignKey("clientes")] 
        public int IdCliente { get; set; }
        [Required] 
        public DateTime DataLocacao { get; set; }

        public List<VeiculoModels> veiculos = new List<VeiculoModels>();

        public LocacaoModels(ClienteModels cliente, DateTime dataLocacao)
        {
            IdCliente = cliente.IdCliente;
            DataLocacao = dataLocacao;
            veiculos = new List<VeiculoModels>();
            cliente.AdicionarLocacao(this);

            var db = new Context();
            db.Locacoes.Add(this);
            db.SaveChanges();
        }

        public LocacaoModels()
        {

        }

        public void AdicionarVeiculo(VeiculoModels veiculo)
        {
            var db = new Context();
            LocacaoVeiculoModels locacaoVeiculo = new LocacaoVeiculoModels()
            {
                IdVeiculo = veiculo.IdVeiculo,
                IdLocacao = IdLocacao
            };

            db.LocacaoVeiculo.Add(locacaoVeiculo);
            db.SaveChanges();
        }

        public string VeiculosLocados()
        {
            var db = new Context();
            IEnumerable<int> veiculos =
            from veiculo in db.LocacaoVeiculo
            where veiculo.IdLocacao == IdLocacao
            select veiculo.IdVeiculo;

            string strVeiculos = "";

            if (veiculos.Count() > 0)
            {
                foreach (int IdVeiculo in veiculos)
                {
                    VeiculoModels veiculo = VeiculoController.GetVeiculo(IdVeiculo);
                    strVeiculos += $"ID: {veiculo.IdVeiculo} >>> " +
                                 $"Marca: {veiculo.Marca}\n";
                }
            }
            else
            {
                strVeiculos += "    NÃO HÁ VEICULOS!";
            }
            return strVeiculos;
        }

        public DateTime CalculoDataDevol()
        {
            var db = new Context();
            IEnumerable<int> veiculos =
            from veiculo in db.LocacaoVeiculo
            where veiculo.IdLocacao == IdLocacao
            select veiculo.IdVeiculo;

            ClienteModels cliente = ClienteModels.GetCliente(IdCliente);
            return LocacaoController.CalculoDataDevolucao(DataLocacao, cliente);
        }

        public int QtdeVeiculos()
        {
            var db = new Context();
            IEnumerable<int> veiculos =
            from veiculo in db.LocacaoVeiculo
            where veiculo.IdLocacao == IdLocacao
            select veiculo.IdVeiculo;

            ClienteModels cliente = ClienteModels.GetCliente(IdCliente);

            return veiculos.Count();
        }

        public double ValorTotal()
        {
            double total = 0;
            var db = new Context();
            IEnumerable<int> veiculos =
            from veiculo in db.LocacaoVeiculo
            where veiculo.IdLocacao == IdLocacao
            select veiculo.IdVeiculo;

            foreach (int id in veiculos)
            {
                VeiculoModels veiculo = VeiculoModels.GetVeiculo(id);
                total += veiculo.ValorLocacaoVeiculo;
            }
            return total;
        }
        public static List<LocacaoModels> GetLocacoes()
        {
            var db = new Context();
            return db.Locacoes.ToList();
        }

        public static LocacaoModels GetLocacao(int idLocacao)
        {
            var db = new Context();
            return (from locacao in db.Locacoes
                    where locacao.IdLocacao == idLocacao
                    select locacao).First();
        }

        public static void DeleteLocacao(int idLocacao)
        {
            Context db = new Context();
            try
            {
                LocacaoModels locacao = db.Locacoes.First(locacao => locacao.IdLocacao == idLocacao);
                db.Remove(locacao);
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        public static List<LocacaoModels> GetLocacoesByCliente(int IdCliente)
        {
            var db = new Context();
            return (from locacao in db.Locacoes
                    where locacao.IdCliente == IdCliente
                    select locacao).ToList();
        }
    }
}