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
            if (username != "" && password != "") {
                MessageBox.Show(sqlStatement.GetData(username, password).ToString());
                _mainFrame.Navigate(new CrudPage());
            }
            else if(sqlStatement.GetData(username, password).ToString() == "Nincs regisztrálva")
            {
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBox.Show($"Navigálás a regisztrációhoz: {buttons}");
                _mainFrame.Navigate(new RegistrationPage());
            }
            else if(username == "" && password == "")
            {
                MessageBox.Show("Kérem töltse ki a mezőket!");
            }

        }
    }
}
