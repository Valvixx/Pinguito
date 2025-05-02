using Domain.DbModels;

namespace Domain.Interfaces;

public interface IAdvertRepository
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    public Task<int> CreateAdvert(DbAdvert dbAdvert);
}