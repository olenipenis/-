namespace ConsoleApp1

{
    internal class Applicant(string fullName, int schoolClass) : IComparable
    {
        public double averageGPA;

        public string FullName
        {
            get { return fullName; }
            set
            {
                if (value.Length > 1)
                    fullName = value;
            }
        }

        public double AverageGPA
        {
            get { return averageGPA; }
            set
            {
                if (value > 0)
                    averageGPA = value;
            }
        }

        public bool GPA => schoolClass >= 11;

        public void PrintInformation()
            => Console.WriteLine($"fullName: {fullName} \nschoolClass: {schoolClass} \n averageGPA: {averageGPA}.");

        public bool IsCorrectAverageScore(double inputGPA)
            => inputGPA < averageGPA;
    }
}