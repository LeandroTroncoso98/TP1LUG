using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente : Usuario
    {
        #region propiedades
        public int Telefono { get; set; }
        public string Peso { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Edad;
        public Tarjeta oTarjeta { get; set; }
        public Rutina oRutina { get; set; }
        public Profesor oProfesor { get; set; }
        #endregion
        #region metodos
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if(fechaNacimiento.Date > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        } 
        #endregion
    }
}
