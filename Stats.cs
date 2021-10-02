using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Stats
    {

        private string _playerName;
        private int _playerScore;
        private string _botName;
        private int _botScore;
        private string _dateTime;

        public string PlayerName
        {
            get
            {
                return _playerName;
            }
        }
        public int PlayerScore
        {
            get
            {
                return _playerScore;
            }
        }
        public string BotName
        {
            get
            {
                return _botName;
            }
        }
        public int BotScore
        {
            get
            {
                return _botScore;
            }
        }

        public string DateTime
        {
            get
            {
                return _dateTime;
            }
        }

        public override string ToString()
        {
            return $"{this.PlayerName} {this.PlayerScore} : {this.BotName} {this.BotScore} - {this.DateTime}";
        }

        public Stats(string playerName,int playerScore, string botName, int botScore, string dateTime)
        {
            this._playerName = playerName;
            this._playerScore = playerScore;
            this._botName = botName;
            this._botScore = botScore;
            this._dateTime = dateTime;
        }

    }
}
