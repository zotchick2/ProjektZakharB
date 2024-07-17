using ProjektZakharB.Models;
using System.Windows;


namespace ProjektZakharB
{
    public partial class AddUserWindow : Window
    {
        private readonly ApplicationDbContext _context;

        public AddUserWindow(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Email = EmailTextBox.Text,
                PasswordHash = PasswordBox.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            MessageBox.Show("User added successfully!");
            Close();
        }
    }
}
