namespace GestionLivres.DomainModels
{
    public class AddLivreRequest
    {
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
