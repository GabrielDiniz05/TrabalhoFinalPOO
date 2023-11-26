using System;
using System.Collections.Generic;
using TrabalhoFinalPOO.sistema;

public class Program
{
    static StreamReader sr = new StreamReader("tabelas/consumidores.txt");
    static List<Consumidor> consumidores = new List<Consumidor>();
    static List<ContaLuz> contasDeLuz = new List<ContaLuz>();

    static List<ContaAgua> contasDeAgua = new List<ContaAgua>();

    static int indexDoConsumidor;

    static int qntdConsumidores;

    public static void Main(String[] args)
    {
        ReceberConsumidores();
        ReceberContasLuz();
        ReceberContasAgua();

        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("+----------------------------------+");
            Console.WriteLine("|          MENU PRINCIPAL          |");
            Console.WriteLine("|----------------------------------|");
            Console.WriteLine("| SEJA BEM VINDO AO NOSSO SISTEMA! |");
            Console.WriteLine("| 1. CADASTRAR-SE                  |");
            Console.WriteLine("| 2. LOGAR                         |");
            Console.WriteLine("| 3. SAIR DO SISTEMA               |");
            Console.WriteLine("+----------------------------------+");

            Console.Write("Escolha uma opção: ");
            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    RegistrarConsumidor();
                    break;
                case "2":
                    Logar();
                    break;
                case "3":
                    Console.WriteLine("=== OBRIGADO E ATÉ LOGO! ===");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("=== OPÇÃO INVÁLIDA. TENTE NOVAMENTE. ===");
                    break;
            }

