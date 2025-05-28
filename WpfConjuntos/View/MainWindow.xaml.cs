using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfConjuntos
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private Conjunto conjuntoA;
        private Conjunto conjuntoB;


        public MainWindow()
        {
            InitializeComponent();
            conjuntoA = new Conjunto(listA);
            conjuntoB = new Conjunto(listB);
        }

      
        // Conjunto A
        private void addConjuntoA_Click(object sender, RoutedEventArgs e)
        {
            string entrada = txt_numA.Text.Trim(); 
            // .Trim serve para remover espaços em branco no ínicio ou no final do texto
            // serve para caso o usuário insira um numero e um espaço a mais.  Ex: "89 "

            if (!string.IsNullOrEmpty(entrada))
            {
                if (conjuntoA.Adicionar(entrada, out string erro))
                {
                    txt_numA.Clear();
                }
                else
                {
                    MessageBox.Show(erro, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void limparA_Click(object sender, RoutedEventArgs e)
        {
            conjuntoA.LimparConjunto();
        }


        private void removeConjuntoA_Click(object sender, RoutedEventArgs e)
        {

        }









        // Conjunto B
        private void addConjuntoB_Click(object sender, RoutedEventArgs e)
        {
            string entrada = txt_numB.Text.Trim(); 

            if (!string.IsNullOrEmpty(entrada))
            {
                if (conjuntoB.Adicionar(entrada, out string erro))
                {
                    txt_numB.Clear();
                }
                else
                {
                    MessageBox.Show(erro, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void limparB_Click(object sender, RoutedEventArgs e)
        {
            conjuntoB.LimparConjunto();
        }




        private void removeConjuntoB_Click(object sender, RoutedEventArgs e)
        {

        }





        // Operações
        private void Uniao_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Interseccao_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DiferencaAB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DiferençaBA_Click(object sender, RoutedEventArgs e)
        {

        }

       

       


        //remover depois
        private void addConjuntoA_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void removeConjuntoB_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
