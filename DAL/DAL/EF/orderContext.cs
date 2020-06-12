using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.EF
{
    public class orderContext
        : DbContext
    {
        public DbSet<added> Added { get; set; }
        public DbSet<location> Location { get; set; }
        public DbSet<@operator> Operator { get; set; }
        public DbSet<situation> Situation { get; set; }
        public orderContext(DbContextOptions options)
            : base(options) { }
    }
}