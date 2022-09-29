using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_Movie_Library_Abstract_Class.Models
{
    public class Movie : Media
    {
        public Movie()
        {
            Title = "";
            Genres = new List<string>();
        }

        public List<string> Genres { get; set; }

        public override void Read(string line)
        {
            string[] movieDetails = line.Split(',');
            string[] movieGenres = movieDetails[2].Split('|');

            Id = int.Parse(movieDetails[0]);
            Title = movieDetails[1];

            for(int i = 0; i < movieGenres.Length; i++)
            { Genres.Add(movieGenres[i]); }
        }
        public override void Display()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.Write("Genre(s): ");
            for(int i = 0; i < Genres.Count; i++)
            { 
                Console.Write(Genres[i]);
                if (i != Genres.Count - 1) { Console.Write(", "); }
            }
            Console.WriteLine("\n");
        }
    }
}
