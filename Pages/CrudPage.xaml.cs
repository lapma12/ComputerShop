using ComputerShop.Services;
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using System.Windows.Controls; // ha sqlStatement ott van

namespace ComputerShop.Pages
{
    
    public partial class CrudPage : Page
    {
        ISqlStatement sqlStatement = new ComputerTable();
        public CrudPage()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            List<User> users = sqlStatement.GetAllUsers();
            userDataGrid.ItemsSource = users;
        }
    }
}
