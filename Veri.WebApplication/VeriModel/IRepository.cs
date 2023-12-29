using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veri.DBContext; 

namespace Veri
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        List<TEntity> GetAll();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected MyDBContext _dbContext ;
        public Repository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TEntity> GetAll()
        {
            return this._dbContext.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return this._dbContext.Set<TEntity>().Find(new object[]
                {
                    id
                });
        }
    }
}
