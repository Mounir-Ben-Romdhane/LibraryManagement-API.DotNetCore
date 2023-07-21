namespace GestionLivres.DomainModels
{
    public class CLaim
    {
        public int Id { get; set; }
        public string claimName { get; set; }
        public Guid RoleId { get; set; }
    }
}
