using System;

class DijkstraAlgorithm
{
    // Метод для нахождения кратчайших путей
    public static void Dijkstra(int[,] graph, int start)
    {
        int vertices = graph.GetLength(0);
        int[] distances = new int[vertices]; // Массив для хранения расстояний
        bool[] visited = new bool[vertices]; // Массив для отметки посещенных вершин

        // Инициализация расстояний
        for (int i = 0; i < vertices; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[start] = 0;

        // Основной цикл
        for (int count = 0; count < vertices - 1; count++)
        {
            int u = MinDistance(distances, visited); // Выбор вершины с минимальным расстоянием
            visited[u] = true;

            // Обновление расстояний до соседей
            for (int v = 0; v < vertices; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue &&
                    distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                }
            }
        }

        // Вывод результатов
        Console.WriteLine("\nРезультат:");
        Console.WriteLine("Вершина\tРасстояние от начальной вершины");
        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine($"{i}\t{distances[i]}");
        }
    }

    // Метод для нахождения вершины с минимальным расстоянием
    private static int MinDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < distances.Length; v++)
        {
            if (!visited[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    // Метод для ввода графа пользователем
    private static int[,] InputGraph()
    {
        Console.Write("Введите количество вершин: ");
        int vertices = int.Parse(Console.ReadLine());

        int[,] graph = new int[vertices, vertices];

        Console.WriteLine("Введите матрицу смежности (веса ребер):");
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                Console.Write($"Вес ребра [{i} -> {j}]: ");
                graph[i, j] = int.Parse(Console.ReadLine());
            }
        }

        return graph;
    }

    // Основной метод программы
    public static void Main()
    {
        Console.WriteLine("Программа для нахождения кратчайших путей (алгоритм Дейкстры)");

        int[,] graph;
        int start;

        Console.WriteLine("\nВыберите вариант:");
        Console.WriteLine("1. Использовать предопределенный граф");
        Console.WriteLine("2. Ввести граф вручную");
        Console.Write("Ваш выбор: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            // Предопределенный граф
            graph = new int[,] {
                { 0, 2, 4, 0, 0 },
                { 2, 0, 1, 7, 0 },
                { 4, 1, 0, 3, 5 },
                { 0, 7, 3, 0, 2 },
                { 0, 0, 5, 2, 0 }
            };
            start = 0; // Начальная вершина
        }
        else if (choice == 2)
        {
            // Ввод графа пользователем
            graph = InputGraph();
            Console.Write("Введите начальную вершину: ");
            start = int.Parse(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Неверный выбор. Программа завершена.");
            return;
        }

        // Запуск алгоритма Дейкстры
        Dijkstra(graph, start);
    }
}