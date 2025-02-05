namespace Prim
{
    class G
    {
        private int v;
        private List<E> e;

        public G(int v)
        {
            this.v = v;
            this.e = new List<E>();
        }

        public void A(int u, int v, int w)
        {
            e.Add(new E(u, v, w));
        }

        public void K()
        {
            bool[] m = new bool[v];
            int[] p = new int[v];
            int[] k = new int[v];

            H h = new H(v);

            for (int i = 0; i < v; i++)
            {
                k[i] = int.MaxValue;
                m[i] = false;
                p[i] = -1;
            }

            k[0] = 0;
            h.I(0, k[0]);

            while (!h.M())
            {
                int u = h.L();
                m[u] = true;

                foreach (var t in e)
                {
                    if (t.U == u || t.V == u)
                    {
                        int w = (t.U == u) ? t.V : t.U;
                        if (!m[w] && t.W < k[w])
                        {
                            k[w] = t.W;
                            p[w] = u;
                            h.I(w, k[w]);
                        }
                    }
                }
            }

            for (int i = 1; i < v; i++)
            {
                Console.WriteLine($"{p[i]}  {i} length:{k[i]}");
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

    public class H
    {
        private int[] h;
        private int[] k;
        private int s;

        public H(int cap)
        {
            h = new int[cap];
            k = new int[cap];
            s = 0;
        }

        public bool M()
        {
            return s == 0;
        }

        public void I(int v, int k)
        {
            h[s] = v;
            this.k[v] = k;
            s++;
            D(s - 1);
        }

        public int L()
        {
            int r = h[0];
            h[0] = h[s - 1];
            s--;
            C(0);
            return r;
        }

        private void D(int i)
        {
            while (i > 0 && this.k[h[(i - 1) / 2]] > this.k[h[i]])
            {
                F(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        private void C(int i)
        {
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int m = i;

            if (l < s && this.k[h[l]] < this.k[h[m]])
                m = l;
            if (r < s && this.k[h[r]] < this.k[h[m]])
                m = r;
            if (m != i)
            {
                F(i, m);
                C(m);
            }
        }

        private void F(int i, int j)
        {
            int t = h[i];
            h[i] = h[j];
            h[j] = t;
        }
    }

    class Program
    {
        static void Main()
        {
            G g = new G(5);
            g.A(0, 1, 2);
            g.A(0, 3, 6);
            g.A(1, 2, 3);
            g.A(1, 3, 8);
            g.A(1, 4, 5);
            g.A(2, 4, 7);
            g.A(3, 4, 9);
            g.K();
        }
    }
}
