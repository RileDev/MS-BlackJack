using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class User
    {
        private string _username;
        private int _points;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        public User()
        {

        }

        public User(string username)
        {
            this._username = username;
        }

        public User(string username, int points)
        {
            this._username = username;
            this._points = points;
        }

    }
}
