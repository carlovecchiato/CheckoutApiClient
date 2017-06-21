using Checkout.ApiServices.Drinks.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Drinks
{
    public class DrinkService
    {
        public HttpResponse<int> CreateDrink(Drink requestModel)
        {
            return new ApiHttpClient().PostRequest<int>(ApiUrls.DrinkWebApi, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<Drink> GetDrink(string drinkId)
        {
            var drinkApiUri = string.Format(ApiUrls.DrinkWebApi, drinkId);
            return new ApiHttpClient().GetRequest<Drink>(drinkApiUri, AppSettings.SecretKey);
        }

        public HttpResponse<OkResponse> UpdateDrink(Drink requestModel)
        {
            return new ApiHttpClient().PutRequest<OkResponse>(ApiUrls.DrinkWebApi, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> DeleteDrink(string drinkId)
        {
            var drinkApiUri = string.Format(ApiUrls.DrinkWebApi, drinkId);
            return new ApiHttpClient().DeleteRequest<OkResponse>(drinkApiUri, AppSettings.SecretKey);
        }

        public HttpResponse<DrinkList> GetDrinkList()
        {
            var drinkApiUri = string.Format(ApiUrls.DrinkWebApi, string.Empty);
            return new ApiHttpClient().GetRequest<DrinkList>(drinkApiUri, AppSettings.SecretKey);
        }
    }
}
