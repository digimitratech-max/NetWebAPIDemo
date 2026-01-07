using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Register(Student student)
        {
            return Ok(await _service.RegisterAsync(student));
        }

        [HttpPut]
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
