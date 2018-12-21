using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Infrastructure
{
    public class MusicContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        public DbSet<BandMember> BandMembers { get; set; }

        public DbSet<Instrument> Instruments { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local); Database = Music; Trusted_Connection = True");
        }
    }
}
