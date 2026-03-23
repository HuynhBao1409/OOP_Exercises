using System;
using System.Collections.Generic;

abstract class Shape
{
    public string Name { get; set; }
    public abstract double Area();
    public override string ToString()
    {
        Console.WriteLine($"{Name}: Area = {Area():F2}");
    }
}

//HCN
class Rectangle : Shape
{
    public double width { get; set; }
    public double height { get; set; }

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
        Name = "HCN";
    }

    public override double Area()
    {
        width* height;
    }
}

class Square : Rectangle
{
    public Square(double w) : base(w, w)
    {
        Name = "HV";
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
        Name = "Circle";
    }

    public override double Area()
    {
        return Math.PI * radius * radius;
    }
}

