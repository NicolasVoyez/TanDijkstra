using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanDijkstra
{
    public class TanNode : Node
    {
        public TanNode(string nodeText)
            : base(new List<Node>())
        {
            var split = nodeText.Split(new[] { "," }, StringSplitOptions.None);
            ShortName = split[0];
            LongName = split[1].Trim('\"');
            Descripion = split[2];
            var degLat = double.Parse(split[3], CultureInfo.InvariantCulture);
            Lat = ToRadian(degLat);
            var degLong = double.Parse(split[4], CultureInfo.InvariantCulture);
            Long = ToRadian(degLong);
            ZoneId = split[5];
            StopUri = string.IsNullOrEmpty(split[6]) ? null : new Uri(split[6]);
            StopType = string.IsNullOrEmpty(split[7]) ? -1 : int.Parse(split[7]);
            MotherStation = split[8];
        }

        private static double ToRadian(double degrees)
        {
            return degrees / 180;
        }

        public string Descripion { get; set; }
        public string ZoneId { get; set; }
        public Uri StopUri { get; set; }
        public int StopType { get; set; }
        public string MotherStation { get; set; }

        public string ShortName { get; set; }
        public string LongName { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
