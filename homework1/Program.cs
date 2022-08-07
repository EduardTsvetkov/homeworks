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