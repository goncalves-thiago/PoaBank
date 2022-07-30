using System.Collections.Generic;

namespace PoaBank.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> Get();

        public T Get(int id);

        public void Create(T model);

        public void Update(T model);

        public void Delete(T model);

        public void Delete(int id);
    }
}