            if (isRunning)
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        GerarRelatorio();
    }

    static void ReceberConsumidores(){
        
        Consumidor consumidor;

        String[] entrada = sr.ReadToEnd().Split("\n");

        qntdConsumidores = entrada.Length;

        String[] strFormatada;
        try{            
            for (int i = 0; i < entrada.Length; i++){
                strFormatada = entrada[i].Split(',');
                consumidor = new Consumidor(strFormatada[1], strFormatada[2]);
                consumidores.Add(consumidor);
            }
            sr.Close();
        }catch (Exception e){
            
            sr.Close();
            return;
        }


    }

    static void ReceberContasLuz(){
        sr = new StreamReader("tabelas/contasDeLuz.txt");

        ContaLuz contaLuz;

        String[] entrada = sr.ReadToEnd().Split("\n");

        String[] strFormatada;

        try{
            for (int i = 0; i < entrada.Length; i++){
                strFormatada = entrada[i].Split(',');
                contaLuz = new ContaLuz(strFormatada[2], strFormatada[1], double.Parse(strFormatada[3]), double.Parse(strFormatada[4]), int.Parse(strFormatada[8]));
                contasDeLuz.Add(contaLuz);
            }
        }catch (Exception e){
            Console.WriteLine("Erro no metodo ReceberContasLuz. Erro: " + e.Message);
        }
        sr.Close();
        return;
    }

    

    public static void GerarRelatorio()
    {
        Relatorio relatorio = new Relatorio(contasDeLuz, contasDeAgua);
        string nomeArquivo = "tabelas/Relatorio.txt";
        relatorio.EscreverContasNoArquivo(nomeArquivo);
    }



    static void ReceberContasAgua(){
        sr = new StreamReader("tabelas/contasDeAgua.txt");
        
        ContaAgua contaAgua;

        String[] entrada = sr.ReadToEnd().Split("\n");

        String[] strFormatada;

        try{
            for (int i = 0; i < entrada.Length; i++){
                strFormatada = entrada[i].Split(',');
                contaAgua = new ContaAgua(strFormatada[2], strFormatada[1], double.Parse(strFormatada[3]), double.Parse(strFormatada[4]), int.Parse(strFormatada[8]));
                contasDeAgua.Add(contaAgua);
            }
            sr.Close();
        }catch (Exception e){
            Console.WriteLine("Erro no metodo ReceberContasAgua. Erro: " + e.Message);
            sr.Close();
            return;
        }
    }

    static void RegistrarConsumidor()
    {
        try
        {
            Console.WriteLine("Digite seu nome: ");
            string? nome = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string? senha = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                throw new Exception("Nome e senha não podem ser vazios.");
            }

            Consumidor novoConsumidor = new Consumidor(nome, senha);
            consumidores.Add(novoConsumidor);
            

            Console.WriteLine("Cadastro realizado com sucesso!");
            MenuContas(novoConsumidor);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no cadastro: {ex.Message}");
        }
    }



    static void Logar()
    {
        Consumidor consumidor;

        Consumidor[] aux = new Consumidor[consumidores.Count];
        aux = consumidores.ToArray();

        Console.WriteLine("Digite seu nome: ");
        string? nome = Console.ReadLine();

        if (EstaNoBanco(nome, 1))
        {
            consumidor = aux[indexDoConsumidor - 1];
            Console.WriteLine("Digite sua senha: ");
            string? senha = Console.ReadLine();
            if (EstaNoBanco(senha, 2))
            {
                MenuContas(consumidor);
            }
            else
            {
                Console.WriteLine("Senha inválida");
                Logar();
            }
        }
        else
        {
            Console.WriteLine("Nome inválido");
            Logar();
        }
    }

    static bool EstaNoBanco(String entrada, int tipo)
    {
        sr = new StreamReader("tabelas/consumidores.txt");
        String[] primeiraEntrada = sr.ReadLine().Split(',');

        try
        {
            while (primeiraEntrada[tipo] != entrada)
            {
                primeiraEntrada = sr.ReadLine().Split(',');
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao consultar no banco. Erro: " + e.Message);
            return false;
        }

        indexDoConsumidor = int.Parse(primeiraEntrada[0]);

        sr.Close();
        return true;
    }

    static void MenuContas(Consumidor consumidor)
    {
        Console.WriteLine($"Bem-vindo, {consumidor.getNome()}!");

        while (true)
        {

            if(consumidores.Count > 0){
                MenuConta1(consumidor);
            }else{
                MenuConta2(consumidor);
            }
        }
    }

    static void MenuConta1(Consumidor consumidor){
        Console.WriteLine("+----------------------------------+");
        Console.WriteLine("|          MENU DE CONTAS          |");
        Console.WriteLine("|----------------------------------|");
        Console.WriteLine("|1.     Cadastrar Conta de Água    |");
        Console.WriteLine("|2.     Cadastrar Conta de Luz     |");
        Console.WriteLine("|3.     Gerar relatorio das contas |");
        Console.WriteLine("|4.             Sair               |");
        Console.WriteLine("+----------------------------------+");

        Console.WriteLine("Escolha uma opção: ");
        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                try
                {
                    Console.WriteLine("DIGITE O TIPO DE IMOVEL: ");
                    string? tipoImovel = Console.ReadLine();
                    Console.WriteLine("DIGITE O NOME DO MÊS ATUAL: ");
                    string nomeMesAtual = Console.ReadLine();
                    Console.WriteLine("DIGITE A LEITURA DO MÊS ANTERIOR DO HIDRÔMETRO: ");
                    double leituraMesAnterior = double.Parse(Console.ReadLine());
                    Console.WriteLine("DIGITE A LEITURA DO HIDRÔMETRO DESSE MÊS: ");
                    double leituraMesAtual = double.Parse(Console.ReadLine());
                    ContaAgua ca1 = new ContaAgua(tipoImovel, nomeMesAtual, leituraMesAnterior, leituraMesAtual, consumidor.getId());
                    contasDeAgua.Add(ca1);

                    consumidor.ContasDeAgua.Add(ca1);

                    ca1.enviarParaBanco();
                    double valorContaImposto = ca1.ValorTotalComImposto();
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
                    string? tipoImovel = Console.ReadLine();
                    Console.WriteLine("DIGITE O NOME DO MÊS ATUAL: ");
                    string nomeMesAtual = Console.ReadLine();
                    Console.WriteLine("DIGITE A LEITURA DO MÊS ANTERIOR DO RELÓGIO: ");
                    double leituraMesAnterior = double.Parse(Console.ReadLine());
                    Console.WriteLine("DIGITE A LEITURA DO RELÓGIO DESSE MÊS: ");
                    double leituraMesAtual = double.Parse(Console.ReadLine());
                    ContaLuz cl1 = new ContaLuz(tipoImovel, nomeMesAtual, leituraMesAnterior, leituraMesAtual, consumidor.getId());
                    contasDeLuz.Add(cl1);

                    consumidor.ContasDeLuz.Add(cl1);

                    cl1.enviarParaBanco();
                    double valorContaImposto = cl1.ValorTotalComImposto();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao visualizar conta de luz: {ex.Message}");
                }
                break;
            case "3":
                consumidor.enviarParaBanco();
                VisualizarRelatorio();
                return;
            case "4":
                consumidor.enviarParaBanco();
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void MenuConta2(Consumidor consumidor){
        Console.WriteLine("+----------------------------------+");
        Console.WriteLine("|          MENU DE CONTAS          |");
        Console.WriteLine("|----------------------------------|");
        Console.WriteLine("|1.   Cadastrar Conta de Água      |");
        Console.WriteLine("|2.   Cadastrar Conta de Luz       |");
        Console.WriteLine("|3.   Visualizar Contas de Luz     |");
        Console.WriteLine("|4.   Visualizar Contas de Agua    |");
        Console.WriteLine("|5.   Gerar relatorio das contas   |");
        Console.WriteLine("|6.             Sair               |");
        Console.WriteLine("+----------------------------------+");

        Console.WriteLine("Escolha uma opção: ");
        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                try
                {
                    Console.WriteLine("DIGITE O TIPO DE IMOVEL: ");
                    string? tipoImovel = Console.ReadLine();
                    Console.WriteLine("DIGITE O NOME DO MÊS ATUAL: ");
                    string nomeMesAtual = Console.ReadLine();
                    Console.WriteLine("DIGITE A LEITURA DO MÊS ANTERIOR DO HIDRÔMETRO: ");
                    double leituraMesAnterior = double.Parse(Console.ReadLine());
                    Console.WriteLine("DIGITE A LEITURA DO HIDRÔMETRO DESSE MÊS: ");
                    double leituraMesAtual = double.Parse(Console.ReadLine());
                    ContaAgua ca1 = new ContaAgua(tipoImovel, nomeMesAtual, leituraMesAnterior, leituraMesAtual, consumidor.getId());
                    contasDeAgua.Add(ca1);

                    consumidor.ContasDeAgua.Add(ca1);

                    ca1.enviarParaBanco();
                    double valorContaImposto = ca1.ValorTotalComImposto();
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
                    string? tipoImovel = Console.ReadLine();
                    Console.WriteLine("DIGITE O NOME DO MÊS ATUAL: ");
                    string nomeMesAtual = Console.ReadLine();
                    Console.WriteLine("DIGITE A LEITURA DO MÊS ANTERIOR DO RELÓGIO: ");
                    double leituraMesAnterior = double.Parse(Console.ReadLine());
                    Console.WriteLine("DIGITE A LEITURA DO RELÓGIO DESSE MÊS: ");
                    double leituraMesAtual = double.Parse(Console.ReadLine());
                    ContaLuz cl1 = new ContaLuz(tipoImovel, nomeMesAtual, leituraMesAnterior, leituraMesAtual, consumidor.getId());
                    contasDeLuz.Add(cl1);

                    consumidor.ContasDeLuz.Add(cl1);

                    cl1.enviarParaBanco();
                    double valorContaImposto = cl1.ValorTotalComImposto();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao visualizar conta de luz: {ex.Message}");
                }
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("|        CONTAS DE LUZ        |");
                Console.WriteLine("+-----------------------------+");
                ContaLuz[] contaLuzs = consumidor.ContasDeLuz.ToArray();
                if(contaLuzs.Length > 0){
                    for(int i = 0; i < contaLuzs.Length; i++){
                        VisualizarContaLuz(contaLuzs[i]);
                    }
                }else{
                    Console.WriteLine("Não exitem contas de luz cadastradas.");
                    return;
                }
                break;
            case "4":
                Console.Clear();
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("|        CONTAS DE AGUA       |");
                Console.WriteLine("+-----------------------------+");
                ContaAgua[] contaAguas = consumidor.ContasDeAgua.ToArray();
                if(contaAguas.Length > 0){
                    for(int i = 0; i < contaAguas.Length; i++){
                        VisualizarContaAgua(contaAguas[i]);
                    }
                }else{
                    Console.WriteLine("Não exitem contas de água cadastradas.");
                    return;
                }
                break;
            case "5":
                consumidor.enviarParaBanco();
                VisualizarRelatorio();
                return;
            case "6":
                consumidor.enviarParaBanco();
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }


    static void VisualizarRelatorio()
    {
        Console.Clear();
        Console.WriteLine("+-----------------------------+");
        Console.WriteLine("|     RELATÓRIO DE CONTAS     |");
        Console.WriteLine("+-----------------------------+");

        foreach (var contaLuz in contasDeLuz)
        {
            VisualizarContaLuz(contaLuz);
            Console.WriteLine("+-----------------------------+");
        }

        foreach (var contaAgua in contasDeAgua)
        {
            VisualizarContaAgua(contaAgua);
            Console.WriteLine("+-----------------------------+");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    static void VisualizarContaLuz(ContaLuz cl1)
    {
        Console.WriteLine($"Tipo de Imóvel: {cl1.getTipoImovel()}");
        Console.WriteLine($"Leitura do Mês Anterior: {cl1.getLeituraMesAnterior()}");
        Console.WriteLine($"Leitura do Mês Atual: {cl1.getLeituraMesAtual()}");
        Console.WriteLine($"Consumo: {cl1.getConsumo()}");
        Console.WriteLine("VALOR TOTAL DA CONTA: " + "R$" + cl1.ValorTotalComImposto());
    }

    static void VisualizarContaAgua(ContaAgua ca1)
    {
        Console.WriteLine($"Tipo de Imóvel: {ca1.getTipoImovel()}");
        Console.WriteLine($"Leitura do Mês Anterior: {ca1.getLeituraMesAnterior()}");
        Console.WriteLine($"Leitura do Mês Atual: {ca1.getLeituraMesAtual()}");
        Console.WriteLine($"Consumo: {ca1.getConsumo()}");
        Console.WriteLine("VALOR TOTAL DA CONTA: " + "R$" + ca1.ValorTotalComImposto());
    }
}
