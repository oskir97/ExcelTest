namespace ExcelTest.API.Endpoints
{
    public static class RegisterEndpoints
    {
        public static WebApplication UseEndpoints(this WebApplication app)
        {
            app.MapPost("/postOrders", new PostOrdersEndpoint().PostOrders);
            app.MapPost("/getOrders", new GetOrdersEndpoint().GetOrders);
            return app;
        }
    }

}
