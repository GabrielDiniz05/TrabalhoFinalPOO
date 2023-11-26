using System;

namespace TrabalhoFinalPOO.sistema{
    public class ContaLuz : Conta, GerenciadorDados{

        private static int cont = 1;
        private int id;
        private double valorFixoSerPago = 13.25;

        public ContaLuz(string tipoImovel, string nomeMesAtual, double leituraMesAnterior, double leituraMesAtual, int idConsumidor) : base(){
            this.id = cont;
            cont++;
            this.idConsumidor = idConsumidor;
            this.nomeMesAtual = nomeMesAtual;
            this.tipoImovel = tipoImovel;
            this.leituraMesAnterior = leituraMesAnterior;
            this.leituraMesAtual = leituraMesAtual;
            consumo = this.leituraMesAtual - this.leituraMesAnterior;
        }

        public int getId(){
            return id;
        }

        public override double ValorTotalComImposto(){
            try{
                tipoImovel.ToLower();
                switch (tipoImovel){
                    case "comercial":
                        double tarifa = 0.41;
                        total = (consumo * tarifa) + valorFixoSerPago;
                        valorSemImposto = total;
                        if (consumo > 90){
                            total *= 1.2195;
                        }
                        return total;

                    case "residencial":
                        tarifa = 0.46;
                        total = (consumo * tarifa) + valorFixoSerPago;
                        valorSemImposto = total;
                        if (consumo > 90){
                            total *= 1.4285;
                        }
                        return total;

                    default:
                        throw new Exception("Tipo de imóvel inválido.");
                }
            }catch (Exception ex){
                Console.WriteLine($"Erro ao calcular o valor total com imposto: {ex.Message}");
                return 0; // ou outra ação apropriada para o seu caso
            }
        }

        public void enviarParaBanco(){
            StreamWriter sw = new StreamWriter("tabelas/contasDeLuz.txt", true);
            sw.WriteLine(this.ToString());
            sw.Close();
        }

        public override String ToString(){
            return id + 
            "," + nomeMesAtual + 
            "," + tipoImovel + 
            "," + leituraMesAnterior +
            "," + leituraMesAtual + 
            "," + consumo +
            "," + valorSemImposto +
            "," + idConsumidor;
        }
    }
}
