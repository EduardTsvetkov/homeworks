// Задача 64: Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N.
// M = 1; N = 5. -> ""1, 2, 3, 4, 5""
// M = 4; N = 8. -> ""4, 6, 7, 8""

// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 29

/// <summary>
/// Получение от пользователя ответа на вопрос.
/// </summary>
/// <param name='question'>Это вопрос пользователю</param>
/// <returns>true - Y (да), false - N (нет)</returns>
bool MakeChoice(string question)  // получаем ответ пользователя на вопрос
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

/// <summary>
/// Запрос у пользователя на ввод информации, проверка правильности 
/// </summary>
/// <param name='request'>Запрос к пользователю на ввод информации</param>
/// <returns>Целое число, введенное пользователем</returns>
int GetIntInResponce(string request)
{
    string answer = String.Empty;
    while (true)
    {
        Console.Write(request);
        answer = Console.ReadLine();
        if (int.TryParse(answer, out int result))
        {
            return result;
        }
        Console.WriteLine("Вы ввели не целое число. ");
    }
}

/// <summary>
/// Заполнение массива числами от M до N (рекурсия) 
/// </summary>
/// <param name='m'>Начальное число</param>
/// <param name='n'>Конечное число</param>
/// <returns></returns>
void PrintNumbers(int m, int n)
{
    Console.Write($" {m}");
    if(m < n)
    {
        PrintNumbers(m + 1, n);
    }
}

/// <summary>
/// подсчет суммы чисел от M до N (рекурсия) 
/// </summary>
/// <param name='m'>Начальное число</param>
/// <param name='n'>Конечное число</param>
/// <returns></returns>
int CalcSum(int m, int n, int result = 0)
{
    if(m <= n)
    {
        result = m + CalcSum(m + 1, n, result);
    }
    return result;
}

/// <summary>
/// Вычисление функции Аккермана (рекурсия) 
/// </summary>
/// <param name='m'>Первое число</param>
/// <param name='n'>Второе число</param>
/// <returns>Значение функции</returns>

ulong AkkermanFunction(ulong m, ulong n)
{
    ulong result;
    if (m == 0)
    {
        result = n + 1;
    }
    else if (m > 0 & n == 0)
    {
        result = AkkermanFunction(m - 1, 1);
    }
    else
    {
        result = AkkermanFunction(m - 1, AkkermanFunction(m, n - 1));    
    }
    return result;
}


Console.Clear();
while (MakeChoice("Решаем задачу 64 (вывод чисел в указанном интервале)? "))
{
    Console.Clear();
    int numFrom, numTo;
    do
    {
        Console.WriteLine("Введите числа (второе больше первого):");
        numFrom = GetIntInResponce("введие первое число ");
        numTo = GetIntInResponce("введие второе число ");
    } while (numFrom >= numTo);
    
    PrintNumbers(numFrom, numTo);
    Console.WriteLine();
    Console.WriteLine();
}

Console.Clear();
while (MakeChoice("Решаем задачу 66 (вывод суммы диапазона чисел)? "))
{
    Console.Clear();
    int numFrom2, numTo2;
    do
    {
        Console.WriteLine("Введите числа (второе больше первого):");
        numFrom2 = GetIntInResponce("введие первое число ");
        numTo2 = GetIntInResponce("введие второе число ");
    } while (numFrom2 >= numTo2);
    
    Console.WriteLine(CalcSum(numFrom2, numTo2));
    Console.WriteLine();
}

Console.Clear();
while (MakeChoice("Решаем задачу 68 (функция Аккермана)? "))
{
    Console.Clear();
    ulong numM = Convert.ToUInt64(GetIntInResponce("Введие первое число: "));
    ulong numN = Convert.ToUInt64(GetIntInResponce("Введие второе число: "));
    Console.WriteLine("Функция Аккермана:");
    Console.WriteLine($"A({numM},{numN}) = {AkkermanFunction(numM, numN)}");
    Console.WriteLine();
}