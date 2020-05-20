using System.Collections.Generic;
using System.Linq;
namespace CartesianNeighbors
{
    public class Challenge
    {
        public static IEnumerable<int[]> cartesianNeighbor(int x, int y)
        {
            int[] m = { 1, -1, 0 };
            return m.Select(d => m.Select(d2 => new int[] { x + d, y + d2 })).SelectMany(d => d).Where(d => !(d[0] == x && d[1] == y));
        }
    }
}
