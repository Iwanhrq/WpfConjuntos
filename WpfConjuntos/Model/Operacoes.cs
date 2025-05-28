using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfConjuntos.Model
{
    public static class Operacoes
    {

        //Uniao A e B
        public static List<int> Uniao(List<int> A, List<int> B)
        {
            return A.Union(B).ToList();
        }


        // Interseção A ∩eB
        public static List<int> Interseccao(List<int> A, List<int> B)
        {
            return A.Intersect(B).ToList();
        }


        // Diferença AB
        public static List<int> DiferencaAB(List<int> A, List<int> B)
        {
            return A.Except(B).ToList();
        }


        // Diferença BA
        public static List<int> DiferencaBA(List<int> A, List<int> B)
        {
            return B.Except(A).ToList();
        }

    }
}
