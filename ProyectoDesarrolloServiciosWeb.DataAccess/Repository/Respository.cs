using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ProyectoDesarrolloServiciosWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Repository
{
    /*implementara IRpository*/
    public class Repository<T> : IRepository<T> where T : class
    {
        /*para la conexion a base de datos*/
        private readonly ApplicationDbContext _db;
        /*conjunto de entidades*/
        internal DbSet<T> dbSet; 
        
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            /*establece bdSet como el conjunto de entidades tipo T*/
            this.dbSet = _db.Set<T>();
            _db.producto.Include(u => u.Categoria).Include(u => u.categoriaId);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[]
                    {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string ? includeProperties=null)
        {
            IQueryable<T> query = dbSet;

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(new char[]
                    {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }


    }
}
