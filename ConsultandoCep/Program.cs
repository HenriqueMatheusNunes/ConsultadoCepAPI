using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsultandoCep
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Olá, tudo bem? Digite um CEP (SOMENTE 8 NÚMEROS):");
            string entradaUsuario = Console.ReadLine();

            // Sanitização de caracteres desnecessários
            string cepSanitizado = entradaUsuario?.Replace("-", "").Replace(" ", "").Trim() ?? "";

            // Validação defensiva (Early Return)
            if (cepSanitizado.Length != 8 || !ulong.TryParse(cepSanitizado, out _))
            {
                Console.WriteLine("Formato inválido. Digite exatamente 8 números.");
                return;
            }

            // Consumo da API REST com descarte correto da memória
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cepSanitizado}/json/");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dadosCep = JsonSerializer.Deserialize<Informacoes>(json);

                if (dadosCep == null || dadosCep.Erro == "true")
                {
                    Console.WriteLine("CEP não existe na base de dados.");
                    return;
                }

                Console.WriteLine("\n--- CEP Encontrado ---");
                Console.WriteLine($"CEP:        {dadosCep.Cep}");
                Console.WriteLine($"Logradouro: {dadosCep.Logradouro}");
                Console.WriteLine($"Bairro:     {dadosCep.Bairro}");
                Console.WriteLine($"Cidade:     {dadosCep.Localidade}");
                Console.WriteLine($"UF:         {dadosCep.Uf}");
            }
            else
            {
                Console.WriteLine($"CEP não foi encontrado. Status HTTP: {response.StatusCode}");
            }
        }
    }
}