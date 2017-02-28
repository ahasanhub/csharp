using System.Collections.Generic;

namespace Plural.EF.MvcSalesApp.Domain
{
  public class Category 
  {
      public Category()
    {
      Products = new List<Product>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    

    public ICollection<Product> Products { get; set; }
  }
}