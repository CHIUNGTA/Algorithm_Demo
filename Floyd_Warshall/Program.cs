using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_Warshall
{
    class Program
    {
        private static readonly int M = int.MaxValue;
        private static int N = 0;
        static void Main(string[] args)
        {
            int[,] graph = { {0,12,15,18,M,M,M,M},
                             {12,0,M,5,M,29,M,M},
                             {15,M,0,7,17,M,10,M},
                             {18,5,7,0,9,13,M,M},
                             {M,M,17,9,0,8,6,M},
                             {M,M,M,13,8,0,16,14},
                             {M,M,10,M,6,16,0,11},
                             {M,M,M,M,M,14,11,0}};
            N = (int)Math.Sqrt(graph.Length);
            floydWarshall(graph);
            Console.ReadLine(); 
        }


        private static void floydWarshall(int[,] graph)
        {
            
            int[,] dist = new int[N, N];
            int i, j, k;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    dist[i, j] = graph[i, j];
                }
            }
            for (k = 0; k < N; k++)
            {
                for (i = 0; i < N; i++)
                {
                    for (j = 0; j < N; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }
            printSolution(dist);
        }

        private static void printSolution(int[,] dist)
        {
            Console.WriteLine("佛洛伊德最短路徑:");
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if (dist[i, j] == M)
                    {
                        Console.Write("M ");
                    }
                    else
                    {
                        Console.Write(dist[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
