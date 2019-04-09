using System;

namespace WahooDespesa.Model
{
    public class Despesa
    {
        public long DespesaId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
