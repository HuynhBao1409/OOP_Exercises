// Stack v2 - Kế thừa & Đa hình

using System;

// ==================== Lớp cơ sở ====================
class Stack
{
    protected int top;
    protected int Max;
    protected int[] data;

    public Stack(int max)
    {
        Max = max;
        data = new int[Max];
        top = -1;
    }

    public bool IsEmpty() => top == -1;
    public bool IsFull() => top == Max - 1;

    public void Push(int value)
    {
        if (IsFull()) { Console.WriteLine("Ngăn xếp đầy!"); return; }
        data[++top] = value;
    }

    public int Pop()
    {
        if (IsEmpty()) { Console.WriteLine("Ngăn xếp rỗng!"); return -1; }
        return data[top--];
    }

    public int Peek()
    {
        if (IsEmpty()) { Console.WriteLine("Ngăn xếp rỗng!"); return -1; }
        return data[top];
    }

    // Phương thức ảo — lớp con override theo nhu cầu
    public virtual void Print()
    {
        if (IsEmpty()) { Console.WriteLine("Ngăn xếp rỗng!"); return; }
        Console.Write("Stack (đỉnh → đáy): ");
        for (int i = top; i >= 0; i--)
            Console.Write(data[i] + " ");
        Console.WriteLine();
    }
}

// ==================== Lớp dẫn xuất: phân tích thừa số ====================
class PrimeStack : Stack
{
    private int originalNumber;

    public PrimeStack(int max, int n) : base(max)
    {
        originalNumber = n;
    }

    // Override: in dãy thừa số nguyên tố (pop từ lớn → nhỏ)
    public override void Print()
    {
        if (IsEmpty()) { Console.WriteLine("Ngăn xếp rỗng!"); return; }

        Console.Write($"{originalNumber} = ");
        while (!IsEmpty())
        {
            Console.Write(Pop());
            if (!IsEmpty()) Console.Write(" * ");
        }
        Console.WriteLine();
    }
}

// ==================== Lớp dẫn xuất: đổi sang Hexa ====================
class HexaStack : Stack
{
    private static readonly char[] HEX = "0123456789ABCDEF".ToCharArray();
    private int originalNumber;

    public HexaStack(int max, int n) : base(max)
    {
        originalNumber = n;
    }

    // Override: in biểu diễn hex (pop cho ra thứ tự đúng)
    public override void Print()
    {
        if (IsEmpty()) { Console.WriteLine("0x0"); return; }

        Console.Write($"{originalNumber} (thập phân) = ");
        if (originalNumber < 0) Console.Write("-");
        Console.Write("0x");
        while (!IsEmpty())
            Console.Write(HEX[Pop()]);
        Console.WriteLine(" (thập lục phân)");
    }
}

// ==================== Chương trình chính ====================
class Program
{
    static void PhanTichThuaSo(int n)
    {
        Console.WriteLine($"\n=== Phân tích thừa số nguyên tố: {n} ===");
        if (n <= 1) { Console.WriteLine("Số phải lớn hơn 1."); return; }

        PrimeStack s = new PrimeStack(100, n);
        int tam = n;

        for (int uoc = 2; uoc * uoc <= tam; uoc++)
            while (tam % uoc == 0) { s.Push(uoc); tam /= uoc; }

        if (tam > 1) s.Push(tam);

        s.Print();   // gọi chung Print()
    }

    static void DoiSangHexa(int n)
    {
        Console.WriteLine($"\n=== Đổi {n} sang hệ 16 ===");
        if (n == 0) { Console.WriteLine("0x0"); return; }

        HexaStack s = new HexaStack(32, n);
        int tam = Math.Abs(n);

        while (tam > 0) { s.Push(tam % 16); tam /= 16; }

        s.Print();   // gọi chung Print()
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        PhanTichThuaSo(12);
        PhanTichThuaSo(360);
        PhanTichThuaSo(98);

        DoiSangHexa(12);
        DoiSangHexa(255);
        DoiSangHexa(4096);
    }
}