namespace CloudflightCodingContest;

public class Program
{
    static void Main(string[] args)
    {
        string fileContent = Read("test.txt");
        Console.WriteLine(fileContent);
        Write("test.txt", fileContent);
        Append("test.txt", fileContent);
    }
    
    public static string Read(string filename)
    {
        string content = "";
        using (StreamReader sr =
               new StreamReader(Path.Combine(@"..\..\..\input",
                   filename)))
        {
            content = sr.ReadToEnd();
        }

        return content;
    }

    public static void Write(string filename, string content)
    {
        using (StreamWriter sw =
               new StreamWriter(Path.Combine(@"..\..\..\output",
                   filename)))
        {
            sw.Write(content);
        }
    }

    public static void Append(string filename, string content)
    {
        using FileStream fs =
            new FileStream(
                Path.Combine(@"..\..\..\output", filename),
                FileMode.Append, FileAccess.Write);
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.Write(content);
        }
    }
}