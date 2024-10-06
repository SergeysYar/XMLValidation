using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLValidation
{
    public class Registrator
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Registrator(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public XElement ToXElement()
        {
            return new XElement("Registrator",
                new XAttribute("ID", ID),
                new XAttribute("Name", Name));
        }
    }
}
