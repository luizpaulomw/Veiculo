using System;
using System.Collections.Generic;
using System.Linq;
using Conexão_banco;
using Models;

namespace Dados 
{
    public static class ClienteDados
    {
        public static void CadastrarCliente(
            string nomeCliente,
            string dataNascimento,
            string cpfCliente,
            int diasDevolucao
        )
        {
            DateTime dtNasc;
            try
            {
                dtNasc = Convert.ToDateTime(dataNascimento);
            }
            catch
            {
                Console.WriteLine(" Erro!");
                dtNasc = DateTime.Now;
            }

            new ClienteModels(
                nomeCliente,
                dataNascimento,
                cpfCliente,
                diasDevolucao
            );

        }
        public static void AtualizaCliente(
                int idCliente,
                string nomeCliente,
                string dataNascimento,
                string cpfCliente,
                int diasDevolucao)

        {
            
            ClienteModels.AtualizaCliente (
            idCliente, 
            nomeCliente, 
            dataNascimento, 
            cpfCliente, 
            diasDevolucao);
        }

        public  static ClienteModels GetCliente(int idCliente)
        {
            return ClienteModels.GetCliente(idCliente);
        }

        public static List<ClienteModels> GetClientes()
        {
            return ClienteModels.GetClientes();
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