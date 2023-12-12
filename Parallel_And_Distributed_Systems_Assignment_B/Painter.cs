using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_And_Distributed_Systems_Assignment_B
{
    internal class Painter
    {
        public int Id { get; set; }

        ConsoleColor color { get; set; }
        public ConcurrentDictionary<Circle, bool> CirclesPool { get; set; }

        public Painter(ConcurrentDictionary<Circle, bool> _CirclesPool, int id)
        {
            Random random = new Random();
            this.CirclesPool = _CirclesPool;
            color = (ConsoleColor)random.Next(1,15);
            Id = id;
        }


        public void PaintCircle(Circle circle)
        {
            CirclesPool[circle] = true;
            Thread.Sleep(20);
            Console.ForegroundColor = color;
            Console.Write("{" + $"{Id}" +"}");
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
