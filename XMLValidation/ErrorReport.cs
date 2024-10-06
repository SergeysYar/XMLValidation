using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLValidation
{
    public class ErrorReport
    {
        private Dictionary<string, int> _errorCounts = new Dictionary<string, int>
        {
            {"Не указан ФИО", 0},
            {"Не указан Рег. номер", 0},
            {"Не указан DiasoftID", 0},
            {"Не указан Регистратор", 0}
        };

        public void AddErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                if (_errorCounts.ContainsKey(error))
                {
                    _errorCounts[error]++;
                }
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var error in _errorCounts.OrderByDescending(e => e.Value))
                {
                    if (error.Value > 0)
                    {
                        writer.WriteLine($"{error.Key}: {error.Value} записей");
                    }
                }

                int totalErrors = _errorCounts.Values.Sum();
                writer.WriteLine($"Всего ошибочных записей: {totalErrors}");
            }
        }
    }
}
