using Ensek.Api.Enums;

namespace Ensek.Api.Models.MeterReading
{
    public class InvalidMeterReadingImportModel : InvalidMeterReadingModel
    {
        public MeterReadingImportStatusEnum ImportStatus { get; set; }
    }
}
