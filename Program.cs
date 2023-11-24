using System;
using TrabalhoFinalPOO.sistema;


public class Program
{

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
            string Opcao = Console.ReadLine();
            if(Opcao == "3"){
                isRunning = false;
            }
            MenuInicial(Opcao);
            
        }



        static void MenuInicial(string Opcao)
        {
            Consumidor c1;
            string senha;
            string nome;
            switch (Opcao)
            {
                case "1":
                    Console.WriteLine("Digite seu nome: ");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite sua senha: ");
                    senha = Console.ReadLine();
                    c1 = new Consumidor(nome, senha);
                    c1.enviarParaBanco();
                    break;
                case "2":
                    Console.WriteLine("Digite seu nome: ");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite sua senha: ");
                    senha = Console.ReadLine();
                    c1 = new Consumidor(nome, senha);
                    break;
            }
        }


        static void MenuContas()
        {
            
        }
    }
}

