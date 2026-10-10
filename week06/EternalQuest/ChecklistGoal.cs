internal sealed class ChecklistGoal : Goal
{
    private readonly int _target;
    private readonly int _bonus;
    private int _count;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int count = 0)
        : base(name, description, points)
    {
        _target = Math.Max(1, target);
        _bonus = Math.Max(0, bonus);
        _count = Math.Clamp(count, 0, _target);
    }

    public override string StatusMark => _count >= _target ? "[X]" : "[ ]";
    public override string Details => $"Checklist: {_count}/{_target} times, {Points} points each, {_bonus} bonus on completion";

    public override int RecordEvent()
    {
        if (_count >= _target) return 0;
        _count++;
        return Points + (_count == _target ? _bonus : 0);
    }

    public override GoalData ToData() => new("checklist", Name, Description, Points, Count: _count, Target: _target, Bonus: _bonus);
}
