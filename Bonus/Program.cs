using System;
using System.Collections.Generic;

public class ProgramaBonus
{
    public static void Main()
    {
        double percentualBonus = 0.0;
        string nomeBusca;

        // Dicionário contendo os funcionários e seus salários base
        Dictionary<string, double> funcionarios = new()
        {
            {"Marcos Daniel", 2500.00},
            {"Ana Souza", 3000.00},
            {"Carlos Lima", 2800.00},
            {"Beatriz Alves", 2700.00},
            {"Lucas Caio", 1100.00}
        };

        Console.WriteLine("--- Sistema de Cálculo de Bônus ---");

        // Loop até encontrar um funcionário válido
        while (true)
        {
            Console.Write("Digite o nome do funcionário: ");
            nomeBusca = Console.ReadLine();

            if (funcionarios.ContainsKey(nomeBusca))
            {
                Console.WriteLine($"Funcionário encontrado! Salário base: R$ {funcionarios[nomeBusca]:F2}");
                break;
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado. Tente novamente.");
            }
        }

        // Recebe 5 notas dos supervisores
        List<double> notas = new();
        Console.WriteLine("\n--- Avaliação dos Supervisores ---");
        for (int i = 1; i <= 5; i++)
        {
            double nota;
            while (true)
            {
                Console.Write($"Digite a nota do supervisor {i} (1 a 5): ");
                if (double.TryParse(Console.ReadLine(), out nota) && nota >= 1 && nota <= 5)
                {
                    notas.Add(nota);
                    break;
                }
                else
                {
                    Console.WriteLine("Nota inválida! Digite um número entre 1 e 5.");
                }
            }
        }

        // Calcula a média das notas
        double soma = 0;
        foreach (var n in notas) soma += n;
        double mediaNotas = soma / notas.Count;

        Console.WriteLine($"\nMédia das notas dos supervisores: {mediaNotas:F2}");

        // Define o percentual do bônus com base na média
        if (mediaNotas >= 4.5)
        {
            percentualBonus = 0.20;
            Console.WriteLine("Desempenho Excepcional! Bônus de 20% aplicado.");
        }
        else if (mediaNotas >= 3.5)
        {
            percentualBonus = 0.10;
            Console.WriteLine("Desempenho Ótimo! Bônus de 10% aplicado.");
        }
        else if (mediaNotas >= 2.5)
        {
            percentualBonus = 0.05;
            Console.WriteLine("Desempenho Bom! Bônus de 5% aplicado.");
        }
        else
        {
            percentualBonus = 0.0;
            Console.WriteLine("Desempenho Regular ou Abaixo. Nenhum bônus aplicado.");
        }

        double salarioBase = funcionarios[nomeBusca];
        double valorBonus = salarioBase * percentualBonus;
        double salarioTotal = salarioBase + valorBonus;

        Console.WriteLine("\n---------------------------");
        Console.WriteLine($"Valor do Bônus: R$ {valorBonus:F2}");
        Console.WriteLine($"Salário Total: R$ {salarioTotal:F2}");
        Console.WriteLine("---------------------------");

        // Mensagem personalizada com base no valor do bônus
        if (valorBonus >= 500)
        {
            Console.WriteLine($"O funcionário foi excepcional para a empresa. Parabéns ao {nomeBusca}!");
        }
        else if (valorBonus >= 250)
        {
            Console.WriteLine($"O funcionário foi bem para a empresa. Parabéns ao {nomeBusca}!");
        }
        else if (valorBonus >= 100)
        {
            Console.WriteLine($"O funcionário teve uma boa iniciativa para a empresa. Parabéns ao {nomeBusca}!");
        }
        else if (valorBonus == 0)
        {
            Console.WriteLine($"O {nomeBusca} foi regular. Nenhum bônus aplicado.");
        }
        else
        {
            Console.WriteLine("Não há dados sobre esse funcionário. Tente novamente.");
        }

        bool mostrarHistorico = false;

        // Pergunta se o usuário quer ver o histórico
        Console.Write("\nDeseja abrir o histórico de cálculos? (S/N): ");
        string resposta = Console.ReadLine();

        if (resposta == "S" || resposta == "s")
        {
            mostrarHistorico = true;
        }
        else if (resposta == "N" || resposta == "n")
        {
            mostrarHistorico = false;
        }
        else
        {
            Console.WriteLine("Resposta incorreta. Tente novamente.");
        }

        // Cria o histórico (em memória)
        List<string> historico = new()
        {
            $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {nomeBusca} - Salário Base: R$ {salarioBase:F2} - Média Supervisores: {mediaNotas:F2} - Bônus: R$ {valorBonus:F2} - Salário Total: R$ {salarioTotal:F2}"
        };

        if (mostrarHistorico)
        {
            Console.WriteLine("\n--- Histórico de Cálculos ---");
            foreach (var registro in historico)
            {
                Console.WriteLine(registro);
            }
        }
        else
        {
            Console.WriteLine("\nObrigado por usar o nosso sistema. Até logo!");
        }
    }
}
