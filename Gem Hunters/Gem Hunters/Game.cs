using System;

public class Game
{
    private Board Board;
    private Player Player1;
    private Player Player2;
    private Player CurrentTurn;
    private int TotalTurns;
    private const int MaxTurns = 30;

    public Game()
    {
        Board = new Board();
        Player1 = new Player("P1", new Position(0, 0));
        Player2 = new Player("P2", new Position(5, 5));
        CurrentTurn = Player1;
        TotalTurns = 0;
        Board.PlacePlayer(Player1);
        Board.PlacePlayer(Player2);
    }

    public void Start()
    {
        Console.WriteLine("Welcome to Gem Hunters!");
        Console.WriteLine("Player 1: Green (P1)");
        Console.WriteLine("Player 2: Blue (P2)");
        Console.WriteLine("Gems: Yellow (G)");
        Console.WriteLine("Obstacles: Red (O)");
        Console.WriteLine();

        while (!IsGameOver())
        {
            Console.Clear();
            Console.WriteLine($"Turn {TotalTurns + 1}: {CurrentTurn.Name}'s turn");
            Console.WriteLine($"Player 1 Gems: {Player1.GemCount} | Player 2 Gems: {Player2.GemCount}");
            Console.WriteLine($"Turns Left: {MaxTurns - TotalTurns}");
            Board.Display();

            Console.Write("Enter direction (U/D/L/R): ");
            char direction = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Position newPosition = CurrentTurn.GetNewPosition(direction);

            if (Board.IsValidMove(CurrentTurn, newPosition))
            {
                if (Board.CollectGem(CurrentTurn, newPosition))
                    Console.WriteLine($"{CurrentTurn.Name} collected a gem!");

                Board.RemovePlayer(CurrentTurn);
                CurrentTurn.Move(newPosition);
                Board.PlacePlayer(CurrentTurn);


                SwitchTurn();
                TotalTurns++;
            }
            else
            {
                Console.WriteLine("Invalid move! Try again.");
                Console.ReadKey();  // Pause to show invalid move message
            }

            if (Board.AreAllGemsCollected())
                break;
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        AnnounceWinner();
    }

    private void SwitchTurn()
    {
        CurrentTurn = (CurrentTurn == Player1) ? Player2 : Player1;
    }

    private bool IsGameOver()
    {
        return TotalTurns >= MaxTurns || Board.AreAllGemsCollected();
    }

    private void AnnounceWinner()
    {
        Console.WriteLine($"Player 1 collected: {Player1.GemCount} gems");
        Console.WriteLine($"Player 2 collected: {Player2.GemCount} gems");

        if (Player1.GemCount > Player2.GemCount)
            Console.WriteLine("Player 1 wins!");
        else if (Player2.GemCount > Player1.GemCount)
            Console.WriteLine("Player 2 wins!");
        else
            Console.WriteLine("It's a tie!");
    }
}
