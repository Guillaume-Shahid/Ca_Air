using Utils_Ca_Air;

namespace LeRoiDesTris;

internal static class Program
{
    private static List<int> ArgsInList(string[] args)
    {
        List<int> argsList = new();
        
        for(var i = 1; i < (args.Length); i++)
        {
            argsList.Add(int.Parse(args[i]));
        }
        return argsList;
    }

    private static int Partition(List<int> listToSort, int first, int last, int pivot)
    {
        (listToSort[last], listToSort[pivot]) = (listToSort[pivot], listToSort[last]);
        var j = first;
        for (int i = first; i <= last - 1; i++)
        {
            if (listToSort[i] <= listToSort[last])
            {
                (listToSort[i], listToSort[j]) = (listToSort[j], listToSort[i]);
                j++;
            }
        }
        (listToSort[last], listToSort[j]) = (listToSort[j], listToSort[last]);
        return j;
    }

    private static List<int> MyQuickSort(List<int> listToSort, int first, int last)
    {
        if (first < last)
        {
            var pivot = listToSort.IndexOf(listToSort[first]);
            pivot = Partition(listToSort, first, last, pivot);
            MyQuickSort(listToSort, first, (pivot - 1));
            MyQuickSort(listToSort, (pivot + 1), last);
        }
        return listToSort;
    }

    public static void Main(string[] args)
    {
        if (Utils.CheckIfNArgsMiniExists(args, 1))
        {
            try
            {
                var argsInIntList = ArgsInList(args);

                var firstIndex = 0;
                var lastIndex = argsInIntList.IndexOf(argsInIntList[^1]);

                argsInIntList = MyQuickSort(argsInIntList, firstIndex, lastIndex);
                
                Utils.DiplayIntListOnOneLine(argsInIntList);
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