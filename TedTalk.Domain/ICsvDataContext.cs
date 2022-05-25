using CsvHelper.Configuration;
using System.Collections.Generic;

namespace TedTalk.Domain
{
    public interface ICsvDataContext<TEntity, TMap> where TEntity : class
        where TMap : ClassMap
    {
        List<TEntity> ReadCsv(string csvPath);
        void WriteCsv(string csvPath, List<TEntity> records);
        void AppendCsv(string csvPath, List<TEntity> records);
    }
}
