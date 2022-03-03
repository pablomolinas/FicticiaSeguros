using System.ComponentModel.DataAnnotations;

namespace api.Models.dto
{
    public class UserDtoLogin
    {
        /// <summary>
        ///     Email to login.
        /// </summary>
        [Required(ErrorMessage = "Email es requerido")]
        [StringLength(maximumLength: 320, ErrorMessage = "Email es demasiado largo")]
        public string Email { get; set; }

        /// <summary>
        ///     Enter the password to login.
        /// </summary>
        [Required(ErrorMessage = "Password es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "Password es demasiado largo")]
        public string Password { get; set; }
    }
}
