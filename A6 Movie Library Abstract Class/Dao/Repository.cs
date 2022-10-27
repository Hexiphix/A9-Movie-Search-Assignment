using A6_Movie_Library_Abstract_Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_Movie_Library_Abstract_Class.Dao
{
    internal class Repository<T> : IRepository<T> where T : Media
    {
        private Context _context;
        private List<T> medias;

        public Repository()
        {
            _context = new Context();
            medias = _context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return medias;
        }
    }
}
