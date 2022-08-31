// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

// Задача 50. Напишите программу, которая на вход принимает число и ищет в двумерном массиве, 
// и возвращает индексы этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 7 -> 0 , 2
// 5 -> 1 , 0
// 18 -> нет такого элемента

// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

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
/// Заполнение двумерного массива вещественными числами от -100 до 100
/// </summary>
/// <param name='m'>Число строк массива</param>
/// <param name='n'>Число столбцов массива</param>
/// <param name='accuracyCalculations'>Число знаков после запятой при округлении</param>
/// <returns>Двумерный массив вещественных чисел</returns>
double[,] FillDoubleArray2D(int m, int n, int accuracyCalculations)  // получаем размер массива и точность вычисления
{
    double[,] outputArray = new double[m, n];
    Random random = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            outputArray[i, j] = Math.Round(random.Next(-100, 101) * random.NextDouble(), accuracyCalculations);
        }
    }
    return outputArray;
}

/// <summary>
/// Заполнение двумерного массива целых числами от min до max
/// </summary>
/// <param name='m'>Число строк массива</param>
/// <param name='n'>Число столбцов массива</param>
/// <param name='min'>Минимальное число диапазона генерируемых чисел</param>
/// <param name='max'>Максимальное число диапазона генерируемых чисел</param>
/// <returns>Двумерный массив целых чисел</returns>
int[,] FillIntArray2D(int m, int n, int min, int max)  // получаем размер массива и точность вычисления
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
/// Вывод в консоль двумерного массива вещественных чисел
/// </summary>
/// <param name='inputArray'>Двумерный массив вещественных чисел</param>
/// <returns></returns>
void PrintDoubleArray2D(double[,] inputArray)
{
    string max = Convert.ToString(inputArray.Cast<double>().Max());  // находит максимальный элемент массива и в стринг
    string min = Convert.ToString(inputArray.Cast<double>().Min());  // находит минимальный элемент массива и в стринг
    int len = Math.Max(max.Length, min.Length) + 1;                  // определяем размер поля (не совсем корректно...)
    string forFormat = "{0, " + Convert.ToString(len) + "}";
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
    Console.WriteLine();
}


/// <summary>
/// Вывод в консоль индексов искомого числа в массиве целых чисел
/// </summary>
/// <param name='inputArray'>Двумерный массив целых чисел</param>
/// <param name='number'>Число для поиска в массиве</param>
/// <returns>true - число есть в массиве, false - числа нет</returns>
bool FindingNumber(int[,] inputArray, int number)
{
    bool flag = false;

    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            if (inputArray[i, j] == number)
            {
                Console.WriteLine($"У числа {number} в массиве индекс [{i}, {j}]. ");
                flag = true;
            }
        }

    }
    Console.WriteLine();
    return flag;
}

/// <summary>
/// Вывод в консоль среднего арифметического по столбцам массива
/// </summary>
/// <param name='inputArray'>Двумерный массив целых чисел</param>
/// <returns></returns>
void PrintAverageInColumns(int[,] inputArray)
{
    int rows = inputArray.GetLength(0);
    for (int j = 0; j < inputArray.GetLength(1); j++)
    {
        int columnsSum = 0;
        for (int i = 0; i < rows; i++)
        {
            columnsSum += inputArray[i, j];
        }
        double average = Convert.ToDouble(columnsSum) / Convert.ToDouble(rows);
        Console.WriteLine($"Среднее арифметическое столбца {j} равно: {average} ");
    }
}

//------------ Задачи

Console.Clear();
while (MakeChoice("Выполняем задачу 47 (заполнение двумерного массива выещественными числами)?"))
{
    Console.Clear();
    int rows1 = GetIntInResponce("Введите количество строк: ");
    int columns1 = GetIntInResponce("Введите количество столбцов: ");
    int accuracy = GetIntInResponce("Введите точность (количество знаков после запятой): ");

    Console.WriteLine();

    double[,] array1 = FillDoubleArray2D(rows1, columns1, accuracy);
    PrintDoubleArray2D(array1);
    Console.WriteLine();
}

Console.Clear();
while (MakeChoice("Решаем задачу 50 (поиск элемента массива)?"))
{
    Console.Clear();
    int rows2 = GetIntInResponce("Введите количество строк: ");
    int columns2 = GetIntInResponce("Введите количество столбцов: ");
    int numFrom = GetIntInResponce("Массив заполняем числами от: ");
    int numTo = GetIntInResponce("Массив заполняем числами до: ");

    int[,] array2 = FillIntArray2D(rows2, columns2, numFrom, numTo);

    PrintIntArray2D(array2);

    int findNumber = GetIntInResponce("Введите искомое число: ");
    if (!FindingNumber(array2, findNumber))
    {
        Console.WriteLine($"Числа {findNumber} нет в массиве. ");
        Console.WriteLine();
    }
}

Console.Clear();
while (MakeChoice("Решаем задачу 52 (среднее по столбцам),"))
{
    Console.Clear();
    int rows3 = GetIntInResponce("Введите количество строк: ");
    int columns3 = GetIntInResponce("Введите количество столбцов: ");
    int numFrom3 = GetIntInResponce("Массив заполняем числами от: ");
    int numTo3 = GetIntInResponce("Массив заполняем числами до: ");

    int[,] array3 = FillIntArray2D(rows3, columns3, numFrom3, numTo3);

    PrintIntArray2D(array3);
    PrintAverageInColumns(array3);
    Console.WriteLine();
}
Console.Clear();