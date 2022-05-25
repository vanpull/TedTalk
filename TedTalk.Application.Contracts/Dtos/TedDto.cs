using System;

namespace TedTalk.Application.Contracts.Dtos
{
    public class TedDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string Likes { get; set; }
        public string Views { get; set; }
        public string Link { get; set; }
    }
}
