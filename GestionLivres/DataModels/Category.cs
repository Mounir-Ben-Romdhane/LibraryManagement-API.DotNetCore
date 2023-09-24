namespace GestionLivres.DataModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string? SubCategory { get; set; }
        public ICollection<Livre>? Livres { get; set; }
    }
}
