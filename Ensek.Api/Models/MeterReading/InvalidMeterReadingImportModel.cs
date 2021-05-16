using Ensek.Api.Enums;

namespace Ensek.Api.Models.MeterReading
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidMeterReadingImportModel : InvalidMeterReadingModel
    {
        /// <summary>
        /// 
        /// </summary>
        public MeterReadingImportStatusEnum ImportStatus { get; set; }
    }
}
