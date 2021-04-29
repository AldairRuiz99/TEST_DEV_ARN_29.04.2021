using FRONT_WEB.BL.PersonasFisicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRONT_WEB.Controllers
{
    public class PersonasFisicasController : Controller
    {
        public ActionResult Index()
        {
            PersonaFisicaBL obj = new PersonaFisicaBL();
            return View(obj.ConsultarPersonaFisica());
        }

        public ActionResult Editar(int id)
        {
            PersonaFisicaBL obj = new PersonaFisicaBL();
            return View(obj.ConsultarPersonaFisica(id));
        }

        [HttpPost]
        public JsonResult AgregarPersona(FormCollection frmPersona)
        {
            TESTDTO.PersonaFisicaDTO personaDTO = new TESTDTO.PersonaFisicaDTO()
            {
                Nombre = frmPersona["nombre"],
                ApellidoPaterno = frmPersona["apaterno"],
                ApellidoMaterno = frmPersona["amaterno"],
                RFC = frmPersona["rfc"],
                FechaNacimiento = Convert.ToDateTime(frmPersona["fechana"]),
                UsuarioAgrega = Convert.ToInt32(Session["IdUsuario"].ToString()),
            };

            PersonaFisicaBL personaBL = new PersonaFisicaBL();
            return Json(personaBL.AgregarPersonaFisica(personaDTO));
        }

        [HttpPost]
        public JsonResult EditarPersona(FormCollection frmPersona)
        {
            TESTDTO.PersonaFisicaDTO personaDTO = new TESTDTO.PersonaFisicaDTO()
            {
                IdPersonaFisica = Convert.ToInt32(frmPersona["idPersona"]),
                Nombre = frmPersona["nombre"],
                ApellidoPaterno = frmPersona["apaterno"],
                ApellidoMaterno = frmPersona["amaterno"],
                RFC = frmPersona["rfc"],
                FechaNacimiento = Convert.ToDateTime(frmPersona["fechana"]),
                UsuarioAgrega = Convert.ToInt32(Session["IdUsuario"].ToString()),
            };

            PersonaFisicaBL personaBL = new PersonaFisicaBL();
            return Json(personaBL.ActualizarPersonaFisica(personaDTO));
        }

        [HttpPost]
        public JsonResult EliminarPersona(int id)
        {
            PersonaFisicaBL personaBL = new PersonaFisicaBL();
            return Json(personaBL.EliminarPersonaFisica(id));
        }
    }
}
