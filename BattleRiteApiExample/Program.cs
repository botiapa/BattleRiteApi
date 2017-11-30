using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleRiteApi;

namespace BattleRiteApiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleRite battleRite = new BattleRite(new Uri("E:\\Documents\\battlerite_api_key.txt"));
            BattleRiteApi.Matches.MatchCollection matchCollection = battleRite.GetMatchCollection();

            Console.WriteLine(matchCollection.matches[0].attributes.stats.mapID);
            Console.Read();
        }
    }
}
