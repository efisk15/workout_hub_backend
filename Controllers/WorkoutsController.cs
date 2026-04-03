using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly WorkoutService _workoutService;

    public WorkoutsController(WorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Workout>>> Get() =>
        await _workoutService.GetAsync();
    
    [HttpPost]
    public async Task<IActionResult> Post(Workout workout) {
        await _workoutService.CreateAsync(workout);
        return CreatedAtAction(nameof(Get), new {id = workout.Id}, workout);
    }
    [HttpPut]
    public async Task<IActionResult> Put(Workout workout)
    {
        if (workout == null)
        {
            return BadRequest("ID in URL does not match ID in body");
        }

        await _workoutService.UpdateAsync(workout);

        return Ok(workout);
    }
}