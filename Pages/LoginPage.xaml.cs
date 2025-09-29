using System.Windows;
using System.Windows.Controls;

namespace ComputerShop.Pages
{
    public partial class LoginPage : Page
    {
        private Frame _mainFrame;

        public LoginPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                _mainFrame.Navigate(new RegistrationPage());
            }
            else
            {
                MessageBox.Show("Kérlek, töltsd ki a mezőket!");
            }
        }
    }
}
