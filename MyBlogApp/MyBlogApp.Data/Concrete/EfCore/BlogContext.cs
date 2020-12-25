using Microsoft.EntityFrameworkCore;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogApp.Data.Concrete.EfCore
{
    public class BlogContext : DbContext
    {
        //public BlogContext(DbContextOptions<BlogContext> options)
        //    : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyBlogDb;integrated security=true;");
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
