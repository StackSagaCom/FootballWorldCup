using ScoreBoard;
using System;

class Program
{
    static void Main()
    {
        FootballWorldCupScoreBoard scoreBoard = new FootballWorldCupScoreBoard();

        Console.WriteLine("Welcome to the Football World Cup Score Board!");

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Start a game");
            Console.WriteLine("2. Update score");
            Console.WriteLine("3. Finish game");
            Console.WriteLine("4. Display current state");
            Console.WriteLine("5. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Start a game
                        Console.Write("Enter the name of the home team: ");
                        string homeTeam = Console.ReadLine();

                        Console.Write("Enter the name of the away team: ");
                        string awayTeam = Console.ReadLine();

                        if (!string.IsNullOrEmpty(homeTeam) && !string.IsNullOrEmpty(awayTeam) && homeTeam.ToLower() != awayTeam.ToLower())
                        {
                            scoreBoard.StartGame(homeTeam, awayTeam);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("For a football game, we would need two different teams. Please, try again with correct team names. Football teams can not be null \n");
                        }
                        break;

                    case 2:
                        // Update score
                        Console.Write("Enter the name of the home team: ");
                        string updateHomeTeam = Console.ReadLine();

                        Console.Write("Enter the name of the away team: ");
                        string updateAwayTeam = Console.ReadLine();

                        if (!string.IsNullOrEmpty(updateHomeTeam) && !string.IsNullOrEmpty(updateAwayTeam) && updateHomeTeam.ToLower() != updateAwayTeam.ToLower())
                        {

                            Console.Write("Enter the new score for the home team: ");
                            int newHomeTeamScore;
                            if (int.TryParse(Console.ReadLine(), out newHomeTeamScore))
                            {
                                Console.Write("Enter the new score for the away team: ");
                                int newAwayTeamScore;
                                if (int.TryParse(Console.ReadLine(), out newAwayTeamScore))
                                {
                                    scoreBoard.UpdateScore(updateHomeTeam, updateAwayTeam, newHomeTeamScore, newAwayTeamScore);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for the away team score.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for the home team score.");
                            }
                        }
                        break;

                    case 3:
                        // Finish game
                        Console.Write("Enter the name of the home team: ");
                        string finishHomeTeam = Console.ReadLine();

                        Console.Write("Enter the name of the away team: ");
                        string finishAwayTeam = Console.ReadLine();

                        if (!string.IsNullOrEmpty(finishHomeTeam) && !string.IsNullOrEmpty(finishAwayTeam) && finishHomeTeam.ToLower() != finishAwayTeam.ToLower())
                        
                        {
                            scoreBoard.FinishGame(finishHomeTeam, finishAwayTeam);
                        }
                        break;

                    case 4:
                        // Display current state
                        Console.WriteLine("Current state of the score board:");
                        DisplayScoreBoard(scoreBoard);
                        Console.WriteLine();
                        break;

                    case 5:
                        // Exit
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private static void DisplayScoreBoard(FootballWorldCupScoreBoard scoreBoard)
    {
        var summary = scoreBoard.GetSummaryByTotalScore();
        foreach (var match in summary)
        {
            Console.WriteLine($"{match.HomeTeam} {match.HomeTeamScore} - {match.AwayTeamScore} {match.AwayTeam}");
        }
    }
}
