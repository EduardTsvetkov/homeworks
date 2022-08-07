Console.WriteLine();
Console.WriteLine("1. Определяем максимальное из двух чисел.");
Console.Write("Введите первое число: ");
int max = Convert.ToInt16(Console.ReadLine());
Console.Write("Введите второе число: ");
int a = Convert.ToInt16(Console.ReadLine());
if (a > max)
{
    max = a;
}
Console.WriteLine("Максимальное число: " + max);
Console.WriteLine();

//-----

Console.WriteLine();
Console.WriteLine("2. Определяем максимальное из трех чисел.");
Console.Write("Введите первое число: ");
max = Convert.ToInt16(Console.ReadLine());
Console.Write("Введите второе число: ");
a = Convert.ToInt16(Console.ReadLine());
if (a > max) max = a;
Console.Write("Введите третье число: ");
a = Convert.ToInt16(Console.ReadLine());
if (a > max) max = a;
Console.WriteLine("Максимальное число: " + max);
Console.WriteLine();

//-----

Console.WriteLine();
Console.WriteLine("3. Определяем четное или нет.");
Console.Write("Введите число: ");
a = Convert.ToInt16(Console.ReadLine());
if (a % 2 == 0) 
{
    Console.Write("Число " + a + " четное");
}
else
{
    Console.Write("Число " + a + " нечетное");
}

//-----

