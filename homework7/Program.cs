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


bool MakeСhoice(string question)  // получаем ответ пользователя на вопрос
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

//------------

double[,] FillDoubleArray2D(int m, int n, int accuracyCalculations)  // получаем размер массива и точность вычисления
{
    double[,] outputArray = new double[m, n];
    Random random = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            outputArray[i, j] = Math.Round(random.Next(-10, 11) * random.NextDouble(), accuracyCalculations);
        }    
    }
    return outputArray;
}

//------------

void PrintDoubleArray2D(double[,] inputArray)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
//            Console.Write($"{inputArray[i,j]} ");
              Console.Write(String.Format("{0, 6}", inputArray[i, j]));
        }
        Console.WriteLine();
    }
}


//------------ Задачи

Console.Clear();
while (MakeСhoice("Выполняем задачу 47 (заполнение двумерного массива выещественными числами)?"))
{
    bool isInt;
    int rows, columns, accuracy;
    do
    {
        Console.Write("Введите количество строк: ");
        isInt = int.TryParse(Console.ReadLine(), out rows);
    } while (!isInt);

    do
    {
        Console.Write("Введите количество столбцов: ");
        isInt = int.TryParse(Console.ReadLine(), out columns);
    } while (!isInt);

    do
    {
        Console.Write("Введите точность (количество знаков после запятой): ");
        isInt = int.TryParse(Console.ReadLine(), out accuracy);
    } while (!isInt);
    Console.WriteLine();

    double[,] array = FillDoubleArray2D(rows, columns, accuracy);
    PrintDoubleArray2D(array);
    Console.WriteLine();
}

