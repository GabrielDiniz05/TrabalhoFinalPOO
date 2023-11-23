using System.Collections.Generic;
using TrabalhoFinalPOO.sistema;

public class Consumidor{

    static int cont = 1;
    int id;
    string nome;
    List<ContaLuz> ContasDeLuz;
    List<ContaAgua> ContasDeAgua;

    public Consumidor(string nome){
        id = cont;
        cont++;
        this.nome = nome;
        ContasDeLuz = new List<ContaLuz>();
        ContasDeAgua = new List<ContaAgua>();
    }

    public int getId(){
        return id;
    }

    public string getNome(){
        return nome;
    }

    public void setNome(string nome){
        this.nome = nome;
    }
}