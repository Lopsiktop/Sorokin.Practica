using Sorokin.Practica.Application.Utils;
using Sorokin.Practica.Domain;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sorokin.Practica.Windows.Elements
{
    public partial class BasketCard : UserControl
    {
        public event Action<BasketCard> Removed;
        private readonly Basket _basket;

        public BasketCard(Basket basket)
        {
            InitializeComponent();

            _basket = basket;

            RealPriceBox.Text = (_basket.Product.RealPrice * _basket.Amount).ToString() + "₽";
            FakePriceBox.Text = (_basket.Product.FakePrice * _basket.Amount).ToString() + "₽";

            AmountBox.Text = basket.Amount.ToString();

            CompanyBox.Text = basket.Product.Provider;
            NameBox.Text = basket.Product.Name;

            ImageBox.ImageSource = new BitmapImage(new Uri(ImageSaver.GetFullPath(basket.Product.PhotoPath), UriKind.Absolute));
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Main.Background = Brushes.White;
            ShadowEffect.Opacity = 0.3;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Main.Background = Brushes.Transparent;
            ShadowEffect.Opacity = 0;
        }

        private async Task Refresh()
        {
            AmountBox.Text = _basket.Amount.ToString();

            RealPriceBox.Text = (_basket.Product.RealPrice * _basket.Amount).ToString() + "₽";
            FakePriceBox.Text = (_basket.Product.FakePrice * _basket.Amount).ToString() + "₽";

            using (var context = new AppDbContext())
            {
                context.Baskets.Update(_basket);
                await context.SaveChangesAsync();
            }
        }

        private async void MinusClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_basket.Amount - 1 == 0)
                return;

            _basket.Amount--;

            await Refresh();
        }

        private async void PlusClick(object sender, System.Windows.RoutedEventArgs e)
        {
            _basket.Amount++;

            await Refresh();
        }

        private async void RemoveClick(object sender, System.Windows.RoutedEventArgs e)
        {
            using (var context = new AppDbContext())
            {
                context.Baskets.Remove(_basket);
                await context.SaveChangesAsync();

                Removed.Invoke(this);
            }
        }
    }
}
