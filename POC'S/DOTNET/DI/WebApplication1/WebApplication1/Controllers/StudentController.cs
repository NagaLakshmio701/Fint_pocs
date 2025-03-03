using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudents _students;

        public StudentController (IStudents students)   //DI
        {
            _students = students;
        }

        [HttpGet]
        public ActionResult GetAllStudents()
        {
           List<string> s=  _students.GetStudents();

            return Ok(s);
        }
        [HttpGet]
        public ActionResult GetID()
        {
            Guid ID=_students.GenerateID();
            return Ok(ID);
        }

    }
}
