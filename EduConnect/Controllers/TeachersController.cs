using EduConnect.Models;
using EduConnect.Services;
using Microsoft.AspNetCore.Mvc;
using EduConnect.Utils;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using System.Net;

namespace EduConnect.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly TeachersService _teachersService;

    public TeachersController(TeachersService teachersService) =>
        _teachersService = teachersService;

    //GET: api/Teachers
    [HttpGet]
    public async Task<List<TeacherResponseDto>> Get()
    {
        var teachers = await _teachersService.GetAsync();
        // Manual mapping of Teacher to TeacherResponseDto
        return teachers.Select(t => new TeacherResponseDto
        {
            Id = t.Id,
            UserId = t.UserId,
            FirstName = t.FirstName,
            LastName = t.LastName,
            Email = t.Email,
            Contact = t.Contact,
            Role = t.Role,
            ClassAssigned = t.ClassAssigned,
            GuardianClass = t.GuardianClass,
            Subject = t.Subject,
            DateOfBirth = t.DateOfBirth,
            Address = t.Address
        }).ToList();
    }

    //GET: api/Teachers/1
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<TeacherResponseDto>> Get(string id)
    {
        var teacher = await _teachersService.GetAsync(id);

        if (teacher is null)
        {
            return NotFound();
        }

        var teacherResponse = new TeacherResponseDto { 
            Id = teacher.Id,
            UserId = teacher.UserId,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,
            Contact = teacher.Contact,
            Role = teacher.Role,
            ClassAssigned = teacher.ClassAssigned,
            GuardianClass = teacher.GuardianClass,
            Subject = teacher.Subject,
            DateOfBirth = teacher.DateOfBirth,
            Address = teacher.Address
        };

        return Ok(teacherResponse);
    }

    //POST: api/Teachers
    [HttpPost]
    public async Task<IActionResult> Post(Teacher newTeacher)
    {
        await _teachersService.CreateAsync(newTeacher);
        var teacherResponse = new TeacherResponseDto
        {
            Id = newTeacher.Id,
            UserId = newTeacher.UserId,
            FirstName = newTeacher.FirstName,
            LastName = newTeacher.LastName,
            Email = newTeacher.Email,
            Contact = newTeacher.Contact,
            Role = newTeacher.Role,
            ClassAssigned = newTeacher.ClassAssigned,
            GuardianClass = newTeacher.GuardianClass,
            Subject = newTeacher.Subject,
            DateOfBirth = newTeacher.DateOfBirth,
            Address = newTeacher.Address
        };

        return CreatedAtAction(nameof(Get), new { id = newTeacher.Id }, teacherResponse);
    }

    //PUT: api/Teachers/1
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Teacher updatedTeacher)
    {
        var teacher = await _teachersService.GetAsync(id);

        if (teacher is null)
        {
            return NotFound();
        }

        updatedTeacher.Id = teacher.Id;

        updatedTeacher.UserId = updatedTeacher.UserId ?? teacher.UserId;
        updatedTeacher.FirstName = updatedTeacher.FirstName ?? teacher.FirstName;
        updatedTeacher.LastName = updatedTeacher.LastName?? teacher.LastName;
        updatedTeacher.Email = updatedTeacher.Email?? teacher.Email;
        updatedTeacher.Contact = updatedTeacher.Contact?? teacher.Contact;
        updatedTeacher.Role = updatedTeacher.Role?? teacher.Role;
        updatedTeacher.ClassAssigned = updatedTeacher.ClassAssigned ?? teacher.ClassAssigned;
        updatedTeacher.GuardianClass = updatedTeacher.GuardianClass?? teacher.GuardianClass;
        updatedTeacher.Subject = updatedTeacher.Subject ?? teacher.Subject;
        updatedTeacher.DateOfBirth = updatedTeacher.DateOfBirth?? teacher.DateOfBirth;
        updatedTeacher.Address = updatedTeacher.Address?? teacher.Address;
        updatedTeacher.Password = updatedTeacher.Password ?? teacher.Password;
        updatedTeacher.ComfirmPassword = updatedTeacher.ComfirmPassword ?? teacher.ComfirmPassword;
        

        await _teachersService.UpdateAsync(id, updatedTeacher);

        return Ok($"{updatedTeacher.FirstName} updated successfully");

        // return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _teachersService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _teachersService.RemoveAsync(id);

        return NoContent();
    }
}



/*
[HttpGet]
public async Task<List<Teacher>> Get() =>
    await _teachersService.GetAsync();

[HttpGet("{id:length(24)}")]
public async Task<ActionResult<Teacher>> Get(string id)
{
    var teacher = await _teachersService.GetAsync(id);

    if (teacher is null)
    {
        return NotFound();
    }

    return teacher;
}

[HttpPost]
public async Task<IActionResult> Post(Teacher newTeacher)
{
    await _teachersService.CreateAsync(newTeacher);

    return CreatedAtAction(nameof(Get), new { id = newTeacher.Id }, newTeacher);
}

[HttpPut("{id:length(24)}")]
public async Task<IActionResult> Update(string id, Teacher updatedTeacher)
{
    var book = await _teachersService.GetAsync(id);

    if (book is null)
    {
        return NotFound();
    }

    updatedTeacher.Id = book.Id;

    await _teachersService.UpdateAsync(id, updatedTeacher);

    return NoContent();
}

[HttpDelete("{id:length(24)}")]
public async Task<IActionResult> Delete(string id)
{
    var book = await _teachersService.GetAsync(id);

    if (book is null)
    {
        return NotFound();
    }

    await _teachersService.RemoveAsync(id);

    return NoContent();
}
}
*/

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduConnect.Models;

namespace EduConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly TeacherContext _context;

        public TeachersController(TeacherContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(string id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(string id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeacherExists(teacher.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(string id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherExists(string id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
*/