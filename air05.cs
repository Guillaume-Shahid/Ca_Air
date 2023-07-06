namespace SurChacunD_EntreEux;


internal static class Program
{
    private static List<int> GetIntListFromArgs(string[] args)
    {
        List<int> intList = new();
        
        for(var i = 1; i < args.Length - 1; i++)
        {
            intList.Add(int.Parse(args[i]));
        }
        return intList;
    }
    
    private static List<int> Calculate(List<int> intListToCalculate, int numberToCalculate, char calcOperator)
    {
        switch (calcOperator)
        {
            case '+':
                return intListToCalculate.Select(i => i + numberToCalculate).ToList();
            case '-':
                return intListToCalculate.Select(i => i - numberToCalculate).ToList();
            case '*':
                return intListToCalculate.Select(i => i * numberToCalculate).ToList();
            case '/':
                return intListToCalculate.Select(i => i / numberToCalculate).ToList();
            default:
                return intListToCalculate;
        }
    }

    public static void Main(string[] args)
    {
        if (Utils_Ca_Air.Utils.CheckIfNArgsMiniExists(args, 2))
        {
            try
            {
                var listToCalculate = GetIntListFromArgs(args);
                var calcOperator = args[^1][0];
                var numberToCalculate = int.Parse(args[^1][1..]);
                
                Utils_Ca_Air.Utils.DiplayIntListOnOneLine(
                    Calculate(listToCalculate, numberToCalculate, calcOperator));
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