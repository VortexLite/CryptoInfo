using System.Windows.Controls;
using System.Windows.Input;
using CryptoInfo.Models;
using CryptoInfo.ViewModels;

namespace CryptoInfo.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Top10Crypto.xaml
    /// </summary>
    public partial class Top10Crypto : Page
    {
        public InfoCoinViewModel InfoCoinViewModel;
        public Top10Crypto(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            InfoCoinViewModel = new InfoCoinViewModel();
        }

        private void Top10CryptoCoin_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Top10CryptoCoin.SelectedItem is CryptoData selectedCrypto)
            {
                InfoCoinViewModel.GetData(selectedCrypto._NameCoin);
                var MainFrame = MainWindow.GetMainFrame();
                MainFrame.Content = new InfoCoin{ DataContext = InfoCoinViewModel };
            }
        }
    }
}
