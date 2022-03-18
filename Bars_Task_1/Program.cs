namespace Program;
static class Program
{
    private static void Main()
    {
        var sub = new Subscriber();
        sub.SomeMethod();
    }
}

public class Worker
{
    public event EventHandler<char> OnKeyPressed;
    public void Run()
    {
        while (true)
        {
            Console.Write("Write your symbol: ");
            var x = Console.ReadKey();
            if (x.Key == ConsoleKey.C) // 
            {
                Console.WriteLine(" Exit...");
                break;
            }
            else
            {
                OnKeyPressed?.Invoke(this, x.KeyChar);
            }
        }
    }
}

public class Subscriber
{
    public void SomeMethod()
    {
        var worker = new Worker();
        worker.OnKeyPressed += PrintChar;
        worker.Run();
    }

    public void PrintChar(object sender, char letter)
    {
        Console.WriteLine($" Symbol: {letter}");
    }
}