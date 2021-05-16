using System.Collections.Generic;

namespace Ensek.Api.Models.MeterReading
{
    public class MeterReadingImportResponseModel
    {
        public List<Data.Entities.MeterReading> Imports { get; set; } = new List<Data.Entities.MeterReading>();
        public int SuccessfulImports { get; set; }
        public int FailedImports { get; set; }
        public int DuplicateImports { get; set; }
    }
}
