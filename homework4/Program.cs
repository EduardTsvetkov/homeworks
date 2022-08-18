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

string[] GetArrayFromFile(string path)  // читаем все строки файла в массив
{
    Console.WriteLine($"Читаем файл {path}");
    string[] lines = File.ReadAllLines(path);
    return lines;
}



//----------- Задачи

Console.Clear();
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


/*
Читаем массив из файла
Текстовый файл должен находиться в текущей папке (либо указывать полный путь)
В каждой строчке одно число
*/

while (MakeСhoice("Решаем задачу 29 (вывод массива на экран)?"))
{
    Console.Clear();
    Console.Write("Введите имя файла (например, test.txt): ");
    string fileName = Console.ReadLine();
    while (!File.Exists(fileName))   // проверяем открывается ли файл
    {
        Console.WriteLine($"Файл {fileName} не существует.");
        Console.Write("Введите имя файла: ");
        fileName = Console.ReadLine();
    }

    string[] strArr = GetArrayFromFile(fileName);

    Console.WriteLine();
    Console.WriteLine("Полученный массив: ");
    foreach (string itemArr in strArr)  // для каждого элемента strArr, который передается в переменную itemArr
    {
        // что-нибудь делаем с полученным элементом
        Console.Write($"{itemArr} ");
    }
    Console.WriteLine();
    Console.WriteLine();
}
Console.Clear();


/*
Читаем данные из файла
Разбираем строчку на отдельные поля
Текстовый файл должен находиться в текущей папке (либо указывать полный путь)
В каждой строке текст типа
Приход;12 675,15
Расход;2 600,00
*/


while (MakeСhoice("Бонус? "))
{
Console.Clear();
    Console.Write("Введите имя файла (например, balance.txt): ");
    string balanceFileName = Console.ReadLine();
    while (!File.Exists(balanceFileName))   // проверяем открывается ли файл
    {
        Console.WriteLine($"Файл {balanceFileName} не существует.");
        Console.Write("Введите имя файла (например, balance.txt): ");
        balanceFileName = Console.ReadLine();
    }

    string[] balanceArr = GetArrayFromFile(balanceFileName);

    float receipt = 0;
    float spending = 0;
    for (int i = 1; i < balanceArr.Length; i++)
    {
        string[] words = balanceArr[i].Split(';');  // разбиваем строку на слова по разделителю ;
        float sum = Convert.ToSingle(words[1].Replace(" ", ""));
        Console.WriteLine($"{words[0]}: {words[1]}");
        if (words[0] == "Приход")
        {
            receipt += sum;
        }
        else if (words[0] == "Расход")
        {
            spending += sum;
        }


    }
    double balance = Math.Round(receipt - spending, 2);
    Console.WriteLine("-------------------");
    Console.WriteLine($"Приход: {receipt}");
    Console.WriteLine($"Расход: {spending}");
    Console.WriteLine($"Баланс: {balance}");
    Console.WriteLine();
}

// в следующий раз попробую читать excel...

