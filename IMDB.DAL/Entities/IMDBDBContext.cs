using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.DAL.Entities
{
    public class IMDBDBContext : DbContext
    {
        public DbSet<WatchList> WatchList { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=62.171.168.156;Initial Catalog=IMDBDB;Persist Security Info=True;User ID=pabuser;Password=u6JVj6lAU9nLJh1FaDpr");
        }
    }
}
