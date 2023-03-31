namespace application // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static string Read(string filename)
        {
            string content = "";
            using (StreamReader sr = new StreamReader(Path.Combine(@"D:\repos\cloudflight-coding-contest\application\application\input", filename)))
            {
                content = sr.ReadToEnd();
            }
            return content;
        } 
        
        public static void Write(string filename, string content)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(@"D:\repos\cloudflight-coding-contest\application\application\output", filename)))
            {
                sw.Write(content);
            }
        } 
        
        public static void Append(string filename, string content)
        {
            using FileStream fs = new FileStream(Path.Combine(@"D:\repos\cloudflight-coding-contest\application\application\output", filename), FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(content);
            }
        } 
    }
}

