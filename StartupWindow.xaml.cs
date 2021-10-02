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
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.ShowDialog();
            if (!String.IsNullOrEmpty(UserLogin.Username))
            {
                LoginUser(userLogin);
            }
        }

        private void LoginUser(UserLogin userLogin)
        {
            loginInfo.Content = $"Logged as {UserLogin.Username}";
            btnPlay.IsEnabled = true;
            btnLogin.IsEnabled = false;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            UserStats userStats = new UserStats();
            userStats.ShowDialog();
        }
    }
}
