using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_Movie_Library_Abstract_Class.Models
{
    internal class Video : Media
    {
        public Video()
        {
            Title = "";
            Formats = new List<string>();
            Regions = new List<int>();
        }

        public List<string> Formats { get; set; }
        public int Length { get; set; }
        public List<int> Regions { get; set; }

        public override void Read(string line)
        {
            string[] videoDetails = line.Split(',');
            string[] videoFormats = videoDetails[2].Split('|');
            string[] videoRegions = videoDetails[4].Split('|');

            Id = int.Parse(videoDetails[0]);
            Title = videoDetails[1];
            Length = int.Parse(videoDetails[3]);

            for (int i = 0; i < videoFormats.Length; i++)
            { Formats.Add(videoFormats[i]); }

            for (int i = 0; i < videoRegions.Length; i++)
            { Regions.Add(int.Parse(videoRegions[i])); }
        }
        public override void Display()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.Write("Format(s): ");
            for (int i = 0; i < Formats.Count; i++)
            {
                Console.Write(Formats[i]);
                if (i != Formats.Count - 1) { Console.Write(", "); }
            }

            Console.WriteLine($"\nLength: {Length}");
            Console.Write("Region(s): ");
            for (int i = 0; i < Regions.Count; i++)
            { 
                Console.Write(Regions[i]); 
                if(i != Regions.Count - 1) { Console.Write(", "); }
            }
            Console.WriteLine("\n");
        }
    }
}
