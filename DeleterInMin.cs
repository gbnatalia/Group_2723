int[,] array = new int[new Random().Next(3, 6), new Random().Next(4, 7)];

for (int i = 0; i < array.GetLength(0); i++)
    for (int j = 0; j < array.GetLength(1); j++)
        array[i, j] = new Random().Next(99);



void PrintArray(int[,] tarray)
{
    for (int i = 0; i < tarray.GetLength(0); i++)
    {
        for (int j = 0; j < tarray.GetLength(1); j++)
        {
            Console.Write($"{tarray[i, j]} ");
        }
        Console.Write($"\n");
    }
}

int[,] Delete2(int[,] tarray)
{
    int[,] newArray = new int[tarray.GetLength(0) - 1, tarray.GetLength(1) - 1];
    int im = 0;
    int jm = 0;
    for (int i = 0; i < tarray.GetLength(0); i++)
        for (int j = 0; j < tarray.GetLength(1); j++)
            if (tarray[i, j] < tarray[im, jm])
            {
                im = i;
                jm = j;
            }
    for (int i = 0, i2 = 0; i < tarray.GetLength(0); i++, i2++)
    {
        if (i != im)
        {
            for (int j = 0, j2 = 0; j < tarray.GetLength(1); j++, j2++)
            {
                if (j != jm)
                {
                    newArray[i2, j2] = tarray[i, j];
                }
                else
                {
                    j2--;
                }
            }
        }
        else
            i2--;


    }
    return newArray;
}

PrintArray(array);
Console.WriteLine();
PrintArray(Delete2(array));