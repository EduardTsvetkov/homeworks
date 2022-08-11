
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


int getThreeDigit()  // получаем трехзначное число
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

int getMiddleNumber(int num)  // определяем среднюю цифру в трехзначном числе
{
    return (num / 10 % 10);
}

string lookingThirdDigit(string numS)  // определяем третий символ
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


int choosingDay()  // получаем номер дня недели
{
    while (true)
    {
        Console.Write("Ведите номер дня недели (число от 1 до 7): ");
        int dayNum = Convert.ToInt16(Console.ReadLine());
        if (dayNum > 0 & dayNum < 8)
        {
            return dayNum;
        }
    }
}

string whatDay(int dayNumber)  // сообщаем что за день :-)
{
    switch (dayNumber)
    {
        case 1:
            return "Первый день недели - отходим после выходных.";
        case 2:
            return "Второй день недели - готовимся к работе.";
        case 3:
            return "Третий день недели - работаем.";
        case 4:
            return "Четвертый день недели - отходим после работы.";
        case 5:
            return "Пятый день недели - готовимся к выходным.";
        case 6:
            return "Шестой день недели - первый выходной!";
        case 7:
            return "Первый день недели - второй выходной!";
        default:
            return "Что-то не так";
    }
}

// -----  Задачи  -----

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



while ((makeСhoice("Решаем задачу 15?")))
{
    Console.WriteLine(whatDay(choosingDay()));
    Console.WriteLine();
}

Console.WriteLine("Домашка выполнена!");
Console.WriteLine();
