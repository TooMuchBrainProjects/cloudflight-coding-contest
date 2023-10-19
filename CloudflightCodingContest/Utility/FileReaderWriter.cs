namespace Utility;

public static class FileReaderWriter
{
    public static string Read(string path)
    {
        string content = "";
        using (StreamReader sr = new StreamReader(path))
        {
            content = sr.ReadToEnd();
        }

        return content;
    }

    public static void Write(string path, string content)
    {
        using (StreamWriter sw =
               new StreamWriter(path))
        {
            sw.Write(content);
        }
    }

    public static void Append(string path, string content)
    {
        using FileStream fs =
            new FileStream(
                path,
                FileMode.Append, FileAccess.Write);
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.Write(content);
        }
    }
}