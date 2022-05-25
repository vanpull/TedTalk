using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using TedTalk.Domain;

namespace TedTalk.WebHost.HttpApi
{
    public class CsvPathResolver : ICsvPathResolver
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private Dictionary<string, string> _csvDataStores = new Dictionary<string, string>()
        {
            { "TedTalk", "\\Files\\Data\\TedTalk\\data.csv"}
        };

        public CsvPathResolver(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetCsvPath(string fileKey)
        {
            var csvPath = _csvDataStores[fileKey];
            var filePath = $"{_webHostEnvironment.ContentRootPath}{csvPath}";
            return filePath;
        }
    }
}
