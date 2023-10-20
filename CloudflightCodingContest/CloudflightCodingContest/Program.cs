using System.ComponentModel.Design;

namespace CloudflightCodingContest;

public class Program
{
    static void Main(string[] args)
    {
        /*
        string fileContent = FileManager.Read("level3/level3_example.in");
        var output = Execute(fileContent);
        Console.WriteLine(output);
        Console.WriteLine("---");

        FileManager.Write("level3/level3_example.in.out", output);
        //Append("test.txt", fileContent);

        */
        FileManager.All("level3", Execute);
    }

    public static string Execute(string filecontent)
    {
        List<string> lines = filecontent.Split("\n").Skip(1).Take(filecontent.Split("\n").Length - 2).Select(s => s.Trim()).ToList();
        
        Puzzle p = Puzzle.FromString(lines);
        p.Correct(); 

        return p.Print();
    }

    class Piece
    {
        
        public List<Side> PieceSides { get; set; }


        public static Piece FromString(string input)
        {
            return new Piece()
            {
                PieceSides = input.Split(',').Select((s) => (Side)Enum.Parse(typeof(Side), s)).ToList()
            };
        }
        public string Print()
        {
            var print = this.PieceSides.Select(s => s.ToString()).ToList();
            return string.Join(",", print);
        }
        
        public bool Matchs(Piece other, Position rel_pos)
        {
            return true;
        }
    }

    static List<Side> JiggleList(List<Side> list)
    {
        Side firstel = list.First();
        var newList = list.Skip(1).ToList();
        newList.Add(firstel);

        return newList;
    }


    enum Side
    {
        H,
        K,
        E
    }

    enum Position
    {
        top,
        right,
        bottom,
        left
    }

    class Puzzle
    {
       public List<List<Piece>> Pieces { get; set; }
       public List<Piece> AvailPieces { get; set; }

       public static Puzzle FromString(List<string> rows)
       {
           var pieces = rows.Select(r => r.Split(' ').ToList()).ToList();
           return new Puzzle()
           {
               Pieces = pieces.Select((l) => l.Select(Piece.FromString).ToList()).ToList()
           };
       }

       public void Correct()
       {
           for (int i = 0; i < Pieces.Count; i++)
           {
               for (int j = 0; j < Pieces[i].Count; j++)
               {
                   Piece p = Pieces[i][j];
                   

                  if (p.PieceSides[1] != Side.E)
                  {
                      Side next_left = Pieces[i][j + 1].PieceSides[3];
                      if (p.PieceSides[1] == next_left)
                      {
                          if (p.PieceSides[1] == Side.H)
                              p.PieceSides[1] = Side.K;
                          else 
                              p.PieceSides[1] = Side.H;
                      }
                  }
                  
                  if (p.PieceSides[2] != Side.E)
                  {
                      Side next_top = Pieces[i+1][j].PieceSides[0];
                      if (p.PieceSides[2] == next_top)
                      {
                          if (p.PieceSides[2] == Side.H)
                              p.PieceSides[2] = Side.K;
                          else 
                              p.PieceSides[2] = Side.H;
                      }
                  }
               } 
           }
       }

       public string Print()
       {
           string output = "";
           foreach (var row in Pieces)
           {
                var print = row.Select(s => s.Print()).ToList();
                output += string.Join(" ", print);
                
               output += "\n";
           }

           return output;
       }
    }
}
        //public PieceType PieceType { get; set; } 
        /*
        public static Piece FromSides(string pieceSides)
        {
            var sides_orig = pieceSides.Split(",").ToList();
            
            var sides = pieceSides.Split(",").ToList();
            var types = Enum.GetNames(typeof(PieceType));

            string type = "";
            while (true)
            {
                type = string.Join("", sides);
                if(types.Contains(type))
                    break;
                sides = JiggleList(sides);
            }


            return new Piece()
            {
                PieceType =  (PieceType)Enum.Parse(typeof(PieceType), type),
                PieceSides = sides_orig,
            };
        } 
    enum PieceType
    {
       HHHH, 
       HHHK,
       
       HHKK,
       HKHK,
       
       HKKK,
       KKKK,
    }
    
    static string PiceTypeToSplitedString(PieceType type)
    {
        return String.Join(',', type.ToString().ToList());
    }
    
       */
