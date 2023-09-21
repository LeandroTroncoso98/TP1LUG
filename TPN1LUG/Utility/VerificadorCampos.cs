using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public class VerificadorCampos
    {
        public static bool VerificarCamposIniciarSesion(TextBox email,TextBox pass)
        {
            if (!string.IsNullOrWhiteSpace(email.Text) && !string.IsNullOrWhiteSpace(pass.Text))
                return true;
            else return false;
        }
        public static bool VerificarCamposProfesor(TextBox nombre,TextBox apellido,TextBox email, TextBox especializacion)
        {
            if (!string.IsNullOrWhiteSpace(nombre.Text) && !string.IsNullOrWhiteSpace(apellido.Text) && !string.IsNullOrWhiteSpace(email.Text) && !string.IsNullOrWhiteSpace(especializacion.Text))
            {
                return true;
            }
            else return false;
        }
        public static bool VerificarCamposSupervisor(TextBox nombre,TextBox Apellido, TextBox Email)
        {
            if (!string.IsNullOrWhiteSpace(nombre.Text) && !string.IsNullOrWhiteSpace(Apellido.Text) && !string.IsNullOrWhiteSpace(Email.Text))
            {
                return true;
            }
            else return false;
        }
    }
}
