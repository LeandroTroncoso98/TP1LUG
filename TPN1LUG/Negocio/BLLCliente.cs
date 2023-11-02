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
    public class BLLCliente : BLLUsuario
    {
        public BLLCliente()
        {
            oMPPCliente = new MPPCliente();
        }
        MPPCliente oMPPCliente;
        public List<Cliente> listarClientes()
        {
            return oMPPCliente.listarClientes();
        }
        public bool CrearCliente(Cliente cliente)
        {
            return oMPPCliente.Alta(cliente);
        }
        public bool EditarCliente(Cliente cliente)
        {
            return oMPPCliente.Modificar(cliente);
        }
        public Cliente GetCliente(string email)
        {
            return oMPPCliente.GetCliente(email);
        }



    }
}

