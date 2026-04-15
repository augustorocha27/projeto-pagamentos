using System;

namespace Projeto.Pagamento
{
    public class PagamentoCartao : Pagamento
    {
        public string NumeroCartao { get; set; }

        public override string ProcessarPagamento()
        {
            return $"Processando pagamento de R$ {Valor:F2} via Cartão (Número: {NumeroCartao}) na data {Data:dd/MM/yyyy}.";
        }
    }
}