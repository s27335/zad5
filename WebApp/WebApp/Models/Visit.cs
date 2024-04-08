namespace WebApp.Models;

public class Visit
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public Animal animal { get; set; }
    public string description { get; set; }
    public double price { get; set; }
}