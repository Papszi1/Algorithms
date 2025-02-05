using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    //Újra segítség nélkül
    //Újra nehezítéssel
    //Pl minimum 2-re lehet
    class Program
    {
        static void Main()
        {
            Graph g = new Graph(6);
            g.AddEdge(0, 1, 3);
            g.AddEdge(0, 2, 6);
            g.AddEdge(1, 2, 6);
            g.AddEdge(1, 3, 1);
            g.AddEdge(2, 3, 1);
            g.AddEdge(3, 4, 6);
            g.AddEdge(4, 5, 9);

            g.Dijkstra(2);
        }
    }
    class Graph
    {
        private int Vertices;
        private List<(int, int)>[] AdjList;

        public Graph(int vertices)
        {
            Vertices = vertices;
            AdjList = new List<(int, int)>[vertices];
            for (int i = 0; i < vertices; i++)
                AdjList[i] = new List<(int, int)>();
        }

        public void AddEdge(int u, int v, int weight)
        {
            AdjList[u].Add((v, weight));
            AdjList[v].Add((u, weight)); 
        }

        public void Dijkstra(int start)
        {
            int[] distances = new int[Vertices];
            for (int i = 0; i < Vertices; i++)
                distances[i] = int.MaxValue;
            distances[start] = 0;

            PriorityQueue<(int, int)> pq = new PriorityQueue<(int, int)>();
            pq.Enqueue((0, start));

            while (pq.Count > 0)
            {
                var (currentDistance, u) = pq.Dequeue();

                if (currentDistance > distances[u])
                    continue;

                foreach (var (v, weight) in AdjList[u])
                {
                    int newDist = distances[u] + weight;
                    if (newDist < distances[v])
                    {
                        distances[v] = newDist;
                        pq.Enqueue((newDist, v));
                    }
                }
            }

            PrintDistances(distances);
        }

        private void PrintDistances(int[] distances)
        {
            Console.WriteLine("Vertex   Distance from Source");
            for (int i = 0; i < distances.Length; i++)
                Console.WriteLine(i + "        " + distances[i]);
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap = new List<T>();

        public int Count => heap.Count;

        public void Enqueue(T item)
        {
            heap.Add(item);
            int i = heap.Count - 1;
            while (i > 0 && heap[i].CompareTo(heap[(i - 1) / 2]) < 0)
            {
                (heap[i], heap[(i - 1) / 2]) = (heap[(i - 1) / 2], heap[i]);
                i = (i - 1) / 2;
            }
        }

        public T Dequeue()
        {
            T root = heap[0];
            heap[0] = heap[^1];
            heap.RemoveAt(heap.Count - 1);

            int i = 0;
            while (true)
            {
                int left = 2 * i + 1, right = 2 * i + 2, smallest = i;

                if (left < heap.Count && heap[left].CompareTo(heap[smallest]) < 0)
                {
                    smallest = left;
                }
                if (right < heap.Count && heap[right].CompareTo(heap[smallest]) < 0)
                {
                    smallest = right;
                }
                if (smallest == i)
                {
                    break;
                }

                (heap[i], heap[smallest]) = (heap[smallest], heap[i]);
                i = smallest;
            }

            return root;
        }
    }


}
