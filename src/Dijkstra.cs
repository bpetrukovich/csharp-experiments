namespace Template;

public class Dijkstra
{
    public static int NetworkDelayTime(int[][] times, int n, int k)
    {
        k--;

        var network = Enumerable.Range(0, n).Select(_ => new List<(int, int)>()).ToList();

        foreach (var connection in times)
        {
            int u = connection[0] - 1;
            int v = connection[1] - 1;
            int w = connection[2];

            network[u].Add((v, w));
        }


        var distance = Enumerable.Repeat(int.MaxValue, n).ToList();
        distance[k] = 0;

        var queue = new PriorityQueue<int, int>();
        queue.Enqueue(k, distance[k]);

        while (queue.Count > 0)
        {
            queue.TryDequeue(out var current, out var currentDistance);
            if (currentDistance > distance[current])
            {
                continue;
            }

            foreach (var (neighbour, d) in network[current])
            {
                if (distance[neighbour] > distance[current] + d)
                {
                    distance[neighbour] = distance[current] + d;
                    queue.Enqueue(neighbour, distance[neighbour]);
                }
            }
        }

        int maxDistance = distance.Max();
        return maxDistance == int.MaxValue ? -1 : maxDistance;
    }
}