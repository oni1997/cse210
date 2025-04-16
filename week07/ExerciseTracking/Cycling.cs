public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed) 
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    protected override double GetDistance()
    {
        return (_speed * GetLengthInMinutes()) / 60;
    }

    protected override double GetSpeed()
    {
        return _speed;
    }

    protected override double GetPace()
    {
        return 60 / _speed;
    }
}