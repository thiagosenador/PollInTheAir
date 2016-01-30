namespace PollInTheAir.Domain.Repository.Impl
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using PollInTheAir.Domain.Models;

    public class Repository<TObject> : IRepository<TObject> where TObject : Entity
    {
        private readonly AppDbContext context;

        public Repository()
        {
            this.context = new AppDbContext();
        }

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public virtual int Count
        {
            get
            {
                return this.DbSet.Count();
            }
        }

        protected DbSet<TObject> DbSet
        {
            get
            {
                return this.context.Set<TObject>();
            }
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        public virtual IQueryable<TObject> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return this.DbSet.Where(predicate).AsQueryable();
        }

        public virtual IQueryable<TObject> Filter<Key>(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? this.DbSet.Where(filter).AsQueryable() : this.DbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<TObject, bool>> predicate)
        {
            return this.DbSet.Count(predicate) > 0;
        }

        public virtual TObject Find(params object[] keys)
        {
            return this.DbSet.Find(keys);
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return this.DbSet.FirstOrDefault(predicate);
        }

        public virtual TObject Create(TObject obj)
        {
            var newEntry = this.DbSet.Add(obj);

            this.context.SaveChanges();

            return newEntry;
        }

        public virtual void Delete(TObject t)
        {
            this.DbSet.Remove(t);

            this.context.SaveChanges();
        }

        public virtual void Delete(Expression<Func<TObject, bool>> predicate)
        {
            var objects = this.Filter(predicate);

            foreach (var obj in objects)
            {
                this.DbSet.Remove(obj);
            }

            this.context.SaveChanges();
        }

        public virtual void Update(TObject obj)
        {
            var entry = this.context.Entry(obj);

            this.DbSet.Attach(obj);

            entry.State = EntityState.Modified;

            this.context.SaveChanges();
        }
    }
}
