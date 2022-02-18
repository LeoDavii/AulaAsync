using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AulaAsync.cotacao;

namespace AulaAsync.conversor
{
    public class Conversor
    {
        public async Task<double> converterReaisParaRublo(double valorEmReais)
        {   
            var client = new HttpClient();
            var cotacaoRublo = await client.GetStringAsync("https://economia.awesomeapi.com.br/last/RUB-BRL");
            MoedaRUBBRL moeda = JsonSerializer.Deserialize<MoedaRUBBRL>(cotacaoRublo);

            return valorEmReais / double.Parse(moeda.RUBBRL.bid.Replace(".", ","));
        }

        public async Task<double> converterReaisParaDolar(double valorEmReais)
        {   
            var client = new HttpClient();
            var cotacaoDolar = await client.GetStringAsync("https://economia.awesomeapi.com.br/last/USD-BRL");
            MoedaUSDBRL moeda = JsonSerializer.Deserialize<MoedaUSDBRL>(cotacaoDolar);

            return valorEmReais / double.Parse(moeda.USDBRL.bid.Replace(".", ","));
        }

        public async Task<double> converterDolarParaRublo(double valorEmDolar)
        {   
            var client = new HttpClient();
            var cotacaoDolar = await client.GetStringAsync("https://economia.awesomeapi.com.br/last/RUB-USD");
            MoedaRUBUSD moeda = JsonSerializer.Deserialize<MoedaRUBUSD>(cotacaoDolar);

            return valorEmDolar / double.Parse(moeda.RUBUSD.bid.Replace(".", ","));
        }

        public async Task<double> converterRubloParaDolar(double valorRublo)
        {   
            var client = new HttpClient();
            var cotacaoRublo = await client.GetStringAsync("https://economia.awesomeapi.com.br/last/USD-RUB");
            MoedaUSDRUB moeda = JsonSerializer.Deserialize<MoedaUSDRUB>(cotacaoRublo);

            return valorRublo / double.Parse(moeda.USDRUB.bid.Replace(".", ","));
        }

        public async Task converterParaDolar(double valorEmReais)
        { 
            var conversaoRealParaDolar = await converterReaisParaDolar(valorEmReais);
            var valorRUB = await converterReaisParaRublo(valorEmReais);
            var conversaoRUBParaDolar = await converterRubloParaDolar(valorRUB);

            validarConversao(conversaoRealParaDolar, conversaoRUBParaDolar);
            Console.WriteLine($"US$ {conversaoRUBParaDolar}");
        }

        public async Task converterParaRublo(double valorEmReais)
        {
            var conversaoRealParaRublo = await converterReaisParaRublo(valorEmReais);
            var valorUSD = await converterReaisParaDolar(valorEmReais);
            var conversaoDolarParaRublo = await converterDolarParaRublo(valorUSD);  

            validarConversao(conversaoRealParaRublo, conversaoDolarParaRublo);
            Console.WriteLine($"RUB {conversaoDolarParaRublo}");        
        }

        public void validarConversao(double conversaoDireta, double conversaoIndireta)
        {
         if (Convert.ToInt32(conversaoDireta) != Convert.ToInt32(conversaoIndireta))
                throw new Exception("Houve uma falha durante a conversão");
        }
    }
}