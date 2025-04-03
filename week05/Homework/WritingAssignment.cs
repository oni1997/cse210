public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // now this is using  the GetStudentName method from the base class 
        // to access the private _studentName field
        return $"{_title} by {GetStudentName()}";
    }
}