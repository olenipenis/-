class Calculator
{
    public static void Degree(int x, int n)
    {
        if (n > 0)
            x = (int)Math.Pow(x, n);
    }

    public static void Square(int x)
    {
       int result = (int)Math.Pow(x, 2);
    }
}
