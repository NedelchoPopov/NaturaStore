﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey>
    where TEntity : class
    {
        TEntity? GetById(TKey id);
        TEntity? SingleOrDefault(Func<TEntity, bool> predicate);
        TEntity? FirstOrDefault(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetAllAttached();
        int Count();
        void Add(TEntity item);
        void AddRange(IEnumerable<TEntity> items);
        bool Delete(TEntity entity);
        bool HardDelete(TEntity entity);
        bool Update(TEntity item);
        void SaveChanges();
    }
}
