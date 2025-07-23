using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Práctica_Programada.Models
{
    public class Comment
    {
        // Atributo: Id de comentario
        public int Id { get; set; }

        // Atributo: Contenido del comentario
        [Required(ErrorMessage = "El comentario no puede estar vacío")]
        public string Content { get; set; }

        // Atributo: Fecha de creación del comentario
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Atributo: Llave foranea con Usuario
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}