using System.Text.RegularExpressions;

namespace _2024.WeekThree;

public class WeekThreeSolution : ISolution
{
    public string GetSolution()
    {
        var inputFilepath = "WeekThree/input.txt";

        //I think this puzzle only has a single line
        var lines = File.ReadAllLines(inputFilepath);

        var input = string.Join(" ", lines);

        var pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        
        Regex rg = new Regex(pattern);

        var matches = rg.Matches(input);

        int output = 0;
        
        foreach (Match match in matches)
        {
            int leftNum = int.TryParse(match.Groups[1].Value, out int num) ? num : 0;
            int rightNum = int.TryParse(match.Groups[2].Value, out int num2) ? num2 : 0;
                
            output += leftNum * rightNum;
        }

        return output.ToString();
    }
}