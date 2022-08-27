
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

//------------

void DrawAxisX(int y, int axisLength)
{
    for (int i = 0; i < axisLength - 1; i++)
    {
        Console.SetCursorPosition(i, y);
        Console.Write("-");
    }
    Console.Write(">");
    Console.Write("X");
}

//------------

void DrawAxisY(int x, int axisLength)
{
    Console.SetCursorPosition(x, 0);
    Console.Write("^Y");
    for (int i = 1; i < axisLength; i++)
    {
        Console.SetCursorPosition(x, i);
        Console.Write("|");
    }
}

//------------

void DrawLine(double k, double b, int minX, int maxX, int offsetAxisX, int offsetAxisY)
{

    for (int i = minX; i <= maxX; i++)
    {
        int y = Convert.ToInt32( -k * i - b);
        Console.SetCursorPosition(i + offsetAxisY, y + offsetAxisX);
        Console.Write("*");
    }
    
}

//------------

void GetRange(double k, double b, int terminalMiddleSize, double cross, out int min, out int max)
{
    if (k > 0)
    {
        min = Convert.ToInt32((-terminalMiddleSize + 1 + cross - b) / k);
        max = Convert.ToInt32((terminalMiddleSize - 1 + cross - b) / k);
    
    }
    else if (k < 0)
    {
        max = Convert.ToInt32((-terminalMiddleSize + 1 + cross - b) / k);
        min = Convert.ToInt32((terminalMiddleSize - 1 + cross - b) / k) ;
    }
    else
    {
        min = -20;
        max = 20;
    }
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
    Console.WriteLine("(для красоты исполбзуйте цифры от -3 до 3)");
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
    double crossX = 0;
    double crossY = 0;
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
        GetCrossCoordinate(k1, b1, k2, b2, out crossX, out crossY);
        Console.WriteLine($"Координаты точки пересечения прямых y = {k1}*x + {b1} и y = {k2}*x + {b2} ");
        Console.WriteLine($"x = {crossX}, y = {crossY}");

        
    }
    Console.WriteLine();


    if (MakeСhoice("Порисуем?"))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Тогда необходимо увеличить терминал и нажать Enter.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
        Console.Clear();
        int terminalSizeX = 100;
        int terminalSizeY = 20;
        

        int terminalMiddleX = terminalSizeX / 2;
        int terminalMiddleY = terminalSizeY / 2;
        
        int offsetAxisX = terminalMiddleY + Convert.ToInt32(crossY);
        if (offsetAxisX > 0 & offsetAxisX < terminalSizeY)
        {
            DrawAxisX(offsetAxisX, terminalMiddleX * 2);
        }
        int offsetAxisY = terminalMiddleX - Convert.ToInt32(crossX);
        if (offsetAxisY > 0 & offsetAxisY < terminalSizeX)
        {
            DrawAxisY(offsetAxisY, terminalMiddleY * 2);
        }

        int minX = 0;
        int maxX = 0;
        GetRange(k1, b1, terminalMiddleY, crossY, out minX, out maxX);
        Console.ForegroundColor = ConsoleColor.Red;
        DrawLine(k1, b1, minX, maxX, offsetAxisX, offsetAxisY);

        GetRange(k2, b2, terminalMiddleY, crossY, out minX, out maxX);
        Console.ForegroundColor = ConsoleColor.Green;
        DrawLine(k2, b2, minX, maxX, offsetAxisX, offsetAxisY);

        Console.SetCursorPosition(0, terminalSizeY);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"y = {k1}*x + {b1}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"y = {k2}*x + {b2}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Точка пересечения x = {crossX}, y = {crossY}");
    }

}
