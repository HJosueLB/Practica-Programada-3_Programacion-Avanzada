using Práctica_Programada.Infrastructure;
using Práctica_Programada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Práctica_Programada.Controllers
{
    public class CommentController : Controller
    {
        // Instancia: Clase de acceso a datos desde la BD.
        private PP_DataBase db = new PP_DataBase();

        // Constructor: Inicializa la sesión.
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }

            // Proceso: Obtener los comentarios de la base de datos.
            var comments = db.Comments.Include("User").OrderByDescending(c => c.CreatedAt).ToList();

            // Mensaje: Mostrar el total de comentarios y el nombre del usuario.
            ViewBag.TotalComentarios = comments.Count;
            ViewBag.UserName = Session["UserName"];

            return View(comments);
        }

        // Método: Get - Crear un nuevo comentario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string content)
        {
            // Validación: Verificar si el usuario está autenticado.
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }

            // Validación: Verificar si el contenido del comentario no está vacío.
            if (!string.IsNullOrWhiteSpace(content))
            {         
                var comment = new Comment
                {
                    Content = content,
                    UserId = (int)Session["UserId"]
                };

                // Proceso: Crear un nuevo comentario y guardarlo en la base de datos.
                db.Comments.Add(comment);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}