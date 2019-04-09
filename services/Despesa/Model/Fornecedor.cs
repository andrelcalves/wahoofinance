using System;

namespace WahooDespesa.Model
{
    public class Fornecedor
    {
        public long FornecedorId { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}
