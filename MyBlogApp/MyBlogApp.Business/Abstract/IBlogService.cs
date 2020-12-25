using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogApp.Business.Abstract
{
    public interface IBlogService
    {
        Blog GetById(int id);
        List<Blog> GetAll();
        void Create(Blog entity);
        void Update(Blog entity);
        void Delete(Blog entity);
    }
}
