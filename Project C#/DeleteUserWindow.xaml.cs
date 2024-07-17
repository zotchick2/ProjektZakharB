using ProjektZakharB.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjektZakharB
{
    public partial class DeleteUserWindow : Window
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserWindow(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(UserIdTextBox.Text, out int userId))
            {
                var user = _context.Users.SingleOrDefault(u => u.UserID == userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Пользователь удален успешно!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с указанным ID не найден.");
                }
            }
            else
            {
                MessageBox.Show("Введите корректный ID пользователя.");
            }
        }

    }
}
