using System;
using System.Globalization;
using Projeto.Pagamento;

namespace Projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;

            do
            {
                Console.Clear();
                Menu.ExibirMenu();

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        ProcessarCartao();
                        break;

                    case 2:
                        ProcessarBoleto();
                        break;

                    case 3:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (opcao != 3)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 3);
        }

        static decimal LerValor()
        {
            Console.Write("Informe o valor do pagamento: ");
            string input = Console.ReadLine();

            decimal valor;

            while (!decimal.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out valor))
            {
                Console.Write("Valor inválido. Tente novamente: ");
                input = Console.ReadLine();
            }

            return valor;
        }

        static void ProcessarCartao()
        {
            Console.Clear();

            decimal valor = LerValor();

            Console.Write("Informe o número do cartão: ");
            string numero = Console.ReadLine();

            PagamentoCartao pagamento = new PagamentoCartao
            {
                Valor = valor,
                NumeroCartao = numero,
                Data = DateTime.Now
            };

            Console.WriteLine("\n" + pagamento.ProcessarPagamento());
        }

        static void ProcessarBoleto()
        {
            Console.Clear();

            decimal valor = LerValor();

            Console.Write("Informe o código de barras: ");
            string codigo = Console.ReadLine();

            PagamentoBoleto pagamento = new PagamentoBoleto
            {
                Valor = valor,
                CodigoBarras = codigo,
                Data = DateTime.Now
            };

            Console.WriteLine("\n" + pagamento.ProcessarPagamento());
        }
    }
}