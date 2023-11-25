using System;
using System.Collections.Generic;
using TrabalhoFinalPOO.sistema;

public class Program
{
    static StreamReader sr = new StreamReader("tabelas/consumidores.txt");
    static List<Consumidor> consumidores = new List<Consumidor>();

    static int indexDoConsumidor;

    static int qntdConsumidores;

    public static void Main(String[] args)
    {
        ReceberConsumidores();
        qntdConsumidores = consumidores.Count;

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
                    Logar();
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

    static void ReceberConsumidores(){
        try{
            String entrada = sr.ReadLine();
            String[] strFormatada = entrada.Split(',');

            Consumidor consumidor = new Consumidor(strFormatada[1], strFormatada[2]);

            consumidores.Add(consumidor);

            int cont = 1;
        
            try{
                String entrada2 = sr.ReadLine();
                while(entrada2 != entrada && cont < qntdConsumidores){
                    strFormatada = entrada2.Split(',');
                    consumidor = new Consumidor(strFormatada[1], strFormatada[2]);
                    consumidores.Add(consumidor);
                }
            }catch(Exception e){
                Console.WriteLine("Erro no metodo ReceberConsumidores. Erro: " + e.StackTrace);
            }
            sr.Close();
        }catch(Exception e){
            sr.Close();
            return;
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


    
    static void Logar(){
        Consumidor consumidor;

        Consumidor[] aux = new Consumidor[consumidores.Count];
        aux = consumidores.ToArray();
        
        Console.WriteLine("Digite seu nome: ");
        string nome = Console.ReadLine();
        
        if(EstaNoBanco(nome, 1)){
            consumidor = aux[indexDoConsumidor - 1];
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if(EstaNoBanco(senha, 2)){
                MenuContas(consumidor);
            }else{
                Console.WriteLine("Senha inválida");
                Logar();
            }
        }else{
            Console.WriteLine("Nome inválido");
            Logar();
        }
    }

    static bool EstaNoBanco(String entrada, int tipo){
        sr = new StreamReader("tabelas/consumidores.txt");
        String[] primeiraEntrada = sr.ReadLine().Split(',');

        int cont = 1;
        
        try{
            while(primeiraEntrada[tipo] != entrada && cont < qntdConsumidores){
                primeiraEntrada = sr.ReadLine().Split(',');
            }
        }catch(Exception e){
            Console.WriteLine("Erro ao consultar no banco. Erro: " + e.StackTrace);
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
