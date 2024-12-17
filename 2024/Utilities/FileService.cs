namespace _2024.Utilities;

public class FileService
{
    public static string[] GetLines(string filepath)
    {
        if (!File.Exists(filepath))
        {
            //Could throw an Exception - but I think that is overcooking it a little bit. 
            return Array.Empty<string>();
        }
        else
        {
            return File.ReadAllLines(filepath);
        }
    }
}