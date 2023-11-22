using System;

namespace TrabalhoFinalPOO.sistema
{
    public class ContaLuz : Conta
    {
        private double valorFixoSerPago = 13.25;

        public ContaLuz(string tipoImovel, double leituraMesAnterior, double leituraMesAtual) : base(){
            this.tipoImovel = tipoImovel;
            this.leituraMesAnterior = leituraMesAnterior;
            this.leituraMesAtual = leituraMesAtual;
        }

        public override ValorTotalComImposto(){
            switch(tipoImovel){
                case "COMERCIAL":
                    double tarifa = 0.41;
                    double total = (consumo * tarifaComercial) + valorFixoSerPago;
                    valorSemImposto = total;
                    if(consumo > 90){
                        total=1.2195;
                    }
                    break;

                case "RESIDENCIAL":
                    double tarifa = 0.46;
                    double total = (consumo tarifaComercial) + valorFixoSerPago;
                    valorSemImposto = total;
                    if(consumo > 90){
                        total*=1.4285;
                    }
                    break;

                default:
                    throw new Exception("Teste");
            }
        }
    }
}