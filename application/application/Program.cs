namespace application // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Count0("level1_1.in", "level1_1.out");
            Count0("level1_2.in", "level1_2.out");
            Count0("level1_3.in", "level1_3.out");
            Count0("level1_4.in", "level1_4.out");
            Count0("level1_5.in", "level1_5.out");
            Count0("level1_example.in", "level1_example.out");
        }

        public static void Count0(string filename, string outputname)
        {
            string content = Read(filename);
            string[] lines = content.Split("\n");
            int countline1 = 0;
            foreach (var item in lines[1])
            {
                if (item == 'O')
                {
                    countline1++;
                }
            }

            countline1 *= lines.Length - 1;
            
            Write(outputname, countline1.ToString());
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

