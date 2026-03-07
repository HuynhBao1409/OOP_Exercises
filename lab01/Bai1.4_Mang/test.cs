using System;

class ThaoTacMang
{
    static int[] InputArray()
    {
        Console.Write("sadsad");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"asdsadasd a[{i}]");
            arr[i] = int.Parse(Console.ReadLine());
        }
        return arr;
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("Mang: [");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" ]");
    }
}