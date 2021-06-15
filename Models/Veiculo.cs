using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Conexão_banco;
using System.Linq;
using System;

namespace Models
{
    public class VeiculoModels
    {
        [Key]
        public int IdVeiculo { set; get; }
        public string Marca { set; get; }
        public string Modelo { set; get; } 
        public string Ano { set; get; } 
        public double ValorLocacaoVeiculo { set; get; } 
        public int EstoqueVeiculo { set; get; }
        public int VeiculoLocado { set; get; }
        public List<LocacaoModels> locacoes = new List<LocacaoModels>();

        public VeiculoModels(
            string marca,
            string modelo,
            string ano,
            double valorLocacaoVeiculo,
            int estoqueVeiculo
        )
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            ValorLocacaoVeiculo = valorLocacaoVeiculo;
            EstoqueVeiculo = estoqueVeiculo;
            VeiculoLocado = 0;

            var db = new Context();
            db.Veiculos.Add(this);
            db.SaveChanges();
        }

        public VeiculoModels()
        {

        }

        public static VeiculoModels GetVeiculo(int idVeiculo)
        {
            var db = new Context();
            return (from veiculo in db.Veiculos
                    where veiculo.IdVeiculo == idVeiculo
                    select veiculo).First();
        }

        public override string ToString()
        {
            var db = new Context();

           
            int qtdVeiculo = (
                from veiculo in db.LocacaoVeiculo
                where veiculo.IdVeiculo == IdVeiculo
                select veiculo
                ).Count();

           return $"--------------------===[ VEICULO ]===--------------------\n" +
                    $"--> Nº ID DO VEICULO: {IdVeiculo}\n" +
                    $"-> MARCA: {Marca}\n" +
                    $"-> MODELO: {Modelo}\n" +
                    $"-> ANO: {Ano}\n" +
                    $"-> VALOR DA LOCAÇÃO: {ValorLocacaoVeiculo.ToString("C")}\n" +
                    $"-> ESTOQUE: {EstoqueVeiculo}\n" +
                    $"-> LOCAÇÕES REALIZADAS: {qtdVeiculo}\n" +
                    $"-----------------------------------------------------\n";     
        }
      
        public void AtribuirLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao); 
        }

        public static void UpdateVeiculo(
            int idVeiculo,
            string marca,
            string modelo,
            string ano,
            double valorLocacaoVeiculo,
            int estoqueVeiculo
        )
        {
            Context db = new Context();
            try
            {
                VeiculoModels veiculo = db.Veiculos.First(veiculo => veiculo.IdVeiculo == idVeiculo);
                veiculo.Marca = marca;
                veiculo.Modelo = modelo;
                veiculo.Ano = ano;
                veiculo.ValorLocacaoVeiculo = valorLocacaoVeiculo;
                veiculo.EstoqueVeiculo = estoqueVeiculo;
                db.SaveChanges(); 
            }
            catch
            {
                throw new ArgumentException();
            }                  
        }

        public static List<VeiculoModels> GetVeiculos()
        {
            var db = new Context();
            return db.Veiculos.ToList();
        }

        public static void DeleteVeiculo(int idVeiculo){
            Context db = new Context();
            try
            { 
                VeiculoModels veiculo = db.Veiculos.First(veiculo => veiculo.IdVeiculo == idVeiculo );
                db.Remove(veiculo);
                db.SaveChanges();
            }
             catch
            {
                throw new ArgumentException();
            }           
        }
    }
}