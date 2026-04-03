using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Workout
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}
    public string Name{get; set;} = null!;
    public DateTime Date {get; set;}
    public WorkoutType WorkoutType {get; set;} = null!;
    public List<Exercise> Exercises {get; set;} = new();
    public double TimeToComplete {get; set;}

}

public class Exercise
{
    public string Name {get; set;} = null!;
    public double NumSets {get; set;}
    public double SupersetCode {get; set;}
    public List<SetEntry> Sets {get; set;} = new();
}

public class SetEntry
{
    public double Reps {get; set;}
    public double Weight {get; set;}
    public string Note {get; set;} = null!;
    public bool Complete {get; set;}
}

public class WorkoutType
{
    public bool Chest {get; set;}
    public bool Back {get; set;}
    public bool Shoulder {get; set;}
    public bool AntLeg {get; set;}
    public bool PostLeg {get; set;}
    public bool Abb {get; set;}
    public bool Bicep {get; set;}
    public bool Tricep {get; set;}
}