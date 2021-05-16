using System;
using System.ComponentModel.DataAnnotations;

namespace Ensek.Api.Models.MeterReading
{
    public class MeterReadingModel
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public DateTime MeterReadingDateTime { get; set; }

        [Required, Range(1, 99999)]
        public int MeterReadValue { get; set; }
    }
}
