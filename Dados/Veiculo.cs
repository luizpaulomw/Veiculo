using System;
using System.Collections.Generic;
using Models;

namespace Dados
{
    public class VeiculoController
    {
        public static void CadastrarVeiculo(
            string marca,
            string modelo,
            string ano,
            double valorLocacaoVeiculo,
            int estoqueVeiculo
        )
        {
           new VeiculoModels(
              marca,
              modelo,
              ano,
              Convert.ToDouble(valorLocacaoVeiculo),
              estoqueVeiculo
          );

        }

        public static List<VeiculoModels> GetVeiculos()
        {
            return VeiculoModels.GetVeiculos();
        } 

        public static VeiculoModels GetVeiculo(int idVeiculo) {
            return VeiculoModels.GetVeiculo(idVeiculo); 
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
            VeiculoModels.UpdateVeiculo(
             idVeiculo,   
             marca,
             modelo,
             ano,
             valorLocacaoVeiculo,
             estoqueVeiculo
            );            
        }

        public static void DeleteVeiculo(int idVeiculo)

        {
            if (LocacaoController.GetLocacoesByVeiculo(idVeiculo).Count > 0)
            {
                throw new Exception("Há Locações com essa Marca!");
            }
            VeiculoModels.DeleteVeiculo(idVeiculo);
        }
    }        
}