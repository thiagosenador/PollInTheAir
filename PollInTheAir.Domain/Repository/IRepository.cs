namespace PollInTheAir.Domain.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using PollInTheAir.Domain.Models;

    public interface IRepository<T> : IDisposable where T : Entity
    {
        int Count { get; }

        IQueryable<T> All();

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        IQueryable<T> Filter<Key>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        bool Contains(Expression<Func<T, bool>> predicate);

        T Find(params object[] keys);

        T Find(Expression<Func<T, bool>> predicate);

        T Create(T obj);

        void Delete(T t);

        void Delete(Expression<Func<T, bool>> predicate);

        void Update(T obj);
    }
}