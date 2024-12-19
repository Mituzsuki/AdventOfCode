namespace _2024.DaySix;

public class DaySixSolution : ISolution
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
        
        return guard.PositionsTraversed.DistinctBy(item => (item.Y, item.X)).Count().ToString();
    }

}

