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

    }
}