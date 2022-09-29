using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_Movie_Library_Abstract_Class.Models
{
    internal class Show : Media
    {
        public Show()
        {
            Title = "";
            Writers = new List<string>();
        }

        public int Season { get; set; }
        public int Episode { get; set; }
        public List<string> Writers { get; set; }

        public override void Read(string line)
        {
            string[] showDetails = line.Split(',');
            string[] showWriters = showDetails[4].Split('|');

            Id = int.Parse(showDetails[0]);
            Title = showDetails[1];
            Season = int.Parse(showDetails[2]);
            Episode = int.Parse(showDetails[3]);

            for (int i = 0; i < showWriters.Length; i++)
            { Writers.Add(showWriters[i]); }
        }
        public override void Display()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Season: {Season}");
            Console.WriteLine($"Episode: {Episode}");
            Console.Write("Writer(s): ");
            for (int i = 0; i < Writers.Count; i++)
            { 
                Console.Write(Writers[i]);
                if (i != Writers.Count - 1) { Console.Write(", "); }
            }
            Console.WriteLine("\n");
        }
    }
}
