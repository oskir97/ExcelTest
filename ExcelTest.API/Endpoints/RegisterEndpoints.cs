namespace ExcelTest.API.Endpoints
{
    public static class RegisterEndpoints
    {
        public static WebApplication UseEndpoints(this WebApplication app)
        {
            app.MapPost("/postOrders", new PostOrdersEndpoint().PostOrders);
            app.MapPost("/getOrders", new GetOrdersEndpoint().GetOrders);
            app.MapPut("/putOrder", new PutOrderEndpoint().PutOrder);
            app.MapDelete("/removeOrder", new RemoveOrderEndpoint().RemoveOrder);
            app.MapPost("/getCountries", new GetCountriesEndpoint().GetCountries);
            return app;
        }
    }

}
