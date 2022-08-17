// Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

// Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

// Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]

bool MakeСhoice(string question)  // определяем выполнять (повторять) задачу или переходить к следующей
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



int GetInt()  // получаем целое число
{
    string num = Console.ReadLine();
    while (true)
    {
        bool isInt = int.TryParse(num, out int resultInt);
        if (isInt)
        {
            return resultInt;
        }
        else
        {
            Console.WriteLine("Вы ввели не целое число.");
            Console.Write("Введите целое число: ");
            num = Console.ReadLine();
        }
    }
}

int RaiseNumberPower(int baseNum, int indexNum)  // пишем свой метод pow  :-)
{
    int result = baseNum;
    for (int i = 1; i < indexNum; i++)
    {
        result *= baseNum;
    }
    return result;
}

int SumDigit(int num)  // а вот так суммируем цифры
{
    int result = 0;
    num = Math.Abs(num);
    while (num >= 10)
    {
        result += num % 10;
        num /= 10;
    }
    if (num < 10)
    {
        result += num;
    }
    return result;
}



while (MakeСhoice("Решаем задачу 25 (возведение в степень)?"))
{
    Console.Clear();
    Console.Write("Введите целое число A: ");
    int varA = GetInt();
    Console.Write("Введите натуральное число B (больше 0): ");
    int varB = GetInt();
    while (varB <= 0)
    {
        Console.WriteLine($"{varB} меньше или равно 0: ");
        Console.Write("Введите натуральное число B (больше 0): ");
        varB = GetInt();
    }
    Console.WriteLine($"{varA} в степени {varB} равно {RaiseNumberPower(varA, varB)}");
    Console.WriteLine();
}
Console.Clear();

while (MakeСhoice("Решаем задачу 27 (сумма цифр числа)?"))
{
    Console.Clear();
    Console.Write("Введите целое число: ");
    int number = GetInt();
    Console.WriteLine($"Сумма цифр числа {number} равна {SumDigit(number)}");
    Console.WriteLine();
}
Console.Clear();
