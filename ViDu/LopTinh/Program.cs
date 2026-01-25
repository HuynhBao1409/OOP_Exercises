//Thành phần tĩnh của lớp tĩnh
public class Dog
{
    public string Name { get; set; } //TTính lưu tên loài
    public static int Count = 0; //Biến tĩnh để chứa tổng số đối tượng đc tạo

    public Dog(string name = "")//Thiết Lập
    {
        Name = name;
        Count++; //Tăng biến đếm mỗi khi tạo đối tượng mới
    }
}
class Program
{
    static void Main()
    {
        Dog dog1 = new Dog("Shiba");
        Dog dog2 = new Dog("Chihaohao");
        //Truy xuất đến thành phần tĩnh theo: <TênLớp>.<TênThànhPhần>
        Console.WriteLine("Tổng số chóa: {0}", Dog.Count);
    }
}