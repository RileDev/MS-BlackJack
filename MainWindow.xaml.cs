using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _playerScore;
        private int _botScore;
        private int _playersCombinations = 0;
        private int _botsCombinations = 0;

        private MediaPlayer _player;
        private User _user;

        private Random _rand;

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
            Init();
        }

        private void Init()
        {
            _user = new User(UserLogin.Username.ToString());
            playerName.Content = _user.Username;

            _player = new MediaPlayer();
            _rand = new Random();
        }

        private void StartNewGame()
        {
            _playersCombinations = 0;
            _botsCombinations = 0;

            playerScore.Content = _playerScore;
            botScore.Content = _botScore;

            playerCombinations.Content = _playersCombinations;
            botCombinations.Content = _botsCombinations;

            btnHit.IsEnabled = true;
            btnStand.IsEnabled = true;

            playerCards.Children.Clear();
            botCards.Children.Clear();

            playerName.Foreground = new SolidColorBrush(Colors.Black);
            botName.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            int playerPick = _rand.Next(1, 15);
            _playersCombinations += playerPick;

            GenerateCards(playerPick, playerCards);

            _player.Open(new Uri(@"file:C:\Users\Rile\source\repos\BlackJack\swish.m4a"));
            _player.Play();

            playerCombinations.Content = _playersCombinations;

            _player.MediaEnded += _player_MediaEnded;
        }

        private void _player_MediaEnded(object sender, EventArgs e)
        {
            _player.Close();
        }

        private void DisplayWinner(int playerCombinations, int botCombinations)
        {
            if (playerCombinations > 21 && botCombinations > 21) return;

            if(playerCombinations == 21 && botCombinations == 21
                || playerCombinations == botCombinations)
            {
                MessageBox.Show("Tie!", "Tying is better than losing!");
            }
            else if(playerCombinations <= 21 && botCombinations > 21 ||
                playerCombinations > botCombinations && playerCombinations <= 21)
            {
                playerName.Foreground = new SolidColorBrush(Colors.Green);
                botName.Foreground = new SolidColorBrush(Colors.Red);
                _playerScore++;
                playerScore.Content = _playerScore;
                MessageBox.Show("You won!", "Congratulations :)");
            }
            else if(playerCombinations > 21 || botCombinations < 21
                && botCombinations <= 21 || playerCombinations < botCombinations)
            {
                playerName.Foreground = new SolidColorBrush(Colors.Red);
                botName.Foreground = new SolidColorBrush(Colors.Green);
                _botScore++;
                botScore.Content = _botScore;
                MessageBox.Show("You lost", "Good luck next time!");
            }

            UpdateList();

        }

        private void UpdateList()
        {
            string directoryPath = Directory.GetCurrentDirectory() + @"\results.txt";
            if (!File.Exists(directoryPath))
            {
                File.Create(directoryPath);
            }

            using(StreamWriter sw = new StreamWriter(directoryPath, true))
            {
                sw.WriteLine($"{UserLogin.Username}/{_playerScore}/Bot/{_botScore}/{DateTime.Now}");
            }
        }

        private void GenerateCards(int picks, WrapPanel wrapPanel)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri($@"file:C:\Users\Rile\source\repos\BlackJack\{picks}.png"));
            img.Width = 80;
            img.Margin = new Thickness(10);
            wrapPanel.Children.Add(img);
        }

        async private void btnStand_Click(object sender, RoutedEventArgs e)
        {

            btnStand.IsEnabled = false;

            int botPick = 0;
            while (_botsCombinations < 16)
            {
                await Task.Delay(1000);

                botPick = _rand.Next(1, 15);
                _botsCombinations += botPick;

                GenerateCards(botPick, botCards);
                _player.Open(new Uri(@"file:C:\Users\Rile\source\repos\BlackJack\swish.m4a"));
                _player.Play();

                botCombinations.Content = _botsCombinations;

                if (_botsCombinations >= 16 || _botsCombinations >= 21)
                {
                    DisplayWinner(_playersCombinations, _botsCombinations);
                    btnStand.IsEnabled = false;
                    btnHit.IsEnabled = false;
                }
                _player.MediaEnded += _player_MediaEnded;

            }
        }

        private void btnDeal_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

    }
}
