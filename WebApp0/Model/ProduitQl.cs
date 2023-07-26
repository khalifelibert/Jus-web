using Microsoft.EntityFrameworkCore;

namespace WebApp0.Model
{
    public class ProduitQl
    {
        public int Id { get; set; }
        public string Quality { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Img { get; set; } = null!;
        
        public int ProduitId { get; set; }

        public Produit Produit { get; set; } = null!;
    }


}
