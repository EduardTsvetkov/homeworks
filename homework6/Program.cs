
// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3

// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями 
// y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)


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

List<int> FillIntList()
{
    List<int> intList = new List<int>();
    bool flag = true;
    Console.WriteLine("Введите числа для подсчета.");
    Console.WriteLine("Для окончания ввода элементов списка введите любой символ (не число).");
    while (flag)
    {
        string inputString = Console.ReadLine();
        if (int.TryParse(inputString, out int element))
        {
            intList.Add(element);
        }
        else
        {
            flag = false;
        }
       
    }

    return intList;
}

//------------

int CheckPositive(List<int> inputList)
{
    int counter = 0;
    foreach (int item in inputList)
    {
        if (item > 0)
        {
            counter++;
        }
    }
    return counter;
}

//------------

void PrintList(List<int> inputList)
{
    foreach (int item in inputList)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine();
}


//------------ Задачи

Console.Clear();
while (MakeСhoice("Решаем задачу 41? (количество положитедьных)"))
{
    Console.Clear();
    List<int> resultingList = FillIntList();
    int quantityPositive = CheckPositive(resultingList);
    Console.WriteLine("В списке чисел:");
    PrintList(resultingList);
    Console.WriteLine($"Положительных чисел: {quantityPositive} .");
    Console.WriteLine();
}

