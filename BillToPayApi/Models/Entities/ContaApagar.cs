using System;

namespace BillToPayApi.Models.Entities
{
    public class ContaApagar
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
