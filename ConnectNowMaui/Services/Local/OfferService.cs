using ConnectNow.ApiService;
using ConnectNow.ApiService.Requests.MVC;
using ConnectNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Services.Local
{
    public class OfferService : IOfferService
    {
        private readonly ICNApiService apiService;

        public OfferService(ICNApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<ApiResult<bool>> ToggleOfferFavoriteAsync(int businessOffersKey, int userKey)
        {
            var request = new OffersMarkUnmarkFavRequest(userKey, businessOffersKey);

            try
            {
                // Assuming Refit-style response: ApiResponse<OffersFavDto> with IsSuccess & Content
                var response = await apiService.OffersMarkUnmarkFavorite(request);

                if (response?.Success == true && response.Message != null)
                {
                    // If your DTO has a server message, prefer it. Otherwise synthesize one.
                    var isFav = !response.Message.Contains("Disconnected");


                    return new ApiResult<bool>(success: true, message: response.Message, data: isFav);
                }

                return new ApiResult<bool>(success: false, message: "Request failed.", data: false);
            }
            catch (Exception ex)
            {
                return new ApiResult<bool>(success: false, message: ex.Message, data: false);
            }
        }


    }
}
