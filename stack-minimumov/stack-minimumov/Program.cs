using stack_minimumov;
using System.Diagnostics;
using System.Numerics;
using System.Text;


var stopwatch = new Stopwatch();
var rnd = new Random();
string pathMin = @"D:\inf\black-mamba\stack-minimumov\stack-minimumov\testMin.txt";
string pathDefault = @"D:\inf\black-mamba\stack-minimumov\stack-minimumov\testDefault.txt";


for (int n = 1000000; n <= 5000000; n += 100000)
{
    //var queue = new OcheredMinimumov<int>();
    var stackMins = new StackMinimumov<int>();
    var stackDefault = new Stack<int>();

    for (int i = 0; i <= n; i++)
    {
        int x = rnd.Next(1, 100000);
        stackMins.Push(x);
        stackDefault.Push(x);
    }

    // Замер обычного стека
    stopwatch.Start();
    stackDefault.Min();
    stopwatch.Stop();

    File.AppendAllText(pathDefault, $"\n{n} {stopwatch.ElapsedTicks}", Encoding.GetEncoding("iso-8859-1"));
    stopwatch.Reset();

    // Замер стека минимумов
    stopwatch.Start();
    stackMins.Min();
    stopwatch.Stop();

    File.AppendAllText(pathMin, $"\n{n} {stopwatch.ElapsedTicks}", Encoding.GetEncoding("iso-8859-1"));
    stopwatch.Reset();
}