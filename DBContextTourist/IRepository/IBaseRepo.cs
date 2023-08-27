using System;
using System.Collections.Generic;
using System.Text;

namespace DBContextTourist.IRepository
{
    public interface IBaseRepo<Entity> where Entity : class
    {
        public void Add(Entity entity);

        public void Update(Entity entity);

        void Delete(Entity entity);

        IEnumerable<Entity> GetAll();

        Entity GetByID(int id);

        IEnumerable<Entity> GetAllByCondition(Func<Entity, bool> condition);

    }
}
