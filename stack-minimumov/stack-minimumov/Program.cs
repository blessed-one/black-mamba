using stack_minimumov;

public static class Program
{
    public static void Main(string[] args)
    {
        var cifri = new int[] { 9, 8, 6, 8, 4, 1, 5, -2, 45, -1111 };
        var stackk = new StackMinimumov<int>();
        string stackLine = "";
        string minLine = "";
        foreach (int i in cifri)
        {
            stackk.Push(i);
            stackLine += $"{i} ";
            minLine += $"{stackk.Min()} ";

            Console.WriteLine($"Введено число - {i}\nstack: {stackLine}\nminns: {minLine}\n");
        }
    }
}
