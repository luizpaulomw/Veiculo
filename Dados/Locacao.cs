using System;
using Models;
using System.Collections.Generic;

namespace Dados
{
    public class LocacaoController
    {        
        public static LocacaoModels Add(ClienteModels cliente)
        {
            return new LocacaoModels(cliente, DateTime.Now);
        }
        
        public static DateTime CalculoDataDevolucao(DateTime DtLocacao, ClienteModels Cliente)
        {
            return DtLocacao.AddDays(Cliente.DiasDevolucao);
        }
                public static List<LocacaoModels> GetLocacoes()
        {
            return LocacaoModels.GetLocacoes();
        }

        public static LocacaoModels GetLocacao(int idLocacao)
        {
            return LocacaoModels.GetLocacao(idLocacao);
        }
        
        public static List<LocacaoModels> GetLocacoesByCliente(int IdCliente)
        {
            return LocacaoModels.GetLocacoesByCliente(IdCliente);
        }

        public static List<LocacaoVeiculoModels> GetLocacoesByVeiculo(int IdVeiculo)
        {
            return LocacaoVeiculoModels.GetLocacoesByVeiculo(IdVeiculo);
        }
        
        public static void DeleteLocacao(int idLocacao)
        {
            LocacaoController.DeleteLocacao(idLocacao);
        }
    }
}