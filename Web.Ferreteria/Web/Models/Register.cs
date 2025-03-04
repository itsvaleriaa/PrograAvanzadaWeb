using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Register
    {
        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre debe contener solo letras")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe ser mayor a 2 caracteres y menor a 50 caracteres.")]
        [DisplayName("Nombre")]
        public string? Name { get; set; }

        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Los apellidos deben contener solo letras")]
        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Los apellidos debe ser mayor a 5 caracteres y menor a 150 caracteres.")]
        [DisplayName("Apellidos")]
        public string? FirstLastName { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe ser mayor a 5 caracteres y menor a 200 caracteres.")]
        [DisplayName("Ciudad")]
        public string? City { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe ser mayor a 5 caracteres y menor a 200 caracteres.")]
        [DisplayName("Dirección")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido.")]
        //[StringLength(7, MinimumLength = 7, ErrorMessage = "Ingresa un número de telefono válido")]
        [DisplayName("Teléfono")]
        public string? PhoneNumber { get; set; }

        public DateTime? CreatedAt { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Ingresa un correo válido")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El correo debe contener un @ y punto como minimo.")]
        [DisplayName("Correo electrónico")]
        public string? Email { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La contraseña debe ser como minimo de 5 caracteres.")]
        [DisplayName("Contraseña")]
        public string? PasswordHash { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "Repetir la contraseña es obligatorio.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La contraseña debe ser como minimo de 5 caracteres.")]
        [DisplayName("Repetir contraseña")]
        public string? ConfirmPassword { get; set; }

        public string? Hash { get; set; }
    }

    public class RegisterUser
    {
        public int idPerson { get; set; }
        public string? email { get; set; }
        public string? passwordHash { get; set; }
        public DateTime? created_At { get; set; }
    }
}
