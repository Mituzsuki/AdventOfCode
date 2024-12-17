using System.Text.RegularExpressions;

namespace _2024.WeekThree;

public class WeekThreePartTwoSolution : ISolution
{
    public string GetSolution()
    {
        var inputFilepath = "DayThree/input_two.txt";

        //I think this puzzle only has a single line
        //We prepend do() to make our regex work a bit easier
        var lines = File.ReadAllLines(inputFilepath).Prepend("do()").ToArray();

        var input = string.Join(" ", lines);
        
        var pattern = @"do\((.*?)\).*?don't\((.*?)\)";
        var rg = new Regex(pattern);
        var multiPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        var mutliRg = new Regex(multiPattern);

        var output = 0;

        var matches = rg.Matches(input);
        
        foreach (Match match in matches)
        {
            var multiMatches = mutliRg.Matches(match.Value);
            foreach (Match multiMatch in multiMatches)
            {
                int leftNum = int.TryParse(multiMatch.Groups[1].Value, out int num) ? num : 0;
                int rightNum = int.TryParse(multiMatch.Groups[2].Value, out int num2) ? num2 : 0;
                
                output += leftNum * rightNum;
            }
        }
        

        return output.ToString();
    }
}