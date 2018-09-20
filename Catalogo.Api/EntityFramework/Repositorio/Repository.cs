using Catalogo.Api.EntityFramework.DataSource;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Catalogo.Api.EntityFramework.Repositorio
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        protected readonly DataContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DataContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj) => DbSet.Add(obj);

        public virtual TEntity Find(int id) => DbSet.Find(id);

        public virtual IQueryable<TEntity> FindAll() => DbSet;

        public virtual void Remove(int id) => DbSet.Remove(DbSet.Find(id));

        public int SaveChanges() => Db.SaveChanges();

        public virtual void Update(TEntity obj) => DbSet.Update(obj);

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}