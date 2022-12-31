using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest.Models;

namespace WpfTest.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PatternModel> PatternModels { get; set; }
        public DbSet<DailyProgram> DailyPrograms { get; set; }

        public DataContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            if (PatternModels != null)
            {
                modelBuilder.Entity<PatternModel>().HasData(GetPatterns(10));
            }
        }

        private PatternModel[] GetPatterns(int v)
        {
            PatternModel[] patterns = new PatternModel[v];
            for (int i = 0; i < patterns.Length; i++)
            {
                patterns[i] = new PatternModel() { PatternModelId = i + 1, PatternName = "Pattern " + (i + 1) };
            }

            return patterns;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(
           @"Data Source=dailyprograms.db");

    }

}
