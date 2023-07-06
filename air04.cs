namespace UnSeulALaFois;

internal static class Program
{
    private static List<string> OneAtATime(IEnumerable<string> argsSplited)
    {
         List<string> oneAtATimeList = new();

         foreach (var item in argsSplited)
         {
             string temp = "";

             if (item.Trim() != "")
             {
                 for(var i = 0; i < item.Length - 1; i++)
                 {
                     if (item[i] != item[i + 1])
                     {
                         temp += item[i];
                     }
                 }
                 temp += item[^1];
                 oneAtATimeList.Add(temp);
             }
         }
         return oneAtATimeList;
    }
    
    public static void Main(string[] args)
    {
        if (Utils_Ca_Air.Utils.CheckIfNArgExists(args, 1))
        {
            var argSplited = args[1].Split(' ');
            Utils_Ca_Air.Utils.DiplayStringListOnOneLine(OneAtATime(argSplited));
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}