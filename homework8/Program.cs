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
/// Упорядочение по убыванию элементов строк двумерного массива целых числел
/// </summary>
/// <param name='inputArray'>Не сортированный массив</param>
/// <param name='n'>Число столбцов массива</param>
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




//------------ Задачи

while (MakeChoice("Решаем задачу 54 (упорядочить строки)?: "))
{
    int rows1 = GetIntInResponce("Введите количество строк: ");
    int columns1 = GetIntInResponce("Введите количество столбцов: ");
    int numFrom = GetIntInResponce("Массив заполняем числами от: ");
    int numTo = GetIntInResponce("Массив заполняем числами до: ");

    int[,] array1 = FillIntArray2D(rows1, columns1, numFrom, numTo);
    Console.WriteLine("Не сортированный массив: ");
    PrintIntArray2D(array1);
    Console.WriteLine("Cортированный массив: ");
    PrintIntArray2D(SortIntArray2D(array1));

} 