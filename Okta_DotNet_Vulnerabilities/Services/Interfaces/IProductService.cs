using Okta_DotNet_SQL_Injection.Models;

namespace Okta_DotNet_SQL_Injection.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Products> Search(string code);
    }
}