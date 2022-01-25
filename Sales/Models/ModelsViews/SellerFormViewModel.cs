using System.Collections.Generic;

namespace Sales.Models.ModelsViews
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Departments> Departments { get; set; }
    }
}
