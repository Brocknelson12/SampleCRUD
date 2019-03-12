using System.Collections.Generic;
using WorkoutApi.Models;
using WorkoutApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _workoutService;

        public EventController(EventService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public ActionResult<List<Event>> Get()
        {
            return _workoutService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetEvent")]
        public ActionResult<Event> Get(string id)
        {
            var workout = _workoutService.Get(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        [HttpPost]
        public ActionResult<Event> Create(Event workout)
        {
            _workoutService.Create(workout);

            return CreatedAtRoute("GetEvent", new { id = workout.id.ToString() }, workout);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Event workoutIn)
        {
            var workout = _workoutService.Get(id);

            if (workout == null)
            {
                return NotFound();
            }

            _workoutService.Update(id, workoutIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var workout = _workoutService.Get(id);

            if (workout == null)
            {
                return NotFound();
            }

            _workoutService.Remove(workout.id);

            return NoContent();
        }
    }
}