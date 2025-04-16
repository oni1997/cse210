public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance) 
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    protected override double GetDistance()
    {
        return _distance;
    }

    protected override double GetSpeed()
    {
        return (_distance / GetLengthInMinutes()) * 60;
    }

    protected override double GetPace()
    {
        return GetLengthInMinutes() / _distance;
    }
}