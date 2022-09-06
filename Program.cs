int[,] array = new int[new Random().Next(3, 6), new Random().Next(4, 7)];

for (int i = 0; i < array.GetLength(0); i++)
    for (int j = 0; j < array.GetLength(1); j++)
        array[i, j] = new Random().Next(99);

int[,] NumbersCount(int[,] tarray)
{
    int[,] countArray = new int[tarray.GetLength(0) * tarray.GetLength(1), 2];
    int count = 0;
    int size = 1;
    foreach (var item in tarray)
        if (item == 0)
            count++;
    countArray[0, 0] = 0;
    countArray[0, 1] = count;
    if (count == 0)
        size = 0;
    count = 0;
    int currentNumber = 0;
    for (int k = 0; k < countArray.GetLength(0); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (tarray[i, j] != 0 && currentNumber == 0)
                    currentNumber = tarray[i, j];
                if (currentNumber != 0)
                {
                    if (tarray[i, j] == currentNumber)
                    {
                        count++;
                        tarray[i, j] = 0;
                    }
                }
            }
        }
        if (count != 0)
        {
            countArray[size, 0] = currentNumber;
            countArray[size, 1] = count;
            size++;
            currentNumber = 0;
            count = 0;

        }
        else
            break;
    }
    int[,] temparray = new int[size, 2];
    for (int i = 0; i < size; i++)
    {
        temparray[i, 0] = countArray[i, 0];
        temparray[i, 1] = countArray[i, 1];
    }

    for (int j = 0; j < temparray.GetLength(0); j++)
    {
        for (int i = 0; i < temparray.GetLength(0) - 1; i++)
        {
            if (temparray[i, 0] > temparray[i + 1, 0])
            {
                int temp1 = temparray[i, 0];
                int temp2 = temparray[i, 1];
                temparray[i, 0] = temparray[i + 1, 0];
                temparray[i, 1] = temparray[i + 1, 1];
                temparray[i + 1, 0] = temp1;
                temparray[i + 1, 1] = temp2;
            }
        }
    }

    return temparray;
}

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

PrintArray(array);
Console.WriteLine();
PrintArray(NumbersCount(array));