using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UsersApp
{
    class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppContext() : base("DefaultConnection") { }
    }
}
