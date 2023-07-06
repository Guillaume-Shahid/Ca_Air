using System.Collections;

namespace ChercherL_Intrus;

public static class Program
{
    private static List<string?> IntruderKey (Hashtable argsHathtable)
    {
        List<string?> intruderKey = new();
        
        foreach (DictionaryEntry de in argsHathtable)
        {
            if(de.Value!.Equals(1))
            {
                intruderKey.Add(de.Key.ToString());
            }
        }
        return intruderKey;
    }
    
    private static bool IsThereValuesInIntruderKeyList (List<string?> intruderKey)
    {
        return intruderKey.Count != 0;
    }
    
    public static void Main(string[] args)
    {
        if (Utils_Ca_Air.Utils.CheckIfNArgsMiniExists(args, 2))
        {
            var stringsHashtable = Utils_Ca_Air.Utils.ArgsInHashtable(args);
            var intruderList = IntruderKey(stringsHashtable);

            if(IsThereValuesInIntruderKeyList(intruderList))
            {
                Utils_Ca_Air.Utils.DiplayStringList(intruderList!);
            }
            else
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