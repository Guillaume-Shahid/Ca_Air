using Utils_Ca_Air;

namespace AfficherLeContenu;

internal static class Program
{
    public static void Main(string[] args)
    {
        if (Utils.CheckIfNArgExists(args, 1))
        {
            try
            {
                Console.WriteLine(File.ReadAllText(args[1]));
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