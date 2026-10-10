internal sealed class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points) => _completed = completed;

    public override string StatusMark => _completed ? "[X]" : "[ ]";
    public override string Details => $"Simple goal, {Points} points";

    public override int RecordEvent()
    {
        if (_completed) return 0;
        _completed = true;
        return Points;
    }

    public override GoalData ToData() => new("simple", Name, Description, Points, Completed: _completed);
}
