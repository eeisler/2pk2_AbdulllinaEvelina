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
using System.Text.RegularExpressions;

namespace pz_25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "0";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "1";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "2";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "3";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "4";
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "5";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "6";
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "7";
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "8";
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "9";
        }

        private void buttonPLus_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "+";
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "-";
        }

        private void buttonMult_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "*";
        }

        private void buttonDiv_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "/";
        }

        private void buttonEqual_Click(object sender, RoutedEventArgs e)
        {
            infoTextBox.Text += "=";
            string expression = infoTextBox.Text;
            infoTextBox.Text = Caculation(expression).ToString();
        }

        private double Caculation(string expression)
        {
            //string pattern = @"(\d*(\s([\*\/\-\+])\s)\d*)"; do not work
            double result = 0.0;
            //string[] first = Regex.Split(expression, @"^\d+");
            //string[] second = Regex.Split(expression, @"\s(\d+)");
            //string[] oprtr = Regex.Split(expression, @"[\*\/\-\+]");
            string[] first = Regex.Split(expression, @"(\s([\*\/\-\+])\s)");
            string[] second = Regex.Split(expression, @"\s(\d+)");
            string[] oprtr = Regex.Split(expression, @"[\*\/\-\+]");
            double firstOperand = Convert.ToDouble(first[0]);
            double secondOperand = Convert.ToDouble(second[0]);
            char operation = Convert.ToChar(oprtr[0]);

            switch (operation)
            {
                case '+':
                    result = firstOperand + secondOperand;
                    break;
                case '-':
                    result = firstOperand - secondOperand;
                    break;
                case '*':
                    result = firstOperand * secondOperand;
                    break;
                case '/':
                    result = firstOperand / secondOperand;
                    break;
            }
            return result;
        }
    }
}
