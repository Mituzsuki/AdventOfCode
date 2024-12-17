namespace _2024.WeekTwo;

public class WeekTwoSolution : ISolution
{
    public string GetSolution()
    {
        var inputFilepath = "DayTwo/input.txt";

        var lines = File.ReadAllLines(inputFilepath);

        if (lines.Length == 0)
        {
            return string.Empty;
        }

        int safeLines = 0;

        foreach (var line in lines)
        {
            var lineParts = line.Split(" ").Select(int.Parse).ToArray();

            //Should all be increasing or decreasing
            if (DetermineTrend(lineParts).noTrend)
            {
                continue;
            }
            

            for (int i = 0; i < lineParts.Count(); i++)
            {
                if (i == 0) continue;
                var difference = Math.Abs(lineParts[i] - lineParts[i - 1]);
                
                //should grow by 1 but less than 4
                if (difference is > 3 or 0) break;
                
                if(i == lineParts.Count() - 1) safeLines++;
            }
        }
        
        return safeLines.ToString();
    }

    private (bool noTrend, bool isIncreasing) DetermineTrend(int[] list)
    {
        bool isIncreasing = false;
        bool isDecreasing = false;

        for (int i = 0; i < list.Count(); i++)
        {
            if (i == list.Count() - 1)
            {
                continue;
            }
            if (list[i] < list[i + 1])
            {
                isIncreasing = true;
            }
            else if (list[i] > list[i + 1])
            {
                isDecreasing = true;
            }
        }

        if (isIncreasing && isDecreasing || !isIncreasing && !isDecreasing)
        {
            return (true, true);
        }
        else
        {
            return (false, isIncreasing);
        }
    }
}