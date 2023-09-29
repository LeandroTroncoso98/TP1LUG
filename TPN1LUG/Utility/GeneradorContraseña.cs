using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class GeneradorContraseña
    {
        public static string GenerarPassword()
        {
            Random random = new Random();
            string pass = "";
            for(int i = 0; i < 6; i++)
            {
                pass += random.Next(10);
            }
            return pass;
        }
    }
}
