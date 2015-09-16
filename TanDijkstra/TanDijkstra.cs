using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanDijkstra
{
    public class TanDijkstra : Dijkstra<TanNode>
    {
        public TanDijkstra(List<TanNode> nodes)
            : base(nodes)
        {
        }

        public override double GetDist(TanNode n1, TanNode n2)
        {
            var x = (n2.Long - n1.Long) * Math.Cos(Math.PI * (n1.Lat + n2.Lat) / 2);
            var y = n2.Lat - n1.Lat;

            return Math.Sqrt(x * x + y * y) * 6731;
        }
    }
}
