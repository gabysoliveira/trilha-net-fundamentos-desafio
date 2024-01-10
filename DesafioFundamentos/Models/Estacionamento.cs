using System.Data;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        
        private List<string> veiculos = new List<string>();

        // Adicionando um Dicionário para Registar Horários
        private Dictionary<string, List<DateTime>> registros = new Dictionary<string, List<DateTime>>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string novaPlaca = Console.ReadLine();
            veiculos.Add(novaPlaca);

            // Registro do horário de entrada
            if (!registros.ContainsKey(novaPlaca))
            {
                registros[novaPlaca] = new List<DateTime>();
            }
            registros[novaPlaca].Add(DateTime.Now);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + (precoPorHora * horas); 

                veiculos.Remove(placa);

                // Registre o horário de saída
                registros[placa].Add(DateTime.Now);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string item in veiculos)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ExibirRegistros()
        {
            foreach (var registro in registros)
            {
                Console.WriteLine($"Placa: {registro.Key}");
                Console.WriteLine("Registros de Horário: ");

                foreach(var horario in registro.Value)
                {
                    Console.WriteLine($"{horario.ToString("dd/MM/yyyy HH:mm:ss")}");
                }
                Console.WriteLine();
            }
        }
    }
}
