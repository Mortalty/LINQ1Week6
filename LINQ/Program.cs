using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

    public class Player
    {
        Guid _id;
        string _name;
        int _xp;


        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public override string ToString()
        {
            return _id.ToString() + "" + _name.ToString() + "" + _xp.ToString();
        }

    }



    class Program
    {
        static void Main(string[] args)
        {

            List<Player> players = new List<Player>();
            {
                new Player { Id = Guid.NewGuid(), Name = "Pete Volge", Xp = 100 };
                new Player { Id = Guid.NewGuid(), Name = "Joe Blogs", Xp = 10 };
                new Player { Id = Guid.NewGuid(), Name = "Mary Volge", Xp = 200 };
                new Player { Id = Guid.NewGuid(), Name = "Pete Townsend", Xp = 300 };
            }


            Player Found = players.FirstOrDefault(p => p.Name == "Mary Volge");

            if (Found != null)
            {
                Console.WriteLine("{0}", Found.ToString());
            }

            else
            {
                Console.WriteLine("Player not Found");
            }


            // return the first accurance of the some records
            Player Found1 = players.FirstOrDefault(p => p.Name.Contains("Pete"));

            if (Found1 != null)
            {
                Console.WriteLine("{0}", Found1.ToString());
            }

            else
            {
                Console.WriteLine("Player not Found");
            }


            // retuen all with xp over 100
            List<Player> TopPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if (TopPlayers.Count > 0)

            foreach (var item in TopPlayers)
            {
                Console.WriteLine("{0}", item.ToString());
            }

            else Console.WriteLine("No match found");




            // produce a scorebord of players names and scores


            Console.WriteLine("Top scores Board");

            var ScoreBoard = players
                                        .OrderByDescending(o => o.Xp)
                                        .Select(scores => new { scores.Name, scores.Xp });

            foreach (var item in ScoreBoard)
            {
                Console.WriteLine("{0} {1} ", item.Name, item.Xp);
            }


            Console.ReadLine();
        }
    }
}
