using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Conexão_banco;

namespace Models
{
    public class ClienteModels
    {
        [Key]
        public int IdCliente { get; set; }
       
        public string NomeCliente { get; set; }
        public string DataNascimento { get; set; }
        public string CpfCliente { get; set; }
        public int DiasDevolucao { get; set; }

        public List<LocacaoModels> locacoes = new List<LocacaoModels>();


        public ClienteModels(
            string nomeCliente,
            string dataNascimento,
            string cpfCliente,
            int diasDevolucao
            )
        {
            NomeCliente = nomeCliente;
            DataNascimento = dataNascimento;
            CpfCliente = cpfCliente;
            DiasDevolucao = diasDevolucao;
            locacoes = new List<LocacaoModels>();

            var db = new Context();
            db.Clientes.Add(this);
            db.SaveChanges();
        }

        public ClienteModels()
        {

        }

        public static ClienteModels GetCliente(int idCliente)
        {
            var db = new Context();
            return (from cliente in db.Clientes
                    where cliente.IdCliente == idCliente
                    select cliente).First();
        }

        public override string ToString()
        {
            return $"-------------------===[ CLIENTE ]===-------------------\n" +
                    $"--> Nº ID DO CLIENTE: {IdCliente}\n" +
                    $"-> NOME COMPLETO: {NomeCliente}\n" +
                    $"-> DATA DE NASCIMENTO: {DataNascimento}\n" +
                    $"-> CPF: {CpfCliente}\n" +
                    $"-> DIAS P/ DEVOLUÇÃO: {DiasDevolucao}\n" +
                    $"-------------------------------------------------------";
        }

        public void AdicionarLocacao(LocacaoModels locacao)
        {
            locacoes.Add(locacao);

        }

        public static List<ClienteModels> GetClientes()
        {
            var db = new Context();
            return db.Clientes.ToList();
        }

        public static void AtualizaCliente(
            int IdCliente,
            string nomeCliente,
            string dataNascimento,
            string cpfCliente,
            int diasDevolucao)
        {
            var db = new Context();
            try
            {
                ClienteModels cliente = db.Clientes.First(cliente => cliente.IdCliente == IdCliente);
                cliente.NomeCliente = nomeCliente;
                cliente.DataNascimento = dataNascimento;
                cliente.CpfCliente = cpfCliente;
                cliente.DiasDevolucao = diasDevolucao;
                db.SaveChanges();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        public static void DeleteCliente(int idCliente)
        {
            Context db = new Context();
            try
            {
                ClienteModels cliente = db.Clientes.First(cliente => cliente.IdCliente == idCliente);
                db.Remove(cliente);
                db.SaveChanges();
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }
}