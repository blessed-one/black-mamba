using ochered_minimumov;
using stack_minimumov;
using System.Diagnostics;
using System.Numerics;
using System.Text;


var stopwatch = new Stopwatch();
var rnd = new Random();
for (int n = 1000000; n < 5000000; n += 100000)
{
    //var queue = new OcheredMinimumov<int>();
    var queue = new Queue<int>();

    for (int i = 0; i <= n; i++)
    {
        queue.Enqueue(rnd.Next(1, 100000));
    }

    stopwatch.Start();
    queue.Min();
    stopwatch.Stop();
    string path = @"D:\ControlWork1\Hackathon\black-mamba\stack-minimumov\ochered-minimumov\queGetMinimum.txt";

    File.AppendAllText(path, $"\n{n} {stopwatch.ElapsedTicks}", Encoding.GetEncoding("iso-8859-1"));
    stopwatch.Reset();
}