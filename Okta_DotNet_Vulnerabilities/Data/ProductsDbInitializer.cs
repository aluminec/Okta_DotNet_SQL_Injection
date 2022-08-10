namespace Okta_DotNet_SQL_Injection.Data
{
    public static class ProductsDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProductsDbContext>();
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new Models.Products()
                    {
                        Name = "Mobile Phone",
                        Code = "MP63842"
                    },
                    new Models.Products()
                    {
                        Name = "Printer",
                        Code = "PR535"
                    },
                    new Models.Products()
                    {
                        Name = "Camera",
                        Code = "CA36321"
                    },
                    new Models.Products()
                    {
                        Name = "Laptop",
                        Code = "LA4456"
                    },
                    new Models.Products()
                    {
                        Name = "Smart Watch",
                        Code = "SW5233"
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
