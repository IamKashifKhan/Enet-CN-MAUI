using EnetCNMAUI.Models;

namespace EnetCNMAUI.Services.Local
{
    public interface IOfferService
    {
        Task<ApiResult<bool>> ToggleOfferFavoriteAsync(int businessOffersKey, int userKey);
    }
}