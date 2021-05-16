using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;

namespace Ensek.Api.Models.MeterReading
{
    public class MeterReadingsImportRequestModel : IValidatableObject
    {
        //public DateTime ReadDate { get; set; }
        //public int AccountId { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile CsvFile { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var csvFile = ((MeterReadingsImportRequestModel)validationContext.ObjectInstance).CsvFile;
            var extension = Path.GetExtension(csvFile.FileName);

            if (!extension.ToLower().Equals(".csv"))
            {
                yield return new ValidationResult("File extension is not valid, please select a CSV file.");
            }

            var outputStream = CsvFile.OpenReadStream();

            using (var parser = new TextFieldParser(outputStream))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                string[] line;

                while (Equals(!parser.EndOfData))
                {
                    try
                    {
                        line = parser.ReadFields();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }
    }
}
