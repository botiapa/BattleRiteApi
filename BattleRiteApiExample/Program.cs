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
            Console.WriteLine(battleRite.GetSingeMatch(matchCollection.matches[0].id).match.links);
            Console.WriteLine(battleRite.GetApiStatusAsync().GetAwaiter().GetResult());
            Console.Read();
        }
    }
}
