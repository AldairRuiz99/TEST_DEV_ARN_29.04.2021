using FRONT_WEB.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRONT_WEB.BL.Clientes
{
    public class ClienteBL
    {
        public TESTDTO.Token ObtenerToken()
        {
            GenericLayer<TESTDTO.Token> p = new GenericLayer<TESTDTO.Token>();
            TESTDTO.UsuarioDTO datos = new TESTDTO.UsuarioDTO();
            datos.Username = "ucand0021";
            datos.Password = "yNDVARG80sr@dDPc2yCT!";
            return p.PostToken(new TESTDTO.Token(), datos);
        }
        public TESTDTO.ResponseDTO ConsultarClientes(string token)
        {
            GenericLayer<TESTDTO.ResponseDTO> p = new GenericLayer<TESTDTO.ResponseDTO>();
            return p.Get(new TESTDTO.ResponseDTO(), token);
        }
    }
}
