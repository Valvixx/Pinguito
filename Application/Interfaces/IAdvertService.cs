using Application.Dto.Requests;
using Application.Dto.Requests.Advert;
using Application.Dto.Responses.Advert;

namespace Application.Interfaces;

public interface IAdvertService
{
    public Task<CreateAdvertResponse> CreateAdvert(CreateAdvertRequest advertRequest);
}