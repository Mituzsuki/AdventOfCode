using System.Text;

namespace _2024.DaySix;

internal class Guard
{
    public readonly HashSet<Position> PositionsTraversed = new HashSet<Position>();
    
    private Position currentPosition = new Position(0, 0, Direction.Down);
    private Direction currentDirection = Direction.Up; //Assumption..

    public bool LoopReached { get; private set; } = false;

    private readonly Position _startPosition;
    private readonly int _height;
    private readonly int _width;
    private readonly char[][] _grid;
    private readonly char _obstruction = '#';

    
    public Guard(char[][] grid, int height, int width)
    {
        _grid = grid;
        _height = height;
        _width = width;
        
        //Get our current position
        bool startingPositionFound = false;
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (grid[y][x] is '^' or 'v' or '>' or '<')
                {
                    currentPosition = new Position(y, x, Direction.Up);
                    PositionsTraversed.Add(currentPosition);
                    _startPosition = currentPosition;
                    startingPositionFound = true;
                    break;
                }
            }
            if(startingPositionFound) break;
        }
    }

    public void TraverseGrid()
    {
        do
        {
            MakeNextMove();
        } while (!GuardIsLeavingGrid(currentPosition));
    }

    public Task<Guard> TraverseGridUntilLoopAsync()
    {
        return Task.Run(() =>
        {
            do
            {
                MakeNextMove();
            } while (!LoopReached && !GuardIsLeavingGrid(currentPosition));

            return this;
        });
    }

    private void MakeNextMove()
    {
        if (currentDirection == Direction.Up)
        {
            Position potentialPosition = new Position(currentPosition.Y - 1, currentPosition.X, Direction.Up);
            if (PositionIsValid(potentialPosition))
            {
                currentPosition = potentialPosition;
                if (!PositionsTraversed.Add(currentPosition))
                {
                    LoopReached = true;}
                return;
            }
            else
            {
                currentDirection = Direction.Right;
            }
        }

        if (currentDirection == Direction.Right)
        {
            Position potentialPosition = new Position(currentPosition.Y, currentPosition.X + 1, Direction.Right);
            if (PositionIsValid(potentialPosition))
            {
                currentPosition = potentialPosition;
                if (!PositionsTraversed.Add(currentPosition))
                {
                    LoopReached = true;}
                return;
            }
            else
            {
                currentDirection = Direction.Down;
            }
        }

        if (currentDirection == Direction.Down)
        {
            Position potentialPosition = new Position(currentPosition.Y + 1, currentPosition.X, Direction.Down);
            if (PositionIsValid(potentialPosition))
            {
                currentPosition = potentialPosition;
                if (!PositionsTraversed.Add(currentPosition))
                {
                    LoopReached = true;}
                return;
            }
            else
            {
                currentDirection = Direction.Left;
            }
        }

        if (currentDirection == Direction.Left)
        {
            Position potentialPosition = new Position(currentPosition.Y, currentPosition.X - 1, Direction.Left);
            if (PositionIsValid(potentialPosition))
            {
                currentPosition = potentialPosition;
                if (!PositionsTraversed.Add(currentPosition))
                {
                    LoopReached = true;
                    
                }
                return;
            }
            else
            {
                currentDirection = Direction.Up;
            }
        }
    }

    private bool PositionIsValid(Position position)
    {
        return 
            (position.Y >= 0 && position.Y < _height) && 
            (position.X >= 0 && position.X < _width) &&
            (_grid[position.Y][position.X] != _obstruction && _grid[position.Y][position.X] != 'O');
    }

    private bool GuardIsLeavingGrid(Position position)
    {
        return
            (position.Y == 0 && currentDirection == Direction.Up) ||
            (position.Y == _height -1 && currentDirection == Direction.Down) ||
            (position.X == 0 && currentDirection == Direction.Left) ||
            (position.X == _width - 1 && currentDirection == Direction.Right);
    }

    public bool HasAlreadyTraversedPosition()
    {
        //Don't just return the result for debugging purposes
        var b = PositionsTraversed.Count(item => item == currentPosition) > 1;
        if (b)
        {
            return true;
        }
        return false;
    }
}