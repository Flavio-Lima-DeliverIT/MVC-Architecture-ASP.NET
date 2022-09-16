using BillToPayApi.Models.Database;
using BillToPayApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillToPayApi.Models.Services
{
    public class ContaApagarService : IContaApagarService
    {
        private ContaApagarContext _context;
        


        public ContaApagarService(ContaApagarContext contaApagarContext)
        {
            this._context = contaApagarContext;
        }

        public IEnumerable<ContaApagar> GetContaApagar()
        {
            return _context.ContaApagar.ToList();
        }

        public void InserirContaApagar(ContaApagar conta) 
        {
            _context.Add(conta);
            _context.SaveChanges();
        }

        public ContaApagar BuscarContaApagar(int id)
        {
            return _context.ContaApagar.Find(id);
        }

        public bool Remover(int id)
        {
            ContaApagar conta = _context.Find<ContaApagar>(id);

            if (conta == null)
            {
                return false;
            }

            _context.Remove(conta);
            _context.SaveChanges();

            return true;
        }

        // Calcular juros e multa
        public void CalcularContaAtrasada(ContaApagar conta)
        {

            // IEnumerable<ContaApagar> contas = _context.ContaApagar.ToList();
            // foreach (ContaApagar cont in contas)
            // { 
                
                TimeSpan atraso = (conta.DataPagamento - conta.DataVencimento);
                decimal valorOriginal = conta.ValorOriginal;

                if (atraso.Days > 0 && atraso.Days <= 3)
                {
                    conta.ValorCorrigido = (valorOriginal
                        + (valorOriginal * 2) / 100
                        + Convert.ToDecimal(atraso.Days * 0.1));

                    conta.QdeDiasEmAtraso = atraso.Days;
                    conta.Multa = Convert.ToDecimal(valorOriginal * 2)/100;
                    conta.JurosDia = Convert.ToDecimal(atraso.Days * 0.1);
                }

                if (atraso.Days > 3 && atraso.Days <= 5)
                {
                    conta.ValorCorrigido = (valorOriginal
                        + (valorOriginal * 3) / 100
                        + Convert.ToDecimal(atraso.Days * 0.2));

                    conta.QdeDiasEmAtraso = atraso.Days;
                    conta.Multa = Convert.ToDecimal(valorOriginal * 3) / 100;
                    conta.JurosDia = Convert.ToDecimal(atraso.Days * 0.2);
                }

                if (atraso.Days > 5)
                {
                    conta.ValorCorrigido = (valorOriginal
                        + (valorOriginal * 5) / 100
                        + Convert.ToDecimal(atraso.Days * 0.3));

                    conta.QdeDiasEmAtraso = atraso.Days;
                    conta.Multa = Convert.ToDecimal(valorOriginal * 5) / 100;
                    conta.JurosDia = Convert.ToDecimal(atraso.Days * 0.3);
                }
            //}
            _context.SaveChanges();
        }

        /*public IEnumerable<ContaApagar> ListaContas() { return _context.ContaApagar.ToList(); } */ // em teste     
    }
}

