namespace _2024.DaySix;

public class DaySixPartTwoSolution : ISolution
{
    public string GetSolution()
    {
        var inputFilepath = "DaySix/input.txt";

        var lines = File.ReadAllLines(inputFilepath);

        if (lines.Length == 0)
        {
            return string.Empty;
        }

        //Let's combine the list together into a multi-dimensional array
        //Assumption that the width & length is consistent
        //y(vertical axis),x(horizontal axis)
        int height = lines.Length;
        int width = lines[0].Length;
        char[][] grid = new char[height][];
        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].ToCharArray();
        }
        Guard guard = new Guard(grid, height, width);
        
        guard.TraverseGrid();

        //For this task we try and change a different part of the path by adding in an obstacle and see what sticks
        //We start at index 1 as we can't add an obstacle to the starting position
        List<Task<Guard>> tasks = new List<Task<Guard>>();
        foreach (var position in guard.PositionsTraversed.DistinctBy(item => (item.Y, item.X)))
        {
            char[][] gridCopy = CloneGrid(grid);
            gridCopy[position.Y][position.X] = 'O';
            tasks.Add(new Guard(gridCopy, height, width).TraverseGridUntilLoopAsync());
        }
        
        Task.WhenAll(tasks).Wait();
        
        return tasks.Count(t => t.Result.LoopReached).ToString();
    }

    public char[][] CloneGrid(char[][] array)
    {
        char[][] newArray = new char[array.Length][];
        for (int y = 0; y < array.Length; y++)
        {
            var tempStr = new string(array[y]);
            newArray[y] = tempStr.ToCharArray();
        }
        return newArray;
    }
}