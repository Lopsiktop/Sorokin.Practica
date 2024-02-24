using Sorokin.Practica.Domain;
using Sorokin.Practica.Windows.Pages;
using System.ComponentModel;
using System.Windows;

namespace Sorokin.Practica.Windows
{
    public partial class ShopWindow : Window
    {
        private readonly User _user;

        public ShopWindow(User user)
        {
            InitializeComponent();

            _user = user;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Owner.Close();
        }

        private void ShopPageClick(object sender, RoutedEventArgs e)
        {
            var page = new ShopPage();
            MainFrame.Navigate(page);
        }
    }
}
