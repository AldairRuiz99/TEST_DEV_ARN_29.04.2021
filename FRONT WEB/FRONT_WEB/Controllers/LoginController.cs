using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRONT_WEB.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ValidarCredenciales(string userName, string password)
        {
            TESTDTO.UsuarioDTO usuarioDTO = new TESTDTO.UsuarioDTO();
            try
            {
                usuarioDTO.Username = userName;
                usuarioDTO.Password = password;
                Session["IdUsuario"] = 1;
                return Json("OK");

            }
            catch (Exception)
            {
                return Json(usuarioDTO);
            }

        }
    }
}