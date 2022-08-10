namespace Okta_DotNet_SQL_Injection.Services.Interfaces
{
    public interface IProductCodeValidator
    {
        string GetValidProductCode(string productCode);
    }
}