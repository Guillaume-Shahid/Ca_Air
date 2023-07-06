using Utils_Ca_Air;

namespace MelangerDeuxTableauxTriés;

internal static class Program
{
    private static int GetFusionWordIndex(string[] args)
    {
        for(var i =0; i < args.Length; i++)
        {
            if(args[i].ToLower() == "fusion")
            {
                return i;
            }
        }
        return -1;
    }
    
    private static List<int> GetFirstIntListFromArgs(string[] args, int fusionWordIndex)
    {
        List<int> firstIntList = new();

        for(var i = 1; i < fusionWordIndex; i++)
        {
            firstIntList.Add(int.Parse(args[i]));
        }
        return firstIntList;
    }
    
    private static List<int> GetSecondIntListFromArgs(string[] args, int fusionWordIndex)
    {
        List<int> secondIntList = new();

        for(var i = fusionWordIndex + 1; i < args.Length; i++)
        {
            secondIntList.Add(int.Parse(args[i]));
        }
        return secondIntList;
    }
    
    private static List<int> FusionIntLists(List<int> firstIntList, List<int> secondIntList)
    {
        foreach (var numberInSecondList in secondIntList)
        {
            InsertionDansUnTableauTi.Program.InsertIntInSortedList(firstIntList, numberInSecondList);
        }
        return firstIntList;
    }

    public static void Main(string[] args)
    {
        if (Utils.CheckIfNArgsMiniExists(args, 1))
        {
            try
            {
                int fusionWordIndex = GetFusionWordIndex(args);
                var firstIntList = GetFirstIntListFromArgs(args, fusionWordIndex);
                var secondIntList = GetSecondIntListFromArgs(args, fusionWordIndex);

                var fusionnedIntList = FusionIntLists(firstIntList, secondIntList);
                
                Console.WriteLine(string.Join(" ", fusionnedIntList));
            }
            catch
            {
                Console.WriteLine("error");
            }
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}