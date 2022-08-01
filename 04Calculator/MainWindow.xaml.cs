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

namespace _04Calculator
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
        private void onButtonClick(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            txbAnswer.Text = txbAnswer.Text + clicked.Content;

        }

        private void Button_Flush(object sender, RoutedEventArgs e)
        {
            
            txbAnswer.Text = "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = txbAnswer.Text;
            Console.WriteLine(input);
            //Though the Regex Stream considers splitting into alphabets as well, it's not a valid case. I have used it for completeness of the code. 
            //The code can be made more elegant. Below are the steps I performed: 
            //1. Split the input stream of instructions into individual tokens.
            //2. As this array contains null elements, move all non-null values into an enumeration list.
            //3. Convert the enumeration list into a string separated by a white space and split it into an array having white space as delimiter
            //Alternately, the instructions can be processed on the fly instead of trying to process them all at once.
            String[] m = Regex.Split(input, "([0-9]+|[A-Z]+|[/+]+|[-]+|[//]+|[*])");
            var m2 = m.ToArray().Where(item => item.Length > 0);
            string[] m3 = String.Join(" ", m2).Split(' ');
            int number = Int32.Parse(m3[0]);
            for (int i = 1; i < m3.Length; i++)
            {
                //If m3[i] is a number, make it null. If the length of the output is zero, it's a number.
                if (Regex.Replace(m3[i], "[^0-9.]", "").Length > 0)
                {
                    if (m3[i - 1].Contains('+'))
                    {
                        number = number + Int32.Parse(m3[i]);
                    }
                    if (m3[i - 1].Contains('-'))
                    {
                        number = number - Int32.Parse(m3[i]);
                    }
                    if (m3[i - 1].Contains('*'))
                    {
                        number = number * Int32.Parse(m3[i]);
                    }
                    if (m3[i - 1].Contains('/'))
                    {
                        number = number / Int32.Parse(m3[i]);
                    }
                }

            }
            txbAnswer.Text = number.ToString();
        }
    }
}
