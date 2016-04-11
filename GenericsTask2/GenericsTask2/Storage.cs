using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsTask2
{
    class Worker
    {
        private readonly Dictionary<Guid, object> _storage;

        public Worker()
        {
            _storage = new Dictionary<Guid, object>();
        }

        public T Add<T>() where T : class, new()
        {
            var @object = new T();
            _storage.Add(Guid.NewGuid(), @object);
            return @object;
        }

        public IEnumerable<Tuple<Guid, T>> GetTuplesByType<T>() where T : class, new() => 
            _storage
            .Where(x => x.Value is T)
            .Select(x => new Tuple<Guid,T>(x.Key, (T)x.Value))
            .ToList();

        public T GetObjectById<T>(Guid id) where T : class, new() => 
            _storage
            .Where(x => x.Key == id && x.Value is T)
            .Select(x => (T)x.Value)
            .FirstOrDefault();
    }
}
