using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleRiteApi;

namespace BattleRiteApiTests
{
    public class TestBase
    {
        public static BattleRite api = new BattleRite(new Uri("E:\\Documents\\battlerite_api_key.txt"));
        public static string BadApiKey = "badKeykeybadkeybbaedkeykeybad-key-bad-bad-key-bad";

        public const string matchId = "AB9C81FABFD748C8A7EC545AA6AF97CC";
    }
}
