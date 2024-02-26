using Sorokin.Practica.Domain;
using System.Windows.Controls;
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
            VotesAmountBox.Text = product.VoteAmount.ToString();

            ImageBox.ImageSource = new BitmapImage(new Uri(product.PhotoPath, UriKind.Relative));
        }
    }
}
