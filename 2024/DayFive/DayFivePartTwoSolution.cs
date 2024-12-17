namespace _2024.DayFive;

public class DayFivePartTwoSolution : ISolution
{
    public string GetSolution()
    {
        DayFiveSolution df = new DayFiveSolution();

        (List<PageUpdates> validUpdates, List<PageUpdates> invalidUpdates, List<PageOrderRule> rules) solutions = df.GetValidAndInvalid();
        
        List<PageUpdates> correctedUpdates = new List<PageUpdates>();

        foreach (var p in solutions.invalidUpdates)
        {
            correctedUpdates.Add(MakePageUpdatesValid(p, solutions.rules));
        }
        
        int total = correctedUpdates.Sum(x => x.PageNumberOrder[x.PageNumberOrder.Count / 2]);
        return total.ToString();
        
    }
    
    private PageUpdates MakePageUpdatesValid(PageUpdates pageUpdates, List<PageOrderRule> rules)
    {
        try
        {
            for (var i = 0; i < pageUpdates.PageNumberOrder.Count; i++)
            {
                var matchingRule = rules.Find(rule => rule.PageNumber == pageUpdates.PageNumberOrder[i]);
                //Check if any of the previous page updates violate the current page
                if (pageUpdates.PageNumberOrder.Take(i).Any(item => matchingRule?.MustGoBefore.Contains(item) ?? false))
                {
                    var update = pageUpdates.PageNumberOrder[i];
                    pageUpdates.PageNumberOrder.RemoveAt(i);
                    pageUpdates.PageNumberOrder = pageUpdates.PageNumberOrder.Prepend(update).ToList();
                    //Let's check the order again
                    i = 0;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        
        return pageUpdates;
    }
}