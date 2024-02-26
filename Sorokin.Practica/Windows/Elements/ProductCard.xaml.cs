using Microsoft.EntityFrameworkCore;
using Sorokin.Practica.Application.Utils;
using Sorokin.Practica.Domain;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sorokin.Practica.Windows.Elements
{
    public partial class ProductCard : UserControl
    {
        private readonly int _productId;

        public ProductCard(Product product)
        {
            InitializeComponent();

            _productId = product.Id;

            RealPriceBox.Text = product.RealPrice.ToString() + "₽";
            FakePriceBox.Text = product.FakePrice.ToString() + "₽";

            ProviderBox.Text = product.Provider;
            NameBox.Text = product.Name;

            RatingBox.Text = product.Rating.ToString();
            VotesAmountBox.Text = product.VoteAmount.ToString() + " оценок";

            ImageBox.ImageSource = new BitmapImage(new Uri(ImageSaver.GetFullPath(product.PhotoPath), UriKind.Absolute));
        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Main.Background = Brushes.White;
            ShadowEffect.Opacity = 0.3;
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Main.Background = Brushes.Transparent;
            ShadowEffect.Opacity = 0;
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var context = new AppDbContext();
            var exists = await context.Baskets.SingleOrDefaultAsync(x => x.UserId == ShopWindow.user.Id && x.ProductId == _productId);
            if(exists != null)
            {
                MessageBox.Show("Данный товар уже в корзине!");
                btn.Style = FindResource("MaterialDesignOutlinedButton") as Style;
                btn.Content = "В корзине";
                return;
            }
            var basket = new Basket()
            {
                UserId = ShopWindow.user.Id,
                ProductId = _productId,
                Amount = 1
            };
            await context.Baskets.AddAsync(basket);
            await context.SaveChangesAsync();

            btn.Style = FindResource("MaterialDesignOutlinedButton") as Style;
            btn.Content = "В корзине";
        }
    }
}
