




namespace csharp_gregslist.Repositories;

public class HousesRepository
{
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal House CreateHouse(House houseData)
    {
        string sql =
        @"
        Insert INTO houses (sqft,bedrooms,bathrooms,imgUrl,description,price)
        VALUES (@Sqft, @Bedrooms, @Bathrooms, @ImgUrl, @Description, @Price);

        SELECT * FROM houses WHERE id = LAST_INSERT_ID();
        ";
        House house = _db.Query<House>(sql, houseData).FirstOrDefault();
        return house;
    }

    internal void DestroyHouse(int houseId)
    {
        string sql =
        @"
        DELETE FROM houses 
        WHERE id = @houseId 
        LIMIT 1
        ";
        _db.Execute(sql, new { houseId });
    }

    internal House GetHouseById(int houseId)
    {
        string sql = "SELECT * FROM houses WHERE id = @houseId";
        House house = _db.Query<House>(sql, new { houseId }).FirstOrDefault();
        return house;
    }

    internal List<House> GetHouses()
    {
        string sql = "SELECT * FROM houses";
        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;
    }

    internal void UpdateHouse(House houseToUpdate)
    {
        string sql =
        @"
        Update houses SET
        sqft = @Sqft,
        price = @Price,
        bedrooms = @Bedrooms,
        bathrooms = @Bathrooms,
        imgUrl = @ImgUrl,
        description = @Description

        WHERE id = @Id
        ";

        _db.Execute(sql, houseToUpdate);
    }
}