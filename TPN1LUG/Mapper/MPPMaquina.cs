using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mapper
{
    public class MPPMaquina
    {
        public MPPMaquina()
        {
            _archivo = "Maquinas.xml";
        }
        private string _archivo;
        public bool Agregar(Maquina maquina)
        {
            XDocument xml;
            if (File.Exists(_archivo))
            {
                xml = XDocument.Load(_archivo);
            }
            else
            {
                xml = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Maquinas")
                    );
            }
            XElement maquinaxml = new XElement("Maquina",
                new XElement("Nombre", maquina.Nombre.Trim()),
                new XElement("Cantidad", maquina.Cantidad.ToString().Trim()),
                new XElement("MaximoPeso", maquina.MaximoPeso.ToString().Trim()));
            xml.Element("Maquinas").Add(maquinaxml);
            xml.Save(_archivo);
            return true;
        }
        public bool Borrar(Maquina maquina)
        {
            List<Maquina> maquinas = Leer();
            maquinas = maquinas.Where(m => m.Nombre != maquina.Nombre).ToList();
            XDocument xml = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("Maquinas",
                maquinas.Select(ma => new XElement("Maquina",
                    new XElement("Nombre", ma.Nombre),
                    new XElement("Cantidad", ma.Cantidad),
                    new XElement("MaximoPeso", ma.MaximoPeso)
                ))
            )
        );
            xml.Save(_archivo);
            return true;
        }
        public List<Maquina> Leer()
        {
            List<Maquina> maquinas = new List<Maquina>();
            if (File.Exists(_archivo))
            {
                XDocument xml = XDocument.Load(_archivo);
                foreach (XElement maquinaxml in xml.Descendants("Maquina"))
                {
                    Maquina maquina = new Maquina();
                    maquina.Nombre = maquinaxml.Element("Nombre").Value;
                    maquina.Cantidad = int.Parse(maquinaxml.Element("Cantidad").Value);
                    maquina.MaximoPeso = int.Parse(maquinaxml.Element("MaximoPeso").Value);
                    maquinas.Add(maquina);
                }
            }
            return maquinas;
        }
        public List<Maquina> Buscar(string nombre)
        {
            List<Maquina> maquinas = Leer();
            if (!maquinas.Any())
            {
                return null;
            }
            return maquinas.Where(m => m.Nombre.Contains(nombre)).ToList();
        }

    }
}
