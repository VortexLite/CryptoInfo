using System.Windows.Controls;
using CryptoInfo.ViewModels;

namespace CryptoInfo.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Market.xaml
    /// </summary>
    public partial class Market : Page
    {
        public Market(MarketViewModel marketViewModel)
        {
            InitializeComponent();
            DataContext = marketViewModel;
        }
    }
}
