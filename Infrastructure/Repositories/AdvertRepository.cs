using DataAccess.Dapper;
using DataAccess.Dapper.Interfaces;
using Domain.DbModels;
using Domain.Interfaces;
using Infrastructure.Scripts.Advert;

namespace Infrastructure.Repositories;

public class AdvertRepository(IDapperContext dapperContext) : IAdvertRepository
{
    public void BeginTransaction()
    {
        dapperContext.BeginTransaction();
    }

    public void Commit()
    {
        dapperContext.Commit();
    }

    public void Rollback()
    {
        dapperContext.Rollback();
    }
    
    public async Task<int> CreateAdvert(DbAdvert dbAdvert)
    {
        var parameters = new
        {
            title = dbAdvert.Title,
            description = dbAdvert.Description,
            price = dbAdvert.Price,
            creationDateTime = dbAdvert.CreationDateTime,
            status = dbAdvert.Status.ToString(),
            userId = dbAdvert.UserId,
            category = dbAdvert.Category
        };

        var query = new QueryObject(PostgresAdvert.Insert, parameters);

        return await dapperContext.CommandWithResponse<int>(query);
    }

    public async Task<DbAdvert> GetAdvertById(Guid id)
    {
        var query = new QueryObject(PostgresAdvert.GetById, new { id });
        return await dapperContext.FirstOrDefault<DbAdvert>(query) ??
               throw new KeyNotFoundException($"Advert with ID {id} was not found.");
    }
}