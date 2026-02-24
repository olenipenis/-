using ConsoleApp1;
using System.Reflection.Metadata.Ecma335;

Applicant[] applicants =
       [
        new Applicant() { fullName = "a", schoolClass = 11 },
        new Applicant() { fullName = "b", schoolClass = 10 },
        new Applicant() { fullName = "c", schoolClass = 11 },
        new Applicant() { fullName = "d", schoolClass = 9 },
       ];
Array.Sort(applicants);
class Applicant : IComparable
{
    public string fullName { get; set; }
    public int schoolClass { get; set; }
    public int CompareTo(object obj)
    {
if (obj is null) return 1;
        Applicant applicant = obj as Applicant;
        if (applicant is not null) return schoolClass;
        return 0;
    }
}

