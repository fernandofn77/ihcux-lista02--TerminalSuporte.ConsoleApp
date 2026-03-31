using System;
using System.Text.RegularExpressions;
/*
Heurísticas aplicadas:

#5 - Prevenção de erros:
Confirmação antes de formatar unidade.

#6 - Reconhecimento ao invés de recordação:
Menu exibido na tela com opções.

#10 - Ajuda e documentação:
Comando 'help' mostra instruções.

Extras:
- Uso de cores para feedback (verde, amarelo, vermelho)
- Validação de IP para evitar erro de entrada
*/
class Program
{
    static void Main()
    {
        while (true)
        {
            MostrarMenu();
            Console.Write("\nDigite um comando: ");
            string comando = Console.ReadLine().ToLower();

            switch (comando)
            {
                case "1":
                    PingarIP();
                    break;
                case "2":
                    FormatarUnidade();
                    break;
                case "help":
                case "?":
                    MostrarAjuda();
                    break;
                case "0":
                    return;
                default:
                    ErroComando();
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== TERMINAL DE SUPORTE ===");
        Console.ResetColor();

        Console.WriteLine("1 - Pingar IP");
        Console.WriteLine("2 - Formatar Unidade");
        Console.WriteLine("0 - Sair");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nDigite 'help' ou '?' para ajuda");
        Console.ResetColor();
    }

    static void PingarIP()
    {
        Console.Write("\nDigite o IP: ");
        string ip = Console.ReadLine();

        if (!ValidarIP(ip))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("IP inválido! Use o formato: xxx.xxx.xxx.xxx");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ping realizado com sucesso!");
        Console.ResetColor();
        Console.ReadKey();
    }

    static bool ValidarIP(string ip)
    {
        return Regex.IsMatch(ip, @"^(\d{1,3}\.){3}\d{1,3}$");
    }

    static void FormatarUnidade()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nATENÇÃO: Você está prestes a formatar a unidade!");
        Console.ResetColor();

        Console.Write("Tem certeza? (s/n): ");
        string confirmacao = Console.ReadLine().ToLower();

        if (confirmacao == "s")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Formatando...");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Operação cancelada.");
        }

        Console.ReadKey();
    }

    static void MostrarAjuda()
    {
        Console.WriteLine("\n=== AJUDA ===");
        Console.WriteLine("1 - Testa conexão com IP");
        Console.WriteLine("2 - Formata unidade (ação crítica)");
        Console.WriteLine("0 - Sai do sistema");
        Console.ReadKey();
    }

    static void ErroComando()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nComando inválido!");
        Console.ResetColor();
        Console.ReadKey();
    }
}