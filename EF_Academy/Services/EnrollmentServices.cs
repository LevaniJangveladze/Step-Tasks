using EF_Academy.Data;

namespace EF_Academy.Services;
  
internal class EnrollmentServices
    {
        private readonly DataContext _db;
        public EnrollmentServices(DataContext db)
        {
            _db = db;
        }

        public void create()
        {
            var course = _db.Courses.ToList();
            Courses
        }
    }
