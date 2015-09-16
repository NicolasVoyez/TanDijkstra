using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanDijkstra
{
    public class Node
    {
        protected Node(IEnumerable<Node> linked)
        {
            PathDone = double.MaxValue;
            Previous = null;
            Linked = new List<Node>(linked);
        }

        public double PathDone { get; set; }
        public Node Previous { get; set; }
        public List<Node> Linked { get; set; }
    }
}
