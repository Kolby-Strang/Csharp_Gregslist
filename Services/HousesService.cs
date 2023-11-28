

namespace csharp_gregslist.Services;

public class HousesService
{
    private readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
        _repo = repo;
    }

    internal House CreateHouse(House houseData)
    {
        House house = _repo.CreateHouse(houseData);
        return house;
    }

    internal string DestroyHouse(int houseId)
    {
        GetHouseById(houseId);
        _repo.DestroyHouse(houseId);
        return $"House with Id: {houseId} was destroyed";
    }

    internal House GetHouseById(int houseId)
    {
        House house = _repo.GetHouseById(houseId);
        if (house == null)
        {
            throw new Exception($"House with Id: {houseId} does not exist");
        }
        return house;
    }

    internal List<House> GetHouses()
    {
        List<House> houses = _repo.GetHouses();
        return houses;
    }

    internal House UpdateHouse(House houseData, int houseId)
    {
        House houseToUpdate = GetHouseById(houseId);

        houseToUpdate.Sqft = houseData.Sqft ?? houseToUpdate.Sqft;
        houseToUpdate.Bedrooms = houseData.Bedrooms ?? houseToUpdate.Bedrooms;
        houseToUpdate.Bathrooms = houseData.Bathrooms ?? houseToUpdate.Bathrooms;
        houseToUpdate.Price = houseData.Price ?? houseToUpdate.Price;
        houseToUpdate.ImgUrl = houseData.ImgUrl ?? houseToUpdate.ImgUrl;
        houseToUpdate.Description = houseData.Description ?? houseToUpdate.Description;

        _repo.UpdateHouse(houseToUpdate);
        return houseToUpdate;
    }
}