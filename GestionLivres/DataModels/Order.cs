using GestionLivres.DomainModels;

namespace GestionLivres.DataModels
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Name { get; set; }
        public int LivreId { get; set; }
        public Livre? Livre { get; set; }
        public string? BookName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Returned { get; set; }
    }
}
