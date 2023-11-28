




namespace csharp_gregslist.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Car CreateCar(Car carData)
  {
    // NOTE two seperate sql statements, Insert would only return how many rows were affected
    string sql = @"
    INSERT INTO cars (make, model, year, price, imgUrl, runs, mileage)
    VALUES (@Make, @Model, @Year, @Price, @ImgUrl, @Runs, @Mileage);
    
    SELECT * FROM cars WHERE id = LAST_INSERT_ID();"; // SELECT_LAST_INSERT_ID() is a sql function that gets the id of the last inserted row in our table

    // _db.Execute(sql, carData); NOTE runs sql but returns nothing
    Car car = _db.Query<Car>(sql, carData).FirstOrDefault();
    return car;
  }

  internal void DestroyCar(int carId)
  {
    string sql = "DELETE FROM cars WHERE id = @carId LIMIT 1;";

    _db.Execute(sql, new { carId });
  }

  internal Car GetCarById(int carId)
  {
    // string sql = $"SELECT * FROM cars WHERE id = {carId};"; NEVER INTERPOLATE INSIDE OF SQL STATEMENTS WITH DATA FROM USER

    string sql = "SELECT * FROM cars WHERE id = @carId;";


    //new {carId: 1}
    Car car = _db.Query<Car>(sql, new { carId }).FirstOrDefault();
    return car;
  }

  internal List<Car> GetCars()
  {
    string sql = "SELECT * FROM cars;";

    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }

  internal void UpdateCar(Car originalCar)
  {
    string sql = @"
    UPDATE cars
    SET
    model = @Model,
    price = @Price,
    year = @Year,
    mileage = @Mileage,
    runs = @Runs
    WHERE id = @Id
    ;";

    _db.Execute(sql, originalCar);

  }
}
