internal abstract class Goal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public abstract string StatusMark { get; }
    public abstract string Details { get; }
    public abstract int RecordEvent();
    public abstract GoalData ToData();

    public static Goal FromData(GoalData data) => data.Type switch
    {
        "simple" => new SimpleGoal(data.Name, data.Description, data.Points, data.Completed),
        "eternal" => new EternalGoal(data.Name, data.Description, data.Points, data.Count),
        "checklist" => new ChecklistGoal(data.Name, data.Description, data.Points, data.Target, data.Bonus, data.Count),
        _ => throw new InvalidDataException($"Unknown goal type '{data.Type}'.")
    };
}
