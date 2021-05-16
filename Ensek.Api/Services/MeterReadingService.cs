using AutoMapper;
using CsvHelper;
using Ensek.Api.Helpers;
using Ensek.Api.Interfaces;
using Ensek.Data;
using Ensek.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ensek.Api.Models.MeterReading;

namespace Ensek.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class MeterReadingService : IMeterReadingService
    {
        private readonly EnsekDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public MeterReadingService(EnsekDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<MeterReadingModel>>> GetMeterReadings()
        {
            try
            {
                var readings = await _context.MeterReadings.ToListAsync();

                if (readings.Any())
                {
                    return new ServiceResponse<List<MeterReadingModel>>
                    {
                        Data = _mapper.Map<List<MeterReadingModel>>(readings)
                    };
                }

                return new ServiceResponse<List<MeterReadingModel>>();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<MeterReadingModel>>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<MeterReadingModel>>> GetMeterReading(int accountId)
        {
            try
            {
                var readings = await _context.MeterReadings.Where(w => w.AccountId == accountId).ToListAsync();

                if (readings != null)
                {
                    return new ServiceResponse<List<MeterReadingModel>>
                    {
                        Data = _mapper.Map<List<MeterReadingModel>>(readings)
                    };
                }

                return new ServiceResponse<List<MeterReadingModel>>
                {
                    Data = new List<MeterReadingModel>()
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meterReadingsImportRequestModel"></param>
        public async Task<ServiceResponse<MeterReadingImportResponseModel>> LoadReadings(MeterReadingsImportRequestModel meterReadingsImportRequestModel)
        {
            try
            {
                using var reader = new StreamReader(meterReadingsImportRequestModel.CsvFile.OpenReadStream());
                using var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB"));

                var validList = new List<MeterReadingImportModel>();
                var inValidList = new List<InvalidMeterReadingImportModel>();
                var duplicateList = new List<MeterReadingImportModel>();
                var isRecordBad = false;

                while (csv.Read())
                {
                    var record = new MeterReadingImportModel();
                    csv.Configuration.RegisterClassMap<MeterReadingImportMap>();

                    try
                    {
                        record = csv.GetRecord<MeterReadingImportModel>();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        isRecordBad = true;
                        csv.Configuration.RegisterClassMap<InvalidMeterReadingMap>();
                        inValidList.Add(csv.GetRecord<InvalidMeterReadingImportModel>());
                    }

                    if (!isRecordBad)
                    {
                        validList.Add(record);
                    }

                    isRecordBad = false;
                }


                var readings = _mapper.Map<List<MeterReading>>(validList);
                var newReadings = new List<MeterReading>();
                var accounts = await _context.Accounts.Select(s => s.AccountId).ToListAsync();

                foreach (var reading in readings.Where(w =>
                        !_context.MeterReadings.Any(m =>
                            m.AccountId == w.AccountId && m.ReadDate == w.ReadDate)).Where(w => accounts.Contains(w.AccountId)))
                {
                    newReadings.Add(reading);
                }

                if (newReadings.Any())
                {
                    _context.MeterReadings.AddRange(newReadings);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var diff = validList.Count - newReadings.Count;

                        return new ServiceResponse<MeterReadingImportResponseModel>
                        {
                            Data = new MeterReadingImportResponseModel
                            {
                                Imports = newReadings,
                                SuccessfulImports = newReadings.Count(),
                                FailedImports = inValidList.Count(),
                                DuplicateImports = diff
                            }
                        };
                    }
                }

                if (validList.Any())
                {
                    return new ServiceResponse<MeterReadingImportResponseModel>
                    {
                        Data = new MeterReadingImportResponseModel
                        {
                            Imports = new List<MeterReading>(),
                            SuccessfulImports = 0,
                            FailedImports = validList.Count(),
                            DuplicateImports = validList.Count()
                        }
                    };
                }

                return new ServiceResponse<MeterReadingImportResponseModel>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<MeterReadingImportResponseModel>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }
    }
}
