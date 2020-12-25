using MyBlogApp.Business.Abstract;
using MyBlogApp.Data.Abstract;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogApp.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogRepository _blogRepository;
        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public void Create(Blog entity)
        {
            _blogRepository.Create(entity);
        }

        public void Delete(Blog entity)
        {
            _blogRepository.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public Blog GetById(int id)
        {
            return _blogRepository.GetById(id);
        }

        public void Update(Blog entity)
        {
            _blogRepository.Update(entity);
        }
    }
}
