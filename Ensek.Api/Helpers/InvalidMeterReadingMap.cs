using CsvHelper.Configuration;
using Ensek.Api.Models.MeterReading;

namespace Ensek.Api.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidMeterReadingMap : ClassMap<InvalidMeterReadingModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public InvalidMeterReadingMap()
        {
            Map(m => m.AccountId).Index(0);
            Map(m => m.MeterReadingDateTime).Index(1);
            Map(m => m.MeterReadValue).Index(2);
        }
    }
}
