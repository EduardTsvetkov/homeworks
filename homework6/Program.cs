
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

List<int> FillIntList()  // заполняем список целыми числами
{
    List<int> intList = new List<int>();
    bool flag = true;
    Console.WriteLine("Введите числа для подсчета.");
    Console.WriteLine("Для окончания ввода элементов списка введите любой символ (не число).");
    while (flag)
    {
        string inputString = Console.ReadLine();
        if (int.TryParse(inputString, out int element))  // Конвертируем inputString в element и проверяем на ошибку
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

int CheckPositive(List<int> inputList)  // Считаем количество положительных
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

void PrintList(List<int> inputList)  // Вывод списка
{
    foreach (int item in inputList)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine();
}

//------------

void GetCrossCoordinate(double a, double c, double b, double d, out double x, out double y)
{
    x = (d - c) / (a - b);
    y = (a * d - b * c) / (a - b);
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

Console.Clear();
while (MakeСhoice("Решаем задачу 43? (точка пересечения прямых)"))
{
    Console.Clear();
    Console.WriteLine("График прямой задается формулой y = k * x + b .");
    Console.WriteLine("Введите коэффициенты для 1 прямой:");
    Console.Write("k1 = ");
    double k1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("b1 = ");
    double b1 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Введите коэффициенты для 2 прямой:");
    Console.Write("k2 = ");
    double k2 = Convert.ToDouble(Console.ReadLine());
    Console.Write("b2 = ");
    double b2 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine();
    
    if (k1 == k2)
    {
        Console.WriteLine($"Прямые y = {k1}*x + {b1} и y = {k2}*x + {b2} параллельны.");
        if (b1 == b2)
        {
            Console.WriteLine($"Прямые y = {k1}*x + {b1} и y = {k2}*x + {b2} совпадают.");
        }
    }
    else
    {
        double crossX, crossY;
        GetCrossCoordinate(k1, b1, k2, b2, out crossX, out crossY);
        Console.WriteLine($"Координаты точки пересечения прямых y = {k1}*x + {b1} и y = {k2}*x + {b2} ");
        Console.WriteLine($"x = {crossX}, y = {crossY}");
    }
    Console.WriteLine();
}
