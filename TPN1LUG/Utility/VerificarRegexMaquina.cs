using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public class VerificarRegexMaquina : VerificadorRegex
    {
        public bool BuscarValido(TextBox txtBuscar)
        {
            if (!CampoVacio(txtBuscar))
            {
                return true;
            }
            MessageBox.Show("El campo de busqueda esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
            
        }
        public bool CheckForm(TextBox txtNombre, TextBox txtCantidad, TextBox txtMaxPeso)
        {
            if (!CampoVacio(txtNombre))
            {
                if (!CampoVacio(txtCantidad))
                {
                    if (EsNumerico(txtCantidad))
                    {
                        if (!CampoVacio(txtMaxPeso))
                        {
                            if (EsNumerico(txtMaxPeso))
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("El campo de maximo peso debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo de maximo peso esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo cantidad debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El campo cantidad esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("El campo nombre esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
