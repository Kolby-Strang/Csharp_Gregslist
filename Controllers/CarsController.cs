namespace csharp_gregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly CarsService _carsService;

  public CarsController(CarsService carsService)
  {
    _carsService = carsService;
  }

  [HttpGet]
  public ActionResult<List<Car>> GetCars()
  {
    try
    {
      List<Car> cars = _carsService.GetCars();
      return Ok(cars);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{carId}")]
  public ActionResult<Car> GetCarById(int carId)
  {
    try
    {
      Car car = _carsService.GetCarById(carId);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Car> CreateCar([FromBody] Car carData)
  {
    try
    {
      // NOTE if we ere using auth, assigning relevant ID's here
      Car car = _carsService.CreateCar(carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{carId}")]
  public ActionResult<string> DestroyCar(int carId)
  {
    try
    {
      string message = _carsService.DestroyCar(carId);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{carId}")]
  public ActionResult<Car> UpdateCar(int carId, [FromBody] Car carData)
  {
    try
    {
      Car car = _carsService.UpdateCar(carId, carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
