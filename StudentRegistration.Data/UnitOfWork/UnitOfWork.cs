using StudentRegistration.Data.DbContext;
using StudentRegistration.Data.Entities;
using StudentRegistration.Data.Repositories;

namespace StudentRegistration.Data.UnitOfWork
{
    public class UnitOfWork
    {
        private static SchoolDbContext _context;
        private static UnitOfWork _instance;

        public static UnitOfWork Instance
        {
            get
            {
                if (_instance == null)
                {
                    _context = new SchoolDbContext();
                    _instance = new UnitOfWork();
                }
                return _instance;
            }
        }

        public GenericRepository<Student> Students
            => new GenericRepository<Student>(_context);
    }
}
