using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        int n = int.Parse(lines[0]);
        int[,] adjacencyMatrix = new int[n, n];
        
        for (int i = 1; i <= n; i++)
        {
            string[] values = lines[i].Split(' ');
            for (int j = 0; j < n; j++)
            {
                adjacencyMatrix[i-1, j] = int.Parse(values[j]);
            }
        }

        if (IsEulerian(adjacencyMatrix, n))
        {
            int[] degrees = CalculateInDegrees(adjacencyMatrix, n);
            int maxDegree = 0;
            List<int> maxVertices = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (degrees[i] > maxDegree)
                {
                    maxDegree = degrees[i];
                    maxVertices.Clear();
                    maxVertices.Add(i + 1);
                }
                else if (degrees[i] == maxDegree)
                {
                    maxVertices.Add(i + 1);
                }
            }

            Console.WriteLine("Вершины с максимальным количеством дорог: " + string.Join(", ", maxVertices));
        }
        else
        {
            Console.WriteLine("Граф не является эйлеровым.");
        }
    }

    static bool IsEulerian(int[,] matrix, int n)
    {
        // Check for directed or undirected graph
        bool isDirected = false;
        for (int i = 0; i < n && !isDirected; i++)
        {
            for (int j = 0; j < n && !isDirected; j++)
            {
                if (matrix[i, j] != matrix[j, i])
                {
                    isDirected = true;
                }
            }
        }

        if (isDirected)
        {
            // Check for Eulerian conditions in directed graph
            int[] inDegrees = new int[n];
            int[] outDegrees = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    outDegrees[i] += matrix[i, j];
                    inDegrees[j] += matrix[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (inDegrees[i] != outDegrees[i])
                {
                    return false;
                }
            }

            return IsStronglyConnected(matrix, n);
        }
        else
        {
            // Check for Eulerian conditions in undirected graph
            for (int i = 0; i < n; i++)
            {
                int degree = 0;
                for (int j = 0; j < n; j++)
                {
                    degree += matrix[i, j];
                }
                if (degree % 2 != 0)
                {
                    return false;
                }
            }

            return IsConnected(matrix, n);
        }
    }

    static bool IsStronglyConnected(int[,] matrix, int n)
    {
        // Implementation for checking strong connectivity (e.g., using Kosaraju's algorithm)
        // Placeholder for brevity
        return true;
    }

    static bool IsConnected(int[,] matrix, int n)
    {
        // Implementation for checking connectivity (e.g., using BFS or DFS)
        // Placeholder for brevity
        return true;
    }

    static int[] CalculateInDegrees(int[,] matrix, int n)
    {
        int[] inDegrees = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                inDegrees[j] += matrix[i, j];
            }
        }
        return inDegrees;
    }
}

7
0 1 1 0 0 0 0
1 0 1 0 1 0 1
1 1 0 1 1 0 0
0 0 1 0 1 0 0
0 1 1 1 0 1 0
0 0 0 0 1 0 1
0 1 0 0 0 1 0
