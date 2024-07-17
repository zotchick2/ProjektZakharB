using ProjektZakharB.Models;
using System;
using System.Windows;

namespace ProjektZakharB
{
    public partial class MainWindow : Window
    {
        private readonly ApplicationDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(ApplicationDbContext context) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUserWindow(_context);
            addUserWindow.Show();
        }

        private void ViewUsers_Click(object sender, RoutedEventArgs e)
        {
            var viewUsersWindow = new ViewUsersWindow(_context);
            viewUsersWindow.Show();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var deleteUserWindow = new DeleteUserWindow(_context);
            deleteUserWindow.Show();
        }

    }
}
