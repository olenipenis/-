using System;

class Algorithms
{
    public static void PassCoinsAlgorithm(int amount, int[] coins)//объявляем одномерный массив целых чисел
    {
        Console.WriteLine($"Сумма сдачи: {amount}");
        Console.WriteLine($"Доступные монеты: [{string.Join(", ", coins)}]");

        Array.Sort(coins);//сортируем элементы массива
        Array.Reverse(coins);//располагает их в обратном порядке

        int[] result = new int[coins.Length];//.Length - получение количества элементов в массиве coins
        int remaining = amount;

        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i] <= remaining)
            {
                result[i] = remaining / coins[i];
                remaining %= coins[i];//типа coins[i] = remaining % coins[i], как-то так короче
            }
        }

        if (remaining > 0)
        {
            Console.WriteLine("Невозможно выдать сдачу данным набором монет");
            return;
        }

        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = 0; j < result[i]; j++)
            {
                Console.Write(coins[i] + " ");
            }
        }
        Console.WriteLine();

        int totalCoins = 0;
        for (int i = 0; i < result.Length; i++) totalCoins += result[i];
        Console.WriteLine($"Всего монет: {totalCoins}");
        Console.WriteLine($"O(n)");
    }

    public static int GetLocMax(int[] arr)
    {
        Console.WriteLine($"Массив: [{string.Join(", ", arr)}]");

        if (arr.Length == 1 || arr[0] > arr[1])
        {
            Console.WriteLine($"Локальный максимум: {arr[0]}");
            Console.WriteLine($"O(1)");
            Console.WriteLine();
            return 0;
        }

        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                Console.WriteLine($"Локальный максимум: {arr[i]}");
                Console.WriteLine($"O(n)");
                Console.WriteLine();
                return i;
            }
        }

        if (arr[arr.Length - 1] > arr[arr.Length - 2])
        {
            Console.WriteLine($"Локальный максимум: {arr[arr.Length - 1]}");
            Console.WriteLine($"O(n)");
            Console.WriteLine();
            return arr.Length - 1;
        }

        Console.WriteLine("Локальный максимум не найден");
        Console.WriteLine($"O(n)");
        return -1;
    }

    public static void NearestNeighborAlg(int[,] distances)
    {

        int[,] distances = {
            { 0, 10, 15, 20 },
            { 10, 0, 35, 25 },
            { 15, 35, 0, 30 },
            { 20, 25, 30, 0 }
        };
        int n = distances.GetLength(0);

        int[] visited = new int[n]; // Помечаем посещённые города
        int[] path = new int[n]; // Храним маршрут
        int currentCity = 0; // Начинаем с города 0 
        visited[currentCity] = 1; // Отмечаем как посещённый
        path[0] = currentCity;
        for (int step = 1; step < n; step++)
        {
            int nearestCity = -1;
            int minDistance = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (visited[i] == 0 && (new int[,] {
                    { 0, 10, 15, 20 },
                    { 10, 0, 35, 25 },
                    { 15, 35, 0, 30 },
                    { 20, 25, 30, 0 }
                })[currentCity, i] < minDistance)
                {
                    minDistance = (new int[,] {
                        { 0, 10, 15, 20 },
                        { 10, 0, 35, 25 },
                        { 15, 35, 0, 30 },
                        { 20, 25, 30, 0 }
                    })[currentCity, i];
                    nearestCity = i;
                }
            }
            visited[nearestCity] = 1; // Помечаем город как посещённый
            path[step] = nearestCity; // Добавляем в маршрут
            currentCity = nearestCity; // Переходим в новый город 
        }
        // Вывод результата 
        Console.WriteLine("Приближённый маршрут:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(path[i] + (i < n - 1 ? "->" : ""));
        }
        Console.WriteLine($"O(n^2)");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("5.1. Алгоритм сдачи монет\n");

        Algorithms.PassCoinsAlgorithm(87, new int[] { 10, 5, 2, 1 });

        Console.WriteLine("Пример проблемного случая (6, {1, 3, 4}):");
        Console.WriteLine("Жадный алгоритм выдает: 4 1 1 (3 монеты)");
        Console.WriteLine("Оптимальное решение: 3 3 (2 монеты)");
        Algorithms.PassCoinsAlgorithm(6, new int[] { 1, 3, 4 });

        Algorithms.PassCoinsAlgorithm(28, new int[] { 25, 10, 5, 1 });

        Console.WriteLine("5.2. Алгоритм поиска локального максимума\n");

        Algorithms.GetLocMax(new int[] { 1, 3, 7, 5, 8 });

        Algorithms.GetLocMax(new int[] { 1, 2, 1, 3, 5, 4, 3 });

        Algorithms.GetLocMax(new int[] { 1, 2, 3, 4, 5 });

        Algorithms.GetLocMax(new int[] { 5, 4, 3, 2, 1 });

        Console.WriteLine("5.3. Алгоритм ближайшего соседа\n");

        int[,] distances1 = {
            {0, 10, 15, 20},
            {10, 0, 35, 25},
            {15, 35, 0, 30},
            {20, 25, 30, 0}
        };
        Algorithms.NearestNeighborAlg(distances1);

        int[,] distances2 = {
            {0, 12, 10, 19, 8},
            {12, 0, 3, 7, 2},
            {10, 3, 0, 6, 20},
            {19, 7, 6, 0, 4},
            {8, 2, 20, 4, 0}
        };
        Algorithms.NearestNeighborAlg(distances2);
    }
}
