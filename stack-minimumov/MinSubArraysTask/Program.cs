using ochered_minimumov;


//Очередь
static void PrintMinimumsByQueue(int[] arr, int k)
{
    var queue = new OcheredMinimumov<int>();
    int len = arr.Length;
    for (int i = 0; i < k - 1; i++)
    {
        queue.Push(arr[i]);
    }
    for (int i = k - 1; i < len; i++)
    {
        queue.Push(arr[i]);
        int min = queue.GetMinimum();
        queue.Pop();
    }
}

//Перебор
static void PrintMinimumsByIterating(int[] arr, int k)
{
    for (int i = 0; i < arr.Length-k+1; i++)
    {
        int min = arr[i];
        for (int j = i+1; j < i+k; j++)
        {
            min = arr[j] < min ? arr[j] : min;
        }
    }
}

//Set
static void PrintMinimumsBySet(int[] array, int k)
{
    var window = new SortedSet<int>();

    for (int i = 0; i < k; i++)
    {
        window.Add(array[i]);
    }
    int minElement = window.Min;
    //Console.WriteLine($"Minimum for subsequence 1: {minElement}");
    
    for (int i = k; i < array.Length; i++)
    {
        window.Add(array[i]);
        window.Remove(array[i - k]);
        minElement = window.Min;
        //Console.WriteLine($"Minimum for subsequence {i - k + 2}: {minElement}");
    }
}

