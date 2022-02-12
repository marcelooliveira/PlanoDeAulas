using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PadraoMVC.Models
{
    public class NewScoreViewModel
    {
        public NewScoreViewModel()
        {

        }

        public Score NewScore { get; set; }
            = new Score(0, " ", "", 0);

        public List<string> Avatars { get; set; }
            = new List<string>
            {
                "👨🏻",
                "👨🏼",
                "👨🏽",
                "👨🏾",
                "👨🏿",
                "👩🏻",
                "👩🏼",
                "👩🏽",
                "👩🏾",
                "👩🏿"
            };
    }
}