using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TedTalk.Domain;

namespace TedTalk.Data
{
    public class CsvDataContext<TEntity, TMap> : ICsvDataContext<TEntity, TMap> where TEntity : class
        where TMap : ClassMap
    {       

        public CsvDataContext()
        {           
        }

        public List<TEntity> ReadCsv(string csvPath)
        {
            try
            {

                using (var reader = new StreamReader(csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {   
                    csv.Context.RegisterClassMap<TMap>();
                    var records = csv.GetRecords<TEntity>().ToList();
                    return records;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void WriteCsv(string csvPath, List<TEntity> records)
        {

            using (StreamWriter sw = new StreamWriter(csvPath))
            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                cw.WriteRecords(records);
            }

            //using (StreamWriter sw = new StreamWriter(_csvPath))
            //using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
            //{
            //    cw.WriteHeader<TEntity>();
            //    cw.NextRecord();
            //    foreach (TEntity entity in records)
            //    {
            //        cw.WriteRecord<TEntity>(entity);
            //        cw.NextRecord();
            //    }
            //}
        }

        public void AppendCsv(string csvPath, List<TEntity> records)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var stream = File.Open(csvPath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(records);
            }
        }
    }
}
