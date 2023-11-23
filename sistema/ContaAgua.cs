using System;

namespace TrabalhoFinalPOO.sistema
{
    public class ContaAgua : Conta
    {

        private double tarifaAgua = 0;
        private double tarifaEsgoto = 0;

        private double imposto = 1.03;

        private double ValorTotal = 0;

        public ContaAgua(string tipoImovel, double leituraMesAnterior, double leituraMesAtual) : base()
        {
            this.tipoImovel = tipoImovel;
            this.leituraMesAnterior = leituraMesAnterior;
            this.leituraMesAtual = leituraMesAtual;
            consumo = this.leituraMesAtual - this.leituraMesAnterior;
        }

        public override double ValorTotalComImposto()
        {
            switch (tipoImovel)
            {
                case "RESIDENCIAL":
                    double aux = consumo;
                    double consumoFinalAgua = 0;
                    double consumoFinalEsgoto = 0;
                    double count = 0;
                    if (aux >= 6)
                    {

                        if (aux >= 10)
                        {
                            tarifaAgua = 2.241;
                            tarifaEsgoto = 1.122;
                            consumoFinalAgua += tarifaAgua * 10;
                            consumoFinalEsgoto += tarifaEsgoto * 10;
                            count += 10;
                        }
                        else
                        {
                            tarifaAgua = 2.241;
                            tarifaEsgoto = 1.122;
                            consumoFinalAgua += aux * tarifaAgua;
                            consumoFinalEsgoto += aux * tarifaEsgoto;
                            count = aux;
                        }
                        if (aux - count > 0)
                        {

                            if (aux - count >= 10)
                            {
                                tarifaAgua = 5.447;
                                tarifaEsgoto = 2.724;
                                consumoFinalAgua += tarifaAgua * 5;
                                consumoFinalEsgoto += tarifaEsgoto * 5;
                                count += 5;
                            }
                            else
                            {
                                tarifaAgua = 5.447;
                                tarifaEsgoto = 2.724;
                                consumoFinalAgua += (aux - count) * tarifaAgua;
                                consumoFinalEsgoto += (aux - count) * tarifaEsgoto;
                                count = aux;
                            }
                        }
                        if (aux - count > 0)
                        {
                            if (aux - count >= 15)
                            {
                                tarifaAgua = 5.461;
                                tarifaEsgoto = 2.731;
                                consumoFinalAgua += tarifaAgua * 5;
                                consumoFinalEsgoto += tarifaEsgoto * 5;
                                count += 5;
                            }
                            else
                            {
                                tarifaAgua = 5.461;
                                tarifaEsgoto = 2.731;
                                consumoFinalAgua += (aux - count) * tarifaAgua;
                                consumoFinalEsgoto += (aux - count) * tarifaEsgoto;
                                count = aux;
                            }
                        }
                        if (aux - count > 0)
                        {
                            if (aux - count >= 20)
                            {
                                tarifaAgua = 5.487;
                                tarifaEsgoto = 2.744;
                                consumoFinalAgua = +tarifaAgua * 20;
                                consumoFinalEsgoto = +tarifaEsgoto * 20;
                                count += 20;
                            }
                            else
                            {
                                tarifaAgua = 5.487;
                                tarifaEsgoto = 2.744;
                                consumoFinalAgua += (aux - count) * tarifaAgua;
                                consumoFinalEsgoto += (aux - count) * tarifaEsgoto;
                                count = aux;
                            }
                        }

                        if (aux - count > 0)
                        {
                            tarifaAgua = 10.066;
                            tarifaEsgoto = 5.035;
                            consumoFinalAgua += (aux - count) * tarifaAgua;
                            consumoFinalEsgoto += (aux - count) * tarifaEsgoto;
                        }

                    }
                    else
                    {
                        tarifaAgua = 10.08;
                        tarifaEsgoto = 5.05;
                    }
                    valorSemImposto = tarifaAgua + tarifaEsgoto;
                    return valorSemImposto *= imposto; // Talvez Trocar

                case "COMERCIAL":
                    aux = consumo;
                    consumoFinalAgua = 0;
                    consumoFinalEsgoto = 0;
                    count = 0;
                    if (aux >= 6)
                    {
                        if (aux >= 10)
                        {
                            tarifaAgua = 4.299;
                            tarifaEsgoto = 2.149;
                            consumoFinalAgua += tarifaAgua * 10;
                            consumoFinalEsgoto += tarifaEsgoto * 10;
                            count += 10;
                        }
                        else
                        {
                            tarifaAgua = 4.299;
                            tarifaEsgoto = 2.149;
                            consumoFinalAgua += aux * tarifaAgua;
                            consumoFinalEsgoto += aux * tarifaEsgoto;
                            count = aux;
                        }
                        if (aux - count > 0)
                        {

                            if (aux - count >= 10)
                            {
                                tarifaAgua = 8.221;
                                tarifaEsgoto = 4.111;
                                consumoFinalAgua += tarifaAgua * 30;
                                consumoFinalEsgoto += tarifaEsgoto * 30;
                                count += 30;
                            }
                            else
                            {
                                tarifaAgua = 8.221;
                                tarifaEsgoto = 4.111;
                                consumoFinalAgua += (aux - count) * tarifaAgua;
                                consumoFinalEsgoto += (aux - count) * tarifaEsgoto;
                                count = aux;
                            }
                        }
                        if (aux - count > 0)
                        {
                            if (aux - count >= 40)
                            {
                                tarifaAgua = 8.288;
                                tarifaEsgoto = 4.144;
                                consumoFinalAgua += tarifaAgua * 60;
                                consumoFinalEsgoto += tarifaEsgoto * 60;
                                count += 60;
                            }
                            else
                            {
                                tarifaAgua = 8.288;
                                tarifaEsgoto = 4.144;
                                consumoFinalAgua += (aux - count) * tarifaAgua;
                                consumoFinalEsgoto += (aux - count) * tarifaEsgoto;
                                count = aux;
                            }
                        }

                        if (aux - count > 0)
                        {
                            tarifaAgua = 8.329;
                            tarifaEsgoto = 4.165;
                            consumoFinalAgua += (aux - count) * tarifaAgua;
                            consumoFinalEsgoto += (aux - count) * tarifaEsgoto;
                        }
                    }
                    else
                    {
                        tarifaAgua = 25.79;
                        tarifaEsgoto = 12.90;
                    }
                    valorSemImposto = tarifaAgua + tarifaEsgoto;
                    return valorSemImposto *= imposto; // Talvez Trocar



                default:
                    throw new Exception("Teste");
            }
        }
    }
}