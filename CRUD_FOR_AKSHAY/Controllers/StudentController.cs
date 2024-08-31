using CRUD_FOR_AKSHAY.Data;
using CRUD_FOR_AKSHAY.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_FOR_AKSHAY.Controllers
{
    [Route("api/[controller]")]
    //7200/Student/
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StduentDbContext dbContext;

        public StudentController(StduentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //7200/Student/GetAllStudents
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = dbContext.Students;
            return Ok(students);
        }
        [HttpPost]
        //7200/Student/AddNewStudent

        public IActionResult AddNewStudent(CreateStudentDTO student)
        {

            //If student is not valid return Bad request
            var employeeEntity = new Student()
            {
                FullName = student.FullName,
                Standard = student.Standard,
            };
            dbContext.Students.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            if (id == null)
            {
                return BadRequest("Enter Id");
            }
            var getStudent = dbContext.Students.Find(id);
            if (getStudent.Id != id)
            {
                return NotFound("Data not found");
            }
            return Ok(getStudent);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult studentDelete(int id)
        {
            var getStudent = dbContext.Students.Find(id);
            dbContext.Students.Remove(getStudent);
            dbContext.SaveChanges();
            return Ok("Student Deleted");
        }
        //Hello
    }
}
