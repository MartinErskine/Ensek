using System.Collections.Generic;

namespace Ensek.Api.Models.MeterReading
{
    /// <summary>
    /// 
    /// </summary>
    public class MeterReadingImportResponseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Data.Entities.MeterReading> Imports { get; set; } = new List<Data.Entities.MeterReading>();

        /// <summary>
        /// 
        /// </summary>
        public int SuccessfulImports { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FailedImports { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DuplicateImports { get; set; }
    }
}
