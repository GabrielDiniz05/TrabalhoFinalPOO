using System;

namespace TrabalhoFinalPOO.sistema{
    public abstract class Conta{

        protected string tipoImovel;
        protected double leituraMesAnterior = 0;
        protected double leituraMesAtual = 0;
        protected double consumo = leituraMesAtual - leituraMesAnterior;
        protected double valorSemImposto = 0;

        public String getTipoImovel(){
            return tipoImovel;
        }

        public void setTipoImovel(string tipoImovel){
            this.tipoImovel = tipoImovel;
        }

        public double getLeituraMesAnterior(){
            return leituraMesAnterior;
        }

        public void setLeituraMesAnterior(double leituraMesAnterior){
            this.leituraMesAnterior = leituraMesAnterior;
        }

        public double getLeituraMesAtual(){
            return leituraMesAtual;
        }

        public void setLeituraMesAtual(double leituraMesAtual){
            this.leituraMesAtual = leituraMesAtual;
        }

        public double getConsumo(){
            return consumo;
        }

        public void setConsumo(double consumo){
            this.consumo = consumo;
        }

        public double getValorSemImposto(){
            return valorSemImposto;
        }

        public void setValorSemImposto(double valorSemImposto){
            this.valorSemImposto = valorSemImposto;
        }

        public virtual double ValorTotalComImposto(){
            return 2.3;
        }
    }
}