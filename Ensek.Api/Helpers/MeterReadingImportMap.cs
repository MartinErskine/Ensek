using CsvHelper.Configuration;
using System.Globalization;
using Ensek.Api.Models.MeterReading;

namespace Ensek.Api.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class MeterReadingImportMap : ClassMap<MeterReadingImportModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public MeterReadingImportMap()
        {
            Map(m => m.AccountId).Index(0);
            Map(m => m.MeterReadingDateTime).Index(1).TypeConverterOption.DateTimeStyles(DateTimeStyles.AssumeLocal);
            Map(m => m.MeterReadValue).Index(2);
        }
    }
}
