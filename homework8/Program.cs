// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07


/// <summary>
/// Получение от пользователя ответа на вопрос.
/// </summary>
/// <param name='question'>Это вопрос пользователю</param>
/// <returns>true - да, false - нет</returns>
bool MakeChoice(string question)  // получаем ответ пользователя на вопрос
{
    Console.WriteLine(question);
    while (true)
    {
        Console.Write("Ведите Y (да) или N (нет): ");
        string choice = Console.ReadLine();
        choice = choice.ToLower();
        if (choice == "y")
        {
            return true;
        }
        if (choice == "n")
        {
            Console.WriteLine();
            return false;
        }
    }
}

/// <summary>
/// Запрос у пользователя на ввод информации, проверка правильности 
/// </summary>
/// <param name='request'>Запрос к пользователю на ввод информации</param>
/// <returns>Целое число, введенное пользователем</returns>
int GetIntInResponce(string request)
{
    string answer = String.Empty;
    while (true)
    {
        Console.Write(request);
        answer = Console.ReadLine();
        if (int.TryParse(answer, out int result))
        {
            return result;
        }
        Console.WriteLine("Вы ввели не целое число. ");
    }
}

/// <summary>
/// Заполнение двумерного массива целых числами от min до max
/// </summary>
/// <param name='m'>Число строк массива</param>
/// <param name='n'>Число столбцов массива</param>
/// <param name='min'>Минимальное число диапазона генерируемых чисел</param>
/// <param name='max'>Максимальное число диапазона генерируемых чисел</param>
/// <returns>Двумерный массив целых чисел</returns>
int[,] FillIntArray2D(int m, int n, int min, int max)  // получаем размер массива и границы
{
    int[,] outputArray = new int[m, n];
    Random random = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            outputArray[i, j] = random.Next(min, max + 1);
        }
    }
    return outputArray;
}

/// <summary>
/// Заполнение трехмерного массива неповторяющимися целыми числами от min до max
/// </summary>
/// <param name='l'>Число строк массива</param>
/// <param name='m'>Число столбцов массива</param>
/// <param name='n'>'Глубина' массива</param>
/// <param name='min'>Минимальное число диапазона генерируемых чисел</param>
/// <param name='max'>Максимальное число диапазона генерируемых чисел</param>
/// <returns>Двумерный массив целых чисел</returns>
int[,,] FillIntArray3D(int l, int m, int n, int min, int max)  // получаем размер массива и границы
{
    int[,,] outputArray = new int[l, m, n];
    Random random = new Random();
    List<int> elements = new List<int>();
    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < n; k++)
            {
                do
                {
                    outputArray[i, j, k] = random.Next(min, max + 1);
                } while (elements.Contains(outputArray[i, j, k]));
                elements.Add(outputArray[i, j, k]);
            }
            
        }
    }
    return outputArray;
}

/// <summary>
/// Вывод в консоль двумерного массива целых чисел
/// </summary>
/// <param name='inputArray'>Двумерный массив целых чисел</param>
/// <returns></returns>

void PrintIntArray2D(int[,] inputArray)  // вывод на экран массива целых чисел
{
    string max = Convert.ToString(inputArray.Cast<int>().Max());  // находит максимальный элемент массива и в стринг
    string min = Convert.ToString(inputArray.Cast<int>().Min());  // находит минимальный элемент массива и в стринг
    int len = Math.Max(max.Length, min.Length) + 1;               // определяем размер поля для печати 
    string forFormat = "{0, " + Convert.ToString(len) + "}";      // формируем строку типа "{0, 4}"

    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            Console.Write(String.Format(forFormat, inputArray[i, j]));
        }
        Console.WriteLine();
    }
}



/// <summary>
/// Печать трехмерного массива целых чисел по строкам (слоями).
/// </summary>
/// <param name='inputArray'>Трёхмерный массив целых чисел</param>
/// <param name='m'>Число столбцов массива</param>
/// <returns></returns>
void PrintArray3DLayers(int[,,] inputArray)  
{
    int l = inputArray.GetLength(0);
    int m = inputArray.GetLength(1);
    int n = inputArray.GetLength(2);
    for (int i = 0; i < l; i++)
    {
        Console.WriteLine($"Срез {i}:");
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < n; k++)
            {
                Console.Write(String.Format("{0, 10}", $"{inputArray[i, j, k]}({i},{j},{k})"));
            }
            Console.WriteLine();
        }
    }
}



/// <summary>
/// Упорядочение по убыванию элементов строк двумерного массива целых числел
/// </summary>
/// <param name='inputArray'>Не сортированный массив целых чисел</param>
/// <returns>Двумерный массив целых чисел с отсортированными по убыванию строками</returns>
int[,] SortIntArray2D(int[,] inputArray)  // получаем массив
{
    int temp;
    int unsortPositions;
    for (int i = 0; i < inputArray.GetLength(0) ; i++)
    {
        unsortPositions = inputArray.GetLength(1);
        for (int k = unsortPositions - 1; k > 0; k--)
        {
            for (int j = 0; j < k; j++)
            {
                if (inputArray[i,j] < inputArray[i,j+1])
                {
                    temp = inputArray[i,j];
                    inputArray[i,j] = inputArray[i,j+1];
                    inputArray[i,j+1] = temp;
                }
            }
        }
    }
    return inputArray;
}

