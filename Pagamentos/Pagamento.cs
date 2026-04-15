namespace Projeto.Pagamento
{
    public abstract class Pagamento
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public abstract string ProcessarPagamento();
    }
}