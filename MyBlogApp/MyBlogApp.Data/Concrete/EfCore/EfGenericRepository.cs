﻿using Microsoft.EntityFrameworkCore;
using MyBlogApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlogApp.Data.Concrete.EfCore
{
    public class EfGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public void Create(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public void Update(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
