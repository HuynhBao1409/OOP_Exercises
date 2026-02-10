// Viết chương trình C# thực hiện các công việc sau (mỗi chức năng xây dựng thành một hàm):
// a) Nhập một mảng n số nguyên từ bàn phím.
// b) In các phần tử của mảng lên màn hình.
// c) Trả về phần tử lớn nhất của mảng.
// d) Trả về kiểu boolean kiểm tra mảng đã được sắp xếp tăng dần chưa.
// e) Sắp xếp mảng theo thứ tự tăng dần.
// f) Tách mảng thành 2 mảng con: một mảng chứa các phần tử chẵn, mảng còn lại chứa các phần tử lẻ.
using System;

class ThaoTacMang
{
    //a.Nhập một mảng n số nguyên từ bàn phím
    static int[] InputArray()
    {
        Console.Write("Nhập số phần tử n: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhap ptu trong mang a[{i}]: ");
            arr[i] = int.Parse(Console.ReadLine());
        }
        return arr;
    }

    //b.In các phần tử của mảng lên màn hình.
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

    //c.Trả về phần tử lớn nhất của mảng.
    static int FindMax(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }

    //d.Trả về kiểu boolean kiểm tra mảng đã được sắp xếp tăng dần chưa.
    static bool KTSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    //e. Sắp xếp mảng theo thứ tự tăng dần.
    static int[] SapXepTangDan(int[] arr)
    {
        int[] sorted = (int[])arr.Clone(); //giữ mảng gốc ban đầu
        for (int i = 0; i < sorted.Length - 1; i++)
        {
            for (int j = 0; j < sorted.Length - 1 - i; j++)
            {
                if (sorted[j] > sorted[j + 1])
                {
                    int temp = sorted[j];
                    sorted[j] = sorted[j + 1];
                    sorted[j + 1] = temp;
                }
            }
        }
        return sorted;
    }

    //f.Tách mảng thành 2 mảng con: chẵn và lẻ
    static void TachMang(int[] arr, out int[] mangchan, out int[] mangle)
    {
        int chanCount = 0, leCount = 0;
        foreach (int num in arr)
        {
            if (num % 2 == 0) chanCount++;
            else leCount++;
        }

        mangchan = new int[chanCount];
        mangle = new int[leCount];

        int ci = 0, li = 0;
        foreach (int num in arr)
        {
            if (num % 2 == 0) mangchan[ci++] = num;
            else mangle[li++] = num;
        }
    }

    //Main
    static void Main()
    {
        //a
        int[] arr = InputArray();
        Console.WriteLine();

        //b
        Console.Write("Mang goc: ");
        PrintArray(arr);
        Console.WriteLine();

        //c
        int max = FindMax(arr);
        Console.WriteLine($"Ptu lon nhat: {max}");
        Console.WriteLine();

        //d
        bool isSorted = KTSort(arr);
        Console.WriteLine($">> Mảng đã sắp xếp tăng dần? {(isSorted ? "Đúng" : "Sai")}");
        Console.WriteLine();

        //e
        int[] sortedArr = SapXepTangDan(arr);
        Console.Write(">> Mảng sau khi sắp xếp tăng dần: ");
        PrintArray(sortedArr);

        Console.WriteLine($">> Kiểm tra lại - Đã sắp xếp tăng dần? {(KTSort(sortedArr) ? "Đúng" : "Sai")}");
        Console.WriteLine();

        //f
        TachMang(arr, out int[] mangchan, out int[] mangle);
        Console.Write(">> Mảng các số chẵn: ");
        PrintArray(mangchan);
        Console.Write(">> Mảng các số lẻ:  ");
        PrintArray(mangle);
    }
}