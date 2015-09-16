using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanDijkstra
{
    public abstract class Dijkstra<TNode>
           where TNode : Node
    {
        public List<TNode> Nodes;

        protected Dijkstra(List<TNode> nodes)
        {
            Nodes = nodes;
        }

        public IList<TNode> GetShortestPath(TNode from, TNode to)
        {
            var unSeen = new List<TNode>(Nodes);

            from.PathDone = 0;

            while (unSeen.Count != 0)
            {
                var n1 = unSeen.OrderBy(x => x.PathDone).First();
                unSeen.Remove(n1);
                foreach (var n2 in n1.Linked)
                {
                    var dist = n1.PathDone + GetDist(n1, n2 as TNode);

                    if (!(n2.PathDone > dist)) continue;

                    n2.PathDone = dist;
                    n2.Previous = n1;
                }
            }
            var finalWay = new List<TNode>();
            var currNode = to;
            while (currNode != from && currNode != null)
            {
                finalWay.Add(currNode);
                currNode = currNode.Previous as TNode;
            }
            if (currNode == from)
            {
                finalWay.Add(currNode);
                finalWay.Reverse();
                return finalWay;
            }
            return new List<TNode>();
        }

        public abstract double GetDist(TNode n1, TNode n2);
    }
}
