using Microsoft.EntityFrameworkCore;
using SampleWebWidMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebWidMVC.DBContext
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions<SampleDBContext> options)
           : base(options)
        {
        }
        public DbSet<BooksModel> BooksDbSet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksModel>().ToTable("Books");
        }
    }
}
