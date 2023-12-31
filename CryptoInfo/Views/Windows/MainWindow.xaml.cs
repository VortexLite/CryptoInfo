using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptoInfo.ViewModels;
using CryptoInfo.Views.Pages;

namespace CryptoInfo
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
        //Тригер на тискання по пошуку і видалення слова
        private void SearchTextBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchTextBox.Text == "Пошук")
            {
                SearchTextBox.Text = string.Empty;
            }
            
            SearchTextBox.Focus();
        }

        private void SearchTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Пошук";
            }
        }
    }
}