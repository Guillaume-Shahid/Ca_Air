using Utils_Ca_Air;

namespace ControleDePassSanitaire;

internal static class Program
{
    private static List<string> GetStringListFromArgs(string[] args)
    {
        List<string> stringList = new();
        
        for(var i = 1; i < args.Length - 1; i++)
        {
            stringList.Add(args[i]);
        }
        return stringList;
    }
    
    private static bool StringReallyContainsString(string stringToCheck, string stringToFind, int startingIndex)
    {
        for(int j = 0; j < stringToFind.Length; j++)
        {
            if ((stringToCheck[startingIndex + j] != stringToFind[j]))
            {
                return false;
            }
        }
        return true;
    }
    
    private static bool IsStringListContainPass (string stringToCheck, string stringToFind)
    {
        try
        {
            for(int i = 0; i < stringToCheck.Length; i++)
            {
                if(stringToCheck[i] == stringToFind[0] && StringReallyContainsString(stringToCheck, stringToFind, i))
                {
                    return true;
                }
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    private static List<string> PassCheck(List<string> stringListToCheck, string pass)
    {
        List<string> stringListAfterPassCheck = new();
        
        foreach (var person in stringListToCheck)
        {
            if(!IsStringListContainPass(person.ToLower(), pass))
            {
                stringListAfterPassCheck.Add(person);
            }
        }
        return stringListAfterPassCheck;
    }

    public static void Main(string[] args)
    {
        if (Utils.CheckIfNArgsMiniExists(args, 2))
        {
            var argsInList = GetStringListFromArgs(args);
            var pass = args[^1];
            var listAfterPassCheck = PassCheck(argsInList, pass);
            
            Utils.DiplayStringListOnOneLine(listAfterPassCheck);
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}