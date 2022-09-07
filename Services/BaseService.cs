//namespace SNMedicTreatment.Services
//{
//    public class BaseService<R> where R : class
//    {
//        internal readonly Context _context;

//        public BaseService(Context context)
//        {
//            _context = context;
//        }

//        public void Create(T entity)
//        {
//            _context.Set<T>().Add(entity);
//            _context.SaveChanges();
//        }

//        public T Find(int id)
//        {
//            return _context.Set<T>().Find(id);
//        }

//        public T Find(int id, int userId)
//        {
//            return _context.Set<T>().Find(id, userId);
//        }

//        public void Update(T entity)
//        {
//            _context.Entry(entity).State = EntityState.Modified;
//            _context.SaveChanges();
//        }

//        public void Delete(T entity)
//        {
//            _context.Set<T>().Remove(entity);
//            _context.SaveChanges();
//        }
//    }
//}
