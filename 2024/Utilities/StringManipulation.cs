namespace _2024.Utilities;

public class StringManipulation
{
    public static (string[] leftArray, string[] rightArray) SplitVertically(string[] lines, string separator = "  ")
    {
        string[] leftArray = new string[lines.Length];
        string[] rightArray = new string[lines.Length];

        for (int i = 0; i < leftArray.Length; i++)
        {
            string[] splitted = lines[i].Split(separator);
            leftArray[i] = splitted[0];
            rightArray[i] = splitted[1];
        }
        
        return (leftArray, rightArray);
    }
}