using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public class VerificadorRegexProfesor : VerificadorRegex
    {
        public bool CheckForm(TextBox TxtNombre, TextBox TxtApellido, TextBox TxtEmail, TextBox TxtEspecializacion)
        {
            if (!CampoVacio(TxtNombre))
            {
                if (!CampoVacio(TxtApellido))
                {
                    if (!CampoVacio(TxtEspecializacion))
                    {
                        if (!CampoVacio(TxtEmail))
                        {
                            if (FormatoEmail(TxtEmail))
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("El formato del campo email no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo de email es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de Especializacion es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El campo de apellido es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("El campo de nombre es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
