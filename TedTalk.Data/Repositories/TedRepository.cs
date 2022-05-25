using System.Collections.Generic;
using System.Linq;
using TedTalk.Domain;
using TedTalk.Domain.Entities;
using TedTalk.Domain.Repositories;

namespace TedTalk.Data.Repositories
{
    public class TedRepository : ITedRepository
    {
        private readonly string _csvPath;
        private readonly ICsvDataContext<Ted, TedMap> _csvDataContext;

        public TedRepository(ICsvDataContext<Ted, TedMap> csvDataContext, ICsvPathResolver csvPathResolver)
        {
            _csvDataContext = csvDataContext;
            _csvPath = csvPathResolver.GetCsvPath("TedTalk");
        }

        public void Add(Ted entity)
        {
            var entities = new List<Ted>();
            entities.Add(entity);

            _csvDataContext.AppendCsv(_csvPath, entities);
        }

        public void Delete(int id)
        {
            var records = _csvDataContext.ReadCsv(_csvPath);

            for (int i = 0; i < records.Count; ++i)
            {
                if (records[i].Id == id)
                {
                    records.RemoveAt(i);
                    break;
                }
            }

            _csvDataContext.WriteCsv(_csvPath, records);

        }

        public List<Ted> GetAll()
        {
            return _csvDataContext.ReadCsv(_csvPath);
        }

        public Ted GetById(int id)
        {
            var teds = _csvDataContext.ReadCsv(_csvPath);
            var ted = teds.FirstOrDefault(a=>a.Id == id);
            return ted;
        }

        public void Update(Ted enity)
        {
            var records = _csvDataContext.ReadCsv(_csvPath);

            for (int i = 0; i < records.Count; ++i)
            {
                if (records[i].Id == enity.Id)
                {
                    records[i].Title = enity.Title; 
                    records[i].Author = enity.Author;
                    records[i].Date = enity.Date;
                    records[i].Likes = enity.Likes;
                    records[i].Views = enity.Views;
                    records[i].Link = enity.Link;
                    break;
                }
            }

            _csvDataContext.WriteCsv(_csvPath, records);
        }
    }
}
