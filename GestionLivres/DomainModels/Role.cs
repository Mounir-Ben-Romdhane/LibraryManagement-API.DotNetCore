namespace GestionLivres.DomainModels
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        //public int claimId { get; set; }
        public List<CLaim> claims  { get; set; }
    }
}
