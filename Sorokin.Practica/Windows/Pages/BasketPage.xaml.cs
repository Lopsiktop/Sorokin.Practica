using Microsoft.EntityFrameworkCore;
using Sorokin.Practica.Domain;
using Sorokin.Practica.Windows.Elements;
using System.Windows.Controls;

namespace Sorokin.Practica.Windows.Pages
{
    public partial class BasketPage : Page
    {
        public BasketPage()
        {
            InitializeComponent();
        }

        private void Card_Removed(BasketCard card)
        {
            GoodsPanel.Children.Remove(card);
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            GoodsPanel.Children.Clear();
            var context = new AppDbContext();
            var baskets = context.Baskets.Where(x => x.UserId == ShopWindow.user.Id).Include(x => x.Product);
            foreach (var basket in baskets)
            {
                var card = new BasketCard(basket);
                card.Removed += Card_Removed;
                GoodsPanel.Children.Add(card);
            }
        }
    }
}
