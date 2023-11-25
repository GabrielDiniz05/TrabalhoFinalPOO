using System;
using System.Collections.Generic;
using TrabalhoFinalPOO.sistema;

public class Program
{
    static List<Consumidor> consumidores = new List<Consumidor>();

    public static void Main(String[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("SEJA BEM VINDO AO NOSSO SISTEMA!");
            Console.WriteLine("PARA OS SEGUINTES PROCESSOS, DIGITE UM NUMERO PARA REALIZA-LO.");
            Console.WriteLine("CADASTRAR-SE: 1");
            Console.WriteLine("LOGAR: 2");
            Console.WriteLine("SAIR DO SISTEMA: 3");
            string opcao = Console.ReadLine();
            
            switch (opcao)
            {
                case "1":
                    RegistrarConsumidor();
                    break;
                case "2":
                    // Logar();
                    break;
                case "3":
                    Console.WriteLine("ESPERO QUE TENHAMOS AJUDADO, ATÉ A PROXIMA!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("OPÇÃO");
                    break;
            }
        }
    }

    static void RegistrarConsumidor()
    {
        try
        {
            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                throw new Exception("Nome e senha não podem ser vazios.");
            }

            Consumidor novoConsumidor = new Consumidor(nome, senha);
            consumidores.Add(novoConsumidor);
            novoConsumidor.enviarParaBanco();

            Console.WriteLine("Cadastro realizado com sucesso!");
            MenuContas(novoConsumidor);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no cadastro: {ex.Message}");
        }
    }

    /*
    static void Logar()
    {
        Console.WriteLine("Digite seu nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite sua senha: ");
        string senha = Console.ReadLine();

        Consumidor consumidorLogado = consumidores.Find(c => c.getNome() == nome && c.getSenha() == senha);

        if (consumidorLogado != null)
        {
            Console.WriteLine("Login bem-sucedido!");
            MenuContas(consumidorLogado);
        }
        else
        {
            Console.WriteLine("Nome de usuário ou senha incorretos. Tente novamente.");
        }
    }
    */

    static void MenuContas(Consumidor consumidor)
    {
        Console.WriteLine($"Bem-vindo, {consumidor.getNome()}!");

        while (true)
        {
            Console.WriteLine("MENU DE CONTAS");
            Console.WriteLine("1. Visualizar Conta de Água");
            Console.WriteLine("2. Visualizar Conta de Luz");
            Console.WriteLine("3. Voltar ao Menu Principal");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("DIGITE O TIPO DE IMOVEL: ");
                        string tipoImovel = Console.ReadLine();
                        Console.WriteLine("DIGITE A LEITURA DO MÊS ANTERIOR DO HIDRÔMETRO: ");
                        double leituraMesAnterior = double.Parse(Console.ReadLine());
                        Console.WriteLine("DIGITE A LEITURA DO HIDRÔMETRO DESSE MÊS: ");
                        double leituraMesAtual = double.Parse(Console.ReadLine());
                        ContaAgua ca1 = new ContaAgua(tipoImovel, leituraMesAnterior, leituraMesAtual);
                        double valorContaImposto = ca1.ValorTotalComImposto();
                        VisualizarContaAgua(ca1, valorContaImposto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao visualizar conta de água: {ex.Message}");
                    }
                    break;
                case "2":
                    try
                    {
                        Console.WriteLine("DIGITE O TIPO DE IMOVEL: ");
                        string tipoImovel = Console.ReadLine();
                        Console.WriteLine("DIGITE A LEITURA DO MÊS ANTERIOR DO RELÓGIO: ");
                        double leituraMesAnterior = double.Parse(Console.ReadLine());
                        Console.WriteLine("DIGITE A LEITURA DO RELÓGIO DESSE MÊS: ");
                        double leituraMesAtual = double.Parse(Console.ReadLine());
                        ContaLuz cl1 = new ContaLuz(tipoImovel, leituraMesAnterior, leituraMesAtual);
                        double valorContaImposto = cl1.ValorTotalComImposto();
                        VisualizarContaLuz(cl1, valorContaImposto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao visualizar conta de luz: {ex.Message}");
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void VisualizarContaLuz(ContaLuz cl1, double valorContaImposto)
    {
        Console.WriteLine($"Tipo de Imóvel: {cl1.getTipoImovel()}");
        Console.WriteLine($"Leitura do Mês Anterior: {cl1.getLeituraMesAnterior()}");
        Console.WriteLine($"Leitura do Mês Atual: {cl1.getLeituraMesAtual()}");
        Console.WriteLine($"Consumo: {cl1.getConsumo()}");
        Console.WriteLine("VALOR TOTAL DA CONTA: " + "R$" + valorContaImposto);
    }

    static void VisualizarContaAgua(ContaAgua ca1, double valorContaImposto)
    {
        Console.WriteLine($"Tipo de Imóvel: {ca1.getTipoImovel()}");
        Console.WriteLine($"Leitura do Mês Anterior: {ca1.getLeituraMesAnterior()}");
        Console.WriteLine($"Leitura do Mês Atual: {ca1.getLeituraMesAtual()}");
        Console.WriteLine($"Consumo: {ca1.getConsumo()}");
        Console.WriteLine("VALOR TOTAL DA CONTA: " + "R$" + valorContaImposto);
    }
}
