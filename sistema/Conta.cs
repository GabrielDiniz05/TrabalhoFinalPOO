using System;

namespace TrabalhoFinalPOO.sistema{
    public abstract class Conta{
        protected string tipoImovel;
        protected double leituraMesAnterior = 0;
        protected double leituraMesAtual = 0;
        protected String nomeMesAtual;
        protected double consumo;
        protected double valorSemImposto = 0;
        protected double total = 0;

        protected int idConsumidor;

        public Conta(){
            
        }

        public String getTipoImovel(){
            return tipoImovel;
        }

        public String getNomeMesAtual(){
            return nomeMesAtual;
        }

        public void setNomeMesAtual(String nomeMesAtual){
            this.nomeMesAtual = nomeMesAtual;
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

        public double getTotal(){
            return total;
        }

        public virtual double ValorTotalComImposto(){
            return 2.3;
        }
    }
}