/// <summary>
/// Поиск строки двумерного массива целых чисел с минимальной суммой элементов
/// </summary>
/// <param name='inputArray'>Массив целых чисел</param>
/// <returns>Индекс строки массива с минимальной суммой элементов</returns>
int FindMinRow(int[,] inputArray)  
{
    int[] tempArray = new int[inputArray.GetLength(0)];
    int sum;
        
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < inputArray.GetLength(1); j++)  
        {
            sum += inputArray[i,j];  // Считаем сумму элементов строки
        }
        tempArray[i] = sum;
    }
    int result = 0;
    int minSum = tempArray[0];
    for (int i = 1; i < tempArray.Length; i++)
    {
        if (minSum > tempArray[i])
        {
            result = i;
            minSum = tempArray[i];
        }
    }
    return result;
}

/// <summary>
/// Умножение двух матриц целых чисел
/// </summary>
/// <param name='first'>Первая матрица i x r</param>
/// <param name='second'>Вторая матрица r x j</param>
/// <returns>Итоговая матрица i x j</returns>
int[,] MatrixMultiplication(int[,] first, int[,] second)
{
    int firstRows = first.GetLength(0);
    int secondColumns = second.GetLength(1);
    int size = first.GetLength(1);
    int[,] result = new int[firstRows, secondColumns];
    int sum;
    for (int i = 0; i < firstRows; i++)
    {
        for (int j = 0; j < secondColumns; j++)
        {
            sum = 0;
            for (int r = 0; r < size; r++)
            {
                sum += first[i,r] * second[r,j];
            }
            result[i,j] = sum;

        }
    }
    return result;

}


//------------ Задачи

Console.Clear();
while (MakeChoice("Решаем задачу 54 (упорядочить строки)?: "))
{
    Console.Clear();
    int rows1 = GetIntInResponce("Введите количество строк: ");
    int columns1 = GetIntInResponce("Введите количество столбцов: ");
    int numFrom = GetIntInResponce("Массив заполняем числами от: ");
    int numTo = GetIntInResponce("Массив заполняем числами до: ");
    Console.Clear();
    int[,] array1 = FillIntArray2D(rows1, columns1, numFrom, numTo);
    Console.WriteLine($"Не сортированный массив {rows1}x{columns1} (числа от {numFrom} до {numTo}):");
    PrintIntArray2D(array1);
    Console.WriteLine("Cортированный массив: ");
    PrintIntArray2D(SortIntArray2D(array1));
    Console.WriteLine();
} 

Console.Clear();
while (MakeChoice("Решаем задачу 56 (поиск строки с минимальной суммой элементов)? "))
{
    Console.Clear();
    int rows2 = GetIntInResponce("Введите количество строк: ");
    int columns2 = GetIntInResponce("Введите количество столбцов: ");
    int numFrom = GetIntInResponce("Массив заполняем числами от: ");
    int numTo = GetIntInResponce("Массив заполняем числами до: ");
    Console.Clear();
    int[,] array2 = FillIntArray2D(rows2, columns2, numFrom, numTo);
    Console.WriteLine("В массиве:");
    PrintIntArray2D(array2);
    
    Console.WriteLine($"В строке с индексом {FindMinRow(array2)} сума элементов минимальна.");
    Console.WriteLine();
   
}

Console.Clear();
while (MakeChoice("Решаем задачу 58 (произведение матриц)? "))
{
    Console.Clear();
    Console.WriteLine("Для первой матрицы");
    int rowsFirst = GetIntInResponce("Введите количество строк: ");
    int columnsFirst = GetIntInResponce("Введите количество столбцов: ");
    int numFrom = GetIntInResponce("Массив заполняем числами от: ");
    int numTo = GetIntInResponce("Массив заполняем числами до: ");
    int[,] firstMatrix = FillIntArray2D(rowsFirst, columnsFirst, numFrom, numTo);
    Console.WriteLine("Для второй матрицы");
    int rowsSecond = GetIntInResponce("Введите количество строк: ");
    int columnsSecond = GetIntInResponce("Введите количество столбцов: ");
    numFrom = GetIntInResponce("Массив заполняем числами от: ");
    numTo = GetIntInResponce("Массив заполняем числами до: ");
    int[,] secondMatrix = FillIntArray2D(rowsSecond, columnsSecond, numFrom, numTo);
    Console.Clear();

    if (columnsFirst == rowsSecond)
    {
        Console.WriteLine($"Умножение матрицы {rowsFirst}x{columnsFirst}");
        PrintIntArray2D(firstMatrix);
        Console.WriteLine($"на матрицу {rowsSecond}x{columnsSecond}");
        PrintIntArray2D(secondMatrix);
        Console.WriteLine($"дает матрицу {rowsFirst}x{columnsSecond}");
        PrintIntArray2D(MatrixMultiplication(firstMatrix, secondMatrix));
    }
    else
    {
        Console.WriteLine("Количество столбцов первой матрицы не равно количеству строк второй");
        Console.WriteLine("Умножение матриц невозможно!");
    }
    Console.WriteLine();
}


Console.Clear();
while (MakeChoice("Решаем задачу 60 (с трёхмерным массивом)? "))
{
    Console.Clear();
    int rows = GetIntInResponce("Введите количество строк: ");
    int columns = GetIntInResponce("Введите количество столбцов: ");
    int depth = GetIntInResponce("Введите 'глубину' массива: ");
    int numFrom = GetIntInResponce("Массив заполняем числами от: ");
    int numTo = GetIntInResponce("Массив заполняем числами до: ");
    Console.WriteLine();

    int[,,] array3D = FillIntArray3D(rows, columns, depth, numFrom, numTo);
    PrintArray3DLayers(array3D);
    Console.WriteLine();
}