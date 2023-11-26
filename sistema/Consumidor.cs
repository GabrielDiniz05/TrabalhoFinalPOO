using TrabalhoFinalPOO.sistema;

public class Consumidor : GerenciadorDados{

    static int cont = 1;
    int id;
    string nome;
    string senha;
    public List<ContaLuz> ContasDeLuz;
    public List<ContaAgua> ContasDeAgua;


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
        StreamWriter sw = new StreamWriter("tabelas/consumidores.txt", true);
        sw.WriteLine(this.ToString());
        
        sw.Close();
    }

    public override string ToString(){
        ContaLuz[] contaLuzs = ContasDeLuz.ToArray();
        ContaAgua[] contaAguas = ContasDeAgua.ToArray();

        String p1 = id + "," + nome + "," + senha;

        String p2 = "";
        if(contaLuzs.Length > 0){
            p2 = ",";
            for(int i = 0; i < contaLuzs.Length-1; i++){
                p2 += contaLuzs[i] + "-";
            }
            p2 += contaLuzs[contaLuzs.Length-1] + ",";
        }
        String p3 = ""; 
        if(contaAguas.Length > 0){
       
            for(int i = 0; i < contaAguas.Length-1; i++){
                p3 += contaAguas[i] + "-";
            }
            p3 += contaAguas[contaAguas.Length-1];
        }
        
        return p1 + p2 + p3;
    }
}