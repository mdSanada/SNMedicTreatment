using Microsoft.EntityFrameworkCore;
using SNMedicTreatment.Contexts;


namespace SNMedicTreatment.Repositories
{
    public class BaseRepository<T> where T : class
    {
        internal readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Find(int id, int userId)
        {
            return _context.Set<T>().Find(id, userId);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            Delete(entity);
        }
    }
}
