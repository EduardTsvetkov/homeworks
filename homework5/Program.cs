// Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
// [345, 897, 568, 234] -> 2

// Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0

// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
// [3 7 22 2 78] -> 76

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

int[] FillIntArray(int arraySize, int minValue, int maxValue)
{
    int[] outputArray = new int[arraySize];
    Random random = new Random();
    for (int i = 0; i < arraySize; i++)
    {
        outputArray[i] = random.Next(minValue, maxValue + 1);
    }
    return outputArray;
}

//------------

void PrintIntArray(int[] inputArray)  // вывод на экран массива целых чисел
{
    foreach (int item in inputArray)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine();
}

//------------

int CheckEvenInArray(int[] inputArray)  // подсчет количества четных чисел в массиве
{
    int counter = 0;
    foreach (int item in inputArray)
    {
        if (item % 2 == 0)
        {
            counter++;
        }
    }
    return counter;
}

//------------

int SumOddElements(int[] inputArray)  // подсчет суммы элементов на нечетных позициях
{
    int sum = 0;
    for (int i = 1; i < inputArray.Length; i += 2)
    {
        sum += inputArray[i];
    }

    return sum;
}

//------------ Задачи

Console.Clear();
while (MakeСhoice("Решаем задачу 34? (количество чётных в массиве)"))
{
    Console.Clear();
    Console.Write("Введите размер массива: ");
    int sizeFirstArr = Convert.ToInt32(Console.ReadLine());
    int min = 100, max = 999;
    int[] arr1 = FillIntArray(sizeFirstArr, min, max);
    PrintIntArray(arr1);  // проверка заполнения массива
    Console.WriteLine($"Четных чисел {CheckEvenInArray(arr1)}");
    Console.WriteLine();
}

Console.Clear();
while (MakeСhoice("Решаем задачу 36 (сумма нечетных элементов)?"))
{
    Console.Clear();
    int min = -10, max = 11; // пусть в массиве будут [-50, 50]
    Console.Write("Введите размер массива: ");
    int arrSize = Convert.ToInt32(Console.ReadLine());
    int[] arr2 = FillIntArray(arrSize, min, max);
    PrintIntArray(arr2);  // проверка заполнения массива
    Console.WriteLine($"Сумма элементов на нечётных позициях {SumOddElements(arr2)}");
    Console.WriteLine();
}

