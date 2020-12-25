using MyBlogApp.Data.Abstract;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogApp.Data.Concrete.EfCore
{
    public class EfBlogRepository : EfGenericRepository<Blog, BlogContext>, IBlogRepository
    {

    }
}
