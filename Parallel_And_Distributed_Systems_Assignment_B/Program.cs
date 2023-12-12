using Parallel_And_Distributed_Systems_Assignment_B;

internal class Program
{
    public static SemaphoreSlim locker = new SemaphoreSlim(1, 1);
    private static void Main(string[] args)
    {

        CirclesObject CirclesObject = new CirclesObject(100, 3);
        List<Painter> listOfPainters = new List<Painter>();

        for (int i = 0; i < 10; i++)
        {
            Painter painter = new Painter(CirclesObject.CirclesPool, i+1);
            listOfPainters.Add(painter);
        }

        Parallel.ForEach(listOfPainters, painter =>
        {
            while(CirclesObject.CirclesQueue.Count > 0)
            {
                CirclesObject.CirclesQueue.TryDequeue(out var circleToPaint);

                if (!painter.IsCirclePainted(listOfPainters, circleToPaint))
                {
                    painter.PaintCircle(circleToPaint, locker);
                }
            }
        });
    }


}