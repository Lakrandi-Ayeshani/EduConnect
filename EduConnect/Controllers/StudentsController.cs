using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduConnect.Models;
using MongoDB.Driver;
using EduConnect.Services;

namespace EduConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly StudentContext _context;
        private readonly StudentsService _studentsService;

        //public StudentsController(StudentContext context)
        public StudentsController(StudentsService studentsService)
        {
            ///_context = context;
            _studentsService = studentsService;
        }

        [HttpGet]
        public async Task<List<Student>> Get() =>
           await _studentsService.GetAsync();


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Student>> Get(string id)
        {
            var student = await _studentsService.GetAsync(id);

            if (student is null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student newStudent)
        {
            await _studentsService.CreateAsync(newStudent);

            return CreatedAtAction(nameof(Get), new { id = newStudent.Id }, newStudent);
        }

        // GET: api/Students
        /* [HttpGet]
         public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
         {
             return await _context.Students.ToListAsync();
         }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(string id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(string id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        */
    }
}
