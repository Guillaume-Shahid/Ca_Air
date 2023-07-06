namespace SplitEnFonction;

internal static class Program
{
    private static bool IsASeparator(string stringToCheck, string separator, int i)
    {
        return Utils_Ca_Air.Utils.StringContainsStringAtIndex(stringToCheck, separator, i);
    }
    private static List<string> MySplitFunction(string stringToSplit, string separator)
    {
        List<string> splitedString = new();
        string temp = "";

        for(int i = 0; i < stringToSplit.Length; i++)
        {
            if (IsASeparator(stringToSplit, separator, i))
            {
                splitedString.Add(temp.Trim());
                temp = "";
                i += separator.Length - 1;
            }
            else
            {
                temp += stringToSplit[i];
            }
        }
        splitedString.Add(temp.Trim());
        return splitedString;
    }
    
    public static void Main(string[] args)
    {
        if (Utils_Ca_Air.Utils.CheckIfArgsExists(args, 2))
        {
            if (args.Length == 2)
            {
                Utils_Ca_Air.Utils.DiplayStringList(MySplitFunction(args[1], " "));
            }
            else
            {
                Utils_Ca_Air.Utils.DiplayStringList(MySplitFunction(args[1], args[2]));
            }
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}