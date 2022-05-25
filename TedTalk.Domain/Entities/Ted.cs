using CsvHelper.Configuration.Attributes;
using System;
using TedTalk.Domain.Shared;

namespace TedTalk.Domain.Entities
{
    public class Ted
    {
        [Name(Constants.CsvHeaders.Id)]
        public int Id { get; set; }
        [Name(Constants.CsvHeaders.Title)]
        public string Title { get; set; }
        [Name(Constants.CsvHeaders.Author)]
        public string Author { get; set; }
        [Name(Constants.CsvHeaders.Date)]
        public string Date { get; set; }
        [Name(Constants.CsvHeaders.Likes)]
        public string Likes { get; set; }
        [Name(Constants.CsvHeaders.Views)]
        public string Views { get; set; }
        [Name(Constants.CsvHeaders.Link)]
        public string Link { get; set; }

        public Ted()
        {

        }

    }
}
