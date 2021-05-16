using Ensek.Api.Enums;

namespace Ensek.Api.Models.MeterReading
{
    /// <summary>
    /// 
    /// </summary>
    public class MeterReadingImportModel : MeterReadingModel
    {
        /// <summary>
        /// 
        /// </summary>
        public MeterReadingImportStatusEnum ImportStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReasonNotImported { get; set; }
    }
}
