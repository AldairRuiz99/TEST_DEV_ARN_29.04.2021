using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST_WEBAPI.BL.PersonasFisicas;

namespace TEST_WEBAPI.Controllers
{
    public class PersonasFisicasController : ApiController
    {
        // GET: api/PersonasFisicas
        public List<TESTDTO.PersonaFisicaDTO> Get()
        {
            PersonaFisicaBL BL = new PersonaFisicaBL();
            return BL.ConsultarPersonaFisica();
        }

        // GET: api/PersonasFisicas/5
        public TESTDTO.PersonaFisicaDTO Get(int id)
        {
            PersonaFisicaBL BL = new PersonaFisicaBL();
            TESTDTO.PersonaFisicaDTO p = new TESTDTO.PersonaFisicaDTO();
            p.IdPersonaFisica = id;
            return BL.ConsultarPersonaFisica(p);
        }

        // POST: api/PersonasFisicas
        public TESTDTO.Response Post([FromBody] TESTDTO.PersonaFisicaDTO p)
        {
            PersonaFisicaBL BL = new PersonaFisicaBL();
            return BL.AgregarPersonaFisica(p);
        }

        // PUT: api/PersonasFisicas/
        public TESTDTO.Response Put([FromBody] TESTDTO.PersonaFisicaDTO p)
        {
            PersonaFisicaBL BL = new PersonaFisicaBL();
            return BL.ActualizarPersonaFisica(p);
        }

        // DELETE: api/PersonasFisicas/5
        public TESTDTO.Response Delete(int id)
        {
            PersonaFisicaBL BL = new PersonaFisicaBL();
            return BL.EliminarPersonaFisica(id);
        }
    }
}
