using System;
using System.Collections.Generic;
using System.Linq;

namespace Level5_DDD
{
    // 264. Repository Pattern (Generic).
    // This abstracts the data access logic. The application doesn't care if data 
    // comes from SQL, NoSQL, or an API.

    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }

    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _storage = new();
        public void Add(T entity) => _storage.Add(entity);
        public T GetById(int id) => _storage.FirstOrDefault(); // Simplified
        public IEnumerable<T> GetAll() => _storage;
    }

    class Program
    {
        static void Main() => Console.WriteLine("--- Repository Pattern (Generic) Initialized ---");
    }
}