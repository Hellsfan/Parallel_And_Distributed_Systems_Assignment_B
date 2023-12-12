using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_And_Distributed_Systems_Assignment_B
{
    internal class Painter
    {
        public int Id { get; set; }
        public Dictionary<Circle, bool> CirclesPool { get; set; }

        public Painter(Dictionary<Circle, bool> _CirclesPool, int id)
        {
            this.CirclesPool = _CirclesPool;
            Id = id;
        }

        
        public void PaintCircle(Circle circle, SemaphoreSlim locker)
        {
            locker.Wait();
            CirclesPool[circle] = true;
            Thread.Sleep(20);
            Console.WriteLine($"Painting a circle {circle.Id} right now by painter {Id}...");
            locker.Release();
        }

        public bool IsCirclePainted(List<Painter> painters, Circle circle)
        {
            foreach (var painter in painters)
            {
                if (painter.CirclesPool[circle] == true) return true;
            }

            return false;
        }
    }
}
