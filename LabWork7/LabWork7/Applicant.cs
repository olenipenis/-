class Applicant()
{
    public string fullName {  get; set; }
    public int schoolClass { get; set; }
    public int gpi { get; set; }

    public void Print()
    {
        Console.WriteLine($"{fullName}");
        Console.WriteLine($"{schoolClass}");
        Console.WriteLine($"{gpi}");
    }

    public static Applicant operator ++(Applicant applicant)
    {
        applicant.gpi++;
        return applicant;
    }

    public static Applicant operator +(Applicant applicant, int plus)
    {
        return new Applicant()
        {
            fullName = applicant.fullName,
            schoolClass = applicant.schoolClass,
            gpi = applicant.gpi,
        };
    }

    public static bool operator ==(Applicant applicant1, Applicant applicant2)
    {
        if(ReferenceEquals(applicant1, applicant2))
            return true;
        return applicant1.fullName == applicant2.fullName && applicant1.gpi == applicant2.gpi && applicant1.schoolClass == applicant2.schoolClass;
    }


}