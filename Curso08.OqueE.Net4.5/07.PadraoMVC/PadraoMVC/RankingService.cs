using PadraoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace PadraoMVC
{
    public class RankingService
    {
        static readonly Dictionary<int, Score> scores
            = new Dictionary<int, Score>();

        private static RankingService instance;
        public static RankingService Instance()
        {
            if (instance == null)
            {
                instance = new RankingService();
            }
            return instance;
        }

        private RankingService()
        {
            scores.Add(8, new Score(8, "👩🏾", "Marlene F. Martelli", 1298));
            scores.Add(1, new Score(1, "👨🏽", "Caio D. Torres", 800));
            scores.Add(7, new Score(7, "👩🏿", "Sandra D. Martins", 765));
            scores.Add(3, new Score(3, "👨🏾", "Tiago O. Vieira", 721));
        }

        public static int GetNextId()
        {
            int id = 0;
            var last = scores.Values.LastOrDefault();
            if (last != null)
            {
                id = last.Id;
            }
            id++;
            return id;
        }

        public List<Score> GetAll()
        {
            return scores
                .Values
                .ToList()
                .OrderByDescending(o => o.Points)
                .ToList();
        }

        public Score Get(int id)
        {
            return scores
                .Where(i => i.Key == id)
                .Select(i => i.Value)
                .SingleOrDefault();
        }

        public Score Create(Score item)
        {
            int id = GetNextId();
            var newItem = new Score(id, item.Avatar, item.PlayerName, item.Points);
            scores.Add(id, newItem);
            return newItem;
        }

        public Score Save(Score item)
        {
            if (scores.ContainsKey(item.Id))
            {
                scores[item.Id] = item;
                return item;
            }
            else
            {
                return Create(item);
            }
        }

        public Score Delete(int id)
        {
            Score item = null;
            if (scores.ContainsKey(id))
            {
                item = scores[id];
                scores.Remove(id);
            }
            return item;
        }
    }
}