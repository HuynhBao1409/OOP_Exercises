using System;

class Stack
{
    private int top;
    private int Max;
    private int[] stack;

    public Stack(int max)
    {
        Max = max;
        stack = new int[Max];
        top = -1;
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public bool IsFull()
    {
        return top == Max - 1;
    }

    public void Push(int data)
    {
        if (IsFull())
        {
            Console.WriteLine("asdasdas");
            return;
        }
        top++;
        stack[top] = data;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("asdasddas");
            return -1;
        }
        int giatri = stack[top];
        top--;
        return giatri;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("sdadasd");
            return -1;
        }
        return stack[top];
    }


    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("sadsa");
            return;
        }
        for (int i = top; i >= 0; i--)
        {
            Console.Write(stack[i] + " ");
        }
        Console.WriteLine();
    }
}

class test
{
    static void PhanTichThuaSo(int n)
    {
        if (n <= 1)
        {
            return;
        }

        Stack s = new Stack(100);
        int tam=n;

        for(int uoc = 2; uoc * uoc <= tam; uoc++)
        {
            while (tam % uoc == 0)
            {
                s.Push(uoc);
                tam/=uoc;
            }
        }

        if (tam > 1)
        {
            s.Push(tam);
        }

        Console.Write($"{n}=");
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

    static void DoiSangNhiPhan(int n)
    {
        if (n == 0)
        {
            return;
        }
        Stack s=new Stack(64);
        int tam=Math.Abs(n);

        while (tam > 0)
        {
            s.Push(tam%2);
            tam/=2;
        }

        Console.Write($"{n}");
        if(n<0) Console.Write("-");
        while (!s.IsEmpty())
        {
            Console.Write(s.Pop());
        }
    }
}