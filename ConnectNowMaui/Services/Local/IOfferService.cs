using ConnectNow.Models;

namespace ConnectNow.Services.Local
{
    public interface IOfferService
    {
        Task<ApiResult<bool>> ToggleOfferFavoriteAsync(int businessOffersKey, int userKey);
    }
}