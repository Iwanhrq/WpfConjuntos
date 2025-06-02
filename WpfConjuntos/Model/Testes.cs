using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfConjuntos.Model
{
    internal class Testes
    {
        public List<string> RunAllTests()
        {
            var resultados = new List<string>();

            // 1. Criar conjuntos
            var conjunto = new ConjuntoFake();
            resultados.Add("Criando conjunto vazio...");

            // 2. Testar adição de elementos
            string erro;
            bool adicionou;

            adicionou = conjunto.Adicionar("5", out erro);
            resultados.Add(adicionou ? "Adicionado elemento 5." : "Falha ao adicionar 5: " + erro);

            adicionou = conjunto.Adicionar("10", out erro);
            resultados.Add(adicionou ? "Adicionado elemento 10." : "Falha ao adicionar 10: " + erro);

            // Tentar adicionar duplicado
            adicionou = conjunto.Adicionar("5", out erro);
            resultados.Add(adicionou ? "Adicionado elemento 5." : "Falha ao adicionar 5 duplicado: " + erro);

            // 3. Remover elementos
            bool removeu = conjunto.RemoverElemento("5", out erro);
            resultados.Add(removeu ? "Removido elemento 5." : "Falha ao remover 5: " + erro);

            removeu = conjunto.RemoverElemento("7", out erro);
            resultados.Add(removeu ? "Removido elemento 7." : "Falha ao remover 7 (não existe): " + erro);

            // 4. Operações matemáticas
            var conjuntoA = new List<int> { 1, 2, 3 };
            var conjuntoB = new List<int> { 3, 4, 5 };

            resultados.Add($"Criando Conjunto A: {{{string.Join(", ", conjuntoA)}}}");
            resultados.Add($"Criando Conjunto B: {{{string.Join(", ", conjuntoB)}}}");


            var uniao = Operacoes.Uniao(conjuntoA, conjuntoB);
            resultados.Add($"União: {{{string.Join(", ", uniao)}}}"); // esperado {1,2,3,4,5}

            var intersec = Operacoes.Interseccao(conjuntoA, conjuntoB);
            resultados.Add($"Interseção: {{{string.Join(", ", intersec)}}}"); // esperado {3}

            var diffAB = Operacoes.DiferencaAB(conjuntoA, conjuntoB);
            resultados.Add($"Diferença A-B: {{{string.Join(", ", diffAB)}}}"); // esperado {1,2}

            var diffBA = Operacoes.DiferencaBA(conjuntoA, conjuntoB);
            resultados.Add($"Diferença B-A: {{{string.Join(", ", diffBA)}}}"); // esperado {4,5}

            // 5. Validação entradas
            adicionou = conjunto.Adicionar("abc", out erro);
            resultados.Add(adicionou ? "Adicionado elemento 'abc'." : "Falha ao adicionar 'abc': " + erro);

            resultados.Add("✅ Todos os testes foram executados com sucesso.");

            return resultados;
        }

        // Para evitar acoplar os testes com a UI (ListBox), fazemos uma versão fake do Conjunto
        private class ConjuntoFake
        {
            private List<int> elementos = new List<int>();
            private const int limite = 20;

            public bool Adicionar(string entrada, out string mensagemErro)
            {
                mensagemErro = null;
                if (!int.TryParse(entrada, out int numero))
                {
                    mensagemErro = "Apenas números inteiros podem ser adicionados.";
                    return false;
                }

                if (elementos.Contains(numero))
                {
                    mensagemErro = "O número já existe no conjunto.";
                    return false;
                }

                if (elementos.Count >= limite)
                {
                    mensagemErro = "Limite máximo de 20 elementos atingidos.";
                    return false;
                }

                elementos.Add(numero);
                return true;
            }

            public bool RemoverElemento(string entrada, out string mensagemErro)
            {
                mensagemErro = null;
                if (!int.TryParse(entrada, out int numero))
                {
                    mensagemErro = "Digite um número inteiro válido para remover.";
                    return false;
                }

                if (!elementos.Contains(numero))
                {
                    mensagemErro = "O número não existe no conjunto.";
                    return false;
                }

                elementos.Remove(numero);
                return true;
            }
        }
    }
}
