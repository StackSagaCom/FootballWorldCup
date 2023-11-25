namespace ScoreBoard.Test
{
    public class FootballWorldCupScoreBoardTests
    {
        [Fact]
        public void StartGame_ShouldAddNewMatch()
        {
            // Arrange
            var scoreBoard = new FootballWorldCupScoreBoard();

            // Act
            scoreBoard.StartGame("HomeTeam", "AwayTeam");

            // Assert
            var match = Assert.Single(scoreBoard.GetSummaryByTotalScore());
            Assert.Equal("HomeTeam", match.HomeTeam);
            Assert.Equal("AwayTeam", match.AwayTeam);
            Assert.Equal(0, match.HomeTeamScore);
            Assert.Equal(0, match.AwayTeamScore);
        }

        [Fact]
        public void UpdateScore_ShouldUpdateMatchScore()
        {
            // Arrange
            var scoreBoard = new FootballWorldCupScoreBoard();
            scoreBoard.StartGame("HomeTeam", "AwayTeam");

            // Act
            scoreBoard.UpdateScore("HomeTeam", "AwayTeam", 2, 1);

            // Assert
            var updatedMatch = Assert.Single(scoreBoard.GetSummaryByTotalScore());
            Assert.Equal("HomeTeam", updatedMatch.HomeTeam);
            Assert.Equal("AwayTeam", updatedMatch.AwayTeam);
            Assert.Equal(2, updatedMatch.HomeTeamScore);
            Assert.Equal(1, updatedMatch.AwayTeamScore);
        }
    }
}