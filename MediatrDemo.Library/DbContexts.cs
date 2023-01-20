using MediatrDemo.Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Library
{
    public class DbContexts : DbContext
    {

        protected override void OnConfiguring
            (DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "Movies");
        }

        public DbSet<MovieModel> MovieModel { get; set; }

    }
}
