using System;

namespace TrabalhoFinalPOO.sistema{
    public class ContaAgua : Conta{

        private double tarifaAgua = 0;
        private double tarifaEsgoto = 0;

        private double imposto = 1.03;

        public ContaAgua(string tipoImovel, double leituraMesAnterior, double leituraMesAtual) : base(){
            this.tipoImovel = tipoImovel;
            this.leituraMesAnterior = leituraMesAnterior;
            this.leituraMesAtual = leituraMesAtual;
        }

        public override  ValorTotalComImposto(){
            switch(tipoImovel){
                case "RESIDENCIAL":
                    double aux = consumo;

                    if(aux < 6){
                        tarifaAgua = 10.08;
                        tarifaEsgoto = 5.05;
                        valorSemImposto = tarifaAgua + tarifaEsgoto;
                        return valorSemImposto*=imposto;
                    }else if(aux >= 6 && aux < 10){
                        tarifaAgua = 2.241;
                        tarifaEsgoto = 1.122;
                    }

                    break;

                case "COMERCIAL":

                    break;

                default:
                    throw new Exception("Teste");
            }
        }
    }
}