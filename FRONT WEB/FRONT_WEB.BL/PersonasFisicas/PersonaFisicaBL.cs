using FRONT_WEB.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRONT_WEB.BL.PersonasFisicas
{
    public class PersonaFisicaBL
    {
        public List<TESTDTO.PersonaFisicaDTO> ConsultarPersonaFisica()
        {
            GenericLayer<TESTDTO.PersonaFisicaDTO> p = new GenericLayer<TESTDTO.PersonaFisicaDTO>();
            return p.Get("PersonasFisicas", new TESTDTO.PersonaFisicaDTO());
        }

        public TESTDTO.PersonaFisicaDTO ConsultarPersonaFisica(int id)
        {
            GenericLayer<TESTDTO.PersonaFisicaDTO> p = new GenericLayer<TESTDTO.PersonaFisicaDTO>();
            return p.Get("PersonasFisicas", new TESTDTO.PersonaFisicaDTO(), id);
        }

        public TESTDTO.PersonaFisicaDTO AgregarPersonaFisica(TESTDTO.PersonaFisicaDTO e)
        {
            GenericLayer<TESTDTO.PersonaFisicaDTO> p = new GenericLayer<TESTDTO.PersonaFisicaDTO>();
            return p.Post("PersonasFisicas", e);
        }

        public TESTDTO.PersonaFisicaDTO ActualizarPersonaFisica(TESTDTO.PersonaFisicaDTO e)
        {
            GenericLayer<TESTDTO.PersonaFisicaDTO> p = new GenericLayer<TESTDTO.PersonaFisicaDTO>();
            return p.Put("PersonasFisicas", e);
        }

        public TESTDTO.PersonaFisicaDTO EliminarPersonaFisica(int id)
        {
            GenericLayer<TESTDTO.PersonaFisicaDTO> p = new GenericLayer<TESTDTO.PersonaFisicaDTO>();
            return p.Delete("PersonasFisicas", new TESTDTO.PersonaFisicaDTO(), id);
        }
    }
}
