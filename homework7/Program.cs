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

//------------

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

//------------

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

//------------

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

//------------

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

//------------

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

bool FindingNumber(int[,] inputArray, int number, out int indexI, out int indexJ)
{
    indexI = -1;
    indexJ = -1;
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            if (inputArray[i, j] == number)
            {
                indexI = i;
                indexJ = j;
                return true;
            }
        }
        
    }   
    return false; 
}

//------------ Задачи

Console.Clear();
while (MakeChoice("Выполняем задачу 47 (заполнение двумерного массива выещественными числами)?"))
{

    int rows1 = GetIntInResponce("Введите количество строк: ");
    int columns1 = GetIntInResponce("Введите количество столбцов: ");
    int accuracy = GetIntInResponce("Введите точность (количество знаков после запятой): ");
    
    Console.WriteLine();

    double[,] array1 = FillDoubleArray2D(rows1, columns1, accuracy);
    PrintDoubleArray2D(array1);
    Console.WriteLine();
}


while (MakeChoice("Решаем задачу 50 (поиск элемента массива)?"))
{
    int rows2 = GetIntInResponce("Введите количество строк: ");
    int columns2 = GetIntInResponce("Введите количество столбцов: ");    
    int numFrom = GetIntInResponce("Массив заполняем числами от: ");
    int numTo = GetIntInResponce("Массив заполняем числами до: ");
    
    int[,] array2 = FillIntArray2D(rows2, columns2, numFrom, numTo);

    PrintIntArray2D(array2);

    int findNumber = GetIntInResponce("Введите искомое число: ");
    int indI, indJ;
    if (FindingNumber(array2, findNumber, out indI, out indJ))
    {
        Console.WriteLine($"У числа {findNumber} в массиве индекс [{indI}, {indJ}]. ");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"Числа {findNumber} нет в массиве. ");
        Console.WriteLine();
    }
}