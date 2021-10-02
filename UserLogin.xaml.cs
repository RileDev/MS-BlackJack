using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        private User _user;
        private static string _username;
        public static string Username
        {
            get
            {
                return _username;
            }
        }

        public UserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string formUsername = txtUsername.Text.Trim();
            _user = new User(formUsername);
            bool isValid = validateUsername(formUsername);
            if (isValid)
            {
                _username = formUsername;
                _user.Username = _username;
                MessageBox.Show($"You've successfully logged in as {_username}");
                this.Close();
            }
        }

        private bool validateUsername(string username)
        {
            bool valid = true;

            if (String.IsNullOrEmpty(username) || username.Length < 3)
            {
                valid = false;
            }

            return valid;
        }
    }
}
