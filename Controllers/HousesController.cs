namespace csharp_gregslist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
    private readonly HousesService _housesService;
    public HousesController(HousesService housesService)
    {
        _housesService = housesService;
    }

    [HttpGet]
    public ActionResult<List<House>> GetHouses()
    {
        try
        {
            List<House> houses = _housesService.GetHouses();
            return Ok(houses);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpGet("{houseId}")]
    public ActionResult<House> GetHouseById(int houseId)
    {
        try
        {
            House house = _housesService.GetHouseById(houseId);
            return Ok(house);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpPost]
    public ActionResult<House> CreateHouse([FromBody] House houseData)
    {
        try
        {
            House house = _housesService.CreateHouse(houseData);
            return Ok(house);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpPut("{houseId}")]
    public ActionResult<House> UpdateHouse([FromBody] House houseData, int houseId)
    {
        try
        {
            House house = _housesService.UpdateHouse(houseData, houseId);
            return Ok(house);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpDelete("{houseId}")]
    public ActionResult<string> DestroyHouse(int houseId)
    {
        try
        {
            string message = _housesService.DestroyHouse(houseId);
            return Ok(message);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
}