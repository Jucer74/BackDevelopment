using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsAPI.Context;
using StudentsAPI.Exceptions;
using StudentsAPI.Models;

namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppdbContext _context;

        public StudentsController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            if (_context.Students == null)
            {
                //return NotFound();
                throw new InvalidOperationException("The Students DbSet is not initialized.");

            }
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            if (_context.Students == null)
            {
                //return NotFound();
                throw new InvalidOperationException("The Students DbSet is not initialized.");
            }
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                //return NotFound();
                throw new NotFoundException($"Student:{id} was not found.");
            }
           
            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                //return BadRequest();
                throw new BadRequestException("Student ID does not match the provided data.");
            }

            if (!StudentExists(id))
            {
                throw new NotFoundException($"Student:{id} was not found.");
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Este bloque se activará si hay un conflicto de concurrencia real
                throw new Exception("A concurrency error occurred.", ex);
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            if (_context.Students == null)
            {
                //return NotFound();
                throw new InvalidOperationException("The Students DbSet is not initialized.");
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Students == null)
            {
                //return NotFound();
                throw new InvalidOperationException("The Students DbSet is not initialized.");
            }
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                //return NotFound();
                throw new NotFoundException($"Student:{id} was not found.");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}