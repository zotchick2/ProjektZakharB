using ProjektZakharB.Models;
using System.Linq;
using System.Windows;

namespace ProjektZakharB
{
    public partial class ViewUsersWindow : Window
    {
        private readonly ApplicationDbContext _context;

        public ViewUsersWindow(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
            if (_context == null)
            {
                MessageBox.Show("ApplicationDbContext is null");
            }
            else
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            if (_context == null)
            {
                MessageBox.Show("ApplicationDbContext is null");
                return;
            }

            var users = _context.Users.ToList();
            UsersDataGrid.ItemsSource = users;
        }

    }
}
