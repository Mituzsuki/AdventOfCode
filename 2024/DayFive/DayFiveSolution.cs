namespace _2024.DayFive;

public class DayFiveSolution : ISolution
{
    public string GetSolution()
    {
        (List<PageUpdates> validUpdates, List<PageUpdates> invalidUpdates, List<PageOrderRule> rules) updates = GetValidAndInvalid();
        int total = updates.validUpdates.Sum(x => x.PageNumberOrder[x.PageNumberOrder.Count / 2]);
        return total.ToString();
    }

    public (List<PageUpdates> validUpdates, List<PageUpdates> invalidUpdates, List<PageOrderRule> rules) GetValidAndInvalid()
    {
        var inputFilepath = "DayFive/input.txt";

        var lines = File.ReadAllLines(inputFilepath);

        if (lines.Length == 0)
        {
            return (new(), new(), new(0));
        }

        int indexOfEmptyLine = 0;

        List<PageOrderRule> rules = new List<PageOrderRule>();
        foreach (var line in lines)
        {
            //Empty line used to denominate break before next section
            indexOfEmptyLine++;
            if (line == "")
            {
                break;
            }

            var parts = line.Split("|");

            var ruleExistsAlready = rules.Exists(x => x.PageNumber == int.Parse(parts[0]));

            if (ruleExistsAlready)
            {
                rules.Find(x => x.PageNumber == int.Parse(parts[0]))!.MustGoBefore.Add(int.Parse(parts[1]));

            }
            else
            {
                PageOrderRule rule = new PageOrderRule(int.Parse(parts[0]));
                rule.MustGoBefore.Add(int.Parse(parts[1]));
                rules.Add(rule);
            }
        }
        
        List<PageUpdates> validPageUpdates = new List<PageUpdates>();
        List<PageUpdates> invalidPageUpdates = new List<PageUpdates>();

        foreach (var line in lines[indexOfEmptyLine..])
        {
            List<int> pageNumbersQueue = new List<int>();
            //Add technically always appends the element. Cannot use the append function as it doesn't alter the original object.
            line.Split(",").ToList().ForEach(x => pageNumbersQueue.Add(int.Parse(x)));
            //Now we determine if the list is in valid order
            bool isValidPageUpdate = true;
            for (int i = 0; i < pageNumbersQueue.Count; i++)
            {
                PageOrderRule? matchingRule = rules.Find(x => x.PageNumber == pageNumbersQueue[i]);
                if (matchingRule != null)
                {
                    if (pageNumbersQueue.Take(i).Any(item => matchingRule.MustGoBefore.Contains(item)))
                    {
                        isValidPageUpdate = false;
                    }
                }
            }

            if (isValidPageUpdate)
                validPageUpdates.Add(new PageUpdates(pageNumbersQueue));
            else
                invalidPageUpdates.Add(new PageUpdates(pageNumbersQueue));
        }
        
        return (validPageUpdates, invalidPageUpdates, rules);
    }
}

public class PageOrderRule
{
    public int PageNumber { get; init; }
    public List<int> MustGoBefore {get; init; } = new();

    public PageOrderRule(int pageNumber)
    {
        PageNumber = pageNumber;
    }
}

public class PageUpdates
{
    public List<int> PageNumberOrder { get; set; } = new();

    public PageUpdates(List<int> pageNumberOrder)
    {
        PageNumberOrder = pageNumberOrder;
    }
}