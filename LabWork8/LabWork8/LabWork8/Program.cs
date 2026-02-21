public class Applicant
{
    public string GPA { get; set; }
    public string SpecifiedGPA { get; set; }
    public int fullName { get; set; }
    public double schoolClass { get; set; }

    public Applicant? this[int GPA, int SpecifiedGPA, int schoolClass]
    {
        //get
        //{
        //    if (GPA > SpecifiedGPA)
        //        Console.WriteLine("Балл абитуриента выше указанного");
        //    if (schoolClass > 10)
        //        Console.WriteLine("Абитуриент закончил одиннадцатый класс");
        //}
        //set { }
    }
}
class Program
{
    static void Main()
    {
        //Console.WriteLine($"FullName: {fullName}, class: {schoolClass}, GPA: {GPA}");
    }
}