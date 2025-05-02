using Application.Dto.Requests.Advert;
using Application.Dto.Responses.Advert;
using Application.Interfaces;
using Domain.DbModels;
using Domain.Interfaces;
using Mapster;


namespace Application.Services;

public class AdvertService:IAdvertService
{
    private readonly IAdvertRepository _advertRepository;

    public AdvertService(IAdvertRepository advertRepository)
    {
        _advertRepository = advertRepository;
    }

    public async Task<CreateAdvertResponse> CreateAdvert(CreateAdvertRequest advertRequest)
    {
        _advertRepository.BeginTransaction();
        var advert = advertRequest.Adapt<DbAdvert>();
        try
        {
            var id = await _advertRepository.CreateAdvert(advert);
            _advertRepository.Commit();
            return new CreateAdvertResponse { Id = advert.Id};
        }
        catch
        {
            _advertRepository.Rollback();
            throw;
        }
    }
}