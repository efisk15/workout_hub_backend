using MongoDB.Driver;

public class WorkoutService
{
    private readonly IMongoCollection<Workout> _workouts;
    public WorkoutService(IConfiguration config)
    {
        var mongoClient = new MongoClient(
            config["MongoSettings:ConnectionString"]);

        var database = mongoClient.GetDatabase(
            config["MongoSettings:DatabaseName"]);
        
        _workouts = database.GetCollection<Workout>(
            config["MongoSettings:WorkoutCollectionName"]);
    }

    public async Task<List<Workout>> GetAsync() =>
        await _workouts.Find(_ => true).ToListAsync();
    public async Task CreateAsync(Workout workout) =>
        await _workouts.InsertOneAsync(workout);
    public async Task<bool> UpdateAsync(Workout updatedWorkout)
    {
        var result = await _workouts.ReplaceOneAsync(
            x => x.Id == updatedWorkout.Id,
            updatedWorkout
        );

        return result.ModifiedCount > 0;
    }
}