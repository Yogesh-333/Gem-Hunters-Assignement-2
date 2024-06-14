using System;

public class Board
{
    private Cell[,] Grid;
    private int totalGems;

    public Board()
    {
        Grid = new Cell[6, 6];
        totalGems = 0;
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        // Initialize cells
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell();
            }
        }

        // Set obstacles (randomly for demonstration)
        Random rnd = new Random();
        for (int i = 0; i < 6; i++)
        {
            int obsX = rnd.Next(6);
            int obsY = rnd.Next(6);
            if (Grid[obsX, obsY].Occupant == "-")
            {
                Grid[obsX, obsY].Occupant = "O";
            }
            else
            {
                i--; // Retry if obstacle placed on an occupied cell
            }
        }

        // Set gems (randomly for demonstration)
        for (int i = 0; i < 4; i++)
        {
            int gemX = rnd.Next(6);
            int gemY = rnd.Next(6);
            if (Grid[gemX, gemY].Occupant == "-")
            {
                Grid[gemX, gemY].Occupant = "G";
                totalGems++;
            }
            else
            {
                i--; // Retry if gem placed on an occupied cell
            }
        }
    }

    public void PlacePlayer(Player player)
    {
        Grid[player.Position.Y, player.Position.X].Occupant = player.Name;
    }

    public void RemovePlayer(Player player)
    {
        Grid[player.Position.Y, player.Position.X].Occupant = "-";
    }

    public void Display()
    {
        Console.WriteLine("  1 2 3 4 5 6");
        for (int i = 0; i < 6; i++)
        {
            Console.Write((i + 1) + " ");
            for (int j = 0; j < 6; j++)
            {
                string occupant = Grid[i, j].Occupant;
                Console.ForegroundColor = GetColor(occupant);
                Console.Write(occupant + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }


    public bool IsValidMove(Player player, Position newPosition)
    {
        int newX = newPosition.X;
        int newY = newPosition.Y;

        // Check boundaries and obstacles
        if (newX >= 0 && newX < 6 && newY >= 0 && newY < 6 && Grid[newY, newX].Occupant != "O")
            return true;

        return false;
    }

    private ConsoleColor GetColor(string occupant)
    {
        switch (occupant)
        {
            case "P1":
                return ConsoleColor.Green;
            case "P2":
                return ConsoleColor.Blue;
            case "G":
                return ConsoleColor.Yellow;
            case "O":
                return ConsoleColor.Red;
            default:
                return ConsoleColor.White;
        }
    }

    public bool CollectGem(Player player, Position newPosition)
    {
        if (Grid[newPosition.Y, newPosition.X].Occupant == "G")
        {
            player.GemCount++;
            totalGems--;
            Grid[player.Position.Y, player.Position.X].Occupant = "-"; // Remove gem
            return true;
        }
        return false;
    }

    public bool AreAllGemsCollected()
    {
        return totalGems == 0;
    }
}
