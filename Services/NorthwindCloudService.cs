using System.Net.Http.Json;

namespace Navigation_Routing_State2.NorthwindCloud
{
    public class NorthwindCloudService: INorthwindCloudService
    {
        private readonly HttpClient _http;

        public NorthwindCloudService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Customer>> GetCustomer()
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://excel2json.io/api/share/a876482a-7805-4e41-6c8a-08da1411ad26", UriKind.RelativeOrAbsolute));
            using HttpResponseMessage response = await _http.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Customer>>().ConfigureAwait(false);
            }
            return new List<Customer>();
        }

        public async Task<List<ProductsAboveAveragePrice>> GetProductsAboveAveragePrice()
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://northwindcloud.azurewebsites.net/api/products_above_average_price", UriKind.RelativeOrAbsolute));
            using HttpResponseMessage response = await _http.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ProductsAboveAveragePrice>>().ConfigureAwait(false);
            }

            return new List<ProductsAboveAveragePrice>();
        }

        public async Task<List<CustOrderHistResult>> GetCustOrderHistResult(string customerId = "ALFKI")
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://northwindcloud.azurewebsites.net/api/customer_order_history/{customerId}", UriKind.RelativeOrAbsolute));
            using HttpResponseMessage response = await _http.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CustOrderHistResult>>().ConfigureAwait(false);
            }

            return new List<CustOrderHistResult>();
        }

        public async Task<List<CustomerOrdersResult>> GetCustomerOrdersResult(string customerId = "ALFKI")
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://northwindcloud.azurewebsites.net/api/customer_orders/{customerId}", UriKind.RelativeOrAbsolute));
            using HttpResponseMessage response = await _http.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CustomerOrdersResult>>().ConfigureAwait(false);
            }
            return new List<CustomerOrdersResult>();
        }
    }
}