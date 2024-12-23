namespace ECommerceList;
public class Program
{
    public static void Main()
    {
        // Shopping.DefaultData();
        FileHandling.CreateFile();
        FileHandling.ReadCSV();
        Shopping.Operation();
        FileHandling.WriteCSV();
    }
}
