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
                    MessageBox.Show("User deleted successfully!");
                    Close();
                }
                else
                {
                    MessageBox.Show("The user with the specified ID was not found.");
                }
            }
            else
            {
                MessageBox.Show("Enter the correct user ID.");
            }
        }

    }
}
