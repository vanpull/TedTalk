using CsvHelper.Configuration;
using TedTalk.Domain.Entities;
using TedTalk.Domain.Shared;

namespace TedTalk.Domain
{
    public sealed class TedMap : ClassMap<Ted>
    {
        public TedMap()
        {
            Map(m => m.Title).Name(Constants.CsvHeaders.Title);
            Map(m => m.Author).Name(Constants.CsvHeaders.Author);
            Map(m => m.Date).Name(Constants.CsvHeaders.Date);
            Map(m => m.Likes).Name(Constants.CsvHeaders.Likes);
            Map(m => m.Views).Name(Constants.CsvHeaders.Views);
            Map(m => m.Link).Name(Constants.CsvHeaders.Link);
            Map(m => m.Id).Name(Constants.CsvHeaders.Id);
        }
    }
}
