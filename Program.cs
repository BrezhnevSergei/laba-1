using System.Diagnostics;

Problem1();
Problem2();
return;

static void Problem1()
{
    Console.WriteLine("\nProblem 1:\n");
    const int n = 100;

    var random = new Random();

    var array = Enumerable.Range(0, n)
        .Select(i => random.Next(2 * n + 1) - n)
        .ToArray();

    var count = array.Count(x => x == 0);

    var min = array
        .Select((x, i) => new { Value = x, Index = i })
        .MinBy(xi => xi.Value);

    Debug.Assert(min != null, nameof(min) + " != null");

    var sum = array.Skip(min.Index + 1).Sum();

    Console.WriteLine($"Array = [{string.Join(", ", array)}]");
    Console.WriteLine($"Count of elements equals 0 = {count}");
    Console.WriteLine($"Sum after min element = {sum}");

    array = array.OrderBy(Math.Abs).ToArray();
    Console.WriteLine($"Ordered by absolute values array = [{string.Join(", ", array)}]");
}

static void Problem2()
{
    Console.WriteLine("\nProblem 2:\n");

    int[,] matrix = {
        {1, 2, 3, 4},
        {5, 6, 7, 8},
        {9, 10, 11, 12},
        {13, 14, 15, 16}
    };
    PrintMatrix(matrix);

    const int k = 2;

    ShiftMatrixElements(matrix, k);

    Console.WriteLine();
    PrintMatrix(matrix);
}

static void ShiftMatrixElements(int[,] matrix, int k)
{
    var rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int totalElements = rows * columns;
    int[] flattenedMatrix = new int[totalElements];

    // Преобразуем матрицу в одномерный массив
    int index = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            flattenedMatrix[index++] = matrix[i, j];
        }
    }

    // Выполняем циклический сдвиг элементов массива вправо
    int[] shiftedMatrix = new int[totalElements];
    for (int i = 0; i < totalElements; i++)
    {
        int newIndex = (i + k) % totalElements;
        shiftedMatrix[newIndex] = flattenedMatrix[i];
    }

    // Преобразуем одномерный массив обратно в матрицу
    index = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = shiftedMatrix[index++];
        }
    }
}

static void PrintMatrix(int[,] matrix)
{
    int m = matrix.GetLength(0);
    int n = matrix.GetLength(1);

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

