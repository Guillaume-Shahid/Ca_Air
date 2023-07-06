using Utils_Ca_Air;

namespace AfficherUnePyramide;

internal static class Program
{
    private static void DisplayPyramid(char charToDisplay, int numberOfLines, int charNumberInOneLine)
    {
        for (var i = 0; i < numberOfLines; i++)
        {
            var numberOfCharToDisplay = i * 2 + 1;
            var numberOfSpaceToDisplay = (charNumberInOneLine - numberOfCharToDisplay) / 2;
            for (var j = 0; j < numberOfSpaceToDisplay; j++)
            {
                Console.Write(" ");
            }

            for (var j = 0; j < numberOfCharToDisplay; j++)
            {
                Console.Write(charToDisplay);
            }
            Console.WriteLine();
        }
    }
    
    public static void Main(string[] args)
    {
        if (Utils.CheckIfNArgExists(args, 2))
        {
            try
            {
                var charToDisplay = char.Parse(args[1]);
                var numberOfLines = int.Parse(args[2]);
                var charNumberInOneLine = (numberOfLines - 1) * 2 + 1;
                
                if(numberOfLines >= 1)
                {
                    DisplayPyramid(charToDisplay, numberOfLines, charNumberInOneLine);
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