using static Utility.FileReaderWriter;

namespace Utility;

public class CCCInputOutput
{
    private static string projectFolderRelativePath = @"..\..\..\..";
    public static string Input(string filename)
    {
        string path = Path.Combine(projectFolderRelativePath, "input", filename);
        return FileReaderWriter.Read(path);
    }

    public static void Output(string filename, string output)
    {
        string path = Path.Combine(projectFolderRelativePath, "output", filename);
        FileReaderWriter.Write(path, output);
    }
}