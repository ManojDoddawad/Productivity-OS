using Microsoft.AspNetCore.Mvc;
using ProductivityOS.Data;
using ProductivityOS.Entities;

namespace ProductivityOS.Controllers
{
    [ApiController]
    [Route("api/journal")]
    public class JournalController : ControllerBase
    {
        private readonly AppDbContext _db;

        public JournalController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Write(DailyJournal journal)
        {
            _db.Journals.Add(journal);
            await _db.SaveChangesAsync();
            return Ok(journal);
        }

        [HttpGet("{date}")]
        public IActionResult GetByDate(DateTime date)
        {
            var journal = _db.Journals.FirstOrDefault(x => x.Date.Date == date.Date);
            if (journal == null) return NotFound();
            return Ok(journal);
        }
    }

}
