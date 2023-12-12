using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_And_Distributed_Systems_Assignment_B
{
    internal class Circle
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int R { get; set; }

        public Circle(int x, int y, int r, int id) { 
            X = x;
            Y = y;
            R = r;
            Id = id;
        }
    }
}
