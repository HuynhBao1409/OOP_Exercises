// 1. Cài đặt lớp Stack mô tả các thao tác xử lý trên ngăn xếp với dữ liệu là số nguyên.
// Các thuộc tính:
// - top: chỉ số của phần tử trên cùng.
// - Max: số phần tử đối đa.
// - stack: mảng chứa các phần tử.
// Các phương thức:
// - Thiết lập: khởi tạo ngăn xếp rỗng (gán chỉ số top = -1).
// - Push(int data): thêm phần tử.
// - Pop(): lấy ra phần tử trên cùng.
// - Peek(): in ra phần tử trên cùng.
// - IsEmpty(): kiểm tra Stack có rỗng hay không.
// - Print(): In ra danh sách phần tử trong Stack.

// 2. Chương trình chính
// a. Sử dụng lớp Stack để phân tích một số nguyên thành thừa số nguyên tố, sau đó in ra các thừa số theo thứ tự ngược lại.
// Ví dụ:
// Input: 12
// Output: = 3 * 2 * 2
// b. Sử dụng lớp Stack để đổi một số nguyên sang hệ nhị phân, thập lục phân.

using System;

class Stack
{
    private int top;    // chỉ số phần tử trên cùng
    private int Max;     // số phần tử tối đa
    private int[] stack;    // mảng lưu phần tử

    // Khởi tạo ngăn xếp rỗng, gán top = -1
    public Stack(int max)
    {
        Max = max;
        stack = new int[Max];
        top = -1;
    }

    // Kiểm tra ngăn xếp có rỗng không
    public bool IsEmpty()
    {
        return top == -1;
    }

    // Kiểm tra ngăn xếp có đầy không
    public bool IsFull()
    {
        return top == Max - 1;
    }

    // Thêm phần tử vào đỉnh
    public void Push(int data)
    {
        if (IsFull())
        {
            Console.WriteLine("Ngăn xếp đầy, không thể thêm");
            return;
        }
        top++;
        stack[top] = data;
    }

    // Lấy phần tử ở đỉnh ra (xóa khỏi stack)
    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Ngăn xếp rỗng, không thể lấy");
            return -1;
        }
        int giatri = stack[top];
        top--;
        return giatri;
    }

    // Xem phần tử ở đỉnh (không xóa)
    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Ngăn xếp rỗng, không thể lấy");
            return -1;
        }
        return stack[top];
    }

    // In toàn bộ phần tử
    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Ngăn xếp rỗng!!");
            return;
        }

        Console.Write("Stack (từ đỉnh xuống đáy): ");
        for (int i = top; i >= 0; i++)
        {
            Console.Write(stack[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    // --- 2a. Phân tích thừa số nguyên tố ---
    static void PhanTichThuaSo(int n)
    {
        Console.WriteLine($"\n=== Phân tích thừa số ngtố của {n} ===");
        if (n <= 1)
        {
            Console.WriteLine("Số phải lớn hơn 1.");
            return;
        }

        Stack s = new Stack(100);
        int tam = n;

        //Chia liên tiếp từ 2 trở lên, mỗi ước tìm được đẩy vào stack
        for (int uoc = 2; uoc * uoc <= tam; uoc++)
        {
            while (tam % uoc == 0)
            {
                s.Push(uoc);
                tam /= uoc;
            }
        }

        // Nếu còn phần dư > 1 thì đó cũng là thừa số nguyên tố
        if (tam > 1)
        {
            s.Push(tam);
        }
        // Pop ra để in theo thứ tự ngược (từ lớn về nhỏ)
        Console.Write($"{n}= ");
        while (!s.IsEmpty())
        {
            Console.Write(s.Pop());
            if (!s.IsEmpty())
            {
                Console.Write(" * ");
            }
        }
        Console.WriteLine();
    }

    // --- 2b. Đổi sang hệ nhị phân ---
    static void DoiSangNhiPhan(int n)
    {
        Console.WriteLine($"\n=== Đổi {n} sang hệ nhị phân ===");

        if (n == 0)
        {
            Console.WriteLine("Nhị phân: 0");
            return;
        }
        Stack s = new Stack(64);
        int tam = Math.Abs(n);

        // Chia liên tiếp cho 2, đẩy phần dư vào stack
        while (tam > 0)
        {
            s.Push(tam % 2);
            tam /= 2;
        }

        // Pop ra là đúng thứ tự từ bit cao xuống bit thấp
        Console.Write($"{n} (Thập Phân)= ");
        if (n < 0) Console.Write("-");
        while (!s.IsEmpty())
        {
            Console.Write(s.Pop());
        }
        Console.WriteLine(" (Nhị phân) ");
    }

    // --- 2b. Đổi sang hệ thập lục phân ---
    static void DoiSangThapLucPhan(int n)
    {
        Console.WriteLine($"\n=== Đổi {n} sang hệ thập lục phân ===");

        if (n == 0)
        {
            Console.WriteLine("Thập lục phân: 0x0");
            return;
        }

        //Bang ky tu Hex
        char[] kytuHex = {'0','1','2','3','4','5','6','7',
                           '8','9','A','B','C','D','E','F'};

        Stack s = new Stack(32);
        int tam = Math.Abs(n);

        // Chia liên tiếp cho 16, đẩy phần dư vào stack
        while (tam > 0)
        {
            s.Push(tam % 16);
            tam /= 16;
        }
        // Pop ra và tra bảng ký tự hex
        Console.Write($"{n} (thập phân) = ");
        if (n < 0) Console.Write("-");
        Console.Write("0x");
        while (!s.IsEmpty())
        {
            Console.Write(kytuHex[s.Pop()]);
        }
        Console.WriteLine(" (thập lục phân)");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // --- Bài 2a ---
        PhanTichThuaSo(12);
        PhanTichThuaSo(360);
        PhanTichThuaSo(98);

        // --- Bài 2b ---
        DoiSangNhiPhan(21);
        DoiSangNhiPhan(21);
        DoiSangNhiPhan(-10);

        DoiSangThapLucPhan(12);
        DoiSangThapLucPhan(255);
        DoiSangThapLucPhan(4096);

    }
}