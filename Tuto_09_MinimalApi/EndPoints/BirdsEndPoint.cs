namespace Tuto_09_MinimalApi.EndPoints
{
    public static class BirdsEndPoint
    {
        public static void UseBirds(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/birds", () =>
            {

            }).WithName("birds");
        }
    }
}
