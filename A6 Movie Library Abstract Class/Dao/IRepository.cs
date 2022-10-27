using A6_Movie_Library_Abstract_Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_Movie_Library_Abstract_Class.Dao
{
    internal interface IRepository<T> where T : Media
    {
        IEnumerable<T> Get();
    }
}
