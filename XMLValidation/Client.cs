using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLValidation
{
    public class Client
    {
        public string FIO { get; set; }
        public string RegNumber { get; set; }
        public string DiasoftID { get; set; }
        public string Registrator { get; set; }
        public XElement OriginalElement { get; set; }

        public Client(XElement element)
        {
            FIO = (string)element.Element("FIO");
            RegNumber = (string)element.Element("RegNumber");
            DiasoftID = (string)element.Element("DiasoftID");
            Registrator = (string)element.Element("Registrator");
            OriginalElement = element;
        }

        public bool IsValid(out List<string> errorMessages)
        {
            errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(FIO))
                errorMessages.Add("Не указан ФИО");

            if (string.IsNullOrWhiteSpace(RegNumber))
                errorMessages.Add("Не указан Рег. номер");

            if (string.IsNullOrWhiteSpace(DiasoftID))
                errorMessages.Add("Не указан DiasoftID");

            if (string.IsNullOrWhiteSpace(Registrator))
                errorMessages.Add("Не указан Регистратор");

            return !errorMessages.Any();
        }
    }
}
