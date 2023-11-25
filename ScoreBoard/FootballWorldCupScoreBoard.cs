using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoard
{
    public class FootballWorldCupScoreBoard
    {

        private List<FootballMatch> matches = new List<FootballMatch>();

        public void StartGame(string homeTeam, string awayTeam)
        {
            var match = new FootballMatch
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                HomeTeamScore = 0,
                AwayTeamScore = 0
            };

            matches.Add(match);
        }

        public List<FootballMatch> GetSummaryByTotalScore()
        {
            // Order matches by total score and then by the most recently added
            return matches.OrderByDescending(m => m.HomeTeamScore + m.AwayTeamScore)
                          .ThenByDescending(m => matches.IndexOf(m))
                          .ToList();
        }
    }
}
