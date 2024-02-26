using Sorokin.Practica.Domain;
using Sorokin.Practica.Windows.Pages;
using Sorokin.Practica.Windows.Utils;
using System.ComponentModel;
using System.Windows;

namespace Sorokin.Practica.Windows
{
    public partial class ShopWindow : Window
    {
        public static User user;
        private PageSwitcher _switcher;

        public ShopWindow(User _user)
        {
            InitializeComponent();

            user = _user;
            _switcher = new PageSwitcher(MainFrame);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Owner.Close();
        }

        private void ShopPageClick(object sender, RoutedEventArgs e)
        {
            _switcher.ShowPage<ShopPage>();
        }
    }
}
