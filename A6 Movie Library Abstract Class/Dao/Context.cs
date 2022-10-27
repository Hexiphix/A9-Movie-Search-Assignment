using A6_Movie_Library_Abstract_Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_Movie_Library_Abstract_Class.Dao
{
    internal class Context
    {
        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Video> Videos { get; set; }

        public Context()
        {
            Movies = new List<Movie>();
            Shows = new List<Show>();
            Videos = new List<Video>();

            string _fileName = $"{Environment.CurrentDirectory}";

            if (_fileName.Substring(_fileName.Length - 16, 16).Equals("bin\\Debug\\net6.0"))
            {
                _fileName = _fileName.Remove(_fileName.Length - 16, 16);
            }
            else
            {
                _fileName = $"{_fileName}\\";
            }

            try
            {
                int i = 0;
                StreamReader sr = new StreamReader($"{_fileName}movies.csv");

                // first line contains column headers
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Movies.Add(new Movie());
                    Movies[i].Read(line);
                    i++;
                }
                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int i = 0;
                StreamReader sr = new StreamReader($"{_fileName}shows.csv");

                // first line contains column headers
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Shows.Add(new Show());
                    Shows[i].Read(line);
                    i++;
                }
                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int i = 0;
                StreamReader sr = new StreamReader($"{_fileName}videos.csv");

                // first line contains column headers
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Videos.Add(new Video());
                    Videos[i].Read(line);
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

        public List<T> Set<T>()
        {
            var type = typeof(T);
            var contextTables = this.GetType().GetProperties();

            foreach (var property in contextTables)
            {
                if (property.Name.Contains(type.Name))
                {
                    var value = property.GetValue(this, null);
                    return (List<T>)value;
                }
            }

            return null;
        }
    }
}
