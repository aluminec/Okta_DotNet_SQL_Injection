using Okta_DotNet_SQL_Injection.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Okta_DotNet_SQL_Injection.Services
{
    public class ProductCodeValidator : IProductCodeValidator
    {
        public string GetValidProductCode(string productCode)
        {
            string result = productCode.Trim();

            if (!string.IsNullOrEmpty(result))
            {
                // remove newlines and tabs
                result = Regex.Replace(result, @"\t|\n|\r", "");

                // remove spaces
                result = Regex.Replace(result, @"\s+", "");
            }

            if (result.All(char.IsLetterOrDigit) && IsValidPrefix(productCode))
            {
                return result;
            }

            return String.Empty;
        }

        private static bool IsValidPrefix(string productCode)
        {
            var prefixes = new List<string>()
            {
                "MP", "PR", "CA", "LA", "SW"
            };

            return prefixes.Any(prefix => productCode.StartsWith(prefix));
        }
    }
}
