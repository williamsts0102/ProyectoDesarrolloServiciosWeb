using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository
{
    /*llamaremos una clase generica T, donde T sera una clase*/
    public interface IRepository<T> where T : class
    {
        /*T Categorias*/
        /*recuperar todas las categorias*/
        IEnumerable<T> GetAll(string? includeProperties = null);
        /*recuperar solo una categoria*/
        /*resultara un valor booleano*/
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool rastrear =false);

        /*eleminar categoria*/
        void Add(T entity);
        void Remove(T entity);
        /*para eliminar varias categorias de una sola*/
        void RemoveRange (IEnumerable<T> entity);
    }
}
