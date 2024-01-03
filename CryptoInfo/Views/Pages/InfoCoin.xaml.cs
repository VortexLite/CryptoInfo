using System.Windows.Controls;
using CryptoInfo.ViewModels;

namespace CryptoInfo.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoCoin.xaml
    /// </summary>
    public partial class InfoCoin : Page
    {
        public InfoCoin()
        {
            InitializeComponent();
            DataContext = new InfoCoinViewModel();
        }
    }
}
