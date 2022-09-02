using System;

namespace BillToPayApi.Models.Entities
{
    public class ListaContaCadastrada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorCorrigido { get; set; }
        public int QdeDiasEmAtraso { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
