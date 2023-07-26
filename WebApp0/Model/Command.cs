using System.Collections.ObjectModel;

namespace WebApp0.Model
{
    public class Command
    {
        public int Id { get; set; }
        public int ProduitQlId { get; set; }
        public int Quantity { get; set; }

        public List<ProduitQl> ProduitQl { get; set; } = new List<ProduitQl>();

    }
}
