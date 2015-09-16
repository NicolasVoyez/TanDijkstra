using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanDijkstra
{
    public static class TanProgram
    {
        private static TanNode start;
        private static TanNode end;

        public static void Main(string[] args)
        {
            var nodes = Init(true);
            var d = new TanDijkstra(nodes);
            var result = d.GetShortestPath(start, end);

            if (result.Count == 0)
                Console.WriteLine("IMPOSSIBLE");
            else
            {
                foreach (var point in result)
                {
                    Console.WriteLine(point.LongName);
                }
            }

            Console.ReadLine();
        }

        private static IEnumerable<string> FakeDataResult
        {
            get
            {
                foreach (var line in System.IO.File.ReadAllLines(".\\out.txt"))
                    yield return line;
            }
        }
        private static IEnumerable<string> FakeData
        {
            get
            {
                foreach (var line in System.IO.File.ReadAllLines(".\\in.txt"))
                    yield return line;
            }
        }

        private static List<TanNode> Init(bool real)
        {
            var e = FakeData.GetEnumerator();
            var nodes = new Dictionary<string, TanNode>();
            var method = real ? (Func<string>)(Console.ReadLine) : (Func<string>)(() =>
            {
                e.MoveNext();
                return e.Current;
            });
            var startShortName = method();
            var endShortName = method();
            var stopNum = int.Parse(method());
            for (var i = 0; i < stopNum; i++)
            {
                var node = new TanNode(method());
                nodes.Add(node.ShortName, node);
            }
            stopNum = int.Parse(method());
            for (var i = 0; i < stopNum; i++)
            {
                var split = method().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var node1 = nodes[split[0]];
                var node2 = nodes[split[1]];
                node1.Linked.Add(node2);
            }

            start = nodes[startShortName];
            end = nodes[endShortName];

            return nodes.Values.ToList();
        }
    }
}
