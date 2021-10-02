using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserStats.xaml
    /// </summary>
    public partial class UserStats : Window
    {
        
        private List<Stats> _gameStatsList;
        public UserStats()
        {
            InitializeComponent();
            DisplayStats();
        }

        private void DisplayStats()
        {
            listView.ItemsSource = FetchFromList();
        }

        private List<Stats> FetchFromList()
        {
            _gameStatsList = new List<Stats>();

            try
            {
                string directoryPath = Directory.GetCurrentDirectory() + @"\results.txt";
                string[] lines = File.ReadAllLines(directoryPath);
                foreach (string line in lines)
                {
                    string[] data = line.Split('/');
                    string playerName = data[0];
                    int playerScore = 0;
                    string botName = data[2];
                    int botScore = 0;
                    string dateTime = data[4];

                    if (Int32.TryParse(data[1], out playerScore) &&
                        Int32.TryParse(data[3], out botScore))
                    {
                        Stats _gameStats = new Stats(playerName, playerScore, botName, botScore, dateTime);
                        _gameStatsList.Add(_gameStats);
                    }

                }
            }catch
            {
                MessageBox.Show("Error has been occurred when fetching results.", "Error :(");
            }

            return _gameStatsList;
            
        }
    }
}
