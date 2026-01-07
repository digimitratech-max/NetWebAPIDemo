using StudentRegistration.Business.Responses;
using StudentRegistration.Data.Entities;
using StudentRegistration.Data.UnitOfWork;

namespace StudentRegistration.Business.Services
{
    public class StudentService
    {
        private readonly UnitOfWork _uow = UnitOfWork.Instance;

        public ApiResponse<IEnumerable<Student>> GetAll()
        {
            return new ApiResponse<IEnumerable<Student>>
            {
                Success = true,
                Data = _uow.Students.GetAll()
            };
        }

        public async Task<ApiResponse<Student>> RegisterAsync(Student student)
        {
            student.RegisteredOn = DateTime.Now;

            var result = await _uow.Students.CreateAsync(student);

            return new ApiResponse<Student>
            {
                Success = true,
                Message = "Student Registered Successfully",
                Data = result
            };
        }

        public ApiResponse<Student> Update(Student student)
        {
            var updated = _uow.Students.Update(student);

            return new ApiResponse<Student>
            {
                Success = true,
                Message = "Student Updated",
                Data = updated
            };
        }

        public ApiResponse<bool> Delete(int id)
        {
            _uow.Students.Delete(id);

            return new ApiResponse<bool>
            {
                Success = true,
                Message = "Student Deleted",
                Data = true
            };
        }
    }
}
