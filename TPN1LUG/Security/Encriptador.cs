using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class Encriptador
    {
        public static string GenerarMD5(string cadena)
        {
            try
            {
                UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
                byte[] byteSourceText = unicodeEncoding.GetBytes(cadena);
                //Instanciamos MD5 
                MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
                byte[] byteHash = Md5.ComputeHash(byteSourceText); //Calculamos el valor hash MD5 de la fuente.
                return Convert.ToBase64String(byteHash);//convertimos a formato de cadena 
            }
            catch(CryptographicException ex) { throw (ex); }
            catch(Exception ex) { throw ex; }
        }
    }
}
