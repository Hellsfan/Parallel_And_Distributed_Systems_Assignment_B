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
        public ConcurrentDictionary<Circle, bool> CirclesPool;
        public ConcurrentQueue<Circle> CirclesQueue;

        public CirclesObject(int amountOfCircles, int radius)
        {
            CirclesPool = new ConcurrentDictionary<Circle, bool>();
            CirclesQueue = new ConcurrentQueue<Circle>();

            Random rnd = new Random();

            for (int i = 0; i < amountOfCircles; i++)
            {
                Circle c = new Circle(rnd.Next(50, 550), rnd.Next(50, 550), radius, i);
                CirclesPool.TryAdd(c, false);
                CirclesQueue.Enqueue(c);
            }
        }
    }
}
