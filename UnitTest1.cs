using FootballWCSB;
using FootballWCSB.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SuccessfulFlowTest()
        {
            var matchManager = new MatchManager();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "There is already a match running for these teams")]
        public void DoubleStartTest()
        {
            var matchManager = new MatchManager();

            matchManager.StartMatch("Spain", "Italy");
            matchManager.StartMatch("Spain", "Italy");
        }

        [TestMethod]
        public void DefaultSummaryTest()
        {
            var matchManager = new MatchManager();

            var summaryStringList = matchManager.GetSummary().Select(x => x.ToString());
            var summary = string.Join("\n", summaryStringList);

            var expectedSummary = "Uruguay 6 - Italy 6\nSpain 10 - Brazil 2\nMexico 0 - Canada 5\nArgentina 3 - Australia 1\nGermany 2 - France 2";

            Assert.AreEqual(summary, expectedSummary);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The provided match does not exist in the scoreboard")]
        public void UpdateUnexistentMatchTest()
        {
            var matchManager = new MatchManager();

            var match = new Match("Portugal", "Brazil");
            matchManager.UpdateScore(match, 7, 5);
        }
    }
}
