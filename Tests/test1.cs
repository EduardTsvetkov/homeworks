﻿void PrintIntArray2D(int[,] inputArray)  // вывод на экран массива целых чисел
{
    string max = Convert.ToString(inputArray.Cast<int>().Max());  // находит максимальный элемент массива и в стринг
    string min = Convert.ToString(inputArray.Cast<int>().Min());  // находит минимальный элемент массива и в стринг
    int len = Math.Max(max.Length, min.Length) + 1;               // определяем размер поля для печати 
    string forFormat = "{0, " + Convert.ToString(len) + "}";      // формируем строку типа "{0, 4}"
 
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            Console.Write(String.Format(forFormat, inputArray[i, j]));
        }
        Console.WriteLine();
    }
}
 
int rows = 5, columns = 6;
int[,] spiralArr = FillSpiral(rows, columns);
 
int[,] FillSpiral(int Y, int X)
{
    int[,] arr = new int[Y, X];
    int col = 0;
    int row = 0;
    int dX = 0, dY = 0;
    int num = 0;
    for (int i = 1; i < arr.Length + 1; i++)
    {
        arr[row, col] = i;
        if ((X - i) + num > 0)  // идем по верху
        {
            dX = 1; dY = 0;
        }
        else if ((X + Y - 1 - i) + num > 0) // идем по правому краю
        {
            dX = 0; dY = 1;
        }
        else if ((2 * X + Y - 2 - i) + num > 0)  // идем по низу
        {
            dX = -1; dY = 0;
        }
        else if ((2 * X + 2 * Y - 4 - i) + num > 0)  // идем по правому краю
        {
            dX = 0; dY = -1;
        }
        else                                         // вносим корректировки (уменьшаем размер спирали)
        {
            dX = 1; dY = 0;
            X -= 2; Y -= 2;
            num = i;
        }
        row += dY;
        col += dX;
    }
    return arr;
}
 
PrintIntArray2D(spiralArr);