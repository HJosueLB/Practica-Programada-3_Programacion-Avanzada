using System.ComponentModel.DataAnnotations;

namespace Práctica_Programada.Models
{
    public class User
    {
        // Atributo: Id de usuario
        public int Id { get; set; }

        // Atributo: Nombre de usuario - Mensaje de validación
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo de caracteres 50")]
        public string Name { get; set; }

        // Atributo: Apellido de usuario - Mensaje de validación
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo de caracteres 50")]
        public string Lastname { get; set; }

        // Atributo: Correo de usuario - Mensaje de validación
        [Required(ErrorMessage = "Campo obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        public string Email { get; set; }

        // Atributo: Contraseña de usuario - Mensaje de validación
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; }
    }
}