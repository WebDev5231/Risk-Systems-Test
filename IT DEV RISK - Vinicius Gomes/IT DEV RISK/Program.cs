using IT_DEV_RISK.Interfaces;
using IT_DEV_RISK.Models;
using IT_DEV_RISK;
using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Definir a data de referência
        DateTime referenceDate = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture);

        // Criar a lista de trades com os dados fixos
        List<ITrade> trades = new List<ITrade>
        {
            new Trade(2000000, "Private", DateTime.ParseExact("12/29/2025", "MM/dd/yyyy", CultureInfo.InvariantCulture), false),
            new Trade(400000, "Public", DateTime.ParseExact("07/01/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture), false),
            new Trade(5000000, "Public", DateTime.ParseExact("01/02/2024", "MM/dd/yyyy", CultureInfo.InvariantCulture), false),
            new Trade(3000000, "Public", DateTime.ParseExact("10/26/2023", "MM/dd/yyyy", CultureInfo.InvariantCulture), false)
        };

        // Criar classificador e processar os trades fixos
        TradeClassifier classifier = new TradeClassifier();
        Console.WriteLine("Classificação dos trades fixos:");
        foreach (var trade in trades)
        {
            Console.WriteLine(classifier.ClassifyTrade(trade, referenceDate));
        }

        // Permitir entrada de novos valores pelo usuário
        Console.WriteLine("\nAgora, insira novos trades (ou pressione Enter para sair):");

        while (true)
        {
            Console.Write("\nDigite o valor do trade: ");
            string valueInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(valueInput)) break;

            Console.Write("Digite o setor do cliente (Public/Private): ");
            string sectorInput = Console.ReadLine();

            Console.Write("Digite a data do próximo pagamento (MM/dd/yyyy): ");
            string dateInput = Console.ReadLine();

            Console.Write("O cliente é Politicamente Exposto? (true/false): ");
            string pepInput = Console.ReadLine();

            try
            {
                double value = double.Parse(valueInput, CultureInfo.InvariantCulture);
                DateTime nextPaymentDate = DateTime.ParseExact(dateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                bool isPoliticallyExposed = bool.Parse(pepInput);

                ITrade newTrade = new Trade(value, sectorInput, nextPaymentDate, isPoliticallyExposed);
                trades.Add(newTrade);

                Console.WriteLine($"Categoria: {classifier.ClassifyTrade(newTrade, referenceDate)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar o trade: {ex.Message}");
            }
        }

        Console.WriteLine("\nTodos os trades processados. Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}