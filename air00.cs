namespace Split;

public static class Program
{
    public static List<string> MySplitFunction(string stringToSplit, string separator)
    {
        List<string> splitedString = new();
        string temp = "";

        foreach (var charInString in stringToSplit)
        {
           if(charInString == separator[0])
           {
               splitedString.Add(temp.Trim());
               temp = "";
           }
           else
           {
               temp += charInString;
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
                if(args[2].Length == 1)
                {
                    Utils_Ca_Air.Utils.DiplayStringList(MySplitFunction(args[1], args[2]));
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}