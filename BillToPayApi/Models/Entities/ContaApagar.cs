using System;

namespace BillToPayApi.Models.Entities
{
    public class ContaApagar
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorCorrigido { get; set; }
        public int QdeDiasEmAtraso { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Multa { get; set; } 
        public decimal JurosDia { get; set; }

        public override string ToString() 
        {
            string msg = "******** CONTA CADASTRADA ********" +
                         "\nCódigo :  " + Id + 
                         "\nNome Credor :  " + Nome +
                         "\nValor Original : " + ValorOriginal +
                         "\nValor Corrigido : " + ValorCorrigido +
                         "\nData do Vencimento : " + DataVencimento +                   
                         "\nData do Pagamento : " + DataPagamento +
                         "\nDias em Atraso : " + QdeDiasEmAtraso +
                         "\n********************************";
            return msg;
        }
    }
}
