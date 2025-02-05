using System;
using System.Collections.Generic;
using System.Linq;

namespace Krs
{
    class Program
    {
        static void Main()
        {
            G g = new G(4);
            g.A(0, 1, 10);
            g.A(0, 2, 6);
            g.A(0, 3, 5);
            g.A(1, 3, 15);
            g.A(2, 3, 4);

            g.K();
        }
    }
    class G
    {
        public int V { get; set; }
        public List<E> Edg { get; set; }

        public G(int v)
        {
            V = v;
            Edg = new List<E>();
        }

        public void A(int u, int v, int w)
        {
            Edg.Add(new E(u, v, w));
        }

        public void K()
        {
            Edg.Sort((x, y) => x.W.CompareTo(y.W));
            D d = new D(V);
            List<E> m = new List<E>();

            foreach (var e in Edg)
            {
                int u = e.U;
                int v = e.V;
                if (d.F(u) != d.F(v))
                {
                    d.U(u, v);
                    m.Add(e);
                }

                if (m.Count == V - 1)
                    break;
            }

            Console.WriteLine("Edges");
            foreach (var e in m)
            {
                Console.WriteLine($"{e.U}  {e.V} length:{e.W}");
            }
        }
    }

    public class E
    {
        public int U { get; set; }
        public int V { get; set; }
        public int W { get; set; }

        public E(int u, int v, int w)
        {
            U = u;
            V = v;
            W = w;
        }
    }

    public class D
    {
        private int[] p;
        private int[] r;

        public D(int n)
        {
            p = new int[n];
            r = new int[n];
            for (int i = 0; i < n; i++)
            {
                p[i] = i;
                r[i] = 0;
            }
        }

        public int F(int x)
        {
            if (p[x] != x)
            {
                p[x] = F(p[x]);
            }
            return p[x];
        }

        public void U(int x, int y)
        {
            int rX = F(x);
            int rY = F(y);

            if (rX != rY)
            {
                if (r[rX] > r[rY])
                    p[rY] = rX;
                else if (r[rX] < r[rY])
                    p[rX] = rY;
                else
                {
                    p[rY] = rX;
                    r[rX]++;
                }
            }
        }
    }


}
