public interface IPrinter
{
    void Print(string obj, string obj1)
    {
        int info = ChannelWriter.Print(obj, obj1);
    }
}

