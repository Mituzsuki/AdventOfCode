namespace _2024.WeekFour;

public class WeekFourSolution : ISolution
{
    public string GetSolution()
    {
        var inputFilepath = "WeekFour/input.txt";

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
                targetWordsFound += CheckSurroundingCells(height, width, x, y, grid);
            }
        }
        
        return targetWordsFound.ToString();
    }

    private int CheckSurroundingCells(int maxHeight, int maxWidth, int currentY, int currentX, char[][] grid)
    {
        char currentChar = grid[currentY][currentX];

        int targetWordsFound = 0;
        //We only check if we are at the start of the word.. makes it easier.
        if (currentChar == 'X')
        {
            bool canCheckUp = currentY + 1 >= 4;
            bool canCheckLeft = currentX + 1 >= 4;
            bool canCheckDown = currentY + 4 <= maxHeight;
            bool canCheckRight = currentX + 4 <= maxWidth;
            
            //Check in a clock wise direction
            //1. Up
            //2. Diagonal up-right
            //3. Right
            //4. Diagonal down-right
            //5. Down
            //6. Diagonal down-left
            //7. Left
            //8. Diagonal up-left
            if (canCheckUp)
            {
                bool isValid =
                    grid[currentY - 1][currentX] == 'M' &&
                    grid[currentY - 2][currentX] == 'A' &&
                    grid[currentY - 3][currentX] == 'S';
                if(isValid) targetWordsFound++;
            }
            if (canCheckUp && canCheckRight)
            {
                bool isValid =
                    grid[currentY - 1][currentX + 1] == 'M' &&
                    grid[currentY - 2][currentX + 2] == 'A' &&
                    grid[currentY - 3][currentX + 3] == 'S';
                if(isValid) targetWordsFound++;
            }
            if (canCheckRight)
            {
                bool isValid =
                    grid[currentY][currentX + 1] == 'M' &&
                    grid[currentY][currentX + 2] == 'A' &&
                    grid[currentY][currentX + 3] == 'S';
                if(isValid) targetWordsFound++;
            }
            if (canCheckDown && canCheckRight)
            {
                bool isValid =
                    grid[currentY + 1][currentX + 1] == 'M' &&
                    grid[currentY + 2][currentX + 2] == 'A' &&
                    grid[currentY + 3][currentX + 3] == 'S';
                if(isValid) targetWordsFound++;
            }
            if (canCheckDown)
            {
                bool isValid =
                    grid[currentY + 1][currentX] == 'M' &&
                    grid[currentY + 2][currentX] == 'A' &&
                    grid[currentY + 3][currentX] == 'S';
                if(isValid) targetWordsFound++;
            }
            if (canCheckDown && canCheckLeft)
            {
                bool isValid =
                    grid[currentY + 1][currentX - 1] == 'M' &&
                    grid[currentY + 2][currentX - 2] == 'A' &&
                    grid[currentY + 3][currentX - 3] == 'S';
                if(isValid) targetWordsFound++;
            }
            if (canCheckLeft)
            {
                bool isValid =
                    grid[currentY][currentX - 1] == 'M' &&
                    grid[currentY][currentX - 2] == 'A' &&
                    grid[currentY][currentX - 3] == 'S';
                if(isValid) targetWordsFound++;
            }
            if (canCheckUp && canCheckLeft)
            {
                bool isValid =
                    grid[currentY - 1][currentX - 1] == 'M' &&
                    grid[currentY - 2][currentX - 2] == 'A' &&
                    grid[currentY - 3][currentX - 3] == 'S';
                if(isValid) targetWordsFound++;
            }
        }
        
        return targetWordsFound;
    }
}