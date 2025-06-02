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
using WpfConjuntos.Model;



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
        private void btn_addConjuntoA_Click(object sender, RoutedEventArgs e)
        {
            try
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

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar no conjunto A: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btn_removeElementoA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string entrada = txt_numA.Text.Trim();

                if (string.IsNullOrEmpty(entrada))
                {
                    MessageBox.Show("Digite um valor antes de tentar remover.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (conjuntoA.RemoverElemento(entrada, out string erro))
                    {
                        txt_numA.Clear();
                    }

                    else
                    {
                        MessageBox.Show(erro, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover do conjunto A: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_limparA_Click(object sender, RoutedEventArgs e)
        {
            conjuntoA.LimparConjunto();
        }

        private void btn_randomA_Click(object sender, RoutedEventArgs e)
        {
            conjuntoA.addAleatorios();

        }


        // Conjunto B
        private void btn_addConjuntoB_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao adicionar no conjunto B: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void btn_removeElementoB_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string entrada = txt_numB.Text.Trim();

                if (string.IsNullOrEmpty(entrada))
                {
                    MessageBox.Show("Digite um valor antes de tentar remover.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (conjuntoB.RemoverElemento(entrada, out string erro))
                    {
                        txt_numB.Clear();
                    }
                    else
                    {
                        MessageBox.Show(erro, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover do conjunto B: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_limparB_Click(object sender, RoutedEventArgs e)
        {
            conjuntoB.LimparConjunto();
        }

        private void btn_randomB_Click(object sender, RoutedEventArgs e)
        {
            conjuntoB.addAleatorios();
        }



        // Operações
        private void Uniao_Click(object sender, RoutedEventArgs e)
        {
            var resultado = Operacoes.Uniao(conjuntoA.ObterElementos(), conjuntoB.ObterElementos())
                                        .OrderBy(x => x);
            txt_Resultado.Text = "A ∪ B \n{" + string.Join(", ", resultado) + "}";
        }

        private void Interseccao_Click(object sender, RoutedEventArgs e)
        {
            var resultado = Operacoes.Interseccao(conjuntoA.ObterElementos(), conjuntoB.ObterElementos())
                                                 .OrderBy(x => x);
            txt_Resultado.Text = "A ∩ B \n{" + string.Join(", ", resultado) + "}";
        }

        private void DiferencaAB_Click(object sender, RoutedEventArgs e)
        {
            var resultado = Operacoes.DiferencaAB(conjuntoA.ObterElementos(), conjuntoB.ObterElementos())
                                            .OrderBy(x => x);
            txt_Resultado.Text = "A - B \n{" + string.Join(", ", resultado) + "}";
        }

        private void DiferençaBA_Click(object sender, RoutedEventArgs e)
        {
            var resultado = Operacoes.DiferencaBA(conjuntoA.ObterElementos(), conjuntoB.ObterElementos())
                                            .OrderBy(x => x);
            txt_Resultado.Text = "B - A \n{" + string.Join(", ", resultado) + "}";
        }



    }
}
