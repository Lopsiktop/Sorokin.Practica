using Microsoft.EntityFrameworkCore;
using Sorokin.Practica.Domain;
using System.Windows;

namespace Sorokin.Practica.Windows
{
    public partial class LoginWindow : Window
    {
        public LoginWindow() => InitializeComponent();

        private async void RegisterClick(object sender, RoutedEventArgs e)
        {
            if(rPass.Password != rPassRep.Password)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            var context = new AppDbContext();
            var exists = await context.Users.SingleOrDefaultAsync(x => x.Email == rEmail.Text);
            if(exists != null)
            {
                MessageBox.Show("Такой пользователь уже существует!");
                return;
            }

            var user = new User
            {
                Email = rEmail.Text,
                Password = rPass.Password
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            MessageBox.Show("Регистрация прошла успешно!");
        }

        private async void SignInClick(object sender, RoutedEventArgs e)
        {
            var context = new AppDbContext();
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == sEmail.Text && x.Password == sPass.Password);

            if(user == null)
            {
                MessageBox.Show("Неверная почта или пароль!");
                return;
            }

            var shop = new ShopWindow(user);
            shop.Owner = this;
            shop.Show();
            this.Hide();
        }
    }
}
