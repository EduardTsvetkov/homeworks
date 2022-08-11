/*
Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.

456 -> 5
782 -> 8
918 -> 1

Задача 13: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.

645 -> 5

78 -> третьей цифры нет

32679 -> 6

Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.

6 -> да
7 -> да
1 -> нет
*/

bool makeСhoice(string question)
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
            return false;
        }
    }
    Console.WriteLine();
}

int getThreeDigit()
{
    while (true)
    {
        Console.Write("Ведите трехзначное число: ");
        int num3 = Convert.ToInt16(Console.ReadLine());
        if (num3 > 99 & num3 < 1000)
        {
            return num3;
        }
        Console.WriteLine($"Число {num3} не трехзначное!");
    }
}

int getMiddleNumber(int num)
{
    return (num / 10 % 10);
}

string lookingThirdDigit(string numS)
{
    if (numS.Length < 3)
    {
        return $"В числе {numS} третьей цифры нет!";
    }
    else
    {
        return $"В числе {numS} третья цифра {numS[2]}";
    }
}


while (makeСhoice("Решаем задачу 10?"))
{
    int number3 = getThreeDigit();
    Console.Write($"В числе {number3} средняя цифра ");
    Console.WriteLine(getMiddleNumber(number3));
    Console.WriteLine();

}

while ((makeСhoice("Решаем задачу 13?")))
{
    Console.Write("Ведите число: ");
    Console.WriteLine(lookingThirdDigit(Console.ReadLine()));
    Console.WriteLine();
}