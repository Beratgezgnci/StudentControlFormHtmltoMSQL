using BE105_WEEK_8.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BE105_WEEK_8.DTOs;
using BE105_WEEK_8.Entities;

namespace BE105_WEEK_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            if (_context.Students.Count() == 0)
            {
                return NotFound();
            }
            var students = _context.Students.ToList();
            return Ok(students);
        }
        [HttpPost]
        public IActionResult Add([FromBody] StudentCreateDTO dto)
        {
            if(!ModelState.IsValid)  
                return BadRequest();
            Student _student = _context.Students.Where(u => u.StudentNumber == dto.StudentNumber).FirstOrDefault();
            if (_student !=null)
                    return BadRequest();

            Student student = new Student
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                StudentNumber = dto.StudentNumber,
                BirthDate = dto.BirthDate,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok();
            
        }
        [HttpPut]
        public IActionResult Update([FromBody] StudentUpdateDTO dto)
        {
            bool stuExist = _context.Students.Any(u => u.Id == dto.Id);
            if (stuExist == null )
                return NotFound();
            
            Student _student = _context.Students.Where(u=>u.StudentNumber == dto.StudentNumber).FirstOrDefault();
            if (_student != null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Student student = new Student
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                StudentNumber = dto.StudentNumber,
                BirthDate = dto.BirthDate,
                Lastname = dto.Lastname,
                LastUpdatedAt = DateTime.Now,
            };
            _context.Students.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var studentToDelete = _context.Students.Find(id);
            if (studentToDelete == null)
                return NotFound();
            _context.Remove(studentToDelete);
            _context.SaveChanges();
            return Ok();
        }
    }
}
