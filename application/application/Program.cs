using System.Diagnostics.CodeAnalysis;

namespace application // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            FindAll0("level1_1.in", "level1_1.out");
            FindAll0("level1_2.in", "level1_2.out");
            FindAll0("level1_3.in", "level1_3.out");
            FindAll0("level1_4.in", "level1_4.out");
            FindAll0("level1_5.in", "level1_5.out");
            FindAll0("level1_example.in", "level1_example.out");
            */

            /*Level2CallMethod("level2_1.in", "level2_1.out");
            Level2CallMethod("level2_2.in", "level2_2.out");
            Level2CallMethod("level2_3.in", "level2_3.out");
            Level2CallMethod("level2_4.in", "level2_4.out");
            Level2CallMethod("level2_5.in", "level2_5.out");
            Level2CallMethod("level2_example.in", "level2_example.out");*/

            Level2CallMethod("level3_1.in", "level3_1.out");
            Level2CallMethod("level3_2.in", "level3_2.out");
            Level2CallMethod("level3_3.in", "level3_3.out");
            Level2CallMethod("level3_4.in", "level3_4.out");
            Level2CallMethod("level3_5.in", "level3_5.out");
            Level2CallMethod("level3_example.in", "level3_example.out");
        }

        public static void FindAll0(string filename, string outputname)
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

        public static void Level2CallMethod(string filename, string outputname)
        {
            List<string> content = new List<string>();
            string fileContent = Read(filename);


            List<int> counts = new List<int>();
            chararray(fileContent.Split('\n').Skip(2).ToArray(), outputname);
        }

        public static void chararray(string[] lines, string outputname)
        {
            Console.WriteLine(lines[0]);
            List<char[,]> honeycombs = new List<char[,]>();

            int start = 0;
            char[,] honeycomb;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "\r" || i == lines.Length - 1)
                {
                    honeycomb = new char[i - start, lines[i - 1].Length];

                    for (int j = start; j < i; j++)
                    {
                        for (int k = 0; k < lines[i - 1].Length; k++)
                        {
                            honeycomb[j - start, k] = lines[j][k];
                        }
                    }

                    start = i + 1;
                    honeycombs.Add(honeycomb);
                }
            }

            foreach (var item in honeycombs)
            {
                FindEmptyCellsAroundWasp(item, outputname);
            }
        }

        public static void FindEmptyCellsAroundWasp(char[,] grid, string outputname)
        {
            /*var grid = new List<List<string>>();
            foreach (var line in grid_content.Split("\n"))
            {
                grid.Add(line.Split().ToList());
            }*/

            Console.WriteLine(grid[0, 0]);
            Console.WriteLine();

            int wx = 0, wy = 0;
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (grid[y, x] == 'W')
                    {
                        wx = x;
                        wy = y;
                    }
                }
            }

            Dictionary<string, Tuple<int, int>> directions = new Dictionary<string, Tuple<int, int>>();

            Append(outputname, Escape(grid, wx, wy) + "\n")};
        }

        public static bool Escape(char[,] grid, int x, int y)
        {
            
        }




        public static string Read(string filename)
        {
            string content = "";
            using (StreamReader sr =
                   new StreamReader(Path.Combine(@"D:\repos\cloudflight-coding-contest\application\application\input",
                       filename)))
            {
                content = sr.ReadToEnd();
            }

            return content;
        }

        public static void Write(string filename, string content)
        {
            using (StreamWriter sw =
                   new StreamWriter(Path.Combine(@"D:\repos\cloudflight-coding-contest\application\application\output",
                       filename)))
            {
                sw.Write(content);
            }
        }

        public static void Append(string filename, string content)
        {
            using FileStream fs =
                new FileStream(
                    Path.Combine(@"D:\repos\cloudflight-coding-contest\application\application\output", filename),
                    FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(content);
            }
        }
    }
}