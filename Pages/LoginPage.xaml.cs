using ComputerShop.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ComputerShop.Pages
{
    public partial class LoginPage : Page
    {
        private Frame _mainFrame;
        ISqlStatement sqlStatement = new ComputerTable();

        public LoginPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Kérem töltse ki a mezőket!");
                return;
            }

            string result = sqlStatement.GetData(username, password).ToString();

            if (result == "Nincs regisztrálva")
            {
                MessageBoxResult answer = MessageBox.Show("A felhasználó nem regisztrált. Szeretnél regisztrálni?", "Regisztráció", MessageBoxButton.YesNo);
                if (answer == MessageBoxResult.Yes)
                {
                    _mainFrame.Navigate(new RegistrationPage());
                }
            }
            else
            {
                MessageBox.Show(result);
                _mainFrame.Navigate(new CrudPage());
            }
        }

    }
}
