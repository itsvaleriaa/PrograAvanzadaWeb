using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Login
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Ingresa un correo valido")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El correo debe contener un @ y punto como minimo.")]
        [DisplayName("Correo electrónico")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La contraseña debe ser como minimo de 5 caracteres.")]
        [DisplayName("Contraseña")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La contraseña debe ser como minimo de 5 caracteres.")]
        [DisplayName("Contraseña")]
        public string? Hash { get; set; }
    }
}
