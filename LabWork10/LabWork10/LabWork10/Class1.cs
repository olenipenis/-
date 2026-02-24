namespace LabWork10
{
    public class Rectangle : IPrinter
    {
        public int width = 7;
        public int height = 5;
    }

    public class EqualTriangle : IPrinter
    {
        public int side = 7;
    }

    public class Applicant : IPrinter
    {
            public string fullName = "lelele";
            public int schoolClass = 9;
            public double averageGPA = 3.84;
    }
    
}
