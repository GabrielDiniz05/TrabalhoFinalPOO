using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalPOO.sistema
{
    public interface Conta
    {
        void LerMesAtual();
        void LerMesAnterior();
        double Consumo();
        double ValorTotal();
    }
}