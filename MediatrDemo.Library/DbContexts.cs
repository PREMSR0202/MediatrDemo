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

        public DbContexts(DbContextOptions<DbContexts> options): base(options)
        {

        }

        public DbSet<MovieModel> MovieModel { get; set; }

    }
}
