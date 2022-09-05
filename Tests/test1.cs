void PrintIntArray2D(int[,] inputArray)  // вывод на экран массива целых чисел
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

int rows = 3, columns = 3;
int initX = 0, initY = 0;
int initNum = 0;
int[,] array = new int[rows,columns];
FillSpiral(rows, columns, array, initX, initY, initNum);

initNum = 2*rows + 2*columns - 4;
initX++; initY++;
rows -= 2;
columns -=2;
FillSpiral(rows, columns, array, initX, initY, initNum);



void FillSpiral(int Y, int X, int[,] arr, int col, int row, int num){

int dX = 0, dY = 0;

for (int i = 1; i < X + Y + X + Y - 3; i++)
{
    arr[row,col] = i + num;
    if ((X - i) > 0)  // идем по верху
    {
        dX = 1; dY = 0;
    }
    else if ((X + Y - 1 - i) > 0) // идем по правому краю
    {
        dX = 0; dY = 1;
    }
    else if ((2 * X + Y - 2 - i) > 0)
    {
        dX = -1; dY = 0;
    }
    else if ((2 * X + 2 * Y - 3 - i) > 0)
    {
        dX = 0; dY = -1;
    }
    else
    {
        dX = 1; dY = 0;

    }



        row += dY;
        col += dX;
    

}
}



PrintIntArray2D(array);