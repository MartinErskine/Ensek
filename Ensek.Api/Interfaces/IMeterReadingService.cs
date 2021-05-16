using System.Collections.Generic;
using System.Threading.Tasks;
using Ensek.Api.Helpers;
using Ensek.Api.Models.MeterReading;

namespace Ensek.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMeterReadingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<MeterReadingModel>>> GetMeterReadings();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<MeterReadingModel>>> GetMeterReading(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meterReadingsImportRequestModel"></param>
        Task<ServiceResponse<MeterReadingImportResponseModel>> LoadReadings(MeterReadingsImportRequestModel meterReadingsImportRequestModel);
    }
}