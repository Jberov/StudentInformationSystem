using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class UserContext : DbContext
    {
        public DbSet<UserLogin.User> Students { get; set; }
        public UserContext() : base(Properties.Settings.Default.DbConnect)
        { }
    }
}
