using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLValidation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "C:\\_Work\\ECM\\Clients.xml";
            string validClientsFilePath = "valid_clients.xml";
            string registratorsFilePath = "registrators.xml";
            string errorsFilePath = "errors.txt";

            ClientValidator validator = new ClientValidator(inputFilePath);
            validator.ValidateClients();
            validator.SaveValidClients(validClientsFilePath);
            validator.SaveRegistrators(registratorsFilePath);
            validator.SaveErrorReport(errorsFilePath);

            Console.WriteLine("Обработка завершена. Результаты сохранены в файлы.");
            Console.ReadKey();
        }
    }
}