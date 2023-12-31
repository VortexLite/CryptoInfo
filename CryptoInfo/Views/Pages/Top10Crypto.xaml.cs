using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using CryptoInfo.Models;
using CryptoInfo.ViewModels;

namespace CryptoInfo.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Top10Crypto.xaml
    /// </summary>
    public partial class Top10Crypto : Page
    {
        public Top10Crypto()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
