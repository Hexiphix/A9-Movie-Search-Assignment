using A6_Movie_Library_Abstract_Class.Dao;
using A6_Movie_Library_Abstract_Class.Models;
using System.Runtime.CompilerServices;

namespace A6_Movie_Library_Abstract_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Media> media = new List<Media>();
            string _fileName;
            string choice;

            Console.WriteLine("Enter the number of the info you want");
            Console.WriteLine("1) Display Movies");
            Console.WriteLine("2) Display Shows");
            Console.WriteLine("3) Display Videos");
            Console.WriteLine("4) Search For Media By Name");
            Console.WriteLine("X) Quit");

            choice = Console.ReadLine();

            //Ensures the file is properly chosen
            _fileName = $"{Environment.CurrentDirectory}";

            if (choice == "1" || choice == "2" || choice == "3")
            { 
                if (choice == "1")
                {
                    if (_fileName.Substring(_fileName.Length - 16, 16).Equals("bin\\Debug\\net6.0"))
                    {
                        _fileName = _fileName.Remove(_fileName.Length - 16, 16);
                        _fileName = $"{_fileName}movies.csv";
                    }
                    else
                    {
                        _fileName = $"{_fileName}\\movies.csv";
                    }
                }
                else if (choice == "2")
                {
                    if (_fileName.Substring(_fileName.Length - 16, 16).Equals("bin\\Debug\\net6.0"))
                    {
                        _fileName = _fileName.Remove(_fileName.Length - 16, 16);
                        _fileName = $"{_fileName}shows.csv";
                    }
                    else
                    {
                        _fileName = $"{_fileName}\\shows.csv";
                    }
                }
                else if(choice == "3")
                {
                    if (_fileName.Substring(_fileName.Length - 16, 16).Equals("bin\\Debug\\net6.0"))
                    {
                        _fileName = _fileName.Remove(_fileName.Length - 16, 16);
                        _fileName = $"{_fileName}videos.csv";
                    }
                    else
                    {
                        _fileName = $"{_fileName}\\videos.csv";
                    }
                }

                // Attemps to read the given file
                try
                {
                    int i = 0;
                    StreamReader sr = new StreamReader(_fileName);
                    // first line contains column headers
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        if (choice == "1")
                        {
                            media.Add(new Movie());
                            media[i].Read(line);
                        }
                        else if (choice == "2")
                        {
                            media.Add(new Show());
                            media[i].Read(line);
                        }
                        else if (choice == "3")
                        {
                            media.Add(new Video());
                            media[i].Read(line);
                        }

                        i++;
                    }
                    // close file when done
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (choice == "4")
            {
                IRepository<Movie> movieRepo = new Repository<Movie>();
                IRepository<Show> showRepo = new Repository<Show>();
                IRepository<Video> videoRepo = new Repository<Video>();
                List<Media> tempMedia = new List<Media>();
                int i = 0;

                Console.WriteLine("Enter the media's name:");
                var mediaName = Console.ReadLine();

                var movies = movieRepo.Get().ToList();
                movies.ForEach(x => tempMedia.Add(x));
                var shows = showRepo.Get().ToList();
                shows.ForEach(x => tempMedia.Add(x));
                var videos = videoRepo.Get().ToList();
                videos.ForEach(x => tempMedia.Add(x));

                foreach(Media m in tempMedia)
                {
                    if(m.Title.Contains(mediaName, StringComparison.CurrentCultureIgnoreCase) == true)
                    {
                        media.Add(m);
                        i++;
                    }
                }

                Console.Write($"\n\nThe database found a total of {i} things that matched the search \"{mediaName}\"");
            }

            bool foundMovie = false;
            bool foundShow = false;
            bool foundVideo = false;

            Console.WriteLine("\n");
            for (int i = 0; i < media.Count; i++)
            {
                if(choice == "4")
                {
                    if (foundMovie == false && (media[i].GetType()).ToString().Contains("movie", StringComparison.CurrentCultureIgnoreCase) == true)
                    {
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("The following are the movies found on the database");
                        Console.WriteLine("--------------------------------------------------");
                        foundMovie = true;
                    }
                    else if (foundShow == false && (media[i].GetType()).ToString().Contains("show", StringComparison.CurrentCultureIgnoreCase) == true)
                    {
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("The following are the shows found on the database");
                        Console.WriteLine("-------------------------------------------------");
                        foundShow = true;
                    }
                    else if(foundVideo == false && (media[i].GetType()).ToString().Contains("video", StringComparison.CurrentCultureIgnoreCase) == true)
                    {
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("The following are the videos found on the database");
                        Console.WriteLine("--------------------------------------------------");
                        foundVideo = true;
                    }
                }
                else 
                {
                    foundMovie = true;
                    foundShow = true;
                    foundVideo = true;
                }

                media[i].Display();
            }

            if(foundMovie == false)
            { Console.WriteLine("There were no movies that matched your search"); }
            if(foundShow == false)
            { Console.WriteLine("There were no shows that matched your search"); }
            if(foundVideo == false)
            { Console.WriteLine("There were no videos that matched your search"); }
        }
    }
}