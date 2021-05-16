namespace Ensek.Api.Models.MeterReading
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidMeterReadingModel
    {
        public string AccountId { get; set; }
        public string MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }
    }
}
