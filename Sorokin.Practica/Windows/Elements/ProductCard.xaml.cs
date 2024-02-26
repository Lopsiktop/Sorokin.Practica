using Sorokin.Practica.Application.Utils;
using Sorokin.Practica.Domain;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sorokin.Practica.Windows.Elements
{
    public partial class ProductCard : UserControl
    {
        public ProductCard(Product product)
        {
            InitializeComponent();

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
    }
}
