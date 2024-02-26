using Sorokin.Practica.Domain;
using Sorokin.Practica.Windows.Elements;
using System.Windows.Controls;

namespace Sorokin.Practica.Windows.Pages
{
    public partial class ShopPage : Page
    {

        public ShopPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            GoodsPanel.Children.Clear();
            var context = new AppDbContext();
            foreach (var product in context.Products)
            {
                GoodsPanel.Children.Add(new ProductCard(product));
            }
        }
    }
}
