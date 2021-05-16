using System;
using System.ComponentModel.DataAnnotations;

namespace Ensek.Api.Models.MeterReading
{
    /// <summary>
    /// 
    /// </summary>
    public class MeterReadingModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int AccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public DateTime MeterReadingDateTime { get; set; }


        //TODO: Determine Business requirement to deal with Read values greater then 99999.

        /// <summary>
        /// 
        /// </summary>
        [Required, Range(1, 99999)]
        public int MeterReadValue { get; set; }
    }
}
