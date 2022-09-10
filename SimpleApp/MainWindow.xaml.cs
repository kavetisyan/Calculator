using System;
using System.Collections.Generic;
using System.Data;
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

namespace SimpleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            char labelTextLastItem = '?'; //stands for empty label

            if (textLabel.Text.Length>0)
            {
                labelTextLastItem = textLabel.Text[textLabel.Text.Length - 1];
            }

            bool isOperationButton = (str == "=" || str == "+" ||  str == "/" || str == "*");
            bool isLastItemOperationOrLabelIsEmpty = (labelTextLastItem == '?' || labelTextLastItem == '+' || labelTextLastItem == '-' || labelTextLastItem == '*' || labelTextLastItem == '/');

            if (isOperationButton && isLastItemOperationOrLabelIsEmpty)
            {
                textLabel.Text = textLabel.Text;
            }
            else if (str == "AC")
            {
                textLabel.Text = "";
            }
            else if (str == "=")
            {
                string value = new DataTable().Compute(textLabel.Text,null).ToString();
                textLabel.Text = value;
            }
            else
            {
                textLabel.Text += str;
            }
        }
    }
}
