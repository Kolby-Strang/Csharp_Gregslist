namespace csharp_gregslist.Models;

public class Car
{
  public int Id { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  public int Year { get; set; }
  public int Price { get; set; }
  public string ImgUrl { get; set; }
  public bool Runs { get; set; }
  public int Mileage { get; set; }
}