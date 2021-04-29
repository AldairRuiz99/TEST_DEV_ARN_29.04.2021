using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST_WEBAPI.DAO.PersonasFisicas;

namespace TEST_WEBAPI.BL.PersonasFisicas
{
    public class PersonaFisicaBL
    {
        public List<TESTDTO.PersonaFisicaDTO> ConsultarPersonaFisica()
        {
            PersonaFisicaDAO BL = new PersonaFisicaDAO();
            return BL.ConsultarPersonaFisica();
        }
        public TESTDTO.PersonaFisicaDTO ConsultarPersonaFisica(TESTDTO.PersonaFisicaDTO p)
        {
            PersonaFisicaDAO BL = new PersonaFisicaDAO();
            return BL.ConsultarPersonaFisica(p);
        }
        public TESTDTO.Response AgregarPersonaFisica(TESTDTO.PersonaFisicaDTO p)
        {
            PersonaFisicaDAO BL = new PersonaFisicaDAO();
            return BL.AgregarPersonaFisica(p);
        }
        public TESTDTO.Response ActualizarPersonaFisica(TESTDTO.PersonaFisicaDTO p)
        {
            PersonaFisicaDAO BL = new PersonaFisicaDAO();
            return BL.ActualizarPersonaFisica(p);
        }
        public TESTDTO.Response EliminarPersonaFisica(int id)
        {
            PersonaFisicaDAO BL = new PersonaFisicaDAO();
            return BL.EliminarPersonaFisica(id);
        }
    }
}
