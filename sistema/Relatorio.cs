using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalPOO.sistema
{
    public class Relatorio
    {
        private List<ContaLuz> contasDeLuz;
        private List<ContaAgua> contasDeAgua;

        public Relatorio(List<ContaLuz> contasDeLuz, List<ContaAgua> contasDeAgua)
        {
            this.contasDeLuz = contasDeLuz;
            this.contasDeAgua = contasDeAgua;
        }

        public void EscreverContasNoArquivo(string nomeArquivo)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nomeArquivo))
                {
                    sw.WriteLine("=== RELATÓRIO DE CONTAS ===");

                    sw.WriteLine("\n--- CONTAS DE LUZ ---");
                    foreach (ContaLuz contaLuz in contasDeLuz)
                    {
                        sw.WriteLine(contaLuz.ToString());
                    }

                    sw.WriteLine("\n--- CONTAS DE ÁGUA ---");
                    foreach (ContaAgua contaAgua in contasDeAgua)
                    {
                        sw.WriteLine(contaAgua.ToString());
                    }

                    Console.WriteLine($"Relatório gerado com sucesso. Salvo em {nomeArquivo}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar relatório: {ex.Message}");
            }
        }


        public double ValorTotalContas(ContaLuz contaLuz, ContaAgua contaAgua)
        {
            double ValorTotalContas = contaLuz.ValorTotalComImposto() + contaAgua.ValorTotalComImposto();
            return ValorTotalContas;
        }


        public double ValorTotalContasSemImposto(ContaLuz contaLuz, ContaAgua contaAgua)
        {
            double ValorTotalSemImposto = contaLuz.getValorSemImposto() + contaAgua.getValorSemImposto();
            return ValorTotalSemImposto;
        }

    }
}