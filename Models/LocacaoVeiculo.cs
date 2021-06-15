using System.Collections.Generic;
using System.Linq;
using Conexão_banco;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LocacaoVeiculoModels
    {
        [Key] 
        public int Id { get; set; }
        [ForeignKey("locacoes")] 
        public int IdLocacao { get; set; }
        public virtual LocacaoModels Locacao { get; set; }
        [ForeignKey("veiculos")] 
        public int IdVeiculo { get; set; }
        public virtual VeiculoModels Veiculo { get; set; }
        public static List<LocacaoVeiculoModels> GetLocacoesByVeiculo(int IdVeiculo)
        {
            var db = new Context();
            return (from locacao in db.LocacaoVeiculo
                    where locacao.IdVeiculo == IdVeiculo
                    select locacao).ToList();
        }

    }
}