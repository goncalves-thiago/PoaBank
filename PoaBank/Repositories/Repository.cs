using Dapper.Contrib.Extensions;
using PoaBank.Interfaces;
using System.Collections.Generic;

namespace PoaBank.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IBankContext _context;
        public Repository(IBankContext context)
        => _context = context;

        public IEnumerable<T> Get()
        {
            using (var _connection = _context.Connection())
            {
                _connection.Open();
                return _connection.GetAll<T>();
            }
        }

        public T Get(int id)
        {
            using (var _connection = _context.Connection())
            {
                _connection.Open();
                return _connection.Get<T>(id);
            }
        }

        public void Create(T model)
        {
            using (var _connection = _context.Connection())
            {
                _connection.Open();
                _connection.Insert<T>(model);
            }
        }

        public void Update(T model)
        {
            using (var _connection = _context.Connection())
            {
                _connection.Open();
                _connection.Update<T>(model);
            }
        }

        public void Delete(T model)
        {
            using (var _connection = _context.Connection())
            {
                _connection.Open();
                _connection.Delete<T>(model);
            }
        }

        public void Delete(int id)
        {
            using (var _connection = _context.Connection())
            {
                _connection.Open();
                var model = _connection.Get<T>(id);
                _connection.Delete(model);
            }
        }
    }
}
