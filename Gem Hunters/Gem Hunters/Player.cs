public class Player
{
    public string Name { get; }
    public Position Position { get; set; }
    public int GemCount { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        GemCount = 0;
    }

    public Position GetNewPosition(char direction)
    {
        Position newPosition = new Position(Position.X, Position.Y);
        switch (direction)
        {
            case 'U':
                if (newPosition.Y > 0)
                    newPosition.Y--;
                break;
            case 'D':
                if (newPosition.Y < 5)
                    newPosition.Y++;
                break;
            case 'L':
                if (newPosition.X > 0)
                    newPosition.X--;
                break;
            case 'R':
                if (newPosition.X < 5)
                    newPosition.X++;
                break;
            default:
                Console.WriteLine("Invalid direction!");
                break;
        }
        return newPosition;
    }

    public void Move(Position newPosition)
    {
        Position = newPosition;
    }
}
