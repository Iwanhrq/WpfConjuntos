using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfConjuntos
{
    public class Conjunto
    {

        private List<int> elementos;
        private ListBox listBox;
        private const int limite = 20; //limite de elementos por conjunto



        public Conjunto(ListBox listBox)
        {
            this.listBox = listBox;
            elementos = new List<int>();
        }


        //Adicionar um número ao conjunto
        public bool Adicionar(string entrada, out string mensagemErro)
        {
            mensagemErro = null;

            //se o numero não for inteiro
            if (!int.TryParse(entrada, out int numero))
            {
                mensagemErro = "Apenas números inteiros podem ser adicionados.";
                return false;
            }

            if (elementos.Contains(numero)) //verifica se o numero já existe no conjunto
            {
                mensagemErro = "O número já existe no conjunto.";
                return false;
            }

            //verificar se o conjunto já atingiu o limite
            if (elementos.Count >= limite)
            {
                mensagemErro = "Limite máximo de " + limite + " elementos atingidos.";
                return false;
            }

            // Adiciona e atualiza a ListBox
            elementos.Add(numero);
            listBox.Items.Add(numero);
            return true;
        }



        public bool LimparConjunto()
        {
            if (elementos.Count == 0)
            {
                return false; // já está vazio
            }

            elementos.Clear();
            listBox.Items.Clear();
            return true;
        }



        public bool RemoverElemento(string entrada, out string mensagemErro)
        {
            mensagemErro = null;


            if (int.TryParse(entrada, out int numero)) //confere se é numero inteiro
            {
                if (elementos.Contains(numero)) //verifica se o numero está na lista
                {

                    elementos.Remove(numero);

                    foreach (var item in listBox.Items)
                    {
                        if (item.ToString() == numero.ToString())
                        {
                            listBox.Items.Remove(item);
                            break;
                        }
                    }

                    return true;
                }

                else
                {
                    mensagemErro = "O número não existe no conjunto.";
                    return false;
                }
            }
            else
            {
                mensagemErro = "Digite um número inteiro válido para remover.";
                return false;
            }
        }



        public void addAleatorios()
        {
            Random random = new Random(); //gerador de numeros aleatórios
            int adicionados = 0;


            for (int i = 0; i < 20; i++)
            {
                if (elementos.Count >= limite) //quando atinge a quantidadeAleatoria (quantidade de numeros), ele para de adicionar
                {
                    break;
                }

                int numero;

                //garante que não repete número já existente
                do
                {
                    numero = random.Next(1, 101); //gera um numero entre 1 e 100
                }
                while (elementos.Contains(numero));


                elementos.Add(numero);
                listBox.Items.Add(numero);
                adicionados++;


            }


            // Primeiro mostra quantos foram adicionados (se algum)
            if (adicionados > 0)
            {
                MessageBox.Show($"Adicionados {adicionados} número(s) aleatório(s) ao conjunto.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Depois avisa se atingiu o limite
            if (elementos.Count >= limite)
            {
                MessageBox.Show("O conjunto atingiu o limite de 20 elementos.", "Limite atingido", MessageBoxButton.OK, MessageBoxImage.Warning);
            }



        }


        public List<int> ObterElementos()
        {
            return new List<int>(elementos);
        }


    }
}
