public class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _current = 0;
    }

    public override int RecordEvent()
    {
        _current++;
        if (_current == _target)
        {
            _isComplete = true;
            return _points + _bonus;
        }
        return _points;
    }

    public override string GetDisplayString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Currently completed: {_current}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name}|{_description}|{_points}|{_target}|{_bonus}|{_current}";
    }
}