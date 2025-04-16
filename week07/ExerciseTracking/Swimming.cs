public class Swimming : Activity
{
    private int _laps;
    private const double MetersPerLap = 50;
    private const double MetersPerMile = 1609.34;

    public Swimming(DateTime date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    protected override double GetDistance()
    {
        return _laps * MetersPerLap / MetersPerMile;
    }

    protected override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }

    protected override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}