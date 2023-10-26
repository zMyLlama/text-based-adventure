using System.Diagnostics;

while (true)
{
    if (Console.WindowWidth < 120 || Console.WindowHeight < 30)
    {
        Console.WriteLine("Make screen bigger!");
        Thread.Sleep(100);
        Console.Clear();
    }
}
