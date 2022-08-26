﻿using bbdotnet.Persistence.Configurations;
using bbdotnet.Persistence.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace bbdotnet.Persistence
{
    public class BBDotnetDbContext : DbContext
    {
        public readonly string _connectionString; 

        public BBDotnetDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BBDotnetDbContext).Assembly);
        }

        public DbSet<TopicEntity> Topics { get; set; }

        public DbSet<PostEntity> Posts { get; set; }
    }
}
