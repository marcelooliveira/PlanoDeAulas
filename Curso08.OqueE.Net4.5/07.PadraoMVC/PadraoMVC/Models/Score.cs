using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PadraoMVC.Models
{
    public class Score
    {
        public Score()
        {

        }

        public Score(int id, string avatar, string playerName, int points)
        {
            Id = id;
            Avatar = avatar;
            PlayerName = playerName;
            Points = points;
        }

        public int Id { get; set; }
        public string Avatar { get; set; }
        public string PlayerName { get; set; }
        public int Points { get; set; }
    }
}