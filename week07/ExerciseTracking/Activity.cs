public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Abstract methods that must be implemented by derived classes
    protected abstract double GetDistance();
    protected abstract double GetSpeed();
    protected abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_lengthInMinutes} min) - " +
               $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }

    // Protected getter for derived classes
    protected int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }
}