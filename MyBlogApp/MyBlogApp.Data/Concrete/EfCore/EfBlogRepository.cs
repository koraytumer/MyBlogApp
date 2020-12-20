using MyBlogApp.Data.Abstract;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogApp.Data.Concrete.EfCore
{
    public class EfBlogRepository : IBlogRepository
    {
        private BlogContext context;
        public EfBlogRepository(BlogContext _context)
        {
            context = _context;
        }
        public void AddBlog(Blog entity)
        {
            context.Blogs.Add(entity);
            context.SaveChanges();
        }
        public void DeleteBlog(int blogId)
        {
            var blog = context.Blogs.FirstOrDefault(x => x.BlogId == blogId);
            if (blog != null)
            {
                context.Blogs.Remove(blog);
                context.SaveChanges();
            }
        }
        public IQueryable<Blog> GetAll()
        {
            return context.Blogs;
        }
        public Blog GetById(int blogId)
        {
            return context.Blogs.FirstOrDefault(x => x.BlogId == blogId);
        }
        public void SaveBlog(Blog entity)
        {
            if (entity.BlogId == 0)
            {
                entity.Date = DateTime.Now;
                context.Blogs.Add(entity);
            }
            else
            {
                var blog = GetById(entity.BlogId);
                if (blog != null)
                {
                    blog.Title = entity.Title;
                    blog.Description = entity.Description;
                    blog.CategoryId = entity.CategoryId;
                    blog.Image = entity.Image;
                    blog.isHome = entity.isHome;
                    blog.isApproved = entity.isApproved;
                    blog.isSlider = entity.isSlider;
                    blog.Body = entity.Body;
                }
            }
            context.SaveChanges();
        }
        public void UpdateBlog(Blog entity)
        {
            var blog = GetById(entity.BlogId);
            if (blog != null)
            {
                blog.Title = entity.Title;
                blog.Description = entity.Description;
                blog.CategoryId = entity.CategoryId;
                blog.Image = entity.Image;

                context.SaveChanges();
            }
            context.SaveChanges();
        }
    }
}
