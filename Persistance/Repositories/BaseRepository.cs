using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistance.Repositories
{
    /*
     * This is just an abstract class that all our repositories will inherit.An abstract class is a class that 
     * dont have direct instances. You have to create a direct class to create the instances.
     */
    public abstract class BaseRepository
    {
        //protected -> Only be accessible by the children classes, all the children of BaseRepository
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
