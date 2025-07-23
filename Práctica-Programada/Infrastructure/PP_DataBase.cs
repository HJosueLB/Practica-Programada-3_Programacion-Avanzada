using Práctica_Programada.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Práctica_Programada.Infrastructure
{
    public class PP_DataBase : DbContext
    {
        
        public PP_DataBase() : base("name=PP_DataBase"){}

        // Propiedades para la creación de la tabla en la base de datos

        // Entidad Usuarios
        public DbSet<Models.User> Users { get; set; }

        // Entidad Comentarios
        public DbSet<Comment> Comments { get; set; }
    }


}