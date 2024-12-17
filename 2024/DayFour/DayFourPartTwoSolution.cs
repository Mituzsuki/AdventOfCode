namespace _2024.WeekFour;

public class DayFourPartTwoSolution : ISolution
{
   public string GetSolution()
    {
        var inputFilepath = "DayFour/input.txt";

        var lines = File.ReadAllLines(inputFilepath);

        if (lines.Length == 0)
        {
            return string.Empty;
        }
        
        //Let's combine the list together into a multi-dimensional array
        //Assumption that the width & length is consistent
        //y(horizontal axis),x(vertical axis)
        int height = lines.Length;
        int width = lines[0].Length;
        char[][] grid = new char[height][];
        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].ToCharArray();
        }

        int targetWordsFound = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                targetWordsFound += CheckSurroundingCells(height, width, x, y, grid) ? 1 : 0;
            }
        }
        
        return targetWordsFound.ToString();
    }

    private bool CheckSurroundingCells(int maxHeight, int maxWidth, int currentY, int currentX, char[][] grid)
    {
        char currentChar = grid[currentY][currentX];

        int targetWordsFound = 0;
        //We only check if we are at the start of the word.. makes it easier.
        if (currentChar == 'A')
        {
            bool canCheckUp = currentY >= 1;
            bool canCheckLeft = currentX >= 1;
            bool canCheckDown = currentY + 2 <= maxHeight;
            bool canCheckRight = currentX + 2 <= maxWidth;

            bool diagLeftValid = false;
            bool diagRightValid = false;
            
            //Firstly check that a cross can be made
            if (canCheckUp && canCheckLeft && canCheckDown && canCheckRight)
            {
                //Diagonal down to the left
                if(grid[currentY-1][currentX-1] == 'S' && grid[currentY+1][currentX+1] == 'M') diagLeftValid = true;
                if(grid[currentY-1][currentX-1] == 'M' && grid[currentY+1][currentX+1] == 'S') diagLeftValid = true;
                //Diagonal down to the right
                if(grid[currentY-1][currentX+1] == 'S' && grid[currentY+1][currentX-1] == 'M') diagRightValid = true;
                if(grid[currentY-1][currentX+1] == 'M' && grid[currentY+1][currentX-1] == 'S') diagRightValid = true;
            }
            
            return diagLeftValid && diagRightValid;
        }
        
        return false;
    }
}