// Задача 23
// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125


bool makeСhoice(string question)  // определяем выполнять (повторять) задачу или переходить к следующей
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


string getFiveDigit()  // получаем пятизначное число
{
    while (true)
    {
        Console.Write("Ведите пятизначное число: ");
        int num5 = Convert.ToInt32(Console.ReadLine());
        if (num5 > 9999 & num5 < 100000)
        {
            return num5.ToString();
        }
        Console.WriteLine($"Число {num5} не пятизначное!");
    }
}

string stringReverse(string inputS)
{
    string reverseS = "";
    for (int i = inputS.Length - 1; i >= 0; i--)
    {
        reverseS += inputS[i];
    }
    return reverseS;
}

bool checkPalindrome(string s)
{
    if (s == stringReverse(s))
    {
        return true;
    }
    else
    {
        return false;
    }
}

double getLength3D(double x1, double y1, double z1, double x2, double y2, double z2)
{
    return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
}


int[] CalculateCubes(int quantity)
{
    int[] cubes = new int[quantity];
    for (int i = 1; i <= quantity; i++)
    {
        cubes[i-1] = i * i * i;
    }
    return cubes;
}




// -----  Задачи  -----

while (makeСhoice("Решаем задачу 19?"))
{
    string string5 = getFiveDigit();
    if (checkPalindrome(string5))
    {
        Console.WriteLine("ДА");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("НЕТ");
        Console.WriteLine();
    }

}


while ((makeСhoice("Решаем задачу 21?")))
{
    Console.WriteLine("Ведите координаты точки A: ");
    Console.Write("х = ");
    double ax = Convert.ToInt32(Console.ReadLine());
    Console.Write("y = ");
    double ay = Convert.ToInt32(Console.ReadLine());
    Console.Write("z = ");
    double az = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ведите координаты точки B: ");
    Console.Write("х = ");
    double bx = Convert.ToInt32(Console.ReadLine());
    Console.Write("y = ");
    double by = Convert.ToInt32(Console.ReadLine());
    Console.Write("z = ");
    double bz = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine(getLength3D(ax, ay, az, bx, by, bz));
    Console.WriteLine();
}

while (makeСhoice("Решаем задачу 23?"))
{
    Console.Write("Введите число: ");
    int n = Convert.ToInt32(Console.ReadLine());
    
    int[] arrayCubes = CalculateCubes(n);

    Console.Write("3 -> ");
    foreach (int item in arrayCubes) 
    {
        Console.Write($"{item}, ");
    }
    Console.Write();
}