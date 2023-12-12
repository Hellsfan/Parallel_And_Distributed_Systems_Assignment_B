using Parallel_And_Distributed_Systems_Assignment_B;
using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    { 
        RunPaintingProcess(5);
        RunPaintingProcess(20);
        RunPaintingProcess(100);
    }

    private static void RunPaintingProcess(int painterCount)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        CirclesObject circlesObject = new CirclesObject(1000, 3);
        List<Painter> listOfPainters = new List<Painter>();

        for (int i = 0; i < painterCount; i++)
        {
            Painter painter = new Painter(circlesObject.CirclesPool, i + 1);
            listOfPainters.Add(painter);
        }

        Parallel.ForEach(listOfPainters, painter =>
        {
            while (circlesObject.CirclesQueue.TryDequeue(out var circleToPaint))
            {
                if (!painter.IsCirclePainted(listOfPainters, circleToPaint))
                {
                    painter.PaintCircle(circleToPaint);
                }
                if (circleToPaint.Id % 50 == 0) Console.WriteLine();
            }
        });

        stopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine($"Time taken with {painterCount} painters: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }
}