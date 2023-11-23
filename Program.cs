using System;

public class Program
{

    public static void Main(String[] args)
    {
        Consumidor c1;
        Console.WriteLine("SEJA BEM VINDO AO NOSSO SISTEMA!");
        Console.WriteLine("PARA OS SEGUINTES PROCESSOS, DIGITE UM NUMERO PARA REALIZA-LO.");
        Console.WriteLine("CADASTRAR-SE: 1");
        Console.WriteLine("LOGAR: 2");
        Console.WriteLine("SAIR DO SISTEMA: 3");

        string senha = Console.ReadLine();

        switch (senha)
        {
            case "1":
                Console.WriteLine("Digite seu nome: ");
                string nome = Console.ReadLine();
                c1 = new Consumidor(nome);
                break;
            case "2":
                Console.WriteLine("Digite seu nome: ");
                nome = Console.ReadLine();
                c1 = new Consumidor(nome);
                break;
            case "3":
            break;
        }
    }
}

