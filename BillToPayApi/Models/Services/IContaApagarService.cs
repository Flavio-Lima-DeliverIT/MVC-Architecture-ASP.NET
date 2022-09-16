using BillToPayApi.Models.Entities;
using System.Collections.Generic;

namespace BillToPayApi.Models.Services
{
    public interface IContaApagarService
    {
        ContaApagar BuscarContaApagar(int id);
        void CalcularContaAtrasada(ContaApagar conta);
        IEnumerable<ContaApagar> GetContaApagar();
        /*IEnumerable<ContaApagar> ListaContas();*/ // em teste
        void InserirContaApagar(ContaApagar conta);
        bool Remover(int id);
       
    }
}
