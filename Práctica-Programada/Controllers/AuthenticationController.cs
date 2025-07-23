using Práctica_Programada.Infrastructure;
using Práctica_Programada.Models;
using System.Linq;
using System.Web.Mvc;

namespace Práctica_Programada.Controllers
{
    public class AuthenticationController : Controller
    {
        // Instancia: Clase de acceso a datos desde la BD.
        private PP_DataBase dataBase = new PP_DataBase();
        public ActionResult Index()
        {
            return View();
        }

        // Método: Get - Registro
        public ActionResult Register()
        {
            return View();
        }

        // Método: Post - Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            // Validación: Validar datos del usuario.
            if (ModelState.IsValid)
            {
                if (dataBase.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Este correo ya está registrado.");
                    return View(user);
                }

                // Proceso: Registro de usuario en base de datos.
                dataBase.Users.Add(user);
                dataBase.SaveChanges();

                // Mensaje: Registro realizado correctamente
                TempData["Success"] = "Registro realizado correctamente.";
                return RedirectToAction("Login");
            }

            // Retorno de vista.
            return View(user);
        }

        // Método: Get - Inicio de sesión
        public ActionResult Login()
        {
            return View();
        }

        // Método: Post - Inicio de sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            // Validación: Verificar si los campos están vacíos.
            var user = dataBase.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            // Proceso: Verificar si el usuario existe y las credenciales son correctas.
            if (user != null)
            {
                Session["UserId"] = user.Id;
                Session["UserName"] = user.Name;

                // Mensaje: Inicio de sesión exitoso - Bienvenida del usuario.
                TempData["Welcome"] = "Bienvenido, " + user.Name + " " + user.Lastname + "!";

                // Redirección: A la vista de comentarios.
                return RedirectToAction("Index", "Comment");
            }

            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }

        // Método: Cerrar sesión
        public ActionResult Logout()
        {
            Session.Clear();
            TempData.Clear();
            return RedirectToAction("Login");
        }
    }
}