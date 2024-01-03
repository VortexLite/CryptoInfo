using System.Windows;
using System.Windows.Input;
using CryptoInfo.Models;
using CryptoInfo.ViewModels;
using CryptoInfo.Views.Pages;

namespace CryptoInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel mainViewModel;
        public Top10Crypto top10CryptoPage;
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            top10CryptoPage = new Top10Crypto(mainViewModel);
            MainFrame.Content = top10CryptoPage;
        }
        //Тригер на тискання по пошуку і видалення слова
        private void SearchTextBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchTextBox.Text == "Пошук")
            {
                SearchTextBox.Text = string.Empty;
            }
            
            SearchTextBox.Focus();
            mainViewModel.PerformSearch(SearchTextBox.Text);
        }

        private void SearchTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            mainViewModel.PerformSearch(SearchTextBox.Text);
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Пошук";
            }
        }

        private void GetMarketData_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is Top10Crypto top10CryptoPage)
            {
                if (top10CryptoPage.Top10CryptoCoin.SelectedItem is CryptoData selectedCrypto)
                {
                    var marketViewModel = new MarketViewModel();
                    marketViewModel.GetData(selectedCrypto._NameCoin);
                    MainFrame.Content = new Market(marketViewModel);
                }
            }
        }

        private void ViewTop10Crypto(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = top10CryptoPage;
        }
    }
}