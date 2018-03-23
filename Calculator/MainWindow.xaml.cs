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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char[] action = { '*', '/', '+', '-' };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Symbol_click(object sender, RoutedEventArgs e)
        {
            string symbol = (sender as Button).Content.ToString();
            switch (symbol)
            {
                case "±":
                    break;
                case "⟵":
                    Input_line.Text = Input_line.Text.Remove(Input_line.Text.Length - 1, 1);
                    break;
                default:
                    Input_line.Text += (sender as Button).Content;
                    break;
            }                
        }
        private void Input_line_TextChanged(object sender, TextChangedEventArgs e)
        {
            Answer_line.Text = Calculate.compute(Input_line.Text);
        }
    }
}
