using System.Windows.Controls;
using CryptoInfo.ViewModels;

namespace CryptoInfo.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Top10Crypto.xaml
    /// </summary>
    public partial class Top10Crypto : Page
    {
        public Top10Crypto(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
