using Utility;

namespace CloudflightCodingContest;

public class Program
{
    private static string projectFolderRelativePath = @"..\..\..\..";
    private static void ReadExecuteWrite(string inputFilename)
    {
        string outputFilename = inputFilename.Replace(".in", ".out");
        CCCInputOutput.Output(outputFilename, LevelExecution(CCCInputOutput.Input(inputFilename)));
    }
    static void Main(string[] args)
    {
        //ReadExecuteWrite(filename of inputFile); eg. ReadExecuteWrite("level2_3.in");
        ReadExecuteWrite("test.txt");
    }

    private static string LevelExecution(string input)
    {
        string output = "test";
        return output;
    }
    
}