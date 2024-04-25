using ochered_minimumov;
using stack_minimumov;

var cifri = new int[] { 9, 8, 6, 8, 4, 1, 5, -2, 45, -1111 };
var queue = new OcheredMinimumov<int>();
string stackLine = "";
string minLine = "";
foreach (int i in cifri)
{
    queue.Push(i);
    stackLine += $"{i} ";
    minLine += $"{queue.GetMinimum()} ";

    Console.WriteLine($"Введено число - {i}\nqueue: {stackLine}\nminns: {minLine}\n");
}

while (queue.Count > 0)
{
    Console.WriteLine(queue.Pop());
}