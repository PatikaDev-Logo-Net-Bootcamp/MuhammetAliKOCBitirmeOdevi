using EntityFramework.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetAll()
        {
            return unitOfWork.Context.Set<T>().AsQueryable();
        }

        public void Add(T entity)
        {
            unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Deleted;
        }

        //public IQueryable<T> Get()
        //{
        //    return unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        //}
    }
}
