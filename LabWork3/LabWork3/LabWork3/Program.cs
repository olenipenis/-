using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

int GetPower(int n, int x)
{
    if (n == 0)
        return 1;
    if (n > 0)
        return (int)Math.Pow(x, n);
    if (n < 0)
        return 1 / (int)Math.Pow(x, -n);
    else
        return 0;
}

int FastPower(int x, int n)
{
    if (n == 0)
        return 0;
    if (n > 0)
        return (int)Math.Pow(x, n);
    else
        return -1;
}

int GetFibonacci(int n)
{
    if (n < 2)
        return 1;
    else
        return GetFibonacci(n - 1) + GetFibonacci(n - 2);
}

//int GetFibonacciTail(int n, long a = 0, long b = 1)
//{
//    int array { n, a, b};
//    for (int i = 0; i < n; i++)
//    {
//        array[n] = n - 1;
//        array[a] = array[a] + 1;
//        array[b] = array[b] + 1;
//    }
//    return -1;
//}

//Debug.Assert(result("-1"), "error");
