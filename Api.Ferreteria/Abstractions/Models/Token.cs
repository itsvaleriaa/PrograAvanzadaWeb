using System.ComponentModel.DataAnnotations;

namespace Abstractions.Models
{
    public class Token
    {
        public bool SuccessfulValidation { get; set; }
        public string AccessToken { get; set; }
    }

    public class TokenConfiguracion
    {
        [Required]
        [StringLength(100, MinimumLength = 32)]
        public string Key { get; set; }

        [Required]
        public string Issuer { get; set; }

        [Required]
        public string Audience { get; set; }

        [Required]
        public double Expires { get; set; }

    }
}
