using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public abstract class BLLUsuario
    {
        public BLLUsuario()
        {
            oMPPUsuario = new MPPUsuario();
        }
        MPPUsuario oMPPUsuario;

        public bool EliminarUsuario(int id)
        {
            return oMPPUsuario.EliminarUsuario(id);
        }
        public bool VerificarMail(string email, int id = 0)
        {
            return oMPPUsuario.VerificarMail(email, id);
        }

    }
}
