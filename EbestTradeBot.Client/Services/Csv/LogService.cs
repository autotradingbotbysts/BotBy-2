using CsvHelper;
using CsvHelper.Configuration;
using EbestTradeBot.Shared.Models.Log;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace EbestTradeBot.Client.Services.Log
{
    public class LogService : ILogService
    {
        private readonly string _filePath = @".\";
        private static object _lock = new();

        public async Task WriteLog(LogModel model)
        {
            lock (_lock)
            {
                var filePath = _filePath + "log.csv";
                bool fileExists = File.Exists(filePath);

                if (!fileExists)
                {
                    File.Create(filePath).Close();
                }

                using var writer = new StreamWriter(_filePath + "log.csv", true);
                using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = !fileExists });

                if (!fileExists)
                {
                    csv.WriteHeader<LogModel>();
                    csv.NextRecord();
                }

                csv.WriteRecord(model);
                csv.NextRecord();
            }
        }
    }
}
