using Utils_Ca_Air;

namespace InsertionDansUnTableauTi;

public static class Program
{
    private static bool IsIntListSorted(List<int> intListToCheck)
    {
        for(int i = 0; i < intListToCheck.Count - 1; i++)
        {
            if(intListToCheck[i] > intListToCheck[i + 1])
            {
                return false;
            }
        }
        return true;
    }
    
    private static List<int> GetIntListFromArgs(string[] args)
    {
        List<int> intList = new();
        
        for(var i = 1; i < args.Length - 1; i++)
        {
            intList.Add(int.Parse(args[i]));
        }
        return intList;
    }
    
    private static List<int> ShiftIntList(List<int> intListToShift, int numberToInsert, int startingIndex)
    {
        int temp = intListToShift[startingIndex];
        int numberToInsertTemp = numberToInsert;

        for(var i = startingIndex; i < (intListToShift.Count - 1); i++)
        {
            intListToShift[i] = numberToInsertTemp;
            numberToInsertTemp = temp;
            temp = intListToShift[i + 1];
        }
        intListToShift[^1] = numberToInsertTemp;
        intListToShift.Add(temp);
        
        return intListToShift;
    }

    public static List<int> InsertIntInSortedList(List<int> intListToInsert, int numberToInsert)
    {
        for(var i  = 0; i < intListToInsert.Count; i++)
        {
            if(numberToInsert >= intListToInsert[^1])
            {
                intListToInsert.Add(numberToInsert);
                return intListToInsert;
            }
            if(numberToInsert < intListToInsert[i])
            {
                return ShiftIntList(intListToInsert, numberToInsert, i);
            }
        }
        return intListToInsert;
    }
    
    public static void Main(string[] args)
    {
        if (Utils.CheckIfNArgsMiniExists(args, 1))
        {
            try
            {
                var intList = GetIntListFromArgs(args);

                if (IsIntListSorted(intList))
                {
                    var numberToInsert = int.Parse(args[^1]);

                    intList = InsertIntInSortedList(intList, numberToInsert);

                    Utils.DiplayIntListOnOneLine(intList);
                }
                else
                {
                    Console.WriteLine("error");
                }
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