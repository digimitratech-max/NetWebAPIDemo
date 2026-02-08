using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Business.Responses;
using StudentRegistration.Business.Services;
using StudentRegistration.Data.Entities;

namespace StudentRegistration.API.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service = new StudentService();

        [HttpGet]
        [Route("Getall")]
        public IActionResult GetAll()
        {
            
            return Ok(_service.GetAll());
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ApiResponse<Student>> Register(Student student)
        {
            var response = await _service.RegisterAsync(student);
            return response;
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult Update(Student student)
        {
            return Ok(_service.Update(student));
        }

        [HttpDelete("{id}")]        
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
