//Вариант 4.
//16,5,17,4,15,6,14,7,13,8,12,9,11,10,20,1,19,2,18,3

int[] sourceArray = new int[20]
{
    16, 5, 17, 4, 15, 6, 14, 7, 13, 8, 12, 9, 11, 10, 20, 1, 19, 2, 18, 3
};

int[] insertionSortArray = new int[20];
int[] selectionSortArray = new int[20];
int[] bumbleSortArray = new int[20];
int[] shellSortArray = new int[20];

Array.Copy(sourceArray, insertionSortArray, sourceArray.Length);
Array.Copy(sourceArray, selectionSortArray, sourceArray.Length);
Array.Copy(sourceArray, bumbleSortArray, sourceArray.Length);
Array.Copy(sourceArray, shellSortArray, sourceArray.Length);

Console.WriteLine("Исходный массив:");
PrintArray(sourceArray);
Console.WriteLine("\r\n");

var results = new Dictionary<string, (int, int)>();

var resultInsertionSort = InsertionSort(insertionSortArray);
results.Add(nameof(InsertionSort), resultInsertionSort);

var resultSelectionSort = SelectionSort(selectionSortArray);
results.Add(nameof(SelectionSort), resultSelectionSort);

var resultBumbleSort = BumbleSort(bumbleSortArray);
results.Add(nameof(BumbleSort), resultBumbleSort);

var resultShellSort = ShellSort(shellSortArray);
results.Add(nameof(ShellSort), resultShellSort);

Console.WriteLine("\r\n\r\n----------------РЕЗУЛЬТАТЫ----------------\r\n\r\n");

foreach (var result in results)
{
    Console.WriteLine($"{result.Key}:\r\n Число сравнений: {result.Value.Item1}\r\n" +
        $" Число перестановок: {result.Value.Item2}\r\n\r\n");
}

//Сортировка прямыми включениями (сортировка вставками)
(int, int) InsertionSort(int[] sourceArray)
{
    int countCompare = 0;
    int countSwap = 0;

    for (int i = 0; i < sourceArray.Length; i++)
    {
        int selectedElement = sourceArray[i];
        int indexSelectedElement = i;

        countCompare++;
        if (i == 0)
            continue;

        for (int j = i; j > 0; j--)
        {
            countCompare++;
            if (selectedElement > sourceArray[indexSelectedElement - 1])
                break;

            SwapValues(ref sourceArray, indexSelectedElement - 1, j);
            countSwap++;

            //PrintArray(sourceArray);
            indexSelectedElement = j - 1;
        }
    }

    Console.WriteLine("Результат сортировки прямыми включениями:");
    PrintArray(sourceArray);

    Console.WriteLine($"Число сравнений: {countCompare}");
    Console.WriteLine($"Число перестановок: {countSwap}\r\n");

    return (countCompare, countSwap);
}

//Сортировка прямым выбором
(int, int) SelectionSort(int[] sourceArray)
{
    int countCompare = 0;
    int countSwap = 0;

    for (int i = 0; i < sourceArray.Length; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < sourceArray.Length; j++)
        {
            countCompare++;
            if (sourceArray[j] < sourceArray[minIndex])
                minIndex = j;
        }

        countCompare++;
        if (minIndex == i)
            continue;

        SwapValues(ref sourceArray, i, minIndex);
        countSwap++;

        //PrintArray(sourceArray);
    }

    Console.WriteLine("Результат сортировки прямым выбором:");
    PrintArray(sourceArray);

    Console.WriteLine($"Число сравнений: {countCompare}");
    Console.WriteLine($"Число перестановок: {countSwap}\r\n");

    return (countCompare, countSwap);
}

//Сортировка пузырьком
(int, int) BumbleSort(int[] sourceArray)
{
    int countCompare = 0;
    int countSwap = 0;

    for (int i = 0; i < sourceArray.Length; i++)
    {
        for (int j = 0; j < sourceArray.Length - 1 - i; j++)
        {
            countCompare++;
            if (sourceArray[j] > sourceArray[j + 1])
            {
                countSwap++;
                SwapValues(ref sourceArray, j, j + 1);
            }
        }
    }

    Console.WriteLine("Результат сортировки пузырьком:");
    PrintArray(sourceArray);

    Console.WriteLine($"Число сравнений: {countCompare}");
    Console.WriteLine($"Число перестановок: {countSwap}\r\n");

    return (countCompare, countSwap);
}

//Сортировка Шелла
(int, int) ShellSort(int[] sourceArray)
{
    int countCompare = 0;
    int countSwap = 0;

    int  d = 4;
    while (d >= 1)
    {
        for (int i = d; i < sourceArray.Length; i++)
        {
            int j = i;

            while ((j >= d) && (sourceArray[j - d] > sourceArray[j]))
            {
                countCompare++;
                countSwap++;

                SwapValues(ref sourceArray, j, j - d);
                j -= d;
            }
        }

        d /= 2;
    }

    Console.WriteLine("Результат сортировки Шелла:");
    PrintArray(sourceArray);

    Console.WriteLine($"Число сравнений: {countCompare}");
    Console.WriteLine($"Число перестановок: {countSwap}\r\n");

    return (countCompare, countSwap);
}

void SwapValues(ref int[] sourceArray, int index1, int index2)
    => (sourceArray[index2], sourceArray[index1]) = (sourceArray[index1], sourceArray[index2]);

void PrintArray(int[] array)
{
    var stringArray = String.Join(", ", array);
    Console.WriteLine(stringArray);
}