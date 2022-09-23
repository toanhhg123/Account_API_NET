using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountApi.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { set; get; }

        [Required(ErrorMessage = "username isvalid")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email isvalid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "password is valid")]
        [StringLength(200,MinimumLength = 6, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string PasswordHash { get; set; } = string.Empty;

        public Guid Salt { get; set; }

        [Column(TypeName = "Text")]
        public string? Profile { set; get; } = string.Empty;

        public string? Address { set; get; } = string.Empty;

        public string? Avatar { set; get; } = string.Empty;

        public string? BackgroundImage { set; get; } = string.Empty;
        public DateTime? CreateAt { set; get; }

        public DateTime? UpdateAt { set; get; }

    }

    public class UserRegister
    {
        [Required(ErrorMessage = "username isvalid")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email isvalid")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "password is valid")]
        [StringLength(200,MinimumLength = 6, ErrorMessage = "The password has length from 6 to 200 char. ")]
        public string Password { get; set; } = string.Empty;

    }
}