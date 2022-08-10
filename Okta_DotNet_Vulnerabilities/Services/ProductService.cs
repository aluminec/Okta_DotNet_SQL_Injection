using Microsoft.Data.SqlClient;
using Okta_DotNet_SQL_Injection.Models;
using Okta_DotNet_SQL_Injection.Services.Interfaces;

namespace Okta_DotNet_SQL_Injection.Services
{
    public class ProductService : IProductService
    {
        private const string ConnectionString = "ConnectionStrings:SqlServer";
        private readonly IConfiguration _config;
        private readonly IProductCodeValidator _productCodeValidator;

        public ProductService(IConfiguration config, IProductCodeValidator productCodeValidator)
        {
            _config = config;
            _productCodeValidator = productCodeValidator;
        }

        public IEnumerable<Products> Search(string code)
        {
            var validCode = _productCodeValidator.GetValidProductCode(code);
            return GetProductsByCode(validCode);
        }

        private IEnumerable<Products> GetProductsByCode(string productCode)
        {
            var products = new List<Products>();
            
            using SqlConnection connection = new(_config.GetValue<string>(ConnectionString));
            
            try
            {
                string sql = "SELECT * FROM Products WHERE code = @Code";
                var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Code", productCode);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Products()
                    {
                        Id = (int)reader.GetValue(0),
                        Name = (string)reader.GetValue(1),
                        Code = (string)reader.GetValue(2),
                    });
                }
                reader.Close();
                command.Dispose();
            }
            catch (Exception)
            {
                return products;
            }

            return products;
        }
    }
}
