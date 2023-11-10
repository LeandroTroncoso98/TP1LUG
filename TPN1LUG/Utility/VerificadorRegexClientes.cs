using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public class VerificadorRegexClientes : VerificadorRegex
    {

        public bool CheckForm(TextBox txtNombre,TextBox txtApellido,TextBox txtEmail,TextBox txtTelefono,TextBox txtPeso)
        {
            if (!CampoVacio(txtNombre))
            {
                if (!CampoVacio(txtApellido))
                {
                    if (!CampoVacio(txtEmail))
                    {
                        if (FormatoEmail(txtEmail))
                        {
                            if (!CampoVacio(txtTelefono))
                            {
                                if (EsNumerico(txtTelefono))
                                {
                                    if (!CampoVacio(txtPeso))
                                    {
                                        if (EsDecimal(txtPeso))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("El formato del campo peso no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El campo peso esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El formato del campo telefono no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("El campo telefono esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El formato del campo email no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo email esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El campo apellido esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
