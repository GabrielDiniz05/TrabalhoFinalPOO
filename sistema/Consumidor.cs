using TrabalhoFinalPOO.sistema;

public class Consumidor : GerenciadorDados{

    static int cont = 1;
    int id;
    string nome;
    string senha;
    List<ContaLuz> ContasDeLuz;
    List<ContaAgua> ContasDeAgua;

    public Consumidor(string nome, string senha){
        id = cont;
        cont++;
        this.nome = nome;
        this.senha = senha;
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

    public void setSenha(string senha){
        this.senha = senha;
    }

    public void enviarParaBanco(){
        StreamWriter sw = new StreamWriter("tabelas/consumidores.txt");
        sw.WriteLine(this.ToString());
        sw.Close();
    }

    public override string ToString(){
        return id + "," + nome + "," + senha;
    }
}