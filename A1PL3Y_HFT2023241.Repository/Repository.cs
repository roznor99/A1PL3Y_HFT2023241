﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ProjectDbContext ctx;

        public Repository(ProjectDbContext Ctx)
        {
            this.ctx = Ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}