namespace GestionLivres.DataModels
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public float? Price { get; set; } = 0;
        public bool? Ordered { get; set; } = false;
        public DateTime? DateEdition { get; set; }
        public bool? Disponible { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        
    }
}
