using System;
using System.Threading.Tasks;

namespace AulaAsync.conversor
{
    public class MenuConversor
    {
        public void MenuPrincipal()
        {
            Console.WriteLine("Escolha uma das duas opções:");
            Console.WriteLine("1 - Converter Real para Dólar");
            Console.WriteLine("2 - Converter Real para Rublo");
            var opcao = Console.ReadLine();

            double valorInserido = 0;
            switch(opcao) {
                case "1":
                    valorInserido = lerValorUsuario();
                    ExecutarConversaoRealParaDolar(valorInserido).Wait();
                    break;
                case "2":
                    valorInserido = lerValorUsuario();
                    ExecutarConversaoRealParaRublo(valorInserido).Wait();
                    break;
                default:
                    Console.ReadLine();
                    MenuPrincipal();
                    break;
            }
        }

        private async Task ExecutarConversaoRealParaDolar(double valorReais) {
            await Task.WhenAll(
                Task.Run(() => new Conversor().converterParaDolar(valorReais))
            );
        }

        private async Task ExecutarConversaoRealParaRublo(double valorReais) {
            await Task.WhenAll(
                Task.Run(() => new Conversor().converterParaRublo(valorReais))
            );
        }

        private double lerValorUsuario() {
        Console.WriteLine("Digite um número de 1 a 100 para converter");
        return Double.Parse(Console.ReadLine());
        }
    }
}