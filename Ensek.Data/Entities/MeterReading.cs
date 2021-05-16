using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensek.Data.Entities
{
    [Table("MeterReadings")]
    public class MeterReading
    {
        [ForeignKey("AccountFk")]
        public int AccountId { get; set; }

        public DateTime ReadDate { get; set; }
        public int ReadValue { get; set; }
    }
}
