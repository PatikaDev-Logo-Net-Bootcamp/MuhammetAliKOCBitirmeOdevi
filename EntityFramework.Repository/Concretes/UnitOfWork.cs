﻿using EntityFramework.Context;
using EntityFramework.Repository.Abstracts;

namespace EntityFramework.Repository.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext Context { get; }
        public UnitOfWork(AppDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
