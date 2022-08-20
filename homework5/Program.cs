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

void PrintIntArray(int[] inputArray)  // вывод на экран массива целых чисел
{
    foreach (int item in inputArray) 
    {
        Console.Write($"{item} ");
    }
}

//------------

