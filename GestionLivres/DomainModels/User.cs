using System.ComponentModel.DataAnnotations;

namespace GestionLivres.DomainModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string? PasswordHashed { get; set; }
        public string? Token { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTOkenExpiryTime { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime ResetPasswordExpiry { get; set; }
        public bool? Blocked { get; set; } = false;
        public bool? Active { get; set; } = true;
        public float? Fine { get; set; } = 0;
        public string CreatedOn { get; set; } = string.Empty;



    }
}
