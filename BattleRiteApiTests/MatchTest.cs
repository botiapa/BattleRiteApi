using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleRiteApi;

namespace BattleRiteApiTests
{
    [TestClass]
    public class MatchTest : TestBase
    {
        [TestMethod]
        [TestCategory("Match")]
        public void MatchCollectionReturnsFiveMatches()
        {
            var Matches = api.GetMatchCollection();
            Assert.AreEqual(5, Matches.matches.Count);
        }

        [TestMethod]
        [TestCategory("Match"), TestCategory("Async")]
        public void MatchCollectionReturnsFiveMatchesAsync()
        {
            var Matches = api.GetMatchCollectionAsync().GetAwaiter().GetResult();
            Assert.AreEqual(5, Matches.matches.Count);
        }

        [TestMethod]
        [TestCategory("Match")]
        public void SingleMatchReturnsCorrectMatch()
        {
            var Match = api.GetSingeMatch(matchId);
            Assert.AreEqual(Match.match.id, matchId);
        }

        [TestMethod]
        [TestCategory("Match"), TestCategory("Async")]
        public void SingleMatchReturnsCorrectMatchAsync()
        {
            var Match = api.GetSingeMatchAsync(matchId).GetAwaiter().GetResult();
            Assert.AreEqual(Match.match.id, matchId);
        }
    }
}
