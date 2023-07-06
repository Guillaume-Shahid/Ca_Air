using Utils_Ca_Air;

namespace RotationVersLaGauche;

internal static class Program
{
    private static List<string> LeftRotation(string[] args)
    {
        List<string> stringList = new();
        for (var i = 2; i < args.Length; i++)
        {
            stringList.Add(args[i]);
        }
        stringList.Add(args[1]);
        return stringList;
    }
    
    public static void Main(string[] args)
    {
        if (Utils.CheckIfNArgsMiniExists(args, 1))
        {
            var stringList = LeftRotation(args);

            Console.WriteLine(string.Join(", ", stringList));
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}