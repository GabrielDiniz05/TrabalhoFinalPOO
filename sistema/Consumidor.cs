using System;

public class Consumidor{

    static int cont = 1;
    int id;
    string nome;

    public Consumidor(string nome){
        id = cont;
        cont++;
        this.nome = nome;
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