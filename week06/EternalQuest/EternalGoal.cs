internal sealed class EternalGoal : Goal
{
    private int _count;

    public EternalGoal(string name, string description, int points, int count = 0)
        : base(name, description, points) => _count = Math.Max(0, count);

    public override string StatusMark => "[∞]";
    public override string Details => $"Eternal goal, completed {_count} times; {Points} points each time";
    public override int RecordEvent() { _count++; return Points; }
    public override GoalData ToData() => new("eternal", Name, Description, Points, Count: _count);
}
