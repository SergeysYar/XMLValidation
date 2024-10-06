using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLValidation
{
    public class ClientValidator
    {
        private List<Client> _clients;
        private List<Client> _validClients = new List<Client>();
        private Dictionary<string, int> _registratorDictionary = new Dictionary<string, int>();
        private List<Registrator> _registrators = new List<Registrator>();
        private ErrorReport _errorReport = new ErrorReport();
        private int _registratorCounter = 1;

        public ClientValidator(string inputFilePath)
        {
            XDocument xmlDocument = XDocument.Load(inputFilePath);
            _clients = xmlDocument.Root.Elements("Client").Select(e => new Client(e)).ToList();
        }

        public void ValidateClients()
        {
            foreach (var client in _clients)
            {
                if (client.IsValid(out var errorMessages))
                {
                    if (!_registratorDictionary.ContainsKey(client.Registrator))
                    {
                        _registratorDictionary[client.Registrator] = _registratorCounter++;
                    }

                    int registratorId = _registratorDictionary[client.Registrator];
                    client.OriginalElement.SetAttributeValue("RegistratorID", registratorId);
                    _validClients.Add(client);
                }
                else
                {
                    _errorReport.AddErrors(errorMessages);
                }
            }

            // Создаем список регистраторов
            _registrators = _registratorDictionary
                .Select(r => new Registrator(r.Key, r.Value))
                .ToList();
        }

        public void SaveValidClients(string filePath)
        {
            XDocument validClientsDoc = new XDocument(new XElement("Clients", _validClients.Select(c => c.OriginalElement)));
            validClientsDoc.Save(filePath);
        }

        public void SaveRegistrators(string filePath)
        {
            XDocument registratorsDoc = new XDocument(new XElement("Registrators", _registrators.Select(r => r.ToXElement())));
            registratorsDoc.Save(filePath);
        }

        public void SaveErrorReport(string filePath)
        {
            _errorReport.SaveToFile(filePath);
        }
    }
}
