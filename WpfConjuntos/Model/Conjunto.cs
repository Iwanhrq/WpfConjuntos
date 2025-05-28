using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfConjuntos
{
    public class Conjunto
    {

        private List<int> elementos;
        private ListBox listBox;
        private const int limite = 5; //mudar para 20


        public Conjunto(ListBox listBox)
        {
            this.listBox = listBox;
            elementos = new List<int>();
        }

        public bool Adicionar(string entrada, out string mensagemErro)
        {
            mensagemErro = null;

            if(!int.TryParse(entrada, out int numero))
            {
                mensagemErro = "Apenas números inteiros podem ser adicionados.";
                return false;
            }

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

        public void LimparConjunto () 
        {
            elementos.Clear();
            listBox.Items.Clear();
        }

        public List<int> ObterElementos()
        {
            return new List<int>(elementos);
        }


    }
}
