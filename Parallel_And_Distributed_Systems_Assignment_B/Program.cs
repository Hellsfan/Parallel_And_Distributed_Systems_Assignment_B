using Parallel_And_Distributed_Systems_Assignment_B;
using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("IMPORTANT!!! Please go into full screen console for proper visualization. Thank you <3");
        Console.WriteLine();

        RunPaintingProcess(5);
        RunPaintingProcess(20);
        RunPaintingProcess(100);
    }

    private static void RunPaintingProcess(int painterCount)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        CirclesObject circlesObject = new CirclesObject(2000, 3);
        List<Painter> listOfPainters = new List<Painter>();

        for (int i = 0; i < painterCount; i++)
        {
            Painter painter = new Painter(circlesObject.CirclesPool, i + 1);
            listOfPainters.Add(painter);
        }


        //Making the workers work in parallel
        Parallel.ForEach(listOfPainters, painter =>
        {
            //While we have circles in the queue we continue working
            while (circlesObject.CirclesQueue.TryDequeue(out var circleToPaint))
            {
                //Check if circle is painted first
                if (!painter.IsCirclePainted(listOfPainters, circleToPaint))
                {
                    //then paint
                    painter.PaintCircle(circleToPaint);
                }

                //Basically after the 50th circle has been painted we go the next line.
                if (circleToPaint.Id % 50 == 0) Console.WriteLine();
            }
        });

        stopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine($"Time taken with {painterCount} painters: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }
}