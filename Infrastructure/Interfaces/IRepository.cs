using System;
using System.Collections.Generic;
using Core.Interfaces;

namespace Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid id);
        void Add(TEntity entity);
    }
}
