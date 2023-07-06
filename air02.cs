namespace Concat;

public static class Program
{
    private static string ConcatStringList(List<string> stringList, string separator)
    {
        string concatString = "";
        
        for(var i = 0; i < stringList.Count; i++)
        {
            if(i == stringList.Count - 1)
            {
                concatString += stringList[i];
            }
            else
            {
                concatString += stringList[i] + separator;
            }
        }
        return concatString;
    }
     
    public static void Main(string[] args)
    {
        if (Utils_Ca_Air.Utils.CheckIfNArgsMiniExists(args, 2))
        {
            var stringsList = Utils_Ca_Air.Utils.ArgsInList(args);
            Console.WriteLine(ConcatStringList(stringsList, args[^1]));
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}