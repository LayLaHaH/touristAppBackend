using DBContextTourist.IRepository;
using DBContextTourist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoriesAndUOW.Reopsitory
{
    internal class BaseRepo<Entity> : IBaseRepo<Entity> where Entity : class
    {
        protected readonly touristsContext _touristsContext;
        public BaseRepo(touristsContext touristsContext)
        {
            _touristsContext = touristsContext;
        }
        void IBaseRepo<Entity>.Add(Entity entity)
        {
            _touristsContext.Set<Entity>().Add(entity);
        }

        void IBaseRepo<Entity>.Delete(Entity entity)
        {
            _touristsContext.Set<Entity>().Remove(entity);
        }

        Entity IBaseRepo<Entity>.GetByID(int id)
        {
            return _touristsContext.Set<Entity>().Find(id);
        }

        IEnumerable<Entity> IBaseRepo<Entity>.GetAll()
        {
            return _touristsContext.Set<Entity>().ToList();
        }

        void IBaseRepo<Entity>.Update(Entity entity)
        {
            _touristsContext.Set<Entity>().Update(entity);
        }
        IEnumerable<Entity> IBaseRepo<Entity>.GetAllByCondition(Func<Entity, bool> condition)
        {
            return _touristsContext.Set<Entity>().Where(condition);
        }
    }
}
