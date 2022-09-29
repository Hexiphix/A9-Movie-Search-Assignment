using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_Movie_Library_Abstract_Class.Models
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public abstract void Read(string line);
        public abstract void Display();
    }
}
