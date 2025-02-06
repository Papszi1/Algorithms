using System.Diagnostics;

namespace Dijsktra
{
    public  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Graph graph = new Graph(4);
            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 2, 3);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 3, 2);
            graph.AddEdge(0, 3, 6);

            int[] numbers = graph.Dijsktra(0);
            PrintNumbers(numbers);


        }

        static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }

    public class Graph
    {
        private int[,] edges;
        private int vertices;

        public Graph(int vertices)
        {
            this.vertices = vertices;
            edges = new int[vertices, vertices];
        }

        public void AddEdge(int start, int end, int weight)
        {
            edges[start, end] = weight;
            edges[end, start] = weight;
        }

        public int[] Dijsktra(int startingPoint)
        {
            int[] distances = new int[vertices];
            for (int i = 0; i < vertices; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startingPoint] = 0;

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            pq.Enqueue(startingPoint, 0);

            while (pq.Count > 0)
            {
                int u = pq.Dequeue();

                for (int v = 0; v < vertices; v++)
                {
                    if (edges[u, v] != 0) 
                    {
                        int newDist = distances[u] + edges[u, v];
                        if (newDist < distances[v])
                        {
                            distances[v] = newDist;
                            pq.Enqueue(v, newDist);
                        }
                    }
                }
            }


            return distances;

        }
    }

}
