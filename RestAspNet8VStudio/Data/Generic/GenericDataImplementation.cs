using Microsoft.EntityFrameworkCore;
using RestAspNet8VStudio.Model.Base;
using RestAspNet8VStudio.Model.Context;

namespace RestAspNet8VStudio.Data.Implementations
{
    public class GenericDataImplementation<T> : IGenericData<T> where T : BaseEntity
    {
        private PostgreSQLContext _context;
        private DbSet<T> dataSet;

        public GenericDataImplementation(PostgreSQLContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
            return item;
        }

        public T Delete(long id)
        {
            var result = dataSet.SingleOrDefault(u => u.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            } else
            {
                return null;
            }
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }
        public T FindByID(long id)
        {
            return dataSet.SingleOrDefault(u => u.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;
            var result = dataSet.SingleOrDefault(u => u.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }
        private bool Exists(long id)
        {
            return dataSet.Any(u => u.Id.Equals(id));
        }
    }
}
