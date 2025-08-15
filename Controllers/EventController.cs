using Microsoft.AspNetCore.Mvc;

namespace event_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        // Startdata – samma som din kalender visar just nu
        private static List<EventItem> Events = new()
        {
            new EventItem { Id = 1, Title = "Vendor Feedback",    Date = "2029-05-02", Type = "schedule" },
            new EventItem { Id = 2, Title = "Final Event Report",  Date = "2029-05-04", Type = "event" },
            new EventItem { Id = 3, Title = "Team Check-in",       Date = "2029-05-07", Type = "meeting" },
            new EventItem { Id = 4, Title = "Stage Setup",         Date = "2029-05-10", Type = "setup" },
            new EventItem { Id = 5, Title = "Echo Beats Festival", Date = "2029-05-15", Type = "event" }
        };

        private static int nextId = 6;

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(Events);
        }

        [HttpPost]
        public IActionResult AddEvent(EventItem newEvent)
        {
            newEvent.Id = nextId++;
            Events.Add(newEvent);
            return Ok(newEvent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var ev = Events.FirstOrDefault(e => e.Id == id);
            if (ev == null) return NotFound();
            Events.Remove(ev);
            return NoContent();
        }
    }

    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Date { get; set; } = ""; // YYYY-MM-DD
        public string Type { get; set; } = ""; // schedule, event, meeting, setup
        public string? Location { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
    }
}