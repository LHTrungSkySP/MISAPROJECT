public class Program
{
    public static void Main()
    {
        Abc x = new Abc();
        x.a = 1;
        Console.WriteLine(typeof(x).Name);
    }
}
public class Abc
{
    public int a { get; set; }
}