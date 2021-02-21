using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentValidation.Results;
using System.Linq;

namespace Integration.DanceCore
{
    public class VakLatIlmoittautumisetReader
    {
        private readonly ILibraryLogger _logger;
        private readonly DanceCoreValidator _validator;

        public List<DanceCoreVakLatIlmoittautuminen> DanceCoreIlmoittautumiset;

        public VakLatIlmoittautumisetReader(ILibraryLogger logger)
        {
            _logger = logger;
            _validator = new DanceCoreValidator();
            DanceCoreIlmoittautumiset = new List<DanceCoreVakLatIlmoittautuminen>();
        }

        public void ReadRegisteredCouples(string inFilePath)
        {
            using var inFile = File.Open(inFilePath, FileMode.Open, FileAccess.Read);
            ReadRegisteredCouplesFromStream(inFile);
        }

        public void ReadRegisteredCouples(Stream stream)
        {
            ReadRegisteredCouplesFromStream(stream);
        }

        private void ReadRegisteredCouplesFromStream(Stream stream)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using var reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration() { FallbackEncoding = Encoding.GetEncoding(1252) });
            do
            {
                _logger.Log(new LogEntry(LoggingEventType.Information, $"Reading sheet {reader.Name} from file"));

                int rowNumber = 0;
                while (reader.Read()) // read rows in current sheet
                {
                    rowNumber++;
                    var row = new DanceCoreVakLatIlmoittautuminen
                    {
                        RowNumber = rowNumber,
                        ID = reader.GetValue(0)?.ToString()?.Trim(),
                        MID = reader.GetValue(1)?.ToString()?.Trim(),
                        NID = reader.GetValue(2)?.ToString()?.Trim(),
                        EtunimiM = reader.GetString(3)?.Trim(),
                        SukunimiM = reader.GetString(4)?.Trim(),
                        EtunimiN = reader.GetString(5)?.Trim(),
                        SukunimiN = reader.GetString(6)?.Trim(),
                        Seura = reader.GetString(7)?.Trim(),
                        Paikkakunta = reader.GetString(8)?.Trim(),
                        Luokka = reader.GetString(9)?.Trim(),
                        Sarja = reader.GetString(10)?.Trim(),
                        TasoV = reader.GetString(11)?.Trim(),
                        TasoL = reader.GetString(12)?.Trim(),
                        Maksettu = reader.GetString(13)?.Trim(),
                        Ilmoittautunut = reader.GetValue(14)?.ToString()
                    };

                    if (IsHeaderRow(row)) {  continue; } /* Skip header row */

                    ValidationResult result = _validator.Validate(row);
                    foreach (var error in result.Errors)
                    {
                        List<string> errorMessages = row.ValidationErrors.Where(p => p.Key == error.PropertyName)
                            .Select(p => p.Value)
                            .DefaultIfEmpty(new List<string>()).First();
                        errorMessages.Add(error.ErrorMessage);
                        row.ValidationErrors[error.PropertyName] = errorMessages;
                        _logger.Log(new LogEntry(LoggingEventType.Warning, $"Failed to validate property {error.PropertyName} on row {rowNumber}: {error.ErrorMessage}."));
                    }
                    DanceCoreIlmoittautumiset.Add(row);
                }
                _logger.Log(new LogEntry(LoggingEventType.Information, $"Read {rowNumber} rows from sheet {reader.Name}."));

            } while (reader.NextResult()); // Jump to next sheet
        }

        private bool IsHeaderRow(DanceCoreVakLatIlmoittautuminen row)
        {
            return string.Equals("ID", row.ID) && string.Equals("MID", row.MID) && string.Equals("NID", row.NID) &&
                   string.Equals("EtunimiM", row.EtunimiM) && string.Equals("SukunimiM", row.SukunimiM) &&
                   string.Equals("EtunimiN", row.EtunimiN) && string.Equals("SukunimiN", row.SukunimiN);
        }
    }
}
