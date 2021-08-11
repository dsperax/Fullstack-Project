using Microsoft.EntityFrameworkCore;
using phishing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phishing.Data.Context
{
    public class MyDbContext : DbContext
    {
        //constructo
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        //parametrização do model com o dbset
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pergunta> Pergunta { get; set; }

    }
}
