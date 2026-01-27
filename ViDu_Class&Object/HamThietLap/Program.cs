public class Car
{
    public string? NSX; //Hãng sản xuất

    //ham ko tham so
    public Car()
    {
        NSX = "Lambor";
    }
    //ham co tham so
    public Car(string? nsx = "")
    {
        NSX = nsx;
    }
    // in ket qua
    public void Print()
    {
        Console.WriteLine("Nhà sản xuất: " + NSX);
    }
}
class Program
{
    static void Main(string[] args)
    {
        //Tạo đối tượng xe,ko tham số
        Car car1 = new Car();
        car1.Print();

        //Tạo đối tượng xe,có tham số
        Car car2 = new Car("MAZDA");
        car2.Print();
    }
}