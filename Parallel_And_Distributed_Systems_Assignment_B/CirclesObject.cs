using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_And_Distributed_Systems_Assignment_B
{
    internal class CirclesObject
    {
        //Dictionary containing all the circles there are to be painted
        public ConcurrentDictionary<Circle, bool> CirclesPool;

        // Queue used for ejecting the circles one by one for the painters. Concurrent to make it thread safe.
        public ConcurrentQueue<Circle> CirclesQueue;

        public CirclesObject(int amountOfCircles, int radius)
        {
            CirclesPool = new ConcurrentDictionary<Circle, bool>();
            CirclesQueue = new ConcurrentQueue<Circle>();

            Random rnd = new Random();

            //randomizing all the Circles in the pool. I tried using the x and y in Win Forms, but this console version of visualization
            //turned out to be more beautiful <3
            for (int i = 0; i < amountOfCircles; i++)
            {
                Circle c = new Circle(rnd.Next(50, 550), rnd.Next(50, 550), radius, i);
                CirclesPool.TryAdd(c, false);
                CirclesQueue.Enqueue(c);
            }
        }
    }
}
