using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public Db(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Report> Reports { get; set; } 
        public DbSet<ScoutReport> ScoutReports { get; set; } 
        public DbSet<Scout> Scouts { get; set; }
        public DbSet<ClubScout> ClubScouts { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<SportifDirector> SportifDirectors { get; set; }

        public DbSet<TargetList> TargetLists { get; set; }

        public DbSet<TargetListReport> TargetListReports { get; set; }




    }
}
