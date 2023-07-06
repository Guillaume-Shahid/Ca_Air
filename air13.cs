using System.Diagnostics;
using System.Text;


namespace MetaExercice;

internal static class Program
{
    private class Assert
    {
        public string ExpectedOutput { get; set; }
        public string ProgramName { get; set; }
        public string[] Args { get; set; }

        public Assert(string expectedOutput, string programName, string[] args)
        {
            ExpectedOutput = expectedOutput;
            ProgramName = programName;
            Args = args;
        }
    }
    
    
    private static List<string> CollectProgramsPathFromDirectory()
    {
        var path = Environment.CurrentDirectory;
        DirectoryInfo dirPrograms = new(path);
        var directoryPrograms = Directory.GetParent(dirPrograms.ToString());
        
        return new List<string>(Directory.EnumerateDirectories(directoryPrograms!.ToString()));
    }
    
    private static string GetPAthFromList(string programName)
    {
        var path = CollectProgramsPathFromDirectory();
        foreach (var dir in path.Where(dir => Path.GetFileName(dir) == programName))
        {
            return dir;
        }
        return "error";
    }

    private static string ArgsListInString(string[] args)
    {
        return args.Aggregate("Program.cs ", (current, arg) => current + $"\"{arg}\" ");
    }

    private static string GetOutputFromProgram(string path, string programName, string args)
    {
        var process = new Process();
        
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"run --project {path}/{programName}.csproj  {args}";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
         
        var outputBuilder = new StringBuilder();
        
        process.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                outputBuilder.AppendLine(e.Data);
            }
        };
        
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        
        process.WaitForExit();
                    
        return outputBuilder.ToString();
    }

    private static bool Assertion(string expectedOutput, string programName, string[] args)
    {
        expectedOutput = expectedOutput + "\n";
        var path = GetPAthFromList(programName);
        var argsToPass = ArgsListInString(args);
        var output = GetOutputFromProgram(path, programName, argsToPass);

        if(output == expectedOutput)
        {
            return true;
        }
        return false;
    }

    private static void PassWithSuccess(Assert program)
    {
        Console.WriteLine("✅  " + program.ProgramName);
    }
    
    private static void PassWithFailure(Assert program)
    {
        Console.WriteLine("❌  " + program.ProgramName);
    }

    public static void Main()
    {
        Console.Clear();
        var totalSuccess = 0;

        var assert = new List<Assert>
        {
            new Assert("Bonjour\nles\ngars", 
                "Split", 
                new[] { "Bonjour les gars" }),
            new Assert("Crevette magique dans\nmer des étoiles", 
                "SplitEnFonction", 
                new[] { "Crevette magique dans la mer des étoiles", "la" }),
            new Assert("Je teste des trucs", 
                "Concat", 
                new[] { "Je", "teste", "des", "trucs", " "}),
            new Assert("5", 
                "ChercherL_Intrus", 
                new[] { "1", "2", "3", "4", "5", "4", "3", "2", "1" }),
            new Assert("monsieur", 
                "ChercherL_Intrus", 
                new[] { "bonjour", "monsieur", "bonjour" }),
            new Assert("Helo milady, bien ou quoi", 
                "UnSeulALaFois", 
                new[] { "Hello milady,  bien ou quoi" }),
            new Assert("3 4 5 6 7", 
                "SurChacunD_EntreEux", 
                new[] { "1", "2", "3", "4", "5", "+2" }),
            new Assert("dhtfgs", 
                "SurChacunD_EntreEux", 
                new[] { "1", "2", "3", "4", "5", "l" }),
            new Assert("5 6 7 15", 
                "SurChacunD_EntreEux", 
                new[] { "10", "11", "12", "20", "-5" }),
            new Assert("Michel", 
                "ControleDePassSanitaire", 
                new[] { "Michel", "Albert", "Thérèse", "Benoit", "t" }),
            new Assert("Michel Thérèse Benoit", 
                "ControleDePassSanitaire", 
                new[] { "Michel", "Albert", "Thérèse", "Benoit", "a" }),
            new Assert("1 2 3 4", 
                "InsertionDansUnTableauTrie", 
                new[] { "1", "3", "4", "2" }),
            new Assert("10 20 30 33 40 50 60 70 90", 
                "InsertionDansUnTableauTrie", 
                new[] { "10", "20", "30", "40", "50", "60", "70", "90", "33" }),
            new Assert("10 15 20 25 30 35", 
                "MelangerDeuxTableauxTriés", 
                new[] { "10", "20", "30", "fusion", "15", "25", "35" }),
            new Assert("Albert, Thérèse, Benoit, Michel", 
                "RotationVersLaGauche", 
                new[] { "Michel", "Albert", "Thérèse", "Benoit" }),
            new Assert("Je danse le mia", 
                "zAfficherLeContenu", 
                new[] { "a.rtf" }),
            new Assert("    o\n   ooo\n  ooooo\n ooooooo\nooooooooo", 
                "AfficherUnePyramide", 
                new[] { "o", "5" }),
            new Assert("1 2 3 4 5 6", 
                "LeRoiDesTris", 
                new[] { "6", "5", "4", "3", "2", "1" })
        };

        foreach (var program in assert)
        {
            try
            {
                if(Assertion(program.ExpectedOutput, program.ProgramName, program.Args))
                {
                    PassWithSuccess(program);
                    totalSuccess++;
                }
                else
                {
                    PassWithFailure(program);
                } 
            }
            catch
            {
                PassWithFailure(program);
            }
        }
        Console.WriteLine($"\nTotal Success : {totalSuccess}/{assert.Count}");
    }
}