namespace Okta_DotNet_SQL_Injection.Models
{
    public class HomeViewModel
    {
        public string SearchProductCode { get; set; }
        public IEnumerable<Products> Products { get; set; }
    }
}
