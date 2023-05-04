namespace Navigation_Routing_State2.NorthwindCloud
{
    public interface INorthwindCloudService
    {
        Task<List<Customer>> GetCustomer();

        Task<List<ProductsAboveAveragePrice>> GetProductsAboveAveragePrice();

        Task<List<CustOrderHistResult>> GetCustOrderHistResult(string customerId = "ALFKI");

        Task<List<CustomerOrdersResult>> GetCustomerOrdersResult(string customerId = "ALFKI");
    }
}