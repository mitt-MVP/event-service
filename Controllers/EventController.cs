using Microsoft.AspNetCore.Mvc;

namespace event_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private static List<EventItem> Events = new()
        {
            new EventItem { Id = 1, Name = "Music Festival" },
            new EventItem { Id = 2, Name = "Art Exhibition" }
        };

        private static int nextId = 3; // håller koll på nästa unika ID

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
        public string Name { get; set; }
    }
}