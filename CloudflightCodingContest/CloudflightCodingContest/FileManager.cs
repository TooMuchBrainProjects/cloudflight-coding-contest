namespace CloudflightCodingContest;

public static class FileManager
{
    public static string Read(string filename)
    {
        string content = "";
        using (StreamReader sr =
               new StreamReader(Path.Combine(@"../../../input",
                   filename)))
        {
            content = sr.ReadToEnd();
        }

        return content;
    }

    public static void Write(string filename, string content)
    {
        using (StreamWriter sw =
               new StreamWriter(Path.Combine(@"../../../output",
                   filename)))
        {
            sw.Write(content);
        }
    }

    public static void Append(string filename, string content)
    {
        using FileStream fs =
            new FileStream(
                Path.Combine(@"../../../output", filename),
                FileMode.Append, FileAccess.Write);
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.Write(content);
        }
    }

    public static void All(string level_folder, Func<string,string> executer)
    {
        string[] files = Directory.GetFiles( Path.Combine(@"../../../input", level_folder) );
        var filtered = files.Where(file => Path.GetExtension(file).Equals(".in", StringComparison.OrdinalIgnoreCase)).ToArray();

        foreach (string file in filtered)
        {
            string content;
            using (StreamReader sr = new StreamReader(file))
            {
                content = sr.ReadToEnd();
            }
            
            Console.WriteLine(file);
            string output = executer(content);
            
            using (StreamWriter sw = new StreamWriter(file.Replace("input","output") + ".out"))
            {
                sw.Write(output);
            }
        }    
    }
    
}