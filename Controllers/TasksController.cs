using Microsoft.AspNetCore.Mvc;
using ProductivityOS.Data;
using ProductivityOS.Entities;

namespace ProductivityOS.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TasksController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return Ok(task);
        }

        [HttpGet("pending")]
        public IActionResult GetPending()
        {
            return Ok(_db.Tasks.Where(x => !x.IsCompleted).ToList());
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            task.IsCompleted = true;
            await _db.SaveChangesAsync();
            return Ok(task);
        }
    }

}
