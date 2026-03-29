namespace Project.app_logic.Backend.MercadoPagoApi;

using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;

public class MercadoPagoAPi
{

    public static string AccessToken { get; set; } = "APP_USR-3775291861387124-032820-5c0a3fdf1bf684b15950009a02e12b74-3272713638";
    public static string PublicKey { get; set; } = "APP_USR-6fc0942d-c638-4697-a4f5-426f59cc0f4e";

    public MercadoPagoAPi()
    {

    }

    public static async Task<string> createObjectRequestAsync(Media p)
    {
        MercadoPago.Config.MercadoPagoConfig.AccessToken = AccessToken;

        var itemMP = new PreferenceItemRequest
        {
            Title = p.name,
            Quantity = 1,
            UnitPrice = (decimal?)p.price,
            CurrencyId = "ARS"
        };

        var request = new PreferenceRequest
        {
            Items = new List<PreferenceItemRequest> { itemMP },
            BackUrls = new PreferenceBackUrlsRequest
            {
                Success = "/index",
                Failure = "/index",
                Pending = "/index",
            },
            AutoReturn = "approved",
        };

        var client = new PreferenceClient();
        Preference preference = await client.CreateAsync(request);
        return preference.InitPoint;
    }


}



