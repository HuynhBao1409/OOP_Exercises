public class Dog
{
    public string Name { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        //Tạo đối tượng của lớp Dog
        Dog dog = new Dog();
        //Thay đổi giá trị
        dog.Name = "Cau Vang";
        System.Console.WriteLine("Con Chó tên là: " + dog.Name);
    }
}