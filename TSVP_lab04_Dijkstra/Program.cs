using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSVP_lab04_Dijkstra
{
    internal class Program
    {
        static void Dijkstra(int[,] graph, int start)
        {
            int n = graph.GetLength(0);
            int[] distances = new int[n];
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue; // устанавливаем начальное расстояние до всех вершин как бесконечность
                visited[i] = false; // устанавливаем все вершины как непосещенные
            }

            distances[start] = 0; // начальное расстояние до стартовой вершины равно 0

            for (int i = 0; i < n - 1; i++)
            {
                int minDistance = int.MaxValue;
                int minIndex = -1;

                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && distances[j] < minDistance)
                    {
                        minDistance = distances[j];
                        minIndex = j;
                    }
                }

                visited[minIndex] = true;

                for (int k = 0; k < n; k++)
                {
                    int edgeDistance = graph[minIndex, k];

                    if (edgeDistance > 0 && distances[minIndex] + edgeDistance < distances[k])
                    {
                        distances[k] = distances[minIndex] + edgeDistance;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Кратчайшее расстояние от вершины {0} до вершины {1} равно {2}", start, i, distances[i]);
            }
        }

        static void Main(string[] args)
        {
            int[,] graph = {
            { 0, 6, 0, 1, 0 },
            { 6, 0, 5, 2, 2 },
            { 0, 5, 0, 0, 5 },
            { 1, 2, 0, 0, 1 },
            { 0, 2, 5, 1, 0 },};

            Dijkstra(graph, 0); // вызов алгоритма Дейкстры для графа и вершины 0
            Console.ReadKey();
        }
    }
}
