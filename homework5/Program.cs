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

int CheckEvenInArray(int[] inputArray)
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


//------------ Задачи

Console.Clear();
while (MakeСhoice("Решаем задачу 34? (количество чётных в массиве)"))
{
    Console.Clear();
    Console.Write("Введите размер массива: ");
    int size = Convert.ToInt32(Console.ReadLine());
    int min = 100, max = 999; 
    int[] arr = FillIntArray(size, min, max);
    PrintIntArray(arr);  // проверка заполнения массива
    Console.WriteLine($"Четных чисел {CheckEvenInArray(arr)}");
    Console.WriteLine();
} 
