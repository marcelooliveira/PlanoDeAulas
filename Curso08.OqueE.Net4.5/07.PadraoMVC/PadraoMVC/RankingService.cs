using PadraoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace PadraoMVC
{
    public class RankingService
    {
        static readonly Dictionary<int, Score> scores
            = new Dictionary<int, Score>();

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
            return scores.Values.ToList();
